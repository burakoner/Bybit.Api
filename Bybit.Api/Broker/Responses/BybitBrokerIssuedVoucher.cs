namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker issued voucher.
/// </summary>
public record BybitBrokerIssuedVoucher
{
    /// <summary>
    /// User ID.
    /// </summary>
    public string AccountId { get; set; } = string.Empty;

    /// <summary>
    /// Voucher ID.
    /// </summary>
    public string AwardId { get; set; } = string.Empty;

    /// <summary>
    /// Spec code.
    /// </summary>
    public string SpecCode { get; set; } = string.Empty;

    /// <summary>
    /// Amount of voucher.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Whether the voucher has been claimed.
    /// </summary>
    public bool IsClaimed { get; set; }

    /// <summary>
    /// Claim start timestamp in seconds.
    /// </summary>
    [JsonProperty("startAt")]
    public long? StartTimestamp { get; set; }

    /// <summary>
    /// Claim start time.
    /// </summary>
    public DateTime? StartTime { get => StartTimestamp?.ConvertFromSeconds(); }

    /// <summary>
    /// Claim end timestamp in seconds.
    /// </summary>
    [JsonProperty("endAt")]
    public long? EndTimestamp { get; set; }

    /// <summary>
    /// Claim end time.
    /// </summary>
    public DateTime? EndTime { get => EndTimestamp?.ConvertFromSeconds(); }

    /// <summary>
    /// Voucher effective timestamp in seconds after claimed.
    /// </summary>
    [JsonProperty("effectiveAt")]
    public long? EffectiveTimestamp { get; set; }

    /// <summary>
    /// Voucher effective time after claimed.
    /// </summary>
    public DateTime? EffectiveTime { get => EffectiveTimestamp?.ConvertFromSeconds(); }

    /// <summary>
    /// Voucher inactive timestamp in seconds after claimed.
    /// </summary>
    [JsonProperty("ineffectiveAt")]
    public long? IneffectiveTimestamp { get; set; }

    /// <summary>
    /// Voucher inactive time after claimed.
    /// </summary>
    public DateTime? IneffectiveTime { get => IneffectiveTimestamp?.ConvertFromSeconds(); }

    /// <summary>
    /// Amount used by the user.
    /// </summary>
    public decimal? UsedAmount { get; set; }
}
