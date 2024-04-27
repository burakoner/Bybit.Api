namespace Bybit.Api.Models.Trade;

public class BybitProfitAndLoss
{
    public string Symbol { get; set; }
    public string OrderId { get; set; }
    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }
    public decimal OrderPrice { get; set; }
    [JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType OrderType { get; set; }
    [JsonProperty("execType")]
    [JsonConverter(typeof(LabelConverter<BybitExecutionType>))]
    public BybitExecutionType TradeType { get; set; }
    public decimal ClosedSize { get; set; }
    [JsonProperty("cumEntryValue")]
    public decimal CumulatedEntryValue { get; set; }
    [JsonProperty("avgEntryPrice")]
    public decimal AverageEntryPrice { get; set; }
    [JsonProperty("cumExitValue")]
    public decimal CumulatedExitValue { get; set; }
    [JsonProperty("avgExitPrice")]
    public decimal AverageExitPrice { get; set; }
    public decimal ClosedPnl { get; set; }
    public int FillCount { get; set; }
    public decimal Leverage { get; set; }

    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }
}
