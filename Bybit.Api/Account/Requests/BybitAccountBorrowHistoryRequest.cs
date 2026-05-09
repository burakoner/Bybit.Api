namespace Bybit.Api.Account;

/// <summary>
/// Bybit account borrow history request.
/// </summary>
public record BybitAccountBorrowHistoryRequest
{
    /// <summary>
    /// Currency.
    /// </summary>
    public string? Asset { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
