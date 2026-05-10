namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit WebSocket order entry response.
/// </summary>
/// <typeparam name="T">Response data type.</typeparam>
public record BybitWebSocketTradeResponse<T>
{
    /// <summary>
    /// Request ID.
    /// </summary>
    [JsonProperty("reqId")]
    public string RequestId { get; set; } = string.Empty;

    /// <summary>
    /// Return code.
    /// </summary>
    [JsonProperty("retCode")]
    public int ReturnCode { get; set; }

    /// <summary>
    /// Return message.
    /// </summary>
    [JsonProperty("retMsg")]
    public string ReturnMessage { get; set; } = string.Empty;

    /// <summary>
    /// Operation.
    /// </summary>
    [JsonProperty("op")]
    public string Operation { get; set; } = string.Empty;

    /// <summary>
    /// Response data.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Return extra information. Batch order entry returns per-item errors here.
    /// </summary>
    [JsonProperty("retExtInfo")]
    public JToken? ReturnExtraInfo { get; set; }

    /// <summary>
    /// Rate-limit and trace headers.
    /// </summary>
    public BybitWebSocketTradeHeader Header { get; set; } = new();

    /// <summary>
    /// Connection ID.
    /// </summary>
    [JsonProperty("connId")]
    public string ConnectionId { get; set; } = string.Empty;
}

/// <summary>
/// Bybit WebSocket order entry list response data.
/// </summary>
/// <typeparam name="T">List item type.</typeparam>
public record BybitWebSocketTradeList<T>
{
    /// <summary>
    /// Response list.
    /// </summary>
    public List<T> List { get; set; } = [];
}

/// <summary>
/// Bybit WebSocket order entry response header.
/// </summary>
public record BybitWebSocketTradeHeader
{
    /// <summary>
    /// Server timestamp.
    /// </summary>
    [JsonProperty("Timenow")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Server time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Rate limit.
    /// </summary>
    [JsonProperty("X-Bapi-Limit")]
    public int Limit { get; set; }

    /// <summary>
    /// Remaining rate limit.
    /// </summary>
    [JsonProperty("X-Bapi-Limit-Status")]
    public int LimitStatus { get; set; }

    /// <summary>
    /// Rate-limit reset timestamp.
    /// </summary>
    [JsonProperty("X-Bapi-Limit-Reset-Timestamp")]
    public long LimitResetTimestamp { get; set; }

    /// <summary>
    /// Rate-limit reset time.
    /// </summary>
    [JsonIgnore]
    public DateTime LimitResetTime { get => LimitResetTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Trace ID.
    /// </summary>
    [JsonProperty("Traceid")]
    public string TraceId { get; set; } = string.Empty;
}
