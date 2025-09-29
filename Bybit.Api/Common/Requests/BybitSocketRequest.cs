namespace Bybit.Api.Common.Requests;

internal record BybitSocketRequest
{
    [JsonProperty("req_id")]
    public string RequestId { get; set; } = string.Empty;

    [JsonProperty("op")]
    public string Operation { get; set; } = string.Empty;

    [JsonProperty("args")]
    public object[] Parameters { get; set; } = [];

    public bool ValidateResponse(JToken responseData, ref bool forcedExit)
    {
        forcedExit = false;
        var operation = responseData["op"]?.ToString();
        var success = responseData["success"]?.Value<bool>() == true;
        var req_id = responseData["req_id"]?.ToString();

        if (operation != "subscribe")
        {
            forcedExit = true;
            return success;
        }

        if (req_id != RequestId)
        {
            forcedExit = true;
            return success;
        }

        return success;
    }

    public bool MatchReponse(JToken responseData)
    {
        var topic = responseData["topic"]?.ToString();
        return Parameters.Any(p => topic == p.ToString());
    }
}

internal enum BybitStreamOperation
{
    [Map("auth")]
    Auth,

    [Map("ping")]
    Ping,

    [Map("pong")]
    Pong,

    [Map("subscribe")]
    Subscribe,

    [Map("unsubscribe")]
    Unsubscribe,
}

/// <summary>
/// Bybit Stream Type
/// </summary>
public enum BybitStreamType
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("")]
    Unknown,

    /// <summary>
    /// Delta
    /// </summary>
    [Map("delta")]
    Delta,

    /// <summary>
    /// Snapshot
    /// </summary>
    [Map("snapshot")]
    Snapshot,
}