using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Spread;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Spread;

public class SpreadJsonTests
{
    [Fact]
    public void MarketResponses_MapCurrentDocumentShapes()
    {
        var instruments = DeserializeResult<SpreadListResult<BybitSpreadInstrument>>("instrument.json");
        var orderbook = DeserializeResult<BybitSpreadOrderbook>("orderbook.json");
        var tickers = DeserializeResult<SpreadListResult<BybitSpreadTicker>>("tickers.json");
        var recentTrades = DeserializeResult<SpreadListResult<BybitSpreadPublicTrade>>("recent-trade.json");

        var instrument = Assert.Single(instruments.List);
        Assert.Equal("SOLUSDT_SOL/USDT", instrument.Symbol);
        Assert.Equal(BybitSpreadContractType.FundingRateArbitrage, instrument.ContractType);
        Assert.Equal(BybitSpreadStatus.Trading, instrument.Status);
        Assert.Equal(-1999.9998m, instrument.MinimumPrice);
        Assert.Equal(50000m, instrument.MaximumQuantity);
        Assert.Equal(new DateTime(2025, 4, 3, 10, 15, 0, DateTimeKind.Utc), instrument.LaunchTime);
        Assert.Null(instrument.DeliveryTime);
        Assert.Equal(BybitSpreadLegContractType.LinearPerpetual, instrument.Legs[0].ContractType);
        Assert.Equal(BybitSpreadLegContractType.Spot, instrument.Legs[1].ContractType);
        Assert.Equal("first%3D100008%26last%3D100008", instruments.NextPageCursor);

        Assert.Equal("SOLUSDT_SOL/USDT", orderbook.Symbol);
        Assert.Equal(21.0000m, Assert.Single(orderbook.Bids).Price);
        Assert.Equal(4.6m, Assert.Single(orderbook.Asks).Quantity);
        Assert.Equal(213110L, orderbook.CrossSequence);

        var ticker = Assert.Single(tickers.List);
        Assert.Null(ticker.BidPrice);
        Assert.Null(ticker.AskSize);
        Assert.Equal(19.444m, ticker.LastPrice);
        Assert.Equal(24694.9m, ticker.Volume24h);

        var trade = Assert.Single(recentTrades.List);
        Assert.Equal("c8512970-d6fb-5039-93a5-b4196dffbe88", trade.TradeId);
        Assert.Equal(BybitOrderSide.Sell, trade.Side);
        Assert.Equal("123456", trade.Sequence);
        Assert.Equal(new DateTime(2025, 4, 8, 2, 12, 4, 35, DateTimeKind.Utc), trade.Time);
    }

    [Fact]
    public void TradeResponses_MapCurrentDocumentShapes()
    {
        var orderId = DeserializeResult<BybitSpreadOrderId>("order-id.json");
        var cancelAll = DeserializeResult<BybitSpreadCancelAllOrders>("cancel-all.json");
        var openOrders = DeserializeResult<SpreadListResult<BybitSpreadOrder>>("open-orders.json");
        var orderHistory = DeserializeResult<SpreadListResult<BybitSpreadOrder>>("order-history.json");
        var tradeHistory = DeserializeResult<SpreadListResult<BybitSpreadExecution>>("trade-history.json");
        var maxQuantity = DeserializeResult<BybitSpreadMaxOrderQuantity>("max-qty.json");

        Assert.Equal("1b00b997-d825-465e-ad1d-80b0eb1955af", orderId.OrderId);
        Assert.Equal("1744072052193428479", orderId.ClientOrderId);

        Assert.Equal("1", cancelAll.Success);
        Assert.Equal("11ec47f3-f0a2-4b2a-b302-236f2a2d53a2", Assert.Single(cancelAll.List).OrderId);

        var openOrder = Assert.Single(openOrders.List);
        Assert.Equal(BybitOrderStatus.New, openOrder.OrderStatus);
        Assert.Equal(BybitTimeInForce.PostOnly, openOrder.TimeInForce);
        Assert.Equal(-4m, openOrder.Price);
        Assert.Equal(0.1m, openOrder.RemainingQuantity);
        Assert.Equal(new DateTime(2025, 4, 8, 7, 8, 19, 767, DateTimeKind.Utc), openOrder.CreatedTime);

        var historicalOrder = Assert.Single(orderHistory.List);
        Assert.Equal(BybitSpreadContractType.FundingRateArbitrage, historicalOrder.ContractType);
        Assert.Equal(BybitOrderStatus.Cancelled, historicalOrder.OrderStatus);
        Assert.Equal(BybitSpreadLegProductType.Futures, historicalOrder.Leg1ProdType);
        Assert.Equal(BybitSpreadLegProductType.Spot, historicalOrder.Leg2ProdType);
        Assert.Equal("1924011967786517249", historicalOrder.Leg2OrderId);
        Assert.Equal("USDT", historicalOrder.SettleAsset);

        var execution = Assert.Single(tradeHistory.List);
        Assert.Equal(BybitExecutionType.Trade, execution.ExecType);
        Assert.Equal(21m, execution.ExecPrice);
        Assert.Equal("82c82077-0caa-5304-894d-58a50a342bd7", execution.ExecId);
        Assert.Equal(BybitCategory.Linear, execution.Legs[0].Category);
        Assert.Equal(BybitCategory.Spot, execution.Legs[1].Category);
        Assert.Equal("2110000000061481958", execution.Legs[1].ExecId);
        Assert.Equal(0.06186912m, execution.Legs[1].ExecFee);

        Assert.Equal(1992.55199490m, maxQuantity.MaximumOrderQuantity);
    }

    [Fact]
    public void Requests_SerializeStringNumericsAndMappedEnums()
    {
        var place = new BybitSpreadPlaceOrderRequest("SOLUSDT_SOL/USDT", BybitOrderSide.Buy, BybitOrderType.Limit, 0.1m)
        {
            Price = 21m,
            ClientOrderId = "client-1",
            TimeInForce = BybitTimeInForce.PostOnly,
        };
        var amend = new BybitSpreadAmendOrderRequest("SOLUSDT_SOL/USDT")
        {
            ClientOrderId = "client-1",
            Price = 0m,
            Quantity = 0.2m,
        };
        var cancelAll = new BybitSpreadCancelAllOrdersRequest
        {
            CancelAll = true,
        };
        var maxQuantity = new BybitSpreadMaxOrderQuantityRequest("SOLUSDT_SOL/USDT", BybitSpreadMaxQuantitySide.Buy, 50000m);

        var placeJson = Serialize(place);
        var amendJson = Serialize(amend);
        var cancelAllJson = Serialize(cancelAll);
        var maxQuantityJson = Serialize(maxQuantity);

        Assert.Equal("0.1", placeJson["qty"]!.Value<string>());
        Assert.Equal("21", placeJson["price"]!.Value<string>());
        Assert.Equal("Buy", placeJson["side"]!.Value<string>());
        Assert.Equal("PostOnly", placeJson["timeInForce"]!.Value<string>());

        Assert.Equal("0.2", amendJson["qty"]!.Value<string>());
        Assert.Equal("0", amendJson["price"]!.Value<string>());
        Assert.False(amendJson.ContainsKey("orderId"));

        Assert.True(cancelAllJson["cancelAll"]!.Value<bool>());
        Assert.False(cancelAllJson.ContainsKey("symbol"));

        Assert.Equal("1", maxQuantityJson["side"]!.Value<string>());
        Assert.Equal("50000", maxQuantityJson["orderPrice"]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Spread", "Json", fileName);
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

    private sealed record SpreadListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }
}
