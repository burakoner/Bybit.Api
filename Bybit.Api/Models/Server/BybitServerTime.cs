namespace Bybit.Api.Models.Server;

public class BybitServerTime
{
    [JsonProperty("timeSecond")]
    public long EpochSeconds { get; set; }

    [JsonProperty("timeNano")]
    public long NanoSeconds { get; set; }

    [JsonIgnore]
    public DateTime Time { get => EpochSeconds.ConvertFromSeconds(); }
}
