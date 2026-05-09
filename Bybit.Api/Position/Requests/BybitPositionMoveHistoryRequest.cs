namespace Bybit.Api.Position;

/// <summary>
/// Get move position history request.
/// </summary>
public record BybitPositionMoveHistoryRequest
{
    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory? Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Order status.
    /// </summary>
    public BybitMoveStatus? Status { get; set; }

    /// <summary>
    /// Block trade ID.
    /// </summary>
    public string? BlockTradeId { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
