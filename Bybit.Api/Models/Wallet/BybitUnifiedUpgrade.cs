namespace Bybit.Api.Models.Wallet;

public class BybitUnifiedUpgrade
{
    public string UnifiedUpdateStatus { get; set; }

    [JsonProperty("unifiedUpdateMsg")]
    public BybitUnifiedUpgradeMessage UnifiedUpdateMessage { get; set; }

}

public class BybitUnifiedUpgradeMessage
{
    [JsonProperty("msg")]
    public IEnumerable<string> Messages { get; set; }
}
