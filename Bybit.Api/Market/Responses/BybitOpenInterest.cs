namespace Bybit.Api.Market;

/// <summary>
/// Bybit Open Interest
/// </summary>
public class BybitOpenInterest
{
    /// <summary>
    /// Open interest. The value is the sum of both sides
    /// </summary>
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// The timestamp (ms)
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// The time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}