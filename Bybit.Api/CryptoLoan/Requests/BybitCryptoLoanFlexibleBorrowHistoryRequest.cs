namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get flexible crypto loan borrowing history request.
/// </summary>
public record BybitCryptoLoanFlexibleBorrowHistoryRequest
{
    /// <summary>
    /// Loan order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

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
