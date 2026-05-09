using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Trading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Trade;

public class TradeJsonTests
{
    [Fact]
    public void OrderHistory_MapsDocumentFieldsAndNullableNumerics()
    {
        var result = DeserializeResult<TradeListResult<BybitTradingOrder>>("order-history.json");
        var order = Assert.Single(result.List);

        Assert.Equal("BTCUSDT", order.Symbol);
        Assert.Equal(65000.5m, order.BasePrice);
        Assert.Equal(64999.5m, order.LastPriceOnCreated);
        Assert.Null(order.AveragePrice);
        Assert.Null(order.CumulativeExecutedFee);
        Assert.Equal(BybitOcoTriggerBy.StopLoss, order.OcoTriggerBy);
        Assert.Equal(BybitSelfMatchPrevention.None, order.SelfMatchPrevention);
        Assert.Equal(BybitSlippageToleranceType.Percent, order.SlippageToleranceType);
        Assert.Equal(0.05m, order.SlippageTolerance);
        Assert.Equal(0m, order.CumulativeTradingFees["USDT"]);
    }

    [Fact]
    public void ExecutionHistory_MapsExtraFeesAndFutureSpreadExecutionType()
    {
        var result = DeserializeResult<TradeListResult<BybitTradingExecution>>("execution-history.json");
        var execution = Assert.Single(result.List);

        Assert.Equal("e0cbe81d-0f18-5866-9415-cf319b5dab3b", execution.TradeId);
        Assert.Equal(BybitExecutionType.FutureSpread, execution.ExecutionType);
        Assert.Equal(0.000001m, execution.FeeV2);
        Assert.Equal(4688002127L, execution.Sequence);
        Assert.Equal(string.Empty, execution.ExtraFees);
    }

    [Fact]
    public void PreCheckOrder_MapsMarginRateFields()
    {
        var result = DeserializeResult<BybitPreCheckOrder>("pre-check-order.json");

        Assert.Equal("24920bdb-4019-4e37-ad1c-876e3a855ac3", result.OrderId);
        Assert.Equal("test129", result.ClientOrderId);
        Assert.Equal(30, result.PreInitialMarginRateE4);
        Assert.Equal(21, result.PreMaintenanceMarginRateE4);
        Assert.Equal(357, result.PostInitialMarginRateE4);
        Assert.Equal(294, result.PostMaintenanceMarginRateE4);
    }

    [Fact]
    public void BatchPlaceOrder_MapsStringCreateTimestampAsLong()
    {
        var result = DeserializeResult<TradeListResult<BybitTradingBatchPlaceOrder>>("batch-place-response.json");
        var order = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Linear, order.Category);
        Assert.Equal(1672211918471L, order.CreateAtTimestamp);
        Assert.Equal(2022, order.CreateAtTime.Year);
    }

    [Fact]
    public void BatchRequests_OmitUnsetOptionalOrderFields()
    {
        var amend = Serialize(new BybitBatchAmendOrderRequest
        {
            Symbol = "BTCUSDT",
            ClientOrderId = "client-1",
            Price = 65000.5m,
        });
        var cancel = Serialize(new BybitBatchCancelOrderRequest
        {
            Symbol = "BTCUSDT",
            ClientOrderId = "client-1",
        });

        Assert.Equal("65000.5", amend["price"]!.Value<string>());
        Assert.False(amend.ContainsKey("qty"));
        Assert.False(amend.ContainsKey("orderId"));
        Assert.False(cancel.ContainsKey("orderId"));
        Assert.Equal("client-1", cancel["orderLinkId"]!.Value<string>());
    }

    [Fact]
    public void PlaceOrderRequest_SerializesStringNumericsAndBboFields()
    {
        var request = new BybitPlaceOrderRequest(BybitCategory.Linear, "BTCUSDT", BybitOrderSide.Buy, BybitOrderType.Limit, 1m)
        {
            Price = 65000.5m,
            SlippageToleranceType = BybitSlippageToleranceType.Percent,
            SlippageTolerance = 0.05m,
            BboSideType = BybitBboSideType.Counterparty,
            BboLevel = 3,
        };

        var json = Serialize(request);

        Assert.Equal("1", json["qty"]!.Value<string>());
        Assert.Equal("65000.5", json["price"]!.Value<string>());
        Assert.Equal("Percent", json["slippageToleranceType"]!.Value<string>());
        Assert.Equal("0.05", json["slippageTolerance"]!.Value<string>());
        Assert.Equal("Counterparty", json["bboSideType"]!.Value<string>());
        Assert.Equal("3", json["bboLevel"]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Trade", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private static JObject Serialize(object request)
    {
        var json = JsonConvert.SerializeObject(request, SerializerOptions.WithConverters);
        return JObject.Parse(json);
    }

    private sealed record TradeListResult<T>
    {
        public List<T> List { get; set; } = [];
    }
}
