namespace Bybit.Api.Market;

/// <summary>
/// Bybit Time
/// </summary>
public class BybitTime
{
    /// <summary>
    /// Epoch Seconds
    /// </summary>
    [JsonProperty("timeSecond")]
    public long EpochSeconds { get; set; }

    /// <summary>
    /// Nano Seconds
    /// </summary>
    [JsonProperty("timeNano")]
    public long NanoSeconds { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => EpochSeconds.ConvertFromSeconds(); }
}
