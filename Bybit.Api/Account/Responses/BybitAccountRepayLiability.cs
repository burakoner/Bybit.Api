namespace Bybit.Api.Account;

/// <summary>
/// Bybit account repay liability result item.
/// </summary>
public record BybitAccountRepayLiability
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Repayment quantity.
    /// </summary>
    [JsonProperty("repaymentQty")]
    public decimal RepaymentQuantity { get; set; }
}
