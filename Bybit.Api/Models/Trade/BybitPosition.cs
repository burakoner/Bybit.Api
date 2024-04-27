namespace Bybit.Api.Models.Trade;

public class BybitPosition
{
    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex PositionIndex { get; set; }

    public long RiskId { get; set; }
    public decimal RiskLimitValue { get; set; }
    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitPositionSide>))]
    public BybitPositionSide? Side { get; set; }

    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    public decimal? PositionValue { get; set; }

    [JsonProperty("tradeMode"), JsonConverter(typeof(LabelConverter<BybitTradeMode>))]
    public BybitTradeMode TradeMode { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitPositionStatus>))]
    public BybitPositionStatus PositionStatus { get; set; }

    public decimal? Leverage { get; set; }
    public decimal? MarkPrice { get; set; }
    [JsonProperty("liqPrice")]
    public decimal LiquidationPrice { get; set; }
    public decimal? BustPrice { get; set; }
    [JsonProperty("positionIM")]
    public decimal? InitialMargin { get; set; }
    [JsonProperty("positionMM")]
    public decimal? MaintenanceMargin { get; set; }

    [JsonProperty("tpslMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode TakeProfitStopLossMode { get; set; }

    [JsonProperty("takeProfit")]
    public decimal? TakeProfitPrice { get; set; }

    [JsonProperty("stopLoss")]
    public decimal? StopLossPrice { get; set; }

    [JsonProperty("trailingStop")]
    public decimal? TrailingStopDistance { get; set; }

    [JsonProperty("unrealisedPnl")]
    public decimal? UnrealizedPnl { get; set; }

    [JsonProperty("cumRealisedPnl")]
    public decimal? RealizedPnl { get; set; }

    [JsonProperty("adlRankIndicator")]
    public int AutoDeleverageRankIndicator { get; set; }

    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }
}
