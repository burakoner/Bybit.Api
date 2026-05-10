namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade closed PnL item.
/// </summary>
public record BybitPreUpgradeClosedPnl
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitOrderSide? Side { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    public decimal? OrderPrice { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType? OrderType { get; set; }

    /// <summary>
    /// Execution type.
    /// </summary>
    [JsonProperty("execType")]
    public BybitExecutionType? ExecutionType { get; set; }

    /// <summary>
    /// Closed size.
    /// </summary>
    [JsonProperty("closedSize")]
    public decimal? ClosedQuantity { get; set; }

    /// <summary>
    /// Cumulated entry value.
    /// </summary>
    public decimal? CumEntryValue { get; set; }

    /// <summary>
    /// Average entry price.
    /// </summary>
    public decimal? AvgEntryPrice { get; set; }

    /// <summary>
    /// Cumulated exit value.
    /// </summary>
    public decimal? CumExitValue { get; set; }

    /// <summary>
    /// Average exit price.
    /// </summary>
    public decimal? AvgExitPrice { get; set; }

    /// <summary>
    /// Closed PnL.
    /// </summary>
    public decimal? ClosedPnl { get; set; }

    /// <summary>
    /// Number of fills in the order.
    /// </summary>
    public int? FillCount { get; set; }

    /// <summary>
    /// Leverage.
    /// </summary>
    public decimal? Leverage { get; set; }

    /// <summary>
    /// Created timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Created time.
    /// </summary>
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdatedTimestamp { get; set; }

    /// <summary>
    /// Updated time.
    /// </summary>
    public DateTime UpdatedTime { get => UpdatedTimestamp.ConvertFromMilliseconds(); }
}
