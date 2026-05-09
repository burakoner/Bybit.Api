namespace Bybit.Api.Rfq;

/// <summary>
/// Cancel all quotes result.
/// </summary>
public record BybitRfqQuoteCancelAllResult
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Quote ID.
    /// </summary>
    public string QuoteId { get; set; } = string.Empty;

    /// <summary>
    /// Custom quote ID.
    /// </summary>
    public string QuoteLinkId { get; set; } = string.Empty;

    /// <summary>
    /// Cancellation result code. Zero means success.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Cancellation failure reason.
    /// </summary>
    [JsonProperty("msg")]
    public string Message { get; set; } = string.Empty;
}
