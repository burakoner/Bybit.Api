namespace Bybit.Api.Models.Market;

public class BybitHistoricalVolatility
{
    [JsonConverter(typeof(LabelConverter<BybitPeriod>))]
    public BybitPeriod Period { get; set; }
    public decimal Value { get; set; }
    [JsonProperty("time")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}