namespace Bybit.Api.Trading;

/// <summary>
/// Pre-check order request.
/// </summary>
public record BybitPreCheckOrderRequest : BybitPlaceOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreCheckOrderRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="type">Order type.</param>
    /// <param name="quantity">Order quantity.</param>
    public BybitPreCheckOrderRequest(BybitCategory category, string symbol, BybitOrderSide side, BybitOrderType type, decimal quantity)
        : base(category, symbol, side, type, quantity)
    {
    }
}
