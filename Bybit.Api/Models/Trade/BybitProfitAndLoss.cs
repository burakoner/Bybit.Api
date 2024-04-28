namespace Bybit.Api.Models.Trade;

/// <summary>
/// Profit and Loss
/// </summary>
public class BybitProfitAndLoss
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Order Id
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Order Price
    /// </summary>
    public decimal OrderPrice { get; set; }

    /// <summary>
    /// Order Type
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Execution Type
    /// </summary>
    [JsonProperty("execType")]
    [JsonConverter(typeof(LabelConverter<BybitExecutionType>))]
    public BybitExecutionType TradeType { get; set; }

    /// <summary>
    /// Closed Quantity
    /// </summary>
    [JsonProperty("closedSize")]
    public decimal ClosedQuantity { get; set; }

    /// <summary>
    /// Cumulated Entry Value
    /// </summary>
    [JsonProperty("cumEntryValue")]
    public decimal CumulatedEntryValue { get; set; }

    /// <summary>
    /// Average Entry Price
    /// </summary>
    [JsonProperty("avgEntryPrice")]
    public decimal AverageEntryPrice { get; set; }

    /// <summary>
    /// Cumulated Exit Value
    /// </summary>
    [JsonProperty("cumExitValue")]
    public decimal CumulatedExitValue { get; set; }

    /// <summary>
    /// Average Exit Price
    /// </summary>
    [JsonProperty("avgExitPrice")]
    public decimal AverageExitPrice { get; set; }

    /// <summary>
    /// Closed Pnl
    /// </summary>
    public decimal ClosedPnl { get; set; }

    /// <summary>
    /// The number of fills in a single order
    /// </summary>
    public int FillCount { get; set; }

    /// <summary>
    /// The leverage of the order
    /// </summary>
    public decimal Leverage { get; set; }

    /// <summary>
    /// The created time (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// The created time
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// The updated time (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// The updated time
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }
}
