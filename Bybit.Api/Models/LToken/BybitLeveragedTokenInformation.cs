namespace Bybit.Api.Models.LToken;

public class BybitLeveragedTokenInformation
{
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    [JsonProperty("ltName")]
    public string Name { get; set; }

    [JsonProperty("minPurchase")]
    public decimal MinimumPurchase { get; set; }

    [JsonProperty("maxPurchase")]
    public decimal MaximumPurchase { get; set; }

    [JsonProperty("maxPurchaseDaily")]
    public decimal MaximumPurchaseDaily { get; set; }

    [JsonProperty("minRedeem")]
    public decimal MinimumRedeem { get; set; }

    [JsonProperty("maxRedeem")]
    public decimal MaximumRedeem { get; set; }

    [JsonProperty("maxRedeemDaily")]
    public decimal MaximumRedeemDaily { get; set; }

    public decimal PurchaseFeeRate { get; set; }
    public decimal RedeemFeeRate { get; set; }

    public decimal FundFee { get; set; }
    [JsonProperty("fundFeeTime")]
    public long FundFeeTimestamp { get; set; }
    public DateTime FundFeeTime { get => FundFeeTimestamp.ConvertFromMilliseconds(); }

    public decimal ManageFeeRate { get; set; }
    [JsonProperty("manageFeeTime")]
    public long ManageFeeTimestamp { get; set; }
    public DateTime ManageFeeTime { get => ManageFeeTimestamp.ConvertFromMilliseconds(); }

    public decimal Value { get; set; }
    public decimal NetValue { get; set; }
    public decimal Total { get; set; }
}