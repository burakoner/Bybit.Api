namespace Bybit.Api.Market;

/// <summary>
/// Bybit Funding History
/// </summary>
public class BybitFundingHistory
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Funding Rate
    /// </summary>
    public decimal FundingRate { get; set; }

    /// <summary>
    /// Funding Timestamp
    /// </summary>
    [JsonProperty("fundingRateTimestamp")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Funding Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}