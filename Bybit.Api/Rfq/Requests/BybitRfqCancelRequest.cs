namespace Bybit.Api.Rfq;

/// <summary>
/// Cancel RFQ request.
/// </summary>
public record BybitRfqCancelRequest
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    [JsonProperty("rfqId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RfqId { get; set; }

    /// <summary>
    /// Custom inquiry ID.
    /// </summary>
    [JsonProperty("rfqLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RfqLinkId { get; set; }
}
