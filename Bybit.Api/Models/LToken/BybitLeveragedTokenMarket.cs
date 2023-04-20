namespace Bybit.Api.Models.LToken;

public class BybitLeveragedTokenMarket
{
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    [JsonProperty("nav")]
    public decimal NetValue { get; set; }

    [JsonProperty("navTime")]
    public long NetValueTimestamp { get; set; }
    public DateTime NetValueTime { get => NetValueTimestamp.ConvertFromMilliseconds(); }

    public decimal Circulation { get; set; }
    public decimal Basket { get; set; }
    public decimal Leverage { get; set; }
}