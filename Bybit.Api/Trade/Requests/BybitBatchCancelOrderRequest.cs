namespace Bybit.Api.Trade;

/// <summary>
/// Batch cancel order request model.
/// </summary>
public class BybitBatchCancelOrderRequest
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;
}
