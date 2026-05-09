namespace Bybit.Api.Rfq;

/// <summary>
/// Cancel quote request.
/// </summary>
public record BybitRfqCancelQuoteRequest
{
    /// <summary>
    /// Quote ID.
    /// </summary>
    [JsonProperty("quoteId", NullValueHandling = NullValueHandling.Ignore)]
    public string? QuoteId { get; set; }

    /// <summary>
    /// Inquiry ID.
    /// </summary>
    [JsonProperty("rfqId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RfqId { get; set; }

    /// <summary>
    /// Custom quote ID.
    /// </summary>
    [JsonProperty("quoteLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? QuoteLinkId { get; set; }
}
