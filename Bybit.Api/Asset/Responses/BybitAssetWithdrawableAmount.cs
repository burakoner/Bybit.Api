namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Withdrawable Quantity
/// </summary>
public record BybitAssetWithdrawableAmount
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
    public BybitAssetWithdrawableAmountData WithdrawableAmounts { get; set; } = default!;
}

/// <summary>
/// Bybit Withdrawable Quantity Category
/// </summary>
public record BybitAssetWithdrawableAmountData
{
    /// <summary>
    /// Spot wallet, it is not returned if spot wallet is removed
    /// </summary>
    public BybitAssetWithdrawableAmountItem Spot { get; set; } = default!;

    /// <summary>
    /// Funding wallet
    /// </summary>
    public BybitAssetWithdrawableAmountItem Fund { get; set; } = default!;
}

/// <summary>
/// Bybit Withdrawable Quantity Category Item
/// </summary>
public record BybitAssetWithdrawableAmountItem
{
    /// <summary>
    /// Coin name
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

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
