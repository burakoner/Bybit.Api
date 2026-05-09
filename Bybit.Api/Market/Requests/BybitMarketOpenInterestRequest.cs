namespace Bybit.Api.Market;

/// <summary>
/// Request for open interest.
/// </summary>
public record BybitMarketOpenInterestRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketOpenInterestRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Interval time</param>
    public BybitMarketOpenInterestRequest(BybitCategory category, string symbol, BybitRecordPeriod period)
    {
        Category = category;
        Symbol = symbol;
        Period = period;
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
    /// Interval time.
    /// </summary>
    public BybitRecordPeriod Period { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 50;

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
