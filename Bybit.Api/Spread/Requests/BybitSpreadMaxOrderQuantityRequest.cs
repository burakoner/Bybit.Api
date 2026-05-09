namespace Bybit.Api.Spread;

/// <summary>
/// Spread maximum order quantity request.
/// </summary>
public record BybitSpreadMaxOrderQuantityRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="orderPrice">Order price.</param>
    public BybitSpreadMaxOrderQuantityRequest(string symbol, BybitSpreadMaxQuantitySide side, decimal orderPrice)
    {
        Symbol = symbol;
        Side = side;
        OrderPrice = orderPrice;
    }

    /// <summary>
    /// Spread symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order side.
    /// </summary>
    [JsonProperty("side")]
    public BybitSpreadMaxQuantitySide Side { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    [JsonProperty("orderPrice"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal OrderPrice { get; set; }
}
