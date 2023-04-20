namespace Bybit.Api.Models;

public class BybitReason
{
    [JsonProperty("reasonCode")]
    public string ReasonCode { get; set; }

    [JsonProperty("reasonMsg")]
    public string ReasonMessage { get; set; }
}