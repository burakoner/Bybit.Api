namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get flexible crypto loan repayment history request.
/// </summary>
public record BybitCryptoLoanFlexibleRepaymentHistoryRequest
{
    /// <summary>
    /// Repayment transaction ID.
    /// </summary>
    [JsonProperty("repayId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RepayId { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanCurrency { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
