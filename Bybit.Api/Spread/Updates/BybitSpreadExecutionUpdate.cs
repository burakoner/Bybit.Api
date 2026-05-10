namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread execution stream update.
/// </summary>
public record BybitSpreadExecutionUpdate
{
    /// <summary>
    /// Category name: combination, spot_leg or future_leg.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Combo or leg symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Whether to borrow for the spot leg.
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsLeverage { get; set; }

    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customized order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

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
    public decimal? LeavesQty { get; set; }

    /// <summary>
    /// Order create type.
    /// </summary>
    public string CreateType { get; set; } = string.Empty;

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Leg execution fee, deprecated for spot leg.
    /// </summary>
    public decimal? ExecFee { get; set; }

    /// <summary>
    /// Spot leg execution fee.
    /// </summary>
    public decimal? ExecFeeV2 { get; set; }

    /// <summary>
    /// Leg fee currency.
    /// </summary>
    public string FeeCoin { get; set; } = string.Empty;

    /// <summary>
    /// Combo execution ID for leg events.
    /// </summary>
    public string ParentExecId { get; set; } = string.Empty;

    /// <summary>
    /// Execution ID.
    /// </summary>
    public string ExecId { get; set; } = string.Empty;

    /// <summary>
    /// Execution price.
    /// </summary>
    public decimal ExecPrice { get; set; }

    /// <summary>
    /// Execution quantity.
    /// </summary>
    public decimal ExecQty { get; set; }

    /// <summary>
    /// Profit and loss for each close position execution.
    /// </summary>
    public decimal? ExecPnl { get; set; }

    /// <summary>
    /// Execution type.
    /// </summary>
    public BybitExecutionType ExecType { get; set; }

    /// <summary>
    /// Execution value.
    /// </summary>
    public decimal? ExecValue { get; set; }

    /// <summary>
    /// Execution timestamp in milliseconds.
    /// </summary>
    public long ExecTime { get; set; }

    /// <summary>
    /// Execution time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => ExecTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Is maker order.
    /// </summary>
    public bool IsMaker { get; set; }

    /// <summary>
    /// Trading fee rate.
    /// </summary>
    public decimal? FeeRate { get; set; }

    /// <summary>
    /// Mark price.
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Closed position size.
    /// </summary>
    public decimal? ClosedSize { get; set; }

    /// <summary>
    /// Cross sequence.
    /// </summary>
    [JsonProperty("seq")]
    public long Sequence { get; set; }
}
