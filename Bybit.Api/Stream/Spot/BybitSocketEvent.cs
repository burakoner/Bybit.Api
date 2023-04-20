namespace Bybit.Api.Stream.Spot;

public abstract class BybitSocketEvent
{
    [JsonProperty("e")]
    public string Event { get; set; }

    [JsonProperty("E")]
    public long Timestamp { get; set; }
    public DateTime Time{ get => Timestamp.ConvertFromMilliseconds(); }
}
