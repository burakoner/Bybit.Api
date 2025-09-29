namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Deposit Allowed Asset
/// </summary>
public class BybitAssetDepositAllow
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Chain
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; } = string.Empty;

    /// <summary>
    /// Coin Show Name
    /// </summary>
    [JsonProperty("coinShowName")]
    public string AssetName { get; set; } = string.Empty;

    /// <summary>
    /// Chain Type
    /// </summary>
    [JsonProperty("chainType")]
    public string ChainType { get; set; } = string.Empty;

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
