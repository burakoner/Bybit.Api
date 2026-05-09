namespace Bybit.Api.Spread;

/// <summary>
/// Spread amend order request.
/// </summary>
public record BybitSpreadAmendOrderRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    public BybitSpreadAmendOrderRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Spread combination order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Amended order quantity.
    /// </summary>
    [JsonProperty("qty", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Amended order price.
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Price { get; set; }
}
