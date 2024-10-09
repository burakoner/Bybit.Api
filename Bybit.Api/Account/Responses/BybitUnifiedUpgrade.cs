namespace Bybit.Api.Account;

/// <summary>
/// Bybit Unified Account Upgrade Response
/// </summary>
public class BybitUnifiedUpgrade
{
    /// <summary>
    /// Status of the unified account upgrade
    /// </summary>
    public string UnifiedUpdateStatus { get; set; }

    /// <summary>
    /// Unified account upgrade messages
    /// </summary>
    [JsonProperty("unifiedUpdateMsg")]
    public BybitUnifiedUpgradeMessage UnifiedUpdateMessage { get; set; }

}

/// <summary>
/// Bybit Unified Account Upgrade Message
/// </summary>
public class BybitUnifiedUpgradeMessage
{
    /// <summary>
    /// Messages
    /// </summary>
    [JsonProperty("msg")]
    public List<string> Messages { get; set; } = [];
}
