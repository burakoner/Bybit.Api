namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ leg request.
/// </summary>
public record BybitRfqLegRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Instrument symbol.</param>
    /// <param name="side">Inquiry transaction direction.</param>
    /// <param name="quantity">Order quantity.</param>
    public BybitRfqLegRequest(BybitCategory category, string symbol, BybitOrderSide side, decimal quantity)
    {
        Category = category;
        Symbol = symbol;
        Side = side;
        Quantity = quantity;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Instrument symbol.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Inquiry transaction direction.
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }
}
