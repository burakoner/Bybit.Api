namespace Bybit.Api.Rfq;

/// <summary>
/// Accept non-LP quote request.
/// </summary>
public record BybitRfqAcceptOtherQuoteRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    public BybitRfqAcceptOtherQuoteRequest(string rfqId)
    {
        RfqId = rfqId;
    }

    /// <summary>
    /// Inquiry ID.
    /// </summary>
    [JsonProperty("rfqId")]
    public string RfqId { get; set; }
}
