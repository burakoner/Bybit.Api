namespace Bybit.Api.Trading;

/// <summary>
/// Get open and closed orders request.
/// </summary>
public record BybitGetOrdersRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitGetOrdersRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitGetOrdersRequest(BybitCategory category)
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
    /// Open-only query mode.
    /// </summary>
    public BybitQueryOpenOnly? OpenOnly { get; set; }

    /// <summary>
    /// Order filter.
    /// </summary>
    public BybitOrderFilter? OrderFilter { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
