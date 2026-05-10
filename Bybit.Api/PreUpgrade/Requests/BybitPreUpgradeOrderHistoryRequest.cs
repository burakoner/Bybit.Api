namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade order history request.
/// </summary>
public record BybitPreUpgradeOrderHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeOrderHistoryRequest"/> record.
    /// </summary>
    public BybitPreUpgradeOrderHistoryRequest(BybitCategory category)
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
    /// Base coin. Used for option queries.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Order ID.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// User customised order ID.
    /// </summary>
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Order filter.
    /// </summary>
    public BybitOrderFilter? OrderFilter { get; set; }

    /// <summary>
    /// Order status. Not supported for spot.
    /// </summary>
    public BybitOrderStatus? OrderStatus { get; set; }

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
