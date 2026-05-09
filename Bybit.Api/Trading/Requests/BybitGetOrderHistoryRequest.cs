namespace Bybit.Api.Trading;

/// <summary>
/// Get order history request.
/// </summary>
public record BybitGetOrderHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitGetOrderHistoryRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitGetOrderHistoryRequest(BybitCategory category)
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
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Settle coin.
    /// </summary>
    public string? SettleAsset { get; set; }

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
    /// Order status.
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
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
