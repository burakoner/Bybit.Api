namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan borrow contract.
/// </summary>
public record BybitCryptoLoanFixedBorrowContract
{
    /// <summary>
    /// Annual rate for the borrowing.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Deprecated auto-repay setting.
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool? AutoRepay { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    public string BorrowCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Borrow timestamp.
    /// </summary>
    public long BorrowTime { get; set; }

    /// <summary>
    /// Borrow time.
    /// </summary>
    public DateTime BorrowDateTime { get => BorrowTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Paid interest.
    /// </summary>
    public decimal InterestPaid { get; set; }

    /// <summary>
    /// Loan contract ID.
    /// </summary>
    public string LoanId { get; set; } = string.Empty;

    /// <summary>
    /// Loan order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Repayment timestamp.
    /// </summary>
    public long RepaymentTime { get; set; }

    /// <summary>
    /// Repayment time.
    /// </summary>
    public DateTime RepaymentDateTime { get => RepaymentTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitFixedBorrowRepayType RepayType { get; set; }

    /// <summary>
    /// Unpaid interest.
    /// </summary>
    public decimal ResidualPenaltyInterest { get; set; }

    /// <summary>
    /// Unpaid principal.
    /// </summary>
    public decimal ResidualPrincipal { get; set; }

    /// <summary>
    /// Loan contract status.
    /// </summary>
    public BybitFixedBorrowContractStatus Status { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }
}
