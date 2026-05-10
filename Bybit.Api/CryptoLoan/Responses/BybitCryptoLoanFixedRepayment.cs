namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan repayment history item.
/// </summary>
public record BybitCryptoLoanFixedRepayment
{
    /// <summary>
    /// Repayment details.
    /// </summary>
    public List<BybitCryptoLoanFixedRepaymentDetail> Details { get; set; } = [];

    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Repayment amount.
    /// </summary>
    public decimal RepayAmount { get; set; }

    /// <summary>
    /// Repayment order ID.
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

/// <summary>
/// Fixed crypto loan repayment detail.
/// </summary>
public record BybitCryptoLoanFixedRepaymentDetail
{
    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Loan ID.
    /// </summary>
    public string LoanId { get; set; } = string.Empty;

    /// <summary>
    /// Repayment amount.
    /// </summary>
    public decimal RepayAmount { get; set; }
}
