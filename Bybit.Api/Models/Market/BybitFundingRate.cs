namespace Bybit.Api.Models.Market;

public class BybitFundingRate
{
    public string Symbol { get; set; }
    public decimal FundingRate { get; set; }
    [JsonProperty("fundingRateTimestamp")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}