namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker issued voucher request.
/// </summary>
public record BybitBrokerIssuedVoucherRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBrokerIssuedVoucherRequest"/> record.
    /// </summary>
    /// <param name="accountId">User ID.</param>
    /// <param name="awardId">Voucher ID.</param>
    /// <param name="specCode">Spec code.</param>
    public BybitBrokerIssuedVoucherRequest(string accountId, string awardId, string specCode)
    {
        AccountId = accountId;
        AwardId = awardId;
        SpecCode = specCode;
    }

    /// <summary>
    /// User ID.
    /// </summary>
    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    /// <summary>
    /// Voucher ID.
    /// </summary>
    [JsonProperty("awardId")]
    public string AwardId { get; set; }

    /// <summary>
    /// Spec code.
    /// </summary>
    [JsonProperty("specCode")]
    public string SpecCode { get; set; }

    /// <summary>
    /// Whether to return the amount used by the user.
    /// </summary>
    [JsonProperty("withUsedAmount", NullValueHandling = NullValueHandling.Ignore)]
    public bool? WithUsedAmount { get; set; }
}
