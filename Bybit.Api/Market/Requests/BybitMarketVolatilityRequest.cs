namespace Bybit.Api.Market;

/// <summary>
/// Request for option historical volatility.
/// </summary>
public record BybitMarketVolatilityRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketVolatilityRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketVolatilityRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Quote coin. Supported values are USD and USDT.
    /// </summary>
    public string? QuoteAsset { get; set; }

    /// <summary>
    /// Volatility period.
    /// </summary>
    public BybitOptionPeriod? Period { get; set; }
}
