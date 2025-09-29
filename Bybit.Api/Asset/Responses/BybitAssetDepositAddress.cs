namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Deposit Address
/// </summary>
public class BybitAssetDepositAddress
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Chains
    /// </summary>
    [JsonProperty("chains")]
    public List<BybitAssetDepositAddressByChain> Chains { get; set; } = [];
}

/// <summary>
/// Bybit Deposit Address Item
/// </summary>
public class BybitAssetDepositAddressByChain
{
    /// <summary>
    /// Chain type
    /// </summary>
    [JsonProperty("chainType")]
    public string ChainType { get; set; } = "";

    /// <summary>
    /// The address for deposit
    /// </summary>
    [JsonProperty("addressDeposit")]
    public string Address { get; set; } = "";

    /// <summary>
    /// Tag of deposit
    /// </summary>
    [JsonProperty("tagDeposit")]
    public string Tag { get; set; } = "";

    /// <summary>
    /// Chain
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; } = "";

    /// <summary>
    /// The deposit limit for this coin in this chain. "-1" means no limit
    /// </summary>
    public decimal BatchReleaseLimit { get; set; }
}
