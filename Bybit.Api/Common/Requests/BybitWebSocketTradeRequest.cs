namespace Bybit.Api.Common.Requests;

internal record BybitWebSocketTradeRequest
{
    [JsonProperty("reqId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RequestId { get; set; }

    [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
    public BybitWebSocketTradeRequestHeader? Header { get; set; }

    [JsonProperty("op")]
    public string Operation { get; set; } = string.Empty;

    [JsonProperty("args")]
    public object[] Parameters { get; set; } = [];
}
