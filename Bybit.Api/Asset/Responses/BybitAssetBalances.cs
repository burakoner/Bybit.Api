namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Asset Balances
/// </summary>
public record BybitAssetBalances
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonProperty("accountType")]
    public BybitAccountType Account { get; set; }

    /// <summary>
    /// UID
    /// </summary>
    public string MemberId { get; set; } = string.Empty;

    /// <summary>
    /// Balances
    /// </summary>
    [JsonProperty("balance")]
    public List<BybitAssetBalancesItem> Balances { get; set; } = [];
}

/// <summary>
/// Bybit Asset Balance Item
/// </summary>
public record BybitAssetBalancesItem
{
    /// <summary>
    /// Currency type
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Wallet balance
    /// </summary>
    public decimal WalletBalance { get; set; }

    /// <summary>
    /// Transferable balance
    /// </summary>
    public decimal TransferBalance { get; set; }

    /// <summary>
    /// The bonus
    /// </summary>
    public decimal? Bonus { get; set; }

    /// <summary>
    /// Safe amount to transfer. Keep "" if not query
    /// </summary>
    public decimal? TransferSafeAmount { get; set; }

    /// <summary>
    /// Transferable amount for ins loan account. Keep "" if not query
    /// </summary>
    public decimal? LtvTransferSafeAmount { get; set; }
}
