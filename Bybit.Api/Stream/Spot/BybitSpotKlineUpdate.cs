namespace Bybit.Api.Stream.Spot;

public class BybitSpotKlineUpdate
{
    [JsonProperty("t")]
    public long OpenTimestamp { get; set; }
    public DateTime OpenTime { get => OpenTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("sn")]
    public string SymbolName { get; set; }

    [JsonProperty("o")]
    public decimal Open { get; set; }

    [JsonProperty("h")]
    public decimal High { get; set; }

    [JsonProperty("l")]
    public decimal Low{ get; set; }

    [JsonProperty("c")]
    public decimal Close { get; set; }

    [JsonProperty("v")]
    public decimal Volume { get; set; }
}
