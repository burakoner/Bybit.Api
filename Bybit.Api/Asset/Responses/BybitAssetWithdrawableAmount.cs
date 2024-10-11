namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Withdrawable Quantity
/// </summary>
public class BybitAssetWithdrawableAmount
{
    /// <summary>
    /// The frozen amount due to risk, in USD
    /// </summary>
    [JsonProperty("limitAmountUsd")]
    public decimal LimitAmountUsd { get; set; }

    /// <summary>
    /// Withdrawable amount
    /// </summary>
    [JsonProperty("withdrawableAmount")]
    public BybitAssetWithdrawableAmountData WithdrawableAmounts { get; set; }
}

/// <summary>
/// Bybit Withdrawable Quantity Category
/// </summary>
public class BybitAssetWithdrawableAmountData
{
    /// <summary>
    /// Spot wallet, it is not returned if spot wallet is removed
    /// </summary>
    public BybitAssetWithdrawableAmountItem Spot { get; set; }

    /// <summary>
    /// Funding wallet
    /// </summary>
    public BybitAssetWithdrawableAmountItem Fund { get; set; }
}

/// <summary>
/// Bybit Withdrawable Quantity Category Item
/// </summary>
public class BybitAssetWithdrawableAmountItem
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
