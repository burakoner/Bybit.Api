namespace Bybit.Api.Stream.Spot;

public class BybitSpotTickerUpdate
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    [JsonProperty("price24hPcnt")]
    public decimal ChangePercentage { get; set; }

    [JsonProperty("volume24h")]
    public decimal Volume { get; set; }

    [JsonProperty("turnover24h")]
    public decimal Turnover { get; set; }

    [JsonProperty("usdIndexPrice")]
    public decimal UsdIndexPrice { get; set; }

    [JsonProperty("lastPrice")]
    public decimal Last { get; set; }

    [JsonProperty("highPrice24h")]
    public decimal High { get; set; }

    [JsonProperty("lowPrice24h")]
    public decimal Low { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal Open { get; set; }
}
