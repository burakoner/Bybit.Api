namespace Bybit.Api.Account;

/// <summary>
/// Bybit Market Maker Protection State
/// </summary>
public class BybitAccountMmp
{
    /// <summary>
    /// Base coin
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; }

    /// <summary>
    /// Whether the account is enabled mmp
    /// </summary>
    public bool MmpEnabled { get; set; }

    /// <summary>
    /// Time window (ms)
    /// </summary>
    public int Window { get; set; }

    /// <summary>
    /// Frozen period (ms)
    /// </summary>
    public int FrozenPeriod { get; set; }

    /// <summary>
    /// Trade qty limit
    /// </summary>
    [JsonProperty("qtyLimit")]
    public decimal QuantityLimit { get; set; }

    /// <summary>
    /// Delta limit
    /// </summary>
    [JsonProperty("qtyLimit")]
    public decimal DeltaLimit { get; set; }

    /// <summary>
    /// Unfreeze timestamp (ms)
    /// </summary>
    [JsonProperty("mmpFrozenUntil")]
    public long MmpFrozenUntilTimestamp { get; set; }

    /// <summary>
    /// Unfreeze timestamp
    /// </summary>
    public DateTime MmpFrozenUntilTime { get => MmpFrozenUntilTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Whether the mmp is triggered.
    /// true : mmpFrozenUntil is meaningful
    /// false: please ignore the value of mmpFrozenUntil
    /// </summary>
    public bool MmpFrozen { get; set; }
}
