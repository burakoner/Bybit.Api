namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Flexible crypto loan borrowing history item.
/// </summary>
public record BybitCryptoLoanFlexibleBorrow
{
    /// <summary>
    /// Borrow timestamp.
    /// </summary>
    public long BorrowTime { get; set; }

    /// <summary>
    /// Borrow time.
    /// </summary>
    public DateTime BorrowDateTime { get => BorrowTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Initial loan amount.
    /// </summary>
    public decimal InitialLoanAmount { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Loan order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Loan order status.
    /// </summary>
    public BybitCryptoLoanOperationStatus Status { get; set; }
}
