namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread execution.
/// </summary>
public record BybitSpreadExecution
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Spread combination order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Combo execution price.
    /// </summary>
    public decimal ExecPrice { get; set; }

    /// <summary>
    /// Combo execution timestamp in milliseconds.
    /// </summary>
    public long ExecTime { get; set; }

    /// <summary>
    /// Combo execution time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => ExecTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Combo execution type.
    /// </summary>
    public BybitExecutionType ExecType { get; set; }

    /// <summary>
    /// Combo execution quantity.
    /// </summary>
    public decimal ExecQty { get; set; }

    /// <summary>
    /// Combo execution ID.
    /// </summary>
    public string ExecId { get; set; } = string.Empty;

    /// <summary>
    /// Leg executions.
    /// </summary>
    public List<BybitSpreadExecutionLeg> Legs { get; set; } = [];
}

/// <summary>
/// Bybit spread execution leg.
/// </summary>
public record BybitSpreadExecutionLeg
{
    /// <summary>
    /// Leg symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Leg side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Leg execution price.
    /// </summary>
    public decimal ExecPrice { get; set; }

    /// <summary>
    /// Leg execution timestamp in milliseconds.
    /// </summary>
    public long ExecTime { get; set; }

    /// <summary>
    /// Leg execution time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => ExecTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Leg execution value.
    /// </summary>
    public decimal ExecValue { get; set; }

    /// <summary>
    /// Leg execution type.
    /// </summary>
    public BybitExecutionType ExecType { get; set; }

    /// <summary>
    /// Leg category.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Leg execution quantity.
    /// </summary>
    public decimal ExecQty { get; set; }

    /// <summary>
    /// Leg execution fee.
    /// </summary>
    public decimal? ExecFee { get; set; }

    /// <summary>
    /// Spot leg execution fee.
    /// </summary>
    public decimal? ExecFeeV2 { get; set; }

    /// <summary>
    /// Fee currency.
    /// </summary>
    public string FeeCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Leg execution ID.
    /// </summary>
    public string ExecId { get; set; } = string.Empty;
}
