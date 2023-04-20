namespace Bybit.Api.Stream.Spot;

public class BybitSpotLeverageUpdate
{
    [JsonProperty("t")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("nav")]
    public decimal NetAssetValue { get; set; }

    [JsonProperty("b")]
    public decimal BasketValue { get; set; }

    [JsonProperty("l")]
    public decimal RealLeverage { get; set; }

    [JsonProperty("loan")]
    public decimal BasketLoan { get; set; }

    [JsonProperty("ti")]
    public decimal CirculatingSupply { get; set; }

    [JsonProperty("n")]
    public decimal TotalPositionValue { get; set; }
}