namespace Bybit.Api.Models.Account;

public class BybitDepositAddress
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chains")]
    public List<BybitNetworkDepositAddress> Networks { get; set; } = [];
}

public class BybitDepositAddressSingle
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chains")]
    public BybitNetworkDepositAddress Network { get; set; }
}

public class BybitNetworkDepositAddress
{
    [JsonProperty("chainType")]
    public string NetworkType { get; set; }

    [JsonProperty("addressDeposit")]
    public string Address { get; set; }

    [JsonProperty("tagDeposit")]
    public string Tag { get; set; }

    [JsonProperty("chain")]
    public string Network { get; set; }
}
