namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get fixed crypto loan supply contract information request.
/// </summary>
public record BybitCryptoLoanFixedSupplyContractsRequest
{
    /// <summary>
    /// Supply order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Supply contract ID.
    /// </summary>
    [JsonProperty("supplyId", NullValueHandling = NullValueHandling.Ignore)]
    public string? SupplyId { get; set; }

    /// <summary>
    /// Supply coin name.
    /// </summary>
    [JsonProperty("supplyCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? SupplyCurrency { get; set; }

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
