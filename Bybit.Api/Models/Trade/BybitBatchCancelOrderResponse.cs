namespace Bybit.Api.Models.Trade;

/// <summary>
/// Batch cancel order response
/// </summary>
public class BybitBatchCancelOrderResponse
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// User customised order ID
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}