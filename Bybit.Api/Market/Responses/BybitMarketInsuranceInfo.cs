namespace Bybit.Api.Market;

/// <summary>
/// Bybit insurance pool information.
/// </summary>
public record BybitMarketInsuranceInfo
{
    /// <summary>
    /// Data update timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }

    /// <summary>
    /// Data update time.
    /// </summary>
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Insurance pool data.
    /// </summary>
    public List<BybitMarketInsurance> List { get; set; } = [];
}
