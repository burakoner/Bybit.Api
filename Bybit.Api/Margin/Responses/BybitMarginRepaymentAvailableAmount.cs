namespace Bybit.Api.Margin;

/// <summary>
/// Available amount to repay.
/// </summary>
public record BybitMarginRepaymentAvailableAmount
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Repayment amount without asset conversion.
    /// </summary>
    public decimal LossLessRepaymentAmount { get; set; }
}
