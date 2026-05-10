namespace Bybit.Api.Common.Requests;

internal record BybitWebSocketTradeRequestHeader
{
    [JsonProperty("X-BAPI-TIMESTAMP")]
    public long Timestamp { get; set; }

    [JsonProperty("X-BAPI-RECV-WINDOW")]
    public long ReceiveWindow { get; set; }

    [JsonProperty("Referer", NullValueHandling = NullValueHandling.Ignore)]
    public string? Referer { get; set; }
}
