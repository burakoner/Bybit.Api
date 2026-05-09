namespace Bybit.Api.Trading;

/// <summary>
/// Cancel all orders request.
/// </summary>
public record BybitCancelAllOrdersRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCancelAllOrdersRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitCancelAllOrdersRequest(BybitCategory category)
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
    /// Order filter.
    /// </summary>
    public BybitOrderFilter? OrderFilter { get; set; }

    /// <summary>
    /// Stop order type.
    /// </summary>
    public BybitStopOrderType? StopOrderType { get; set; }
}
