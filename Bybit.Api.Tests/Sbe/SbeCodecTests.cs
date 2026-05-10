using Bybit.Api.Sbe;
using System.Text;

namespace Bybit.Api.Tests.Sbe;

public class SbeCodecTests
{
    [Fact]
    public void TopicHelpers_CreateDocumentTopics()
    {
        Assert.Equal("v5/public-sbe/spot", BybitSbeTopic.SpotMarketPath);
        Assert.Equal("v5/public-sbe/linear", BybitSbeTopic.LinearMarketPath);
        Assert.Equal("v5/public-sbe/inverse", BybitSbeTopic.InverseMarketPath);
        Assert.Equal("v5/trade-sbe", BybitSbeTopic.TradePath);

        Assert.Equal("ob.rpi.1.sbe.BTCUSDT", BybitSbeTopic.BestBidOfferRpi(" BTCUSDT "));
        Assert.Equal("ob.50.sbe.BTCUSDT", BybitSbeTopic.Level50OrderBook("BTCUSDT"));
        Assert.Equal("publicTrade.sbe.BTCUSDT", BybitSbeTopic.PublicTrade("BTCUSDT"));
        Assert.Throws<ArgumentException>(() => BybitSbeTopic.PublicTrade(""));
    }

    [Fact]
    public void MarketDecoder_ReadsBboCompactAndFullFrames()
    {
        var compact = new FrameBuilder();
        compact.WriteHeader(82, BybitSbeConstants.BestOrderBookRpiTemplateId, BybitSbeConstants.MarketSchemaId, BybitSbeConstants.MarketVersion);
        compact.WriteInt64(1_757_497_309_814);
        compact.WriteInt64(1_808_827_611);
        compact.WriteInt64(1_757_497_309_030);
        compact.WriteInt64(312);
        compact.WriteInt64(1_060_342_500);
        compact.WriteInt64(120_000);
        compact.WriteInt64(10_000);
        compact.WriteInt64(1_060_250_000);
        compact.WriteInt64(150_000);
        compact.WriteInt64(8_000);
        compact.WriteSByte(2);
        compact.WriteSByte(5);
        compact.WriteVarString("BTCUSDT");

        var compactEvent = BybitSbeMarketDecoder.DecodeBestOrderBookRpi(compact.ToArray());

        Assert.False(compactEvent.HasSeparateRpiPrices);
        Assert.Equal("BTCUSDT", compactEvent.Symbol);
        Assert.Equal(10_603_425m, compactEvent.AskNormalPrice);
        Assert.Equal(1.2m, compactEvent.AskNormalSize);
        Assert.Equal(compactEvent.AskNormalPriceMantissa, compactEvent.AskRpiPriceMantissa);
        Assert.Equal(compactEvent.BidNormalPriceMantissa, compactEvent.BidRpiPriceMantissa);

        var full = new FrameBuilder();
        full.WriteHeader(98, BybitSbeConstants.BestOrderBookRpiTemplateId, BybitSbeConstants.MarketSchemaId, BybitSbeConstants.MarketVersion);
        full.WriteInt64(1_757_497_309_814);
        full.WriteInt64(1_808_827_612);
        full.WriteInt64(1_757_497_309_030);
        full.WriteInt64(313);
        full.WriteInt64(1_060_342_500);
        full.WriteInt64(120_000);
        full.WriteInt64(1_060_330_000);
        full.WriteInt64(10_000);
        full.WriteInt64(1_060_250_000);
        full.WriteInt64(150_000);
        full.WriteInt64(1_060_260_000);
        full.WriteInt64(8_000);
        full.WriteSByte(2);
        full.WriteSByte(5);
        full.WriteVarString("BTCUSDT");

        var fullEvent = BybitSbeMarketDecoder.DecodeBestOrderBookRpi(full.ToArray());

        Assert.True(fullEvent.HasSeparateRpiPrices);
        Assert.Equal(10_603_300m, fullEvent.AskRpiPrice);
        Assert.Equal(10_602_600m, fullEvent.BidRpiPrice);
    }

