namespace Bybit.Api.Models;

/// <summary>
/// Bybit Reason
/// </summary>
public class BybitReason
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