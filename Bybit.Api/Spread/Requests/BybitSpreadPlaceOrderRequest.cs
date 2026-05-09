namespace Bybit.Api.Spread;

/// <summary>
/// Spread place order request.
/// </summary>
public record BybitSpreadPlaceOrderRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="orderType">Order type.</param>
    /// <param name="quantity">Order quantity.</param>
    public BybitSpreadPlaceOrderRequest(string symbol, BybitOrderSide side, BybitOrderType orderType, decimal quantity)
    {
        Symbol = symbol;
        Side = side;
        OrderType = orderType;
        Quantity = quantity;
    }

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order side.
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    [JsonProperty("orderType")]
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Price { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Time in force.
    /// </summary>
    [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTimeInForce? TimeInForce { get; set; }
}
