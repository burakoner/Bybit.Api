using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Position;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Position;

public class PositionJsonTests
{
    [Fact]
    public void PositionInfo_MapsCurrentFieldsAndEmptyNumericValues()
    {
        var result = DeserializeResult<PositionListResult<BybitPosition>>("position-info.json");
        var position = result.List[0];
        var emptyPosition = result.List[1];

        Assert.Equal(BybitCategory.Inverse, result.Category);
        Assert.Equal(BybitPositionSide.Sell, position.Side);
        Assert.True(position.AutoAddMargin);
        Assert.Equal(93556.73034991m, position.BreakEvenPrice);
        Assert.Null(position.LiquidationPrice);
        Assert.Null(position.OpenTime);
        Assert.Equal(5723621632L, position.CrossSequence);
        Assert.Equal(new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc), position.MaintenanceMarginUpdateTime);
        Assert.Null(position.LeverageUpdateTime);

        Assert.Null(emptyPosition.Side);
        Assert.False(emptyPosition.AutoAddMargin);
        Assert.Null(emptyPosition.AveragePrice);
        Assert.Null(emptyPosition.PositionValue);
        Assert.Null(emptyPosition.Leverage);
        Assert.Null(emptyPosition.BreakEvenPrice);
        Assert.Equal(-1L, emptyPosition.CrossSequence);
    }

    [Fact]
    public void AddOrReduceMargin_MapsPositionResponseShape()
    {
        var position = DeserializeResult<BybitPosition>("add-or-reduce-margin.json");

        Assert.Equal("ETHUSD", position.Symbol);
        Assert.Equal(11, position.RiskId);
        Assert.False(position.AutoAddMargin);
        Assert.Equal(1550.80m, position.LiquidationPrice);
        Assert.Equal(0.01926611m, position.InitialMargin);
    }

    [Fact]
    public void ClosedPnl_MapsMovePositionExecutionAndNullableFees()
    {
        var result = DeserializeResult<PositionListResult<BybitPositionProfitAndLoss>>("closed-pnl.json");
        var pnl = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Linear, result.Category);
        Assert.Equal("5a373bfe-188d-4913-9c81-d57ab5be8068%3A1672214887231423699", result.NextPageCursor);
        Assert.Equal(BybitExecutionType.MovePosition, pnl.ExecutionType);
        Assert.Equal(4, pnl.FillCount);
        Assert.Null(pnl.OpenFee);
        Assert.Null(pnl.CloseFee);
    }

    [Fact]
    public void ClosedOptionsPosition_MapsTimestampsAndDecimalStrings()
    {
        var result = DeserializeResult<PositionListResult<BybitOptionsPosition>>("closed-options-position.json");
        var position = Assert.Single(result.List);

        Assert.Equal(BybitCategory.Option, result.Category);
        Assert.Equal(BybitPositionSide.Sell, position.Side);
        Assert.Equal(0.02m, position.Quantity);
        Assert.Equal(1749726002161L, position.CloseTimestamp);
        Assert.Equal(107281.77405031m, position.DeliveryPrice);
        Assert.Equal(0.90760719m, position.TotalPnl);
    }

    [Fact]
    public void MovePosition_MapsStatusAndRejectParty()
    {
        var result = DeserializeResult<BybitPositionMove>("move-position.json");

        Assert.Equal("e9bb926c95f54cf1ba3e315a58b8597b", result.BlockTradeId);
        Assert.Equal(BybitMoveStatus.Processing, result.Status);
        Assert.Equal(string.Empty, result.RejectParty);
    }

    [Fact]
    public void MovePositionHistory_UsesLongUserIdAndMappedEnums()
    {
        var result = DeserializeResult<PositionListResult<BybitPositionMoveHistory>>("move-position-history.json");
        var move = Assert.Single(result.List);

        Assert.Equal("page_token%3D1241742%26", result.NextPageCursor);
        Assert.Equal(BybitCategory.Option, move.Category);
        Assert.Equal(592324L, move.UserId);
        Assert.Equal(BybitOrderSide.Buy, move.Side);
        Assert.Equal(BybitMoveStatus.Filled, move.Status);
        Assert.Equal(0m, move.Fee);
        Assert.Equal(1697186522865L, move.CreateTimestamp);
    }

    [Fact]
    public void MovePositionRequest_SerializesStringNumericsAndMappedEnums()
    {
        var request = new BybitPositionMoveRequest
        {
            Category = BybitCategory.Spot,
            Symbol = "BTCUSDT",
            Side = BybitOrderSide.Sell,
            Price = 100m,
            Quantity = 0.01m,
        };

        var json = JObject.Parse(JsonConvert.SerializeObject(request, SerializerOptions.WithConverters));

        Assert.Equal("spot", json["category"]!.Value<string>());
        Assert.Equal("Sell", json["side"]!.Value<string>());
        Assert.Equal("100", json["price"]!.Value<string>());
        Assert.Equal("0.01", json["qty"]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Position", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record PositionListResult<T>
    {
        public BybitCategory Category { get; set; }
        public List<T> List { get; set; } = [];
        public string? NextPageCursor { get; set; }
    }
}
