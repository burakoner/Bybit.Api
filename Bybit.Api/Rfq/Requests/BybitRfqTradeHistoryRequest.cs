namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ trade history request.
/// </summary>
public record BybitRfqTradeHistoryRequest
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
    /// Quote ID.
    /// </summary>
    public string? QuoteId { get; set; }

    /// <summary>
    /// Custom quote ID.
    /// </summary>
    public string? QuoteLinkId { get; set; }

    /// <summary>
    /// Trader type.
    /// </summary>
    public BybitRfqTraderType? TraderType { get; set; }

    /// <summary>
    /// Trade status.
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
