namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Flexible crypto loan.
/// </summary>
public record BybitCryptoLoanFlexibleLoan
{
    /// <summary>
    /// Latest hourly flexible interest rate.
    /// </summary>
    public decimal HourlyInterestRate { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Unpaid principal and interest.
    /// </summary>
    public decimal TotalDebt { get; set; }

    /// <summary>
    /// Unpaid principal.
    /// </summary>
    public decimal UnpaidAmount { get; set; }

    /// <summary>
    /// Unpaid interest.
    /// </summary>
    public decimal UnpaidInterest { get; set; }
}
