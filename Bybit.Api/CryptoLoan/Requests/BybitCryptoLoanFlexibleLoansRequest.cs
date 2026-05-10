namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get flexible crypto loans request.
/// </summary>
public record BybitCryptoLoanFlexibleLoansRequest
{
    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanCurrency { get; set; }
}
