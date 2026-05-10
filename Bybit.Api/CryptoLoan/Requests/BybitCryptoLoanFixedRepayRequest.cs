namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fully repay fixed crypto loan request.
/// </summary>
public record BybitCryptoLoanFixedRepayRequest
{
    /// <summary>
    /// Loan contract ID.
    /// </summary>
    [JsonProperty("loanId", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanId { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanCurrency { get; set; }
}
