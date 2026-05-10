using ApiSharp.Models;
using Bybit.Api.Common.Requests;
using Bybit.Api.Enums;
using Bybit.Api.Market;
using Bybit.Api.Models.Socket;
using Bybit.Api.System;
using Bybit.Api.Trading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.WebSocket;

public class WebSocketJsonTests
{
    [Fact]
    public void PublicStreams_MapCurrentDocumentShapes()
    {
        var allLiquidation = Assert.Single(DeserializeDataList<BybitAllLiquidationUpdate>("all-liquidation.json"));
        var priceLimit = DeserializeData<BybitOrderPriceLimitUpdate>("order-price-limit.json");
        var insurance = Assert.Single(DeserializeDataList<BybitInsurancePoolUpdate>("insurance-pool.json"));
        var adlAlert = Assert.Single(DeserializeDataList<BybitAdlAlertUpdate>("adl-alert.json"));

        Assert.Equal("ROSEUSDT", allLiquidation.Symbol);
        Assert.Equal(BybitOrderSide.Sell, allLiquidation.Side);
        Assert.Equal(20000m, allLiquidation.Quantity);
        Assert.Equal(0.04499m, allLiquidation.Price);

        Assert.Equal("BTCUSDT", priceLimit.Symbol);
        Assert.Equal(114450m, priceLimit.BuyLimit);
        Assert.Equal(103550m, priceLimit.SellLimit);

        Assert.Equal("USDT", insurance.Asset);
        Assert.Equal("GRIFFAINUSDT", insurance.Symbols);
        Assert.Equal(25614.92972633m, insurance.Balance);
        Assert.Equal(1747722930000L, insurance.UpdateTimestamp);

        Assert.Equal("BTCUSDT", adlAlert.Symbol);
        Assert.Null(adlAlert.MaxBalance);
        Assert.Equal(-0.3m, adlAlert.InsurancePnlRatio);
    }

    [Fact]
    public void PrivateStreams_MapCurrentDocumentShapes()
    {
        var position = Assert.Single(DeserializeDataList<BybitPositionUpdate>("position.json"));
        var execution = Assert.Single(DeserializeDataList<BybitExecutionUpdate>("execution.json"));
        var order = Assert.Single(DeserializeDataList<BybitOrderUpdate>("order.json"));
        var fastExecution = Assert.Single(DeserializeDataList<BybitFastExecutionUpdate>("fast-execution.json"));

        Assert.Equal(BybitCategory.Linear, position.Category);
        Assert.Null(position.Side);
        Assert.Equal(1701412416813L, position.OpenTimestamp);
        Assert.Equal(27913.4m, position.BreakEvenPrice);
        Assert.Equal(59.43968m, position.PositionIMByMp);

        Assert.Equal("e0cbe81d-0f18-5866-9415-cf319b5dab3b", execution.TradeId);
        Assert.Equal(0.001m, execution.ProfitAndLoss);
        Assert.Equal(BybitUnit.BaseAsset, execution.MarketUnit);
        Assert.Equal("USDT", execution.FeeCurrency);
        Assert.Equal("USDT", execution.ExtraFees![0]!["feeToken"]!.Value<string>());

        Assert.Equal("parent-link-1", order.ParentClientOrderId);
        Assert.Equal(0.06186912m, order.CumulativeFeeDetail!["USDT"]!.Value<decimal>());
        Assert.Equal(BybitSlippageToleranceType.Percent, order.SlippageToleranceType);
        Assert.Equal(0.05m, order.SlippageTolerance);

        Assert.Equal("2100000000007764263", fastExecution.TradeId);
        Assert.Equal(4688002127L, fastExecution.Sequence);
    }

    [Fact]
    public void SystemStream_MapsMaintenanceShape()
    {
        var status = Assert.Single(DeserializeDataList<BybitSystemStatus>("system-status.json"));

        Assert.Equal("4d95b2a0-587f-11f0-bcc9-56f28c94d6ea", status.Id);
        Assert.Equal(BybitSystemState.Completed, status.State);
        Assert.Equal(1751596902000L, status.BeginTimestamp);
        Assert.Equal(BybitSystemMaintainType.PlannedMaintenance, status.MaintainType);
        Assert.Equal(BybitSystemEnvironment.Production, status.Environment);
    }

    [Fact]
    public void WebSocketTradeResponses_MapHeadersAndNullableBatchCreateTime()
    {
        var single = DeserializeMessage<BybitWebSocketTradeResponse<BybitTradingOrderId>>("trade-response.json");
        var batch = DeserializeMessage<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchPlaceOrder>>>("batch-trade-response.json");

        Assert.Equal(0, single.ReturnCode);
        Assert.Equal("order.create", single.Operation);
        Assert.Equal("1321003749386327552", single.Data!.OrderId);
        Assert.Equal(10, single.Header.Limit);
        Assert.Equal("0b35b1234babc1234", single.Header.TraceId);

        var batchOrder = Assert.Single(batch.Data!.List);
        Assert.Equal(BybitCategory.Linear, batchOrder.Category);
        Assert.Null(batchOrder.CreateAtTimestamp);
        Assert.Null(batchOrder.CreateAtTime);
        Assert.Equal(9, batch.Header.LimitStatus);
    }

    [Fact]
    public void StreamType_MapsSnapshotAndDeltaValues()
    {
        Assert.Equal(BybitStreamType.Snapshot, DeserializeStreamType("all-liquidation.json"));
        Assert.Equal(BybitStreamType.Delta, DeserializeStreamType("insurance-pool.json"));
    }

    private static T DeserializeData<T>(string fileName)
    {
        var data = ReadMessage(fileName)["data"];

        Assert.NotNull(data);
        return data!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private static List<T> DeserializeDataList<T>(string fileName)
    {
        var data = ReadMessage(fileName)["data"];

        Assert.NotNull(data);
        return data!.ToObject<List<T>>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private static T DeserializeMessage<T>(string fileName)
    {
        return ReadMessage(fileName).ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private static BybitStreamType DeserializeStreamType(string fileName)
    {
        return ReadMessage(fileName)["type"]?.Value<string>() switch
        {
            "snapshot" => BybitStreamType.Snapshot,
            "delta" => BybitStreamType.Delta,
            _ => BybitStreamType.Unknown,
        };
    }

    private static JObject ReadMessage(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "WebSocket", "Json", fileName);
        return JObject.Parse(File.ReadAllText(path));
    }
}
