namespace Bybit.Api.Rfq;

/// <summary>
/// Cancel all RFQs result.
/// </summary>
public record BybitRfqCancelAllResult
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Custom inquiry ID.
    /// </summary>
    public string RfqLinkId { get; set; } = string.Empty;

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
