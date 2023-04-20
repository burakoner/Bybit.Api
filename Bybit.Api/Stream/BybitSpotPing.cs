namespace Bybit.Api.Stream;

internal class BybitSpotPing
{
    [JsonProperty("ping")]
    public long Ping { get; set; }
}
