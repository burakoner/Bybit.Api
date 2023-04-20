namespace Bybit.Api.Stream.Spot;

public class BybitSpotOrderUpdate : BybitSocketEvent
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
    public long OrderId { get; set; }

    [JsonProperty("M")]
    public long MatchOrderId { get; set; }

    [JsonProperty("l")]
    public decimal LastFilledQuantity { get; set; }

    [JsonProperty("z")]
    public decimal TotalQuantityFilled { get; set; }

    [JsonProperty("L")]
    public decimal LastTradePrice { get; set; }

    [JsonProperty("n")]
    public decimal Fee { get; set; }

    [JsonProperty("N")]
    public string FeeAsset { get; set; }

    [JsonProperty("u")]
    public bool IsNormal { get; set; }

    [JsonProperty("w")]
    public bool IsWorking { get; set; }

    [JsonProperty("m")]
    public bool IsLimitMaker { get; set; }

    [JsonProperty("O")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("Z")]
    public decimal TotalValueFilled { get; set; }

    [JsonProperty("A")]
    public long MatchAccountId { get; set; }

    [JsonProperty("C")]
    public bool IsClosed { get; set; }

    [JsonProperty("v")]
    public decimal Leverage { get; set; }
}
