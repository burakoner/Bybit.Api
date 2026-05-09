namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ query request.
/// </summary>
public record BybitRfqQueryRequest
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string? RfqId { get; set; }

    /// <summary>
    /// Custom inquiry ID.
    /// </summary>
    public string? RfqLinkId { get; set; }

    /// <summary>
    /// Trader type.
    /// </summary>
    public BybitRfqTraderType? TraderType { get; set; }

    /// <summary>
    /// RFQ status.
    /// </summary>
    public BybitRfqStatus? Status { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
