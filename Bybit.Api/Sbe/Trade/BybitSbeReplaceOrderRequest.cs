namespace Bybit.Api.Sbe;

/// <summary>
/// SBE replace order request.
/// </summary>
public record BybitSbeReplaceOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeReplaceOrderRequest"/> record.
    /// </summary>
    public BybitSbeReplaceOrderRequest(BybitSbeCategory category, long symbolId, BybitSbeDecimal64 quantity, BybitSbeDecimal64 price)
    {
        Category = category;
        SymbolId = symbolId;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// API request header.
    /// </summary>
    public BybitSbeApiRequestHeader Header { get; set; } = new();

    /// <summary>
    /// Product category.
    /// </summary>
    public BybitSbeCategory Category { get; set; }

    /// <summary>
    /// Internal numeric symbol ID.
    /// </summary>
    public long SymbolId { get; set; }

    /// <summary>
    /// Exchange-assigned order ID.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    public string? OrderLinkId { get; set; }

    /// <summary>
    /// New quantity.
    /// </summary>
    public BybitSbeDecimal64 Quantity { get; set; }

    /// <summary>
    /// New price.
    /// </summary>
    public BybitSbeDecimal64 Price { get; set; }
}
