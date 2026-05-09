namespace Bybit.Api.Position;

/// <summary>
/// Get closed PnL request.
/// </summary>
public record BybitPositionClosedPnlRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionClosedPnlRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitPositionClosedPnlRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

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
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
