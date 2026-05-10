namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Institutional loan repayment result.
/// </summary>
public record BybitLoanRepayResult
{
    /// <summary>
    /// Repayment order status.
    /// </summary>
    public BybitLoanRepayOrderStatus RepayOrderStatus { get; set; }
}
