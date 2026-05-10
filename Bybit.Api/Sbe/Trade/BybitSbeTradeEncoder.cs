namespace Bybit.Api.Sbe;

/// <summary>
/// SBE order entry encoder.
/// </summary>
public static class BybitSbeTradeEncoder
{
    /// <summary>
    /// Encode authentication request.
    /// </summary>
    public static byte[] EncodeAuth(BybitSbeAuthRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateRequired(request.RequestId, nameof(request.RequestId));
        ValidateRequired(request.ApiKey, nameof(request.ApiKey));
        ValidateRequired(request.Signature, nameof(request.Signature));
        if (request.Expires <= 0) throw new ArgumentException("Expires must be greater than 0.", nameof(request));

        var writer = CreateTradeWriter(200, BybitSbeConstants.AuthRequestTemplateId);
        writer.WriteFixedString(request.RequestId, 64);
        writer.WriteFixedString(request.ApiKey, 64);
        writer.WriteUInt64(checked((ulong)request.Expires));
        writer.WriteFixedString(request.Signature, 64);
        return writer.ToArray();
    }

    /// <summary>
    /// Encode ping request.
    /// </summary>
    public static byte[] EncodePing(long timestamp)
    {
        if (timestamp < 0) throw new ArgumentException("Timestamp must be greater than or equal to 0.", nameof(timestamp));

        var writer = CreateTradeWriter(8, BybitSbeConstants.PingRequestTemplateId);
        writer.WriteUInt64(checked((ulong)timestamp));
        return writer.ToArray();
    }

