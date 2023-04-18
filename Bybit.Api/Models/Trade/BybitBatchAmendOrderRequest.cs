namespace Bybit.Api.Models.Trade;

public class BybitBatchAmendOrderRequest
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string OrderLinkId { get; set; }

    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    [JsonProperty("price")]
    public decimal? Price { get; set; }

    [JsonProperty("orderIv")]
    public decimal? ImpliedVolatility { get; set; }
}
