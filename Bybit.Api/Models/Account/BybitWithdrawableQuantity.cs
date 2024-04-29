namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Withdrawable Quantity
/// </summary>
public class BybitWithdrawableQuantity
{
    /// <summary>
    /// The frozen amount due to risk, in USD
    /// </summary>
    [JsonProperty("limitAmountUsd")]
    public decimal LimitQuantityUsd { get; set; }

    /// <summary>
    /// Withdrawable amount
    /// </summary>
    [JsonProperty("withdrawableAmount")]
    public BybitWithdrawableQuantityCategory WithdrawableQuantity { get; set; }
}

/// <summary>
/// Bybit Withdrawable Quantity Category
/// </summary>
public class BybitWithdrawableQuantityCategory
{
    /// <summary>
    /// Spot wallet, it is not returned if spot wallet is removed
    /// </summary>
    public BybitWithdrawableQuantityCategoryItem Spot { get; set; }

    /// <summary>
    /// Funding wallet
    /// </summary>
    public BybitWithdrawableQuantityCategoryItem Fund { get; set; }
}

/// <summary>
/// Bybit Withdrawable Quantity Category Item
/// </summary>
public class BybitWithdrawableQuantityCategoryItem
{
    /// <summary>
    /// Coin name
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Amount that can be withdrawn
    /// </summary>
    [JsonProperty("withdrawableAmount")]
    public decimal WithdrwawableQuantity { get; set; }

    /// <summary>
    /// Available balance
    /// </summary>
    public decimal AvailableBalance { get; set; }
}
