namespace Bybit.Api.Models.Account;

internal class BybitCategoryBalance
{
    public BybitSpotBalance Spot { get; set; } = null!;
}

/// <summary>
/// Bybit Category Balance
/// </summary>
public class BybitSpotBalance
{
    /// <summary>
    /// account status. ACCOUNT_STATUS_NORMAL: normal, ACCOUNT_STATUS_UNSPECIFIED: banned
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// List of assets
    /// </summary>
    public List<BybitSpotBalanceItem> Assets { get; set; } = [];
}

/// <summary>
/// Bybit Category Balance Item
/// </summary>
public class BybitSpotBalanceItem
{
    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

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
