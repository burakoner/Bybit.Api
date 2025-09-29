namespace Bybit.Api.Account;

/// <summary>
/// Bybit Unified Account Upgrade Response
/// </summary>
public class BybitAccountUpgrade
{
    /// <summary>
    /// Status of the unified account upgrade
    /// </summary>
    public string UnifiedUpdateStatus { get; set; } = string.Empty;

    /// <summary>
    /// Unified account upgrade messages
    /// </summary>
    [JsonProperty("unifiedUpdateMsg")]
    public BybitAccountUpgradeMessage UnifiedUpdateMessage { get; set; } = default!;

}

/// <summary>
/// Bybit Unified Account Upgrade Message
/// </summary>
public class BybitAccountUpgradeMessage
{
    /// <summary>
    /// Messages
    /// </summary>
    [JsonProperty("msg")]
    public List<string> Messages { get; set; } = [];
}
