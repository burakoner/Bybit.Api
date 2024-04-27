namespace Bybit.Api.Models.Trade;

public class BybitOrderResponse
{
    public string OrderId { get; set; }
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}