    [Fact]
    public void MarketDecoder_ReadsLevel50AndPublicTradeFrames()
    {
        var level50 = new FrameBuilder();
        level50.WriteHeader(35, BybitSbeConstants.Level50OrderBookTemplateId, BybitSbeConstants.MarketSchemaId, BybitSbeConstants.MarketVersion);
        level50.WriteInt64(1_757_497_310_001);
        level50.WriteInt64(1_808_827_700);
        level50.WriteInt64(1_757_497_310_000);
        level50.WriteInt64(450);
        level50.WriteSByte(2);
        level50.WriteSByte(4);
        level50.WriteByte((byte)BybitSbePackageType.Delta);
        level50.WriteUInt16(16);
        level50.WriteUInt16(2);
        level50.WriteInt64(10_603_425);
        level50.WriteInt64(12_345);
        level50.WriteInt64(10_603_430);
        level50.WriteInt64(20_000);
        level50.WriteUInt16(16);
        level50.WriteUInt16(1);
        level50.WriteInt64(10_602_500);
        level50.WriteInt64(33_000);
        level50.WriteVarString("BTCUSDT");

        var orderbook = BybitSbeMarketDecoder.DecodeLevel50OrderBook(level50.ToArray());

        Assert.Equal(BybitSbePackageType.Delta, orderbook.PackageType);
        Assert.Equal(2, orderbook.Asks.Count);
        Assert.Single(orderbook.Bids);
        Assert.Equal(106_034.25m, orderbook.Asks[0].Price);
        Assert.Equal(1.2345m, orderbook.Asks[0].Size);
        Assert.Equal("BTCUSDT", orderbook.Symbol);

        var publicTrade = new FrameBuilder();
        publicTrade.WriteHeader(10, BybitSbeConstants.PublicTradeTemplateId, BybitSbeConstants.MarketSchemaId, BybitSbeConstants.MarketVersion);
        publicTrade.WriteInt64(1_757_497_311_000);
        publicTrade.WriteSByte(2);
        publicTrade.WriteSByte(4);
        publicTrade.WriteUInt16(35);
        publicTrade.WriteUInt16(1);
        publicTrade.WriteInt64(1_757_497_310_999);
        publicTrade.WriteInt64(10_603_425);
        publicTrade.WriteInt64(12_345);
        publicTrade.WriteInt64(1_808_827_711);
        publicTrade.WriteByte((byte)BybitSbeSide.Sell);
        publicTrade.WriteByte((byte)BybitSbeBool.False);
        publicTrade.WriteByte((byte)BybitSbeBool.True);
        publicTrade.WriteVarString("2100000000007764263");
        publicTrade.WriteVarString("BTCUSDT");

        var trades = BybitSbeMarketDecoder.DecodePublicTrade(publicTrade.ToArray());
        var trade = Assert.Single(trades.Trades);

        Assert.Equal(BybitSbeSide.Sell, trade.Side);
        Assert.Equal(BybitSbeBool.True, trade.IsRpi);
        Assert.Equal("2100000000007764263", trade.ExecutionId);
        Assert.Equal(106_034.25m, trade.Price);
        Assert.Equal(1.2345m, trade.Size);
        Assert.Equal("BTCUSDT", trades.Symbol);
    }

