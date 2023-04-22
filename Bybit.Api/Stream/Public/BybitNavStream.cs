namespace Bybit.Api.Helpers.Public;

public class BybitNavStream
{
    [JsonProperty("time")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("nav")]
    public decimal NetAssetValue { get; set; }

    public decimal Basket { get; set; }
    public decimal BasketLoan { get; set; }
    public decimal BasketPosition { get; set; }
    public decimal Circulation { get; set; }
    public decimal Leverage { get; set; }
}