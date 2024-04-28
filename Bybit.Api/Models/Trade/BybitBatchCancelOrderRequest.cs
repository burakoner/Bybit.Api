namespace Bybit.Api.Models.Trade;

/// <summary>
/// Batch cancel order request model.
/// </summary>
public class BybitBatchCancelOrderRequest
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// User customised order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}
