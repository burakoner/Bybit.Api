namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Asset Information
/// </summary>
public class BybitAsset
{
    /// <summary>
    /// Coin name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Remaining amount
    /// </summary>
    [JsonProperty("remainAmount")]
    public decimal? RemainingWithdrawableQuantity { get; set; }

    /// <summary>
    /// Chains
    /// </summary>
    [JsonProperty("chains")]
    public List<BybitAssetChain> Chains { get; set; } = [];
}

/// <summary>
/// Bybit Asset Network
/// </summary>
public class BybitAssetChain
{
    /// <summary>
    /// Chain type
    /// </summary>
    [JsonProperty("chainType")]
    public string ChainType { get; set; }

    /// <summary>
    /// The number of confirmation for deposit
    /// </summary>
    [JsonProperty("confirmation")]
    public int Confirmations { get; set; }

    /// <summary>
    /// withdraw fee. If withdraw fee is empty, It means that this coin does not support withdrawal
    /// </summary>
    [JsonProperty("withdrawFee")]
    public decimal WithdrawalFee { get; set; }

    /// <summary>
    /// Min. deposit
    /// </summary>
    [JsonProperty("depositMin")]
    public decimal MinimumDeposit { get; set; }

    /// <summary>
    /// Min. withdraw
    /// </summary>
    [JsonProperty("withdrawMin")]
    public decimal MinimumWithdrawal { get; set; }

    /// <summary>
    /// The precision of withdraw or deposit
    /// </summary>
    [JsonProperty("minAccuracy")]
    public decimal MinimumAccuracy { get; set; }

    /// <summary>
    /// The chain status of deposit. 0: suspend. 1: normal
    /// </summary>
    [JsonProperty("chainDeposit")]
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsDepositAllowed { get; set; }

    /// <summary>
    /// The chain status of withdraw. 0: suspend. 1: normal
    /// </summary>
    [JsonProperty("chainWithdraw")]
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsWithdrawalEnabled { get; set; }

    /// <summary>
    /// The withdraw fee percentage. It is a real figure, e.g., 0.022 means 2.2%
    /// </summary>
    [JsonProperty("withdrawPercentageFee")]
    public decimal WithdrawalPercentageFee { get; set; }

}
