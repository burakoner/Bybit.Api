namespace Bybit.Api.Rfq;

/// <summary>
/// Create quote request.
/// </summary>
public record BybitRfqCreateQuoteRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    public BybitRfqCreateQuoteRequest(string rfqId)
    {
        RfqId = rfqId;
    }

    /// <summary>
    /// Inquiry ID.
    /// </summary>
    [JsonProperty("rfqId")]
    public string RfqId { get; set; }

    /// <summary>
    /// Custom quote ID.
    /// </summary>
    [JsonProperty("quoteLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? QuoteLinkId { get; set; }

    /// <summary>
    /// Whether the quote is anonymous.
    /// </summary>
    [JsonProperty("anonymous", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Anonymous { get; set; }

    /// <summary>
    /// Duration of the quote in seconds.
    /// </summary>
    [JsonProperty("expireIn", NullValueHandling = NullValueHandling.Ignore)]
    public int? ExpireIn { get; set; }

    /// <summary>
    /// Buy direction quote legs.
    /// </summary>
    [JsonProperty("quoteBuyList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitRfqQuoteLegRequest>? QuoteBuyList { get; set; }

    /// <summary>
    /// Sell direction quote legs.
    /// </summary>
    [JsonProperty("quoteSellList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitRfqQuoteLegRequest>? QuoteSellList { get; set; }
}
