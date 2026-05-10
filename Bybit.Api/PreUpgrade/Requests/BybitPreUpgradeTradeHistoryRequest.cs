namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade trade history request.
/// </summary>
public record BybitPreUpgradeTradeHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeTradeHistoryRequest"/> record.
    /// </summary>
    public BybitPreUpgradeTradeHistoryRequest(BybitCategory category)
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
    /// Order ID.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// User customised order ID.
    /// </summary>
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Base coin. Used for option queries.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Execution type.
    /// </summary>
    public BybitExecutionType? ExecutionType { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
