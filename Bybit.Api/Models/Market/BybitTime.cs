namespace Bybit.Api.Models.Market;

public class BybitTime
{
    [JsonProperty("timeSecond")]
    public long EpochSeconds { get; set; }

    [JsonProperty("timeNano")]
    public long NanoSeconds { get; set; }

    [JsonIgnore]
    public DateTime Time { get => EpochSeconds.ConvertFromSeconds(); }
}
