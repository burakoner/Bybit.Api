namespace Bybit.Api.Models.Tokens;

/// <summary>
/// Bybit Leverage Token Information
/// </summary>
public class BybitLeverageTokenInformation
{
    /// <summary>
    /// Abbreviation
    /// </summary>
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    /// <summary>
    /// Full name of leveraged token
    /// </summary>
    [JsonProperty("ltName")]
    public string Name { get; set; }

    /// <summary>
    /// Single maximum purchase amount
    /// </summary>
    [JsonProperty("maxPurchase")]
    public decimal MaximumPurchase { get; set; }

    /// <summary>
    /// Single minimum purchase amount
    /// </summary>
    [JsonProperty("minPurchase")]
    public decimal MinimumPurchase { get; set; }

    /// <summary>
    /// Maximum purchase amount in a single day
    /// </summary>
    [JsonProperty("maxPurchaseDaily")]
    public decimal MaximumPurchaseDaily { get; set; }
    
    /// <summary>
    /// Single Maximum redemption quantity
    /// </summary>
    [JsonProperty("maxRedeem")]
    public decimal MaximumRedeem { get; set; }

    /// <summary>
    /// Single Minimum redemption quantity
    /// </summary>
    [JsonProperty("minRedeem")]
    public decimal MinimumRedeem { get; set; }

    /// <summary>
    /// Maximum redemption quantity in a single day
    /// </summary>
    [JsonProperty("maxRedeemDaily")]
    public decimal MaximumRedeemDaily { get; set; }

    /// <summary>
    /// Purchase fee rate
    /// </summary>
    public decimal PurchaseFeeRate { get; set; }

    /// <summary>
    /// Redeem fee rate
    /// </summary>
    public decimal RedeemFeeRate { get; set; }

    /// <summary>
    /// Whether the leverage token can be purchased or redeemed
    /// </summary>
    [JsonProperty("ltStatus")]
    public BybitLeverageTokenStatus Status { get; set; }

    /// <summary>
    /// Funding fee charged daily for users holding leveraged token
    /// </summary>
    public decimal FundFee { get; set; }

    /// <summary>
    /// The time to charge funding fee
    /// </summary>
    [JsonProperty("fundFeeTime")]
    public long FundFeeTimestamp { get; set; }

    /// <summary>
    /// The time to charge funding fee
    /// </summary>
    public DateTime FundFeeTime { get => FundFeeTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Management fee rate
    /// </summary>
    public decimal ManageFeeRate { get; set; }

    /// <summary>
    /// The time to charge management fee
    /// </summary>
    [JsonProperty("manageFeeTime")]
    public long ManageFeeTimestamp { get; set; }

    /// <summary>
    /// The time to charge management fee
    /// </summary>
    public DateTime ManageFeeTime { get => ManageFeeTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Nominal asset value
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Net value
    /// </summary>
    public decimal NetValue { get; set; }

    /// <summary>
    /// Total purchase upper limit
    /// </summary>
    public decimal Total { get; set; }
}