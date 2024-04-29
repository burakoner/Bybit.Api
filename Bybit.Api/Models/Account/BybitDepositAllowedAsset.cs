namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Deposit Allowed Asset
/// </summary>
public class BybitDepositAllowedAsset
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Chain
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; }

    /// <summary>
    /// Coin Show Name
    /// </summary>
    [JsonProperty("coinShowName")]
    public string AssetName { get; set; }

    /// <summary>
    /// Chain Type
    /// </summary>
    [JsonProperty("chainType")]
    public string ChainType { get; set; }

    /// <summary>
    /// Deposit confirmation number
    /// </summary>
    public int BlockConfirmNumber { get; set; }

    /// <summary>
    /// Minimum deposit amount
    /// </summary>
    [JsonProperty("minDepositAmount")]
    public decimal MinimumDepositAmount { get; set; }
}
