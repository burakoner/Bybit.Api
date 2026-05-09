namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ quote leg request.
/// </summary>
public record BybitRfqQuoteLegRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Instrument symbol.</param>
    /// <param name="price">Quote price.</param>
    public BybitRfqQuoteLegRequest(BybitCategory category, string symbol, decimal price)
    {
        Category = category;
        Symbol = symbol;
        Price = price;
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
    /// Quote price.
    /// </summary>
    [JsonProperty("price"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Price { get; set; }
}
