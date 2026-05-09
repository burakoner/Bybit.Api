namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ identifier result.
/// </summary>
public record BybitRfqId
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Custom inquiry ID.
    /// </summary>
    public string RfqLinkId { get; set; } = string.Empty;
}
