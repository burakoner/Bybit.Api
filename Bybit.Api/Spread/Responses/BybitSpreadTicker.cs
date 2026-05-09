namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread ticker.
/// </summary>
public record BybitSpreadTicker
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Best bid price.
    /// </summary>
    public decimal? BidPrice { get; set; }

    /// <summary>
    /// Best bid quantity.
    /// </summary>
    public decimal? BidSize { get; set; }

    /// <summary>
    /// Best ask price.
    /// </summary>
    public decimal? AskPrice { get; set; }

    /// <summary>
    /// Best ask quantity.
    /// </summary>
    public decimal? AskSize { get; set; }

    /// <summary>
    /// Last traded price.
    /// </summary>
    public decimal? LastPrice { get; set; }

    /// <summary>
    /// Highest price in the last 24 hours.
    /// </summary>
    public decimal? HighPrice24h { get; set; }

    /// <summary>
    /// Lowest price in the last 24 hours.
    /// </summary>
    public decimal? LowPrice24h { get; set; }

    /// <summary>
    /// Price 24 hours ago.
    /// </summary>
    public decimal? PrevPrice24h { get; set; }

    /// <summary>
    /// Volume in the last 24 hours.
    /// </summary>
    public decimal? Volume24h { get; set; }
}
