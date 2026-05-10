namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get fixed crypto loan borrow contract information request.
/// </summary>
public record BybitCryptoLoanFixedBorrowContractsRequest
{
    /// <summary>
    /// Loan order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Loan ID.
    /// </summary>
    [JsonProperty("loanId", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanId { get; set; }

    /// <summary>
    /// Loan coin name.
    /// </summary>
    [JsonProperty("orderCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderCurrency { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    [JsonProperty("term", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerToStringConverter))]
    public int? Term { get; set; }

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
