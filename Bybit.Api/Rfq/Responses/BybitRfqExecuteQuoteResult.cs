namespace Bybit.Api.Rfq;

/// <summary>
/// Execute quote result.
/// </summary>
public record BybitRfqExecuteQuoteResult
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
    /// Quote ID.
    /// </summary>
    public string QuoteId { get; set; } = string.Empty;

    /// <summary>
    /// Execution status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }
}
