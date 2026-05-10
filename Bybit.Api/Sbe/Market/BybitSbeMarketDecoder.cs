namespace Bybit.Api.Sbe;

/// <summary>
/// SBE market data decoder.
/// </summary>
public static class BybitSbeMarketDecoder
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
    /// Decode a BBO RPI event.
    /// </summary>
    public static BybitSbeBestOrderBookRpiEvent DecodeBestOrderBookRpi(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateMarketHeader(header, BybitSbeConstants.BestOrderBookRpiTemplateId);

        var compact = header.BlockLength == 82;
        var timestamp = reader.ReadInt64();
        var sequence = reader.ReadInt64();
        var creationTimestamp = reader.ReadInt64();
        var updateId = reader.ReadInt64();
        var askNormalPrice = reader.ReadInt64();
        var askNormalSize = reader.ReadInt64();
        long askRpiPrice;
        long askRpiSize;
        long bidNormalPrice;
        long bidNormalSize;
        long bidRpiPrice;
        long bidRpiSize;

        if (compact)
        {
            askRpiPrice = askNormalPrice;
            askRpiSize = reader.ReadInt64();
            bidNormalPrice = reader.ReadInt64();
            bidNormalSize = reader.ReadInt64();
            bidRpiPrice = bidNormalPrice;
            bidRpiSize = reader.ReadInt64();
        }
        else
        {
            askRpiPrice = reader.ReadInt64();
            askRpiSize = reader.ReadInt64();
            bidNormalPrice = reader.ReadInt64();
            bidNormalSize = reader.ReadInt64();
            bidRpiPrice = reader.ReadInt64();
            bidRpiSize = reader.ReadInt64();
        }

        var priceExponent = reader.ReadSByte();
        var sizeExponent = reader.ReadSByte();
        var symbol = reader.ReadVarString8();

        return new BybitSbeBestOrderBookRpiEvent
        {
            Header = header,
            TimestampMicroseconds = timestamp,
            Sequence = sequence,
            CreationTimestampMicroseconds = creationTimestamp,
            UpdateId = updateId,
            AskNormalPriceMantissa = askNormalPrice,
            AskNormalSizeMantissa = askNormalSize,
            AskRpiPriceMantissa = askRpiPrice,
            AskRpiSizeMantissa = askRpiSize,
            BidNormalPriceMantissa = bidNormalPrice,
            BidNormalSizeMantissa = bidNormalSize,
            BidRpiPriceMantissa = bidRpiPrice,
            BidRpiSizeMantissa = bidRpiSize,
            PriceExponent = priceExponent,
            SizeExponent = sizeExponent,
            Symbol = symbol,
            HasSeparateRpiPrices = !compact,
        };
    }

    /// <summary>
    /// Decode a Level 50 orderbook event.
    /// </summary>
    public static BybitSbeLevel50OrderBookEvent DecodeLevel50OrderBook(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateMarketHeader(header, BybitSbeConstants.Level50OrderBookTemplateId);

        var timestamp = reader.ReadInt64();
        var sequence = reader.ReadInt64();
        var creationTimestamp = reader.ReadInt64();
        var updateId = reader.ReadInt64();
        var priceExponent = reader.ReadSByte();
        var sizeExponent = reader.ReadSByte();
        var packageType = (BybitSbePackageType)reader.ReadByte();
        var asks = ReadOrderBookLevels(reader, priceExponent, sizeExponent);
        var bids = ReadOrderBookLevels(reader, priceExponent, sizeExponent);
        var symbol = reader.ReadVarString8();

        return new BybitSbeLevel50OrderBookEvent
        {
            Header = header,
            TimestampMicroseconds = timestamp,
            Sequence = sequence,
            CreationTimestampMicroseconds = creationTimestamp,
            UpdateId = updateId,
            PriceExponent = priceExponent,
            SizeExponent = sizeExponent,
            PackageType = packageType,
            Asks = asks,
            Bids = bids,
            Symbol = symbol,
        };
    }

    /// <summary>
    /// Decode a public trade event.
    /// </summary>
    public static BybitSbePublicTradeEvent DecodePublicTrade(byte[] frame)
    {
        var reader = new BybitSbeBinaryReader(frame);
        var header = reader.ReadHeader();
        ValidateMarketHeader(header, BybitSbeConstants.PublicTradeTemplateId);

        var timestamp = reader.ReadInt64();
        var priceExponent = reader.ReadSByte();
        var sizeExponent = reader.ReadSByte();
        var trades = ReadTrades(reader, priceExponent, sizeExponent);
        var symbol = reader.ReadVarString8();

        return new BybitSbePublicTradeEvent
        {
            Header = header,
            TimestampMicroseconds = timestamp,
            PriceExponent = priceExponent,
            SizeExponent = sizeExponent,
            Trades = trades,
            Symbol = symbol,
        };
    }

    private static List<BybitSbeOrderBookLevel> ReadOrderBookLevels(BybitSbeBinaryReader reader, sbyte priceExponent, sbyte sizeExponent)
    {
        var blockLength = reader.ReadUInt16();
        var count = reader.ReadUInt16();
        if (blockLength < 16)
            throw new ArgumentException("Orderbook level block length is invalid.");

        var levels = new List<BybitSbeOrderBookLevel>(count);
        for (var i = 0; i < count; i++)
        {
            var offsetBefore = reader.Offset;
            var price = reader.ReadInt64();
            var size = reader.ReadInt64();
            if (blockLength > 16)
                reader.Skip(blockLength - 16);

            levels.Add(new BybitSbeOrderBookLevel(price, size, priceExponent, sizeExponent));

            if (reader.Offset - offsetBefore != blockLength)
                throw new ArgumentException("Orderbook level block length was not consumed correctly.");
        }

        return levels;
    }

    private static List<BybitSbePublicTradeItem> ReadTrades(BybitSbeBinaryReader reader, sbyte priceExponent, sbyte sizeExponent)
    {
        var blockLength = reader.ReadUInt16();
        var count = reader.ReadUInt16();
        if (blockLength < 35)
            throw new ArgumentException("Public trade item block length is invalid.");

        var trades = new List<BybitSbePublicTradeItem>(count);
        for (var i = 0; i < count; i++)
        {
            var offsetBefore = reader.Offset;
            var fillTime = reader.ReadInt64();
            var price = reader.ReadInt64();
            var size = reader.ReadInt64();
            var sequence = reader.ReadInt64();
            var side = (BybitSbeSide)reader.ReadByte();
            var isBlockTrade = (BybitSbeBool)reader.ReadByte();
            var isRpi = (BybitSbeBool)reader.ReadByte();
            if (blockLength > 35)
                reader.Skip(blockLength - 35);

            var executionId = reader.ReadVarString8();
            trades.Add(new BybitSbePublicTradeItem(fillTime, price, size, sequence, side, isBlockTrade, isRpi, executionId, priceExponent, sizeExponent));

            if (reader.Offset < offsetBefore + blockLength)
                throw new ArgumentException("Public trade item block length was not consumed correctly.");
        }

        return trades;
    }

    private static void ValidateMarketHeader(BybitSbeMessageHeader header, ushort expectedTemplateId)
    {
        if (header.TemplateId != expectedTemplateId)
            throw new ArgumentException($"Unexpected SBE template ID. Expected {expectedTemplateId}, received {header.TemplateId}.");
        if (header.SchemaId != BybitSbeConstants.MarketSchemaId)
            throw new ArgumentException($"Unexpected SBE schema ID. Expected {BybitSbeConstants.MarketSchemaId}, received {header.SchemaId}.");
        if (header.Version != BybitSbeConstants.MarketVersion)
            throw new ArgumentException($"Unexpected SBE version. Expected {BybitSbeConstants.MarketVersion}, received {header.Version}.");
    }
}
