namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal request.
/// </summary>
public record BybitAssetWithdrawRequest
{
    public BybitAssetWithdrawRequest(string asset, decimal quantity, string address)
    {
        Asset = asset;
        Quantity = quantity;
        Address = address;
    }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
    public string? Tag { get; set; }

    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public string? Chain { get; set; }

    [JsonProperty("forceChain", NullValueHandling = NullValueHandling.Ignore)]
    public int? ForceChain { get; set; }

    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitAssetWithdrawAccountType? AccountType { get; set; }

    [JsonProperty("feeType", NullValueHandling = NullValueHandling.Ignore)]
    public int? FeeType { get; set; }

    [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RequestId { get; set; }

    [JsonProperty("transactionPurpose", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionPurpose { get; set; }

    [JsonProperty("beneficiary", NullValueHandling = NullValueHandling.Ignore)]
    public BybitAssetWithdrawalBeneficiary? Beneficiary { get; set; }
}
