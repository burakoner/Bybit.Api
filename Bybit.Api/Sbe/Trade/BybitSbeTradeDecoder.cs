namespace Bybit.Api.Sbe;

/// <summary>
/// SBE order entry decoder.
/// </summary>
public static class BybitSbeTradeDecoder
{
    /// <summary>
    /// Decode SBE message header.
    /// </summary>
    public static BybitSbeMessageHeader DecodeHeader(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        return reader.ReadHeader();
    }

    /// <summary>
    /// Decode authentication response.
    /// </summary>
    public static BybitSbeAuthResponse DecodeAuthResponse(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateTradeHeader(header, BybitSbeConstants.AuthResponseTemplateId);

        var requestId = reader.ReadFixedString(64);
        var returnCode = reader.ReadInt32();
        var connectionId = reader.ReadFixedString(64);
        var returnMessage = reader.ReadVarString8();

        return new BybitSbeAuthResponse
        {
            Header = header,
            RequestId = requestId,
            ReturnCode = returnCode,
            ConnectionId = connectionId,
            ReturnMessage = returnMessage,
        };
    }

    /// <summary>
    /// Decode pong response.
    /// </summary>
    public static BybitSbePongResponse DecodePongResponse(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateTradeHeader(header, BybitSbeConstants.PongResponseTemplateId);

        return new BybitSbePongResponse
        {
            Header = header,
            Timestamp = checked((long)reader.ReadUInt64()),
            PongTime = checked((long)reader.ReadUInt64()),
        };
    }

    /// <summary>
    /// Decode create, replace, or cancel order response.
    /// </summary>
    public static BybitSbeOrderResponse DecodeOrderResponse(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        if (header.TemplateId is not (BybitSbeConstants.CreateOrderResponseTemplateId or BybitSbeConstants.ReplaceOrderResponseTemplateId or BybitSbeConstants.CancelOrderResponseTemplateId))
            throw new ArgumentException($"Unexpected SBE template ID for an order response: {header.TemplateId}.");
        ValidateTradeSchema(header);

        var responseHeader = ReadApiResponseHeader(reader);
        var returnCode = reader.ReadInt32();
        var result = ReadOrderIdentifiers(reader);
        var returnMessage = reader.ReadVarString8();

        return new BybitSbeOrderResponse
        {
            Header = header,
            ResponseHeader = responseHeader,
            ReturnCode = returnCode,
            Result = result,
            ReturnMessage = returnMessage,
        };
    }

    /// <summary>
    /// Decode batch create, replace, or cancel order response.
    /// </summary>
    public static BybitSbeBatchOrderResponse DecodeBatchOrderResponse(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        if (header.TemplateId is not (BybitSbeConstants.BatchCreateOrderResponseTemplateId or BybitSbeConstants.BatchReplaceOrderResponseTemplateId or BybitSbeConstants.BatchCancelOrderResponseTemplateId))
            throw new ArgumentException($"Unexpected SBE template ID for a batch order response: {header.TemplateId}.");
        ValidateTradeSchema(header);

        var responseHeader = ReadApiResponseHeader(reader);
        var returnCode = reader.ReadInt32();
        var results = ReadBatchResults(reader, includeCreateAt: header.TemplateId == BybitSbeConstants.BatchCreateOrderResponseTemplateId);
        var returnMessage = reader.ReadVarString8();

        return new BybitSbeBatchOrderResponse
        {
            Header = header,
            ResponseHeader = responseHeader,
            ReturnCode = returnCode,
            Results = results,
            ReturnMessage = returnMessage,
        };
    }

    /// <summary>
    /// Decode common error response.
    /// </summary>
    public static BybitSbeCommonErrorResponse DecodeCommonErrorResponse(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateTradeHeader(header, BybitSbeConstants.CommonErrorResponseTemplateId);

        var responseHeader = ReadApiResponseHeader(reader);
        var returnCode = reader.ReadInt32();
        var returnMessage = reader.ReadVarString8();

        return new BybitSbeCommonErrorResponse
        {
            Header = header,
            ResponseHeader = responseHeader,
            ReturnCode = returnCode,
            ReturnMessage = returnMessage,
        };
    }

    private static BybitSbeApiResponseHeader ReadApiResponseHeader(BybitSbeBinaryReader reader)
    {
        return new BybitSbeApiResponseHeader
        {
            RequestId = reader.ReadFixedString(64),
            ConnectionId = reader.ReadFixedString(64),
            TraceId = reader.ReadFixedString(64),
            TimeNow = reader.ReadInt64(),
            InTime = reader.ReadInt64(),
            RateLimit = reader.ReadInt64(),
            RateLimitStatus = reader.ReadInt64(),
            RateLimitResetTimestamp = reader.ReadInt64(),
        };
    }

    private static BybitSbeOrderIdentifiers ReadOrderIdentifiers(BybitSbeBinaryReader reader)
    {
        return new BybitSbeOrderIdentifiers
        {
            OrderId = reader.ReadFixedString(64),
            OrderLinkId = reader.ReadFixedString(64),
        };
    }

    private static List<BybitSbeBatchOrderResult> ReadBatchResults(BybitSbeBinaryReader reader, bool includeCreateAt)
    {
        var blockLength = reader.ReadUInt16();
        var count = reader.ReadUInt16();
        if (blockLength < 141)
            throw new ArgumentException("Batch order result block length is invalid.");

        var results = new List<BybitSbeBatchOrderResult>(count);
        for (var i = 0; i < count; i++)
        {
            var offsetBefore = reader.Offset;
            var code = reader.ReadInt32();
            var category = (BybitSbeCategory)reader.ReadByte();
            var symbolId = reader.ReadInt64();
            var orderId = reader.ReadFixedString(64);
            var orderLinkId = reader.ReadFixedString(64);
            if (blockLength > 141)
                reader.Skip(blockLength - 141);

            var message = reader.ReadVarString8();
            var createAt = includeCreateAt ? reader.ReadVarString8() : string.Empty;
            results.Add(new BybitSbeBatchOrderResult
            {
                Code = code,
                Category = category,
                SymbolId = symbolId,
                OrderId = orderId,
                OrderLinkId = orderLinkId,
                Message = message,
                CreateAt = createAt,
            });

            if (reader.Offset < offsetBefore + blockLength)
                throw new ArgumentException("Batch order result block length was not consumed correctly.");
        }

        return results;
    }

    private static void ValidateTradeHeader(BybitSbeMessageHeader header, ushort expectedTemplateId)
    {
        if (header.TemplateId != expectedTemplateId)
            throw new ArgumentException($"Unexpected SBE template ID. Expected {expectedTemplateId}, received {header.TemplateId}.");

        ValidateTradeSchema(header);
    }

    private static void ValidateTradeSchema(BybitSbeMessageHeader header)
    {
        if (header.SchemaId != BybitSbeConstants.TradeSchemaId)
            throw new ArgumentException($"Unexpected SBE schema ID. Expected {BybitSbeConstants.TradeSchemaId}, received {header.SchemaId}.");
        if (header.Version != BybitSbeConstants.TradeVersion)
            throw new ArgumentException($"Unexpected SBE version. Expected {BybitSbeConstants.TradeVersion}, received {header.Version}.");
    }
}
