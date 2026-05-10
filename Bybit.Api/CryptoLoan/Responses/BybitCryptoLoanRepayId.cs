namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan repayment ID response.
/// </summary>
public record BybitCryptoLoanRepayId
{
    /// <summary>
    /// Repayment transaction ID.
    /// </summary>
    public string RepayId { get; set; } = string.Empty;
}
