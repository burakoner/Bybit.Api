namespace Bybit.Api.Rfq;

/// <summary>
/// Public RFQ trade.
/// </summary>
public record BybitRfqPublicTrade
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Strategy type.
    /// </summary>
    public string StrategyType { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp in milliseconds.
    /// </summary>
    public long CreatedAt { get; set; }

    /// <summary>
    /// Creation time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime { get => CreatedAt.ConvertFromMilliseconds(); }

    /// <summary>
    /// Update timestamp in milliseconds.
    /// </summary>
    public long UpdatedAt { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdatedTime { get => UpdatedAt.ConvertFromMilliseconds(); }

    /// <summary>
    /// Trade legs.
    /// </summary>
    public List<BybitRfqPublicTradeLeg> Legs { get; set; } = [];
}

/// <summary>
/// Public RFQ trade leg.
/// </summary>
public record BybitRfqPublicTradeLeg
{
    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Instrument symbol.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Execution direction.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Execution price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Executed quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Mark or index price at execution time.
    /// </summary>
    public decimal? MarkPrice { get; set; }
}
