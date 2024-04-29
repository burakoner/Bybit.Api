namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Asset Balances
/// </summary>
public class BybitAssetBalance
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonProperty("accountType")]
    public BybitAccount Account { get; set; }

    /// <summary>
    /// UID
    /// </summary>
    public string MemberId { get; set; }

    /// <summary>
    /// Balances
    /// </summary>
    [JsonProperty("balance")]
    public List<BybitAssetBalanceItem> Balances { get; set; } = [];
}

/// <summary>
/// Bybit Asset Balance Item
/// </summary>
public class BybitAssetBalanceItem
{
    /// <summary>
    /// Currency type
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

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
}

/// <summary>
/// Bybit Asset Balances
/// </summary>
public class BybitSingleAssetBalance
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonProperty("accountType")]
    public BybitAccount Account { get; set; }
    
    /// <summary>
    /// Business type
    /// </summary>
    [JsonProperty("bizType")]
    public int BusinessType { get; set; }

    /// <summary>
    /// Account ID
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// UID
    /// </summary>
    public string MemberId { get; set; }

    /// <summary>
    /// Balances
    /// </summary>
    [JsonProperty("balance")]
    public List<BybitSingleAssetBalanceItem> Balances { get; set; } = [];
}

/// <summary>
/// Bybit Single Asset Balance Item
/// </summary>
public class BybitSingleAssetBalanceItem
{
    /// <summary>
    /// Currency type
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

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