    /// <summary>
    /// Encode create order request.
    /// </summary>
    public static byte[] EncodeCreateOrder(BybitSbeCreateOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCreateOrder(request);

        var writer = CreateTradeWriter(241, BybitSbeConstants.CreateOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        WriteCreateOrderBody(writer, request, includeCategory: true);
        return writer.ToArray();
    }

    /// <summary>
    /// Encode replace order request.
    /// </summary>
    public static byte[] EncodeReplaceOrder(BybitSbeReplaceOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCategory(request.Category);
        ValidateSymbolId(request.SymbolId);
        ValidateOrderIdentifier(request.OrderId, request.OrderLinkId);

        var writer = CreateTradeWriter(295, BybitSbeConstants.ReplaceOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        writer.WriteByte((byte)request.Category);
        writer.WriteInt64(request.SymbolId);
        writer.WriteFixedString(request.OrderId, 64);
        writer.WriteFixedString(request.OrderLinkId, 64);
        writer.WriteDecimal64(request.Quantity);
        writer.WriteDecimal64(request.Price);
        return writer.ToArray();
    }

    /// <summary>
    /// Encode cancel order request.
    /// </summary>
    public static byte[] EncodeCancelOrder(BybitSbeCancelOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCategory(request.Category);
        ValidateSymbolId(request.SymbolId);
        ValidateOrderIdentifier(request.OrderId, request.OrderLinkId);

        var writer = CreateTradeWriter(277, BybitSbeConstants.CancelOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        writer.WriteByte((byte)request.Category);
        writer.WriteInt64(request.SymbolId);
        writer.WriteFixedString(request.OrderId, 64);
        writer.WriteFixedString(request.OrderLinkId, 64);
        return writer.ToArray();
    }

    /// <summary>
    /// Encode batch create order request.
    /// </summary>
    public static byte[] EncodeBatchCreateOrders(BybitSbeBatchCreateOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCategory(request.Category);
        ValidateRequiredCollection(request.Orders, nameof(request.Orders));
        foreach (var order in request.Orders)
        {
            ValidateCreateOrder(order);
            ValidateBatchOrderCategory(request.Category, order.Category);
        }

        var writer = CreateTradeWriter(141, BybitSbeConstants.BatchCreateOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        writer.WriteByte((byte)request.Category);
        writer.WriteUInt16(100);
        writer.WriteUInt16(checked((ushort)request.Orders.Count));
        foreach (var order in request.Orders)
            WriteCreateOrderBody(writer, order, includeCategory: false);

        return writer.ToArray();
    }

    /// <summary>
    /// Encode batch replace order request.
    /// </summary>
    public static byte[] EncodeBatchReplaceOrders(BybitSbeBatchReplaceOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCategory(request.Category);
        ValidateRequiredCollection(request.Orders, nameof(request.Orders));
        foreach (var order in request.Orders)
        {
            ValidateCategory(order.Category);
            ValidateBatchOrderCategory(request.Category, order.Category);
            ValidateSymbolId(order.SymbolId);
            ValidateOrderIdentifier(order.OrderId, order.OrderLinkId);
        }

        var writer = CreateTradeWriter(141, BybitSbeConstants.BatchReplaceOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        writer.WriteByte((byte)request.Category);
        writer.WriteUInt16(154);
        writer.WriteUInt16(checked((ushort)request.Orders.Count));
        foreach (var order in request.Orders)
        {
            writer.WriteInt64(order.SymbolId);
            writer.WriteFixedString(order.OrderId, 64);
            writer.WriteFixedString(order.OrderLinkId, 64);
            writer.WriteDecimal64(order.Quantity);
            writer.WriteDecimal64(order.Price);
        }

        return writer.ToArray();
    }

    /// <summary>
    /// Encode batch cancel order request.
    /// </summary>
    public static byte[] EncodeBatchCancelOrders(BybitSbeBatchCancelOrderRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateCategory(request.Category);
        ValidateRequiredCollection(request.Orders, nameof(request.Orders));
        foreach (var order in request.Orders)
        {
            ValidateCategory(order.Category);
            ValidateBatchOrderCategory(request.Category, order.Category);
            ValidateSymbolId(order.SymbolId);
            ValidateOrderIdentifier(order.OrderId, order.OrderLinkId);
        }

        var writer = CreateTradeWriter(141, BybitSbeConstants.BatchCancelOrderRequestTemplateId);
        WriteApiRequestHeader(writer, request.Header);
        writer.WriteByte((byte)request.Category);
        writer.WriteUInt16(136);
        writer.WriteUInt16(checked((ushort)request.Orders.Count));
        foreach (var order in request.Orders)
        {
            writer.WriteInt64(order.SymbolId);
            writer.WriteFixedString(order.OrderId, 64);
            writer.WriteFixedString(order.OrderLinkId, 64);
        }

        return writer.ToArray();
    }

    private static BybitSbeBinaryWriter CreateTradeWriter(ushort blockLength, ushort templateId)
    {
        var writer = new BybitSbeBinaryWriter();
        writer.WriteHeader(blockLength, templateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        return writer;
    }

    private static void WriteApiRequestHeader(BybitSbeBinaryWriter writer, BybitSbeApiRequestHeader header)
    {
        if (header == null) throw new ArgumentNullException(nameof(header));
        if (header.Timestamp < 0) throw new ArgumentException("Timestamp must be greater than or equal to 0.", nameof(header));
        if (header.ReceiveWindow <= 0) throw new ArgumentException("ReceiveWindow must be greater than 0.", nameof(header));

        writer.WriteFixedString(header.RequestId, 64);
        writer.WriteUInt64(checked((ulong)header.Timestamp));
        writer.WriteUInt32(checked((uint)header.ReceiveWindow));
        writer.WriteFixedString(header.Referer, 64);
    }

    private static void WriteCreateOrderBody(BybitSbeBinaryWriter writer, BybitSbeCreateOrderRequest request, bool includeCategory)
    {
        if (includeCategory)
            writer.WriteByte((byte)request.Category);

        writer.WriteInt64(request.SymbolId);
        writer.WriteByte((byte)request.Side);
        writer.WriteByte((byte)request.OrderType);
        writer.WriteDecimal64(request.Quantity);
        writer.WriteDecimal64(request.Price);
        writer.WriteFixedString(request.OrderLinkId, 64);
        writer.WriteByte((byte)request.TimeInForce);
        writer.WriteByte((byte)request.PositionIndex);
        writer.WriteByte((byte)request.MarketUnit);
        writer.WriteByte((byte)request.IsLeverage);
        writer.WriteByte((byte)request.ReduceOnly);
        writer.WriteByte((byte)request.CloseOnTrigger);
        writer.WriteByte((byte)request.MarketMakerProtection);
        writer.WriteByte((byte)request.SelfMatchPrevention);
    }

    private static void ValidateCreateOrder(BybitSbeCreateOrderRequest request)
    {
        ValidateRequired(request.OrderLinkId, nameof(request.OrderLinkId));
        ValidateCategory(request.Category);
        ValidateSymbolId(request.SymbolId);
        if (request.Side is not (BybitSbeSide.Buy or BybitSbeSide.Sell))
            throw new ArgumentException("Side must be buy or sell.", nameof(request));
        if (request.OrderType is not (BybitSbeOrderType.Market or BybitSbeOrderType.Limit))
            throw new ArgumentException("Order type must be market or limit.", nameof(request));
        if (request.Quantity.Mantissa <= 0)
            throw new ArgumentException("Quantity mantissa must be greater than 0.", nameof(request));
        if (request.OrderType == BybitSbeOrderType.Limit && request.Price.Mantissa <= 0)
            throw new ArgumentException("Limit order price mantissa must be greater than 0.", nameof(request));
        if (request.OrderType == BybitSbeOrderType.Market && request.Price.Mantissa < 0)
            throw new ArgumentException("Market order price mantissa must be greater than or equal to 0.", nameof(request));
    }

    private static void ValidateCategory(BybitSbeCategory category)
    {
        if (category is BybitSbeCategory.Unknown or BybitSbeCategory.NonRepresentable)
            throw new ArgumentException("Category must be a tradable category.", nameof(category));
    }

    private static void ValidateSymbolId(long symbolId)
    {
        if (symbolId <= 0)
            throw new ArgumentException("SymbolId must be greater than 0.", nameof(symbolId));
    }

    private static void ValidateBatchOrderCategory(BybitSbeCategory batchCategory, BybitSbeCategory orderCategory)
    {
        if (orderCategory != batchCategory)
            throw new ArgumentException("Batch order category must match the batch category.", nameof(orderCategory));
    }

    private static void ValidateOrderIdentifier(string? orderId, string? orderLinkId)
    {
        if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(orderLinkId))
            throw new ArgumentException("Either orderId or orderLinkId is required.");
    }

    private static void ValidateRequired(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{name} is required.", name);
    }

    private static void ValidateRequiredCollection<T>(ICollection<T> values, string name)
    {
        if (values == null) throw new ArgumentNullException(name);
        if (values.Count == 0) throw new ArgumentException($"{name} is required.", name);
        if (values.Count > ushort.MaxValue) throw new ArgumentException($"{name} exceeds the SBE group limit.", name);
    }
}
