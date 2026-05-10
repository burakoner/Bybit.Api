namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Flexible crypto loan repayment history item.
/// </summary>
public record BybitCryptoLoanFlexibleRepayment
{
    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Repayment amount.
    /// </summary>
    public decimal RepayAmount { get; set; }

    /// <summary>
    /// Repayment transaction ID.
    /// </summary>
    public string RepayId { get; set; } = string.Empty;

    /// <summary>
    /// Repayment status.
    /// </summary>
    public BybitCryptoLoanOperationStatus RepayStatus { get; set; }

    /// <summary>
    /// Repayment timestamp.
    /// </summary>
    public long RepayTime { get; set; }

    /// <summary>
    /// Repayment time.
    /// </summary>
    public DateTime RepayDateTime { get => RepayTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitCryptoLoanRepayType RepayType { get; set; }
}
