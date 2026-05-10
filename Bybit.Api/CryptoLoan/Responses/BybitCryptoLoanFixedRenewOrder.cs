namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan renew order.
/// </summary>
public record BybitCryptoLoanFixedRenewOrder
{
    /// <summary>
    /// Loan amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitFixedBorrowRepayType AutoRepay { get; set; }

    /// <summary>
    /// Borrow currency.
    /// </summary>
    public string BorrowCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Contract number.
    /// </summary>
    public string ContractNo { get; set; } = string.Empty;

    /// <summary>
    /// Due timestamp.
    /// </summary>
    public long DueTime { get; set; }

    /// <summary>
    /// Due time.
    /// </summary>
    public DateTime DueDateTime { get => DueTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Loan ID.
    /// </summary>
    public string LoanId { get; set; } = string.Empty;

    /// <summary>
    /// Order ID.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    /// Renew loan number.
    /// </summary>
    public string RenewLoanNo { get; set; } = string.Empty;

    /// <summary>
    /// Timestamp.
    /// </summary>
    public long Time { get; set; }

    /// <summary>
    /// Created time.
    /// </summary>
    public DateTime CreatedTime { get => Time.ConvertFromMilliseconds(); }
}
