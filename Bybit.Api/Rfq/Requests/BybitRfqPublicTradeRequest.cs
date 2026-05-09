namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ public trade query request.
/// </summary>
public record BybitRfqPublicTradeRequest
{
    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
