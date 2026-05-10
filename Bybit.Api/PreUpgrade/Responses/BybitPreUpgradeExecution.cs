namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade execution history item.
/// </summary>
public record BybitPreUpgradeExecution
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
    /// User customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitOrderSide? Side { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    public decimal? OrderPrice { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    public decimal? OrderQty { get; set; }

    /// <summary>
    /// Remaining quantity.
    /// </summary>
    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType? OrderType { get; set; }

    /// <summary>
    /// Stop order type.
    /// </summary>
    public BybitOrderStopType? StopOrderType { get; set; }

    /// <summary>
    /// Executed trading fee.
    /// </summary>
    [JsonProperty("execFee")]
    public decimal? Fee { get; set; }

    /// <summary>
    /// Execution ID.
    /// </summary>
    [JsonProperty("execId")]
    public string TradeId { get; set; } = string.Empty;

    /// <summary>
    /// Execution price.
    /// </summary>
    [JsonProperty("execPrice")]
    public decimal? Price { get; set; }

    /// <summary>
    /// Execution quantity.
    /// </summary>
    [JsonProperty("execQty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Execution type.
    /// </summary>
    [JsonProperty("execType")]
    public BybitExecutionType? ExecutionType { get; set; }

    /// <summary>
    /// Execution value.
    /// </summary>
    [JsonProperty("execValue")]
    public decimal? Value { get; set; }

    /// <summary>
    /// Execution timestamp in milliseconds.
    /// </summary>
    [JsonProperty("execTime")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Execution time.
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Whether the order was maker.
    /// </summary>
    public bool IsMaker { get; set; }

    /// <summary>
    /// Trading fee rate.
    /// </summary>
    public decimal? FeeRate { get; set; }

    /// <summary>
    /// Trade implied volatility.
    /// </summary>
    public decimal? TradeIv { get; set; }

    /// <summary>
    /// Mark implied volatility.
    /// </summary>
    public decimal? MarkIv { get; set; }

    /// <summary>
    /// Mark price.
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Index price.
    /// </summary>
    public decimal? IndexPrice { get; set; }

    /// <summary>
    /// Underlying price.
    /// </summary>
    public decimal? UnderlyingPrice { get; set; }

    /// <summary>
    /// Block trade ID.
    /// </summary>
    public string BlockTradeId { get; set; } = string.Empty;

    /// <summary>
    /// Closed position size.
    /// </summary>
    [JsonProperty("closedSize")]
    public decimal? ClosedQuantity { get; set; }
}
