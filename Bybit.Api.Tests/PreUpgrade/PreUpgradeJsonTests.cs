using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.PreUpgrade;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.PreUpgrade;

public class PreUpgradeJsonTests
{
    [Fact]
    public void OrderHistory_MapsDocumentFieldsAndUnknownValues()
    {
        var result = DeserializeResult<PreUpgradeListResult<BybitPreUpgradeOrder>>("order-history.json");
        var order = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Linear, result.Category);
        Assert.Equal("67836246-460e-4c52-a009-af0c3e1d12bc", order.OrderId);
        Assert.Equal(27203.40m, order.Price);
        Assert.Equal(0.200m, order.Quantity);
        Assert.Equal(BybitOrderSide.Sell, order.Side);
        Assert.Equal(string.Empty, order.IsLeverage);
        Assert.Equal(BybitPositionIndex.OneWayModePosition, order.PositionIndex);
        Assert.Equal(BybitOrderStatus.Filled, order.OrderStatus);
        Assert.Equal("UNKNOWN", order.CancelType);
        Assert.Equal("EC_NoError", order.RejectReason);
        Assert.Equal(28632.126000m, order.AveragePrice);
        Assert.Equal(BybitTimeInForce.ImmediateOrCancel, order.TimeInForce);
        Assert.Equal(BybitOrderType.Market, order.OrderType);
        Assert.Null(order.StopOrderType);
        Assert.Null(order.TakeProfitTriggerBy);
        Assert.Equal(0, order.TriggerDirection);
        Assert.Equal(BybitSelfMatchPrevention.None, order.SelfMatchPrevention);
        Assert.Equal(1682487465732L, order.CreatedTimestamp);
    }

    [Fact]
    public void TradeHistory_MapsExecutionAndNullableUnknownEnums()
    {
        var result = DeserializeResult<PreUpgradeListResult<BybitPreUpgradeExecution>>("trade-history.json");
        var execution = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Linear, result.Category);
        Assert.Equal("11f1c4ed-ff20-4d73-acb7-96e43a917f25", execution.TradeId);
        Assert.Equal(BybitOrderSide.Sell, execution.Side);
        Assert.Equal(BybitOrderType.Unknown, execution.OrderType);
        Assert.Null(execution.StopOrderType);
        Assert.Equal(0.6364003m, execution.Fee);
        Assert.Equal(28399.90m, execution.Price);
        Assert.Equal(BybitExecutionType.Funding, execution.ExecutionType);
        Assert.Equal(1682553600000L, execution.Timestamp);
        Assert.False(execution.IsMaker);
        Assert.Null(execution.IndexPrice);
        Assert.Equal(0m, execution.ClosedQuantity);
    }

    [Fact]
    public void ClosedPnl_MapsStringNumericsToTypedValues()
    {
        var result = DeserializeResult<PreUpgradeListResult<BybitPreUpgradeClosedPnl>>("closed-pnl.json");
        var pnl = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Linear, result.Category);
        Assert.Equal("BTCUSDT", pnl.Symbol);
        Assert.Equal(BybitOrderSide.Sell, pnl.Side);
        Assert.Equal(0.200m, pnl.Quantity);
        Assert.Equal(BybitExecutionType.Trade, pnl.ExecutionType);
        Assert.Equal(5588.88m, pnl.CumEntryValue);
        Assert.Equal(204.25510011m, pnl.ClosedPnl);
        Assert.Equal(22, pnl.FillCount);
        Assert.Equal(10m, pnl.Leverage);
        Assert.Equal(1682487465732L, pnl.UpdatedTimestamp);
    }

    [Fact]
    public void TransactionDeliveryAndSettlement_MapDocumentShapes()
    {
        var transaction = Assert.Single(DeserializeResult<PreUpgradeListResult<BybitPreUpgradeTransaction>>("transaction-log.json").List);
        var delivery = Assert.Single(DeserializeResult<PreUpgradeListResult<BybitPreUpgradeDelivery>>("delivery-record.json").List);
        var settlement = Assert.Single(DeserializeResult<PreUpgradeListResult<BybitPreUpgradeSettlement>>("settlement-record.json").List);

        Assert.Equal("ETH-14JUN23-1750-C", transaction.Symbol);
        Assert.Equal(BybitPositionSide.Buy, transaction.Side);
        Assert.Null(transaction.FundingFee);
        Assert.Equal(BybitTransactionType.Delivery, transaction.Type);
        Assert.Equal(0.5m, transaction.Quantity);
        Assert.Equal(1001.1438885m, transaction.CashBalance);
        Assert.Equal(BybitCategory.Option, transaction.Category);
        Assert.Equal(1740.25036667m, transaction.TradePrice);

        Assert.Equal(1686729604507L, delivery.DeliveryTimestamp);
        Assert.Equal(BybitOrderSide.Buy, delivery.Side);
        Assert.Equal(1750m, delivery.Strike);
        Assert.Equal(0.5m, delivery.Position);
        Assert.Equal(0.175m, delivery.DeliveryRpl);

        Assert.Equal("ETHPERP", settlement.Symbol);
        Assert.Equal(BybitOrderSide.Sell, settlement.Side);
        Assert.Equal(-0.5m, settlement.Quantity);
        Assert.Equal(1668.41m, settlement.SettlementPrice);
        Assert.Equal(45.76m, settlement.RealisedPnl);
        Assert.Equal(1686787200000L, settlement.CreatedTimestamp);
    }

    [Fact]
    public async Task ClientValidations_CatchUnsupportedCategoriesAndRiskyTimeRanges()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<NotSupportedException>(() => client.PreUpgrade.GetClosedPnlAsync(BybitCategory.Spot, "BTCUSDT"));
        await Assert.ThrowsAsync<NotSupportedException>(() => client.PreUpgrade.GetDeliveryRecordsAsync(BybitCategory.Linear));
        await Assert.ThrowsAsync<ArgumentException>(() => client.PreUpgrade.GetSettlementRecordsAsync(BybitCategory.Linear, limit: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.PreUpgrade.GetOrderHistoryAsync(new BybitPreUpgradeOrderHistoryRequest(BybitCategory.Linear) { StartTime = 1 }));
        await Assert.ThrowsAsync<ArgumentException>(() => client.PreUpgrade.GetTradeHistoryAsync(new BybitPreUpgradeTradeHistoryRequest(BybitCategory.Linear) { StartTime = 0, EndTime = 604_800_001 }));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "PreUpgrade", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record PreUpgradeListResult<T>
    {
        public BybitCategory? Category { get; set; }

        public List<T> List { get; set; } = [];
    }
}
