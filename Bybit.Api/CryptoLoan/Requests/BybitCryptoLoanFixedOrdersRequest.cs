namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get fixed crypto loan order information request.
/// </summary>
public record BybitCryptoLoanFixedOrdersRequest
{
    /// <summary>
    /// Order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Order coin name.
    /// </summary>
    [JsonProperty("orderCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderCurrency { get; set; }

    /// <summary>
    /// Order state.
    /// </summary>
    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCryptoLoanFixedOrderState? State { get; set; }

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
