namespace Bybit.Api.Models.Wallet;

public class BybitDepositAddress
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chains")]
    public IEnumerable<BybitNetworkDepositAddress> Networks { get; set; } = Array.Empty<BybitNetworkDepositAddress>();
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
