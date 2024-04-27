namespace Bybit.Api.Models.Socket;

public class BybitPositionUpdate
{
    public string Symbol { get; set; }

    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory? Category { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide? Side { get; set; }

    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex? PositionIndex { get; set; }

    [JsonProperty("tradeMode"), JsonConverter(typeof(LabelConverter<BybitTradeMode>))]
    public BybitTradeMode? TradeMode { get; set; }

    public decimal? PositionValue { get; set; }
    public long? RiskId { get; set; }
    public decimal? RiskLimitValue { get; set; }
    public decimal? EntryPrice { get; set; }
    public decimal? MarkPrice { get; set; }
    public decimal? Leverage { get; set; }
    public decimal? PositionBalance { get; set; }

    [JsonProperty("autoAddMargin"), JsonConverter(typeof(BooleanConverter))]
    public bool? AutoAddMargin { get; set; }

    public decimal? PositionMM { get; set; }
    public decimal? PositionIM { get; set; }
    public decimal? LiqPrice { get; set; }
    public decimal? BustPrice { get; set; }

    [JsonProperty("tpslMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    public decimal? TakeProfit { get; set; }
    public decimal? StopLoss { get; set; }
    public decimal? TrailingStop { get; set; }
    public decimal? UnrealisedPnl { get; set; }

    [JsonProperty("CumRealisedPnl")]
    public decimal? CumulativeRealisedPnl { get; set; }

    [JsonProperty("positionStatus"), JsonConverter(typeof(LabelConverter<BybitPositionStatus>))]
    public BybitPositionStatus? PositionStatus { get; set; }

    [JsonProperty("adlRankIndicator"), JsonConverter(typeof(LabelConverter<BybitAdlRankIndicator>))]
    public BybitAdlRankIndicator? AdlRankIndicator { get; set; }

    [JsonProperty("createdTime")]
    public long? CreatedTimestamp { get; set; }
    public DateTime? CreatedTime { get => CreatedTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdatedTimestamp { get; set; }
    public DateTime? UpdatedTime { get => UpdatedTimestamp?.ConvertFromMilliseconds(); }
}