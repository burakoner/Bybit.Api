namespace Bybit.Api.Asset;

internal class BybitAssetCategoryBalance
{
    public BybitAssetSpotBalance Spot { get; set; } = null!;
}

/// <summary>
/// Bybit Category Balance
/// </summary>
public record BybitAssetSpotBalance
{
    /// <summary>
    /// account status. ACCOUNT_STATUS_NORMAL: normal, ACCOUNT_STATUS_UNSPECIFIED: banned
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// List of assets
    /// </summary>
    public List<BybitAssetSpotBalanceItem> Assets { get; set; } = [];
}

/// <summary>
/// Bybit Category Balance Item
/// </summary>
public record BybitAssetSpotBalanceItem
{
    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Freeze amount
    /// </summary>
    public decimal Frozen { get; set; }

    /// <summary>
    /// Free balance
    /// </summary>
    public decimal Free { get; set; }

    /// <summary>
    /// Amount in withdrawing
    /// </summary>
    [JsonProperty("withdraw")]
    public decimal? Withdrawing { get; set; }
}
