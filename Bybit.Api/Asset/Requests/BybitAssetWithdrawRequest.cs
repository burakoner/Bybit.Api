namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal request.
/// </summary>
public record BybitAssetWithdrawRequest
{
    /// <summary>
    /// Initializes a new withdrawal request.
    /// </summary>
    /// <param name="asset">Coin name, uppercase only.</param>
    /// <param name="quantity">Withdrawal amount.</param>
    /// <param name="address">Withdrawal wallet address or Bybit UID when using UID withdrawal.</param>
    public BybitAssetWithdrawRequest(string asset, decimal quantity, string address)
    {
        Asset = asset;
        Quantity = quantity;
        Address = address;
    }

    /// <summary>
    /// Coin name, uppercase only.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Withdrawal amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Withdrawal wallet address, or Bybit UID when force chain is set to UID withdrawal.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// Address tag or memo.
    /// </summary>
    [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
    public string? Tag { get; set; }

    /// <summary>
    /// Chain name.
    /// </summary>
    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public string? Chain { get; set; }

    /// <summary>
    /// On-chain withdrawal mode. 0 allows internal transfer, 1 forces on-chain, 2 uses UID withdrawal.
    /// </summary>
    [JsonProperty("forceChain", NullValueHandling = NullValueHandling.Ignore)]
    public int? ForceChain { get; set; }

    /// <summary>
    /// Wallet to withdraw from.
    /// </summary>
    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitAssetWithdrawAccountType? AccountType { get; set; }

    /// <summary>
    /// Handling fee option.
    /// </summary>
    [JsonProperty("feeType", NullValueHandling = NullValueHandling.Ignore)]
    public int? FeeType { get; set; }

    /// <summary>
    /// Custom request ID for idempotency.
    /// </summary>
    [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RequestId { get; set; }

    /// <summary>
    /// Purpose of the withdrawal transaction where required by regional rules.
    /// </summary>
    [JsonProperty("transactionPurpose", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionPurpose { get; set; }

    /// <summary>
    /// Travel rule beneficiary information.
    /// </summary>
    [JsonProperty("beneficiary", NullValueHandling = NullValueHandling.Ignore)]
    public BybitAssetWithdrawalBeneficiary? Beneficiary { get; set; }
}
