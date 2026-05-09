namespace Bybit.Api.Account;

/// <summary>
/// Bybit account option asset information.
/// </summary>
public record BybitAccountOptionAssetInfo
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Total delta. Only includes delta from option positions.
    /// </summary>
    public decimal TotalDelta { get; set; }

    /// <summary>
    /// Total realised PnL.
    /// </summary>
    [JsonProperty("totalRPL")]
    public decimal TotalRealizedPnl { get; set; }

    /// <summary>
    /// Total unrealised PnL.
    /// </summary>
    [JsonProperty("totalUPL")]
    public decimal TotalUnrealizedPnl { get; set; }

    /// <summary>
    /// Asset initial margin.
    /// </summary>
    [JsonProperty("assetIM")]
    public decimal AssetInitialMargin { get; set; }

    /// <summary>
    /// Asset maintenance margin.
    /// </summary>
    [JsonProperty("assetMM")]
    public decimal AssetMaintenanceMargin { get; set; }

    /// <summary>
    /// Snapshot timestamp (ms).
    /// </summary>
    [JsonProperty("sendTime")]
    public long SendTimestamp { get; set; }

    /// <summary>
    /// Snapshot time.
    /// </summary>
    public DateTime SendTime { get => SendTimestamp.ConvertFromMilliseconds(); }
}
