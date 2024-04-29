namespace Bybit.Api.Models.Account;

public class BybitDepositAllowedAsset
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chain")]
    public string Network { get; set; }

    [JsonProperty("coinShowName")]
    public string AssetShowName { get; set; }

    [JsonProperty("chainType")]
    public string NetworkType { get; set; }

    public int BlockConfirmNumber { get; set; }
    public decimal MinDepositAmount { get; set; }
}
