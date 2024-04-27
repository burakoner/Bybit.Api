namespace Bybit.Api.Models.Trade;

public class BybitBatchCancelOrderResponse
{
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}