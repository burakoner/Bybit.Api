namespace Bybit.Api.Models.Account;

public class BybitAssetInformation
{
    public string Name { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("remain_amount")]
    public decimal? RemainingWithdrawableQuantity { get; set; }

    [JsonProperty("chains")]
    public List<BybitAssetNetwork> Networks { get; set; } = [];
}

public class BybitAssetNetwork
{
    [JsonProperty("chainType")]
    public string NetworkType { get; set; }

    [JsonProperty("confirmation")]
    public int ConfirmationsNeeded { get; set; }

    [JsonProperty("withdrawFee")]
    public decimal WithdrawFee { get; set; }

    [JsonProperty("depositMin")]
    public decimal MinimalDeposit { get; set; }

    [JsonProperty("withdrawMin")]
    public decimal MinimalWithdrawal { get; set; }

    [JsonProperty("chain")]
    public string Network { get; set; }

    [JsonProperty("chainDeposit")]
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsDepositAllowed { get; set; }

    [JsonProperty("chainWithdraw")]
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsWithdrawalEnabled { get; set; }

    [JsonProperty("minAccuracy")]
    public decimal MinimumAccuracy { get; set; }

    [JsonProperty("withdrawPercentageFee")]
    public decimal WithdrawalPercentageFee { get; set; }

}
