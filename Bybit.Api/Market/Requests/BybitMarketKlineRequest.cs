namespace Bybit.Api.Market;

/// <summary>
/// Request for market kline endpoints.
/// </summary>
public record BybitMarketKlineRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketKlineRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval</param>
    public BybitMarketKlineRequest(BybitCategory category, string symbol, BybitInterval interval)
    {
        Category = category;
        Symbol = symbol;
        Interval = interval;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Kline interval.
    /// </summary>
    public BybitInterval Interval { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? Start { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? End { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 200;
}
