namespace Bybit.Api.Models.Socket;

internal class BybitSocketRequest
{
    [JsonProperty("req_id")]
    public string RequestId { get; set; }

    [JsonProperty("op")]
    public string Operation { get; set; }

    [JsonProperty("args")]
    public object[] Parameters { get; set; } = Array.Empty<object>();

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
    [Label("auth")]
    Auth,

    [Label("ping")]
    Ping,

    [Label("pong")]
    Pong,

    [Label("subscribe")]
    Subscribe,

    [Label("unsubscribe")]
    Unsubscribe,
}

public enum BybitStreamType
{
    [Label("")]
    Unknown,

    [Label("delta")]
    Delta,

    [Label("snapshot")]
    Snapshot,
}