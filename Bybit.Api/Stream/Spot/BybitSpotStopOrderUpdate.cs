namespace Bybit.Api.Stream.Spot;

public class BybitSpotStopOrderUpdate : BybitSocketEvent
{
    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("c")]
    public string ClientOrderId { get; set; }

    [JsonProperty("S"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    [JsonProperty("o"), JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType Type { get; set; }

    [JsonProperty("f"), JsonConverter(typeof(LabelConverter<BybitTimeInForce>))]
    public BybitTimeInForce TimeInForce { get; set; }

    [JsonProperty("q")]
    public decimal Quantity { get; set; }

    [JsonProperty("p")]
    public decimal Price { get; set; }

    [JsonProperty("X"), JsonConverter(typeof(LabelConverter<BybitOrderStatus>))]
    public BybitOrderStatus Status { get; set; }

    [JsonProperty("i")]
    public string OrderId { get; set; }

    [JsonProperty("T")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("t")]
    public long? TriggeredTimestamp { get; set; }
    public DateTime? TriggeredTime { get => TriggeredTimestamp?.ConvertFromMilliseconds(); }

    [JsonConverter(typeof(DateTimeConverter))]
    [JsonProperty("C")]
    public long? UpdateTimestamp { get; set; }
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("qp")]
    public string MarketPrice { get; set; } = string.Empty;
    
    [JsonProperty("eo")]
    public string NewOrderId { get; set; } = string.Empty;
}
