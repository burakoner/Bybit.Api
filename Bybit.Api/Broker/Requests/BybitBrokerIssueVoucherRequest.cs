namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker issue voucher request.
/// </summary>
public record BybitBrokerIssueVoucherRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBrokerIssueVoucherRequest"/> record.
    /// </summary>
    /// <param name="accountId">User ID.</param>
    /// <param name="awardId">Voucher ID.</param>
    /// <param name="specCode">Customized unique spec code.</param>
    /// <param name="amount">Issue amount.</param>
    /// <param name="brokerId">Broker ID.</param>
    public BybitBrokerIssueVoucherRequest(string accountId, string awardId, string specCode, decimal amount, string brokerId)
    {
        AccountId = accountId;
        AwardId = awardId;
        SpecCode = specCode;
        Amount = amount;
        BrokerId = brokerId;
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
    /// Customized unique spec code.
    /// </summary>
    [JsonProperty("specCode")]
    public string SpecCode { get; set; }

    /// <summary>
    /// Issue amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }

    /// <summary>
    /// Broker ID.
    /// </summary>
    [JsonProperty("brokerId")]
    public string BrokerId { get; set; }
}