    [Fact]
    public void TradeEncoder_WritesAuthPingAndOrderFrames()
    {
        var authFrame = BybitSbeTradeEncoder.EncodeAuth(new BybitSbeAuthRequest("auth-1", "api-key", 1_757_497_400_000, "signature"));
        var authReader = new FrameReader(authFrame);

        AssertHeader(authReader, 200, BybitSbeConstants.AuthRequestTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        Assert.Equal("auth-1", authReader.ReadFixedString(64));
        Assert.Equal("api-key", authReader.ReadFixedString(64));
        Assert.Equal(1_757_497_400_000UL, authReader.ReadUInt64());
        Assert.Equal("signature", authReader.ReadFixedString(64));
        Assert.Equal(208, authFrame.Length);

        var pingFrame = BybitSbeTradeEncoder.EncodePing(1_757_497_401_000);
        var pingReader = new FrameReader(pingFrame);
        AssertHeader(pingReader, 8, BybitSbeConstants.PingRequestTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        Assert.Equal(1_757_497_401_000UL, pingReader.ReadUInt64());

        var order = new BybitSbeCreateOrderRequest(
            BybitSbeCategory.Linear,
            9_000_001,
            BybitSbeSide.Buy,
            BybitSbeOrderType.Limit,
            new BybitSbeDecimal64(-4, 12_345),
            new BybitSbeDecimal64(-2, 10_603_425),
            "client-1")
        {
            Header = new BybitSbeApiRequestHeader("req-1", 1_757_497_402_000, referer: "wrapper-test"),
            TimeInForce = BybitSbeTimeInForce.PostOnly,
            ReduceOnly = BybitSbeBool.True,
            SelfMatchPrevention = BybitSbeSelfMatchPrevention.CancelTaker,
        };
        var createFrame = BybitSbeTradeEncoder.EncodeCreateOrder(order);
        var createReader = new FrameReader(createFrame);

        AssertHeader(createReader, 241, BybitSbeConstants.CreateOrderRequestTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        Assert.Equal("req-1", createReader.ReadFixedString(64));
        Assert.Equal(1_757_497_402_000UL, createReader.ReadUInt64());
        Assert.Equal(5_000U, createReader.ReadUInt32());
        Assert.Equal("wrapper-test", createReader.ReadFixedString(64));
        Assert.Equal((byte)BybitSbeCategory.Linear, createReader.ReadByte());
        Assert.Equal(9_000_001, createReader.ReadInt64());
        Assert.Equal((byte)BybitSbeSide.Buy, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeOrderType.Limit, createReader.ReadByte());
        Assert.Equal(-4, createReader.ReadSByte());
        Assert.Equal(12_345, createReader.ReadInt64());
        Assert.Equal(-2, createReader.ReadSByte());
        Assert.Equal(10_603_425, createReader.ReadInt64());
        Assert.Equal("client-1", createReader.ReadFixedString(64));
        Assert.Equal((byte)BybitSbeTimeInForce.PostOnly, createReader.ReadByte());
        Assert.Equal((byte)BybitSbePositionIndex.OneWay, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeMarketUnit.BaseCoin, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeBool.False, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeBool.True, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeBool.False, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeBool.False, createReader.ReadByte());
        Assert.Equal((byte)BybitSbeSelfMatchPrevention.CancelTaker, createReader.ReadByte());
        Assert.Equal(249, createFrame.Length);
    }

    [Fact]
    public void TradeEncoder_WritesBatchFramesAndValidatesRiskyInputs()
    {
        var first = CreateBatchOrder("client-1");
        var second = CreateBatchOrder("client-2");
        var batch = new BybitSbeBatchCreateOrderRequest(BybitSbeCategory.Linear, new[] { first, second })
        {
            Header = new BybitSbeApiRequestHeader("batch-1", 1_757_497_403_000),
        };

        var batchFrame = BybitSbeTradeEncoder.EncodeBatchCreateOrders(batch);
        var batchReader = new FrameReader(batchFrame);

        AssertHeader(batchReader, 141, BybitSbeConstants.BatchCreateOrderRequestTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        batchReader.Skip(140);
        Assert.Equal((byte)BybitSbeCategory.Linear, batchReader.ReadByte());
        Assert.Equal(100, batchReader.ReadUInt16());
        Assert.Equal(2, batchReader.ReadUInt16());
        Assert.Equal(353, batchFrame.Length);

        var replaceFrame = BybitSbeTradeEncoder.EncodeBatchReplaceOrders(new BybitSbeBatchReplaceOrderRequest(BybitSbeCategory.Linear, new[]
        {
            new BybitSbeReplaceOrderRequest(BybitSbeCategory.Linear, 9_000_001, new BybitSbeDecimal64(-4, 12_000), new BybitSbeDecimal64(-2, 10_603_000))
            {
                OrderId = "order-1",
            },
        }));
        Assert.Equal(307, replaceFrame.Length);

        var cancelFrame = BybitSbeTradeEncoder.EncodeBatchCancelOrders(new BybitSbeBatchCancelOrderRequest(BybitSbeCategory.Linear, new[]
        {
            new BybitSbeCancelOrderRequest(BybitSbeCategory.Linear, 9_000_001)
            {
                OrderLinkId = "client-1",
            },
        }));
        Assert.Equal(289, cancelFrame.Length);

        var invalidQuantity = CreateBatchOrder("invalid-quantity") with { Quantity = new BybitSbeDecimal64(-4, 0) };
        Assert.Throws<ArgumentException>(() => BybitSbeTradeEncoder.EncodeCreateOrder(invalidQuantity));

        var mismatchedCategory = CreateBatchOrder("wrong-category") with { Category = BybitSbeCategory.Spot };
        Assert.Throws<ArgumentException>(() => BybitSbeTradeEncoder.EncodeBatchCreateOrders(new BybitSbeBatchCreateOrderRequest(BybitSbeCategory.Linear, new[] { mismatchedCategory })));
    }

    [Fact]
    public void TradeDecoder_ReadsResponseFrames()
    {
        var auth = new FrameBuilder();
        auth.WriteHeader(132, BybitSbeConstants.AuthResponseTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        auth.WriteFixedString("auth-1", 64);
        auth.WriteInt32(0);
        auth.WriteFixedString("conn-1", 64);
        auth.WriteVarString("OK");

        var authResponse = BybitSbeTradeDecoder.DecodeAuthResponse(auth.ToArray());
        Assert.Equal(0, authResponse.ReturnCode);
        Assert.Equal("conn-1", authResponse.ConnectionId);
        Assert.Equal("OK", authResponse.ReturnMessage);

        var pong = new FrameBuilder();
        pong.WriteHeader(16, BybitSbeConstants.PongResponseTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        pong.WriteUInt64(1_757_497_404_000);
        pong.WriteUInt64(1_757_497_404_003);

        var pongResponse = BybitSbeTradeDecoder.DecodePongResponse(pong.ToArray());
        Assert.Equal(1_757_497_404_000, pongResponse.Timestamp);
        Assert.Equal(1_757_497_404_003, pongResponse.PongTime);

        var order = new FrameBuilder();
        order.WriteHeader(364, BybitSbeConstants.CreateOrderResponseTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        WriteApiResponseHeader(order, "req-1");
        order.WriteInt32(0);
        order.WriteFixedString("order-1", 64);
        order.WriteFixedString("client-1", 64);
        order.WriteVarString("OK");

        var orderResponse = BybitSbeTradeDecoder.DecodeOrderResponse(order.ToArray());
        Assert.Equal("req-1", orderResponse.ResponseHeader.RequestId);
        Assert.Equal("order-1", orderResponse.Result.OrderId);
        Assert.Equal("client-1", orderResponse.Result.OrderLinkId);
        Assert.Equal("OK", orderResponse.ReturnMessage);

        var batch = new FrameBuilder();
        batch.WriteHeader(236, BybitSbeConstants.BatchCreateOrderResponseTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        WriteApiResponseHeader(batch, "batch-1");
        batch.WriteInt32(0);
        batch.WriteUInt16(141);
        batch.WriteUInt16(1);
        batch.WriteInt32(0);
        batch.WriteByte((byte)BybitSbeCategory.Linear);
        batch.WriteInt64(9_000_001);
        batch.WriteFixedString("order-1", 64);
        batch.WriteFixedString("client-1", 64);
        batch.WriteVarString("OK");
        batch.WriteVarString("1757497404000");
        batch.WriteVarString("OK");

        var batchResponse = BybitSbeTradeDecoder.DecodeBatchOrderResponse(batch.ToArray());
        var batchResult = Assert.Single(batchResponse.Results);
        Assert.Equal(BybitSbeCategory.Linear, batchResult.Category);
        Assert.Equal(9_000_001, batchResult.SymbolId);
        Assert.Equal("1757497404000", batchResult.CreateAt);
        Assert.Equal("OK", batchResponse.ReturnMessage);

        var error = new FrameBuilder();
        error.WriteHeader(236, BybitSbeConstants.CommonErrorResponseTemplateId, BybitSbeConstants.TradeSchemaId, BybitSbeConstants.TradeVersion);
        WriteApiResponseHeader(error, "req-error");
        error.WriteInt32(10001);
        error.WriteVarString("request parameter error");

        var errorResponse = BybitSbeTradeDecoder.DecodeCommonErrorResponse(error.ToArray());
        Assert.Equal(10001, errorResponse.ReturnCode);
        Assert.Equal("request parameter error", errorResponse.ReturnMessage);
    }

    private static BybitSbeCreateOrderRequest CreateBatchOrder(string orderLinkId)
    {
        return new BybitSbeCreateOrderRequest(
            BybitSbeCategory.Linear,
            9_000_001,
            BybitSbeSide.Buy,
            BybitSbeOrderType.Limit,
            new BybitSbeDecimal64(-4, 12_345),
            new BybitSbeDecimal64(-2, 10_603_425),
            orderLinkId);
    }

    private static void WriteApiResponseHeader(FrameBuilder builder, string requestId)
    {
        builder.WriteFixedString(requestId, 64);
        builder.WriteFixedString("conn-1", 64);
        builder.WriteFixedString("trace-1", 64);
        builder.WriteInt64(1_757_497_405_000);
        builder.WriteInt64(1_757_497_404_999);
        builder.WriteInt64(100);
        builder.WriteInt64(99);
        builder.WriteInt64(1_757_497_410_000);
    }

    private static void AssertHeader(FrameReader reader, ushort blockLength, ushort templateId, ushort schemaId, ushort version)
    {
        Assert.Equal(blockLength, reader.ReadUInt16());
        Assert.Equal(templateId, reader.ReadUInt16());
        Assert.Equal(schemaId, reader.ReadUInt16());
        Assert.Equal(version, reader.ReadUInt16());
    }

    private sealed class FrameBuilder
    {
        private readonly List<byte> buffer = [];

        public byte[] ToArray() => [.. buffer];

        public void WriteHeader(ushort blockLength, ushort templateId, ushort schemaId, ushort version)
        {
            WriteUInt16(blockLength);
            WriteUInt16(templateId);
            WriteUInt16(schemaId);
            WriteUInt16(version);
        }

        public void WriteByte(byte value) => buffer.Add(value);

        public void WriteSByte(sbyte value)
        {
            unchecked
            {
                buffer.Add((byte)value);
            }
        }

        public void WriteUInt16(ushort value)
        {
            buffer.Add((byte)value);
            buffer.Add((byte)(value >> 8));
        }

        public void WriteUInt32(uint value)
        {
            buffer.Add((byte)value);
            buffer.Add((byte)(value >> 8));
            buffer.Add((byte)(value >> 16));
            buffer.Add((byte)(value >> 24));
        }

        public void WriteInt32(int value)
        {
            unchecked
            {
                WriteUInt32((uint)value);
            }
        }

        public void WriteUInt64(ulong value)
        {
            for (var i = 0; i < 8; i++)
                buffer.Add((byte)(value >> (8 * i)));
        }

        public void WriteInt64(long value)
        {
            unchecked
            {
                WriteUInt64((ulong)value);
            }
        }

        public void WriteFixedString(string? value, int length)
        {
            var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
            if (bytes.Length > length)
                throw new ArgumentException("Fixed string value is too long.");

            buffer.AddRange(bytes);
            for (var i = bytes.Length; i < length; i++)
                buffer.Add(0);
        }

        public void WriteVarString(string? value)
        {
            var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
            if (bytes.Length > byte.MaxValue)
                throw new ArgumentException("Var string value is too long.");

            WriteByte((byte)bytes.Length);
            buffer.AddRange(bytes);
        }
    }

    private sealed class FrameReader
    {
        private readonly byte[] data;

        public FrameReader(byte[] data)
        {
            this.data = data;
        }

        private int Offset { get; set; }

        public byte ReadByte()
        {
            return data[Offset++];
        }

        public sbyte ReadSByte()
        {
            unchecked
            {
                return (sbyte)ReadByte();
            }
        }

        public ushort ReadUInt16()
        {
            var value = (ushort)(data[Offset] | (data[Offset + 1] << 8));
            Offset += 2;
            return value;
        }

        public uint ReadUInt32()
        {
            var value = (uint)data[Offset]
                | ((uint)data[Offset + 1] << 8)
                | ((uint)data[Offset + 2] << 16)
                | ((uint)data[Offset + 3] << 24);
            Offset += 4;
            return value;
        }

        public ulong ReadUInt64()
        {
            ulong value = 0;
            for (var i = 0; i < 8; i++)
                value |= ((ulong)data[Offset + i]) << (8 * i);

            Offset += 8;
            return value;
        }

        public long ReadInt64()
        {
            unchecked
            {
                return (long)ReadUInt64();
            }
        }

        public string ReadFixedString(int length)
        {
            var start = Offset;
            var end = start;
            var limit = start + length;
            while (end < limit && data[end] != 0)
                end++;

            Offset += length;
            return Encoding.UTF8.GetString(data, start, end - start);
        }

        public void Skip(int length)
        {
            Offset += length;
        }
    }
}
