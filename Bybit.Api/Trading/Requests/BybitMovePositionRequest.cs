namespace Bybit.Api.Trading;

/// <summary>
/// Bybit move position request
/// </summary>
public class BybitMovePositionRequest
{
    /// <summary>
    /// Product type. linear, spot, option
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Trade price
    /// linear: the price needs to be between [95% of mark price, 105% of mark price]
    /// spot&amp;option: the price needs to follow the price rule from Instruments Info
    /// </summary>
    [JsonProperty("price"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Price { get; set; }

    /// <summary>
    /// Trading side of fromUid
    /// For example, fromUid has a long position, when side=Sell, then once executed, the position of fromUid will be reduced or open a short position depending on qty input
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Executed qty
    /// The value must satisfy the qty rule from Instruments Info, in particular, category=linear is able to input maxOrderQty * 5
    /// </summary>
    [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }
}
