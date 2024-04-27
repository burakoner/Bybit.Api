namespace Bybit.Api.Models.Socket;

public class BybitTradeStream
{
    [JsonProperty("i")]
    public string Id { get; set; }

    [JsonProperty("T")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("S"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    [JsonProperty("p")]
    public decimal Price { get; set; }

    [JsonProperty("v")]
    public decimal Quantity { get; set; }

    [JsonProperty("L"), JsonConverter(typeof(LabelConverter<BybitTickDirection>))]
    public BybitTickDirection? Direction { get; set; }

    [JsonProperty("BT")]
    public bool BlockTrade { get; set; }
}
