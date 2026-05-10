namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get fixed crypto loan renew order information request.
/// </summary>
public record BybitCryptoLoanFixedRenewOrdersRequest
{
    /// <summary>
    /// Loan order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Loan coin name.
    /// </summary>
    [JsonProperty("orderCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderCurrency { get; set; }

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
