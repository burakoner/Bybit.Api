namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread cancel all orders result.
/// </summary>
public record BybitSpreadCancelAllOrders
{
    /// <summary>
    /// Cancelled orders.
    /// </summary>
    public List<BybitSpreadOrderId> List { get; set; } = [];

    /// <summary>
    /// Success flag returned by Bybit.
    /// </summary>
    public string Success { get; set; } = string.Empty;
}
