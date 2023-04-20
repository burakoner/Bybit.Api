namespace Bybit.Api.Stream.Spot;

public class BybitSpotUserTradeUpdate : BybitSocketEvent
{
    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("q")]
    public decimal Quantity { get; set; }

    [JsonProperty("t"), JsonConverter(typeof(DateTimeConverter))]
    public long TradeTimestamp { get; set; }
    public DateTime TradeTime { get => TradeTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("p")]
    public decimal Price { get; set; }

    [JsonProperty("T")]
    public long TransactionId { get; set; }

    [JsonProperty("o")]
    public long OrderId { get; set; }

    [JsonProperty("c")]
    public string ClientOrderId { get; set; }

    [JsonProperty("O")]
    public long MatchOrderId { get; set; }

    [JsonProperty("a")]
    public long AccountId { get; set; }

    [JsonProperty("A")]
    public long MatchAccountId { get; set; }

    [JsonProperty("m")]
    public bool Maker { get; set; }

    [JsonProperty("S"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }
}
