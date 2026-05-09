namespace Bybit.Api.Trading;

/// <summary>
/// Cancel order request.
/// </summary>
public record BybitCancelOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCancelOrderRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    public BybitCancelOrderRequest(BybitCategory category, string symbol)
    {
        Category = category;
        Symbol = symbol;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Order ID. Either order ID or client order ID is required.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// User customised order ID. Either order ID or client order ID is required.
    /// </summary>
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Spot order filter.
    /// </summary>
    public BybitOrderFilter? OrderFilter { get; set; }
}
