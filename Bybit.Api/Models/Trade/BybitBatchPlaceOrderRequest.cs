namespace Bybit.Api.Models.Trade;

public class BybitBatchPlaceOrderRequest
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }
    
    [JsonProperty("orderType"), JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType Type { get; set; }

    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    [JsonProperty("price")]
    public decimal? Price { get; set; }

    [JsonProperty("orderIv")]
    public decimal? ImpliedVolatility { get; set; }

    [JsonProperty("timeInForce"), JsonConverter(typeof(LabelConverter<BybitOrderTimeInForce>))]
    public BybitOrderTimeInForce? TimeInForce { get; set; }

    [JsonProperty("orderLinkId")]
    public string OrderLinkId { get; set; }

    [JsonProperty("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonProperty("mmp")]
    public bool? MarketMakerProtection { get; set; }
}
