namespace Bybit.Api.Account;

/// <summary>
/// Bybit Reason
/// </summary>
public class BybitAccountReason
{
    /// <summary>
    /// Reason Code
    /// </summary>
    [JsonProperty("reasonCode")]
    public string ReasonCode { get; set; }

    /// <summary>
    /// Reason Message
    /// </summary>
    [JsonProperty("reasonMsg")]
    public string ReasonMessage { get; set; }
}