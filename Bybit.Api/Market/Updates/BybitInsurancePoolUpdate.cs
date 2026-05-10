namespace Bybit.Api.Market;

/// <summary>
/// Bybit insurance pool stream update.
/// </summary>
public record BybitInsurancePoolUpdate
{
    /// <summary>
    /// Stream type.
    /// </summary>
    [JsonIgnore]
    public Bybit.Api.Common.Requests.BybitStreamType StreamType { get; set; }

    /// <summary>
    /// Stream generated timestamp in milliseconds.
    /// </summary>
    [JsonIgnore]
    public long StreamTimestamp { get; set; }

    /// <summary>
    /// Stream generated time.
    /// </summary>
    [JsonIgnore]
    public DateTime StreamTime { get => StreamTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Insurance pool coin.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbols { get; set; } = string.Empty;

    /// <summary>
    /// Balance.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Data updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updateTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// Data updated time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }
}
