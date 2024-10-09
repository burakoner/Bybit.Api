namespace Bybit.Api.Market;

/// <summary>
/// Bybit Long Short Ratio
/// </summary>
public class BybitMarketLongShortRatio
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// The ratio of users with net long position
    /// </summary>
    public decimal BuyRatio { get; set; }

    /// <summary>
    /// The ratio of users with net short position
    /// </summary>
    public decimal SellRatio { get; set; }

    /// <summary>
    /// Timestamp (ms)
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// Delivery Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}