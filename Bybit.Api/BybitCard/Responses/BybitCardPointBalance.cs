namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card point balance.
/// </summary>
public record BybitCardPointBalance
{
    /// <summary>
    /// Account ID.
    /// </summary>
    public string AccountId { get; set; } = string.Empty;

    /// <summary>
    /// Available points.
    /// </summary>
    public long AvailablePoint { get; set; }

    /// <summary>
    /// Pending points.
    /// </summary>
    public long PendingPoint { get; set; }

    /// <summary>
    /// Account status.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Last update timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updateTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// Last update time.
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Settlement period.
    /// </summary>
    public int SettlementPeriod { get; set; }
}
