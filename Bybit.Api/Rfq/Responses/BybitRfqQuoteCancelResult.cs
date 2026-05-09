namespace Bybit.Api.Rfq;

/// <summary>
/// Cancel quote result.
/// </summary>
public record BybitRfqQuoteCancelResult
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
}
