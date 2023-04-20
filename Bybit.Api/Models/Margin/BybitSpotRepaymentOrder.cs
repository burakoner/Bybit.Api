namespace Bybit.Api.Models.Margin;

public class BybitSpotRepaymentOrder
{
    [JsonProperty("repayId")]
    public string RepaymentId { get; set; }
    public string AccountId { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    public decimal RepaidAmount { get; set; }

    [JsonProperty("repayMarginOrderId")]
    public string RepaymentMarginOrderId { get; set; }

    [JsonProperty("repayTime")]
    public long RepaymentTimestamp { get; set; }
    public DateTime RepaymentTime { get => RepaymentTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("transactIds")]
    public IEnumerable<BybitSpotRepaymentTransaction> Transactions { get; set; }
}

public class BybitSpotRepaymentTransaction
{
    [JsonProperty("transactId")]
    public string TransactionId { get; set; }

    [JsonProperty("repaidInterest")]
    public decimal RepaidInterest { get; set; }

    [JsonProperty("repaidPrincipal")]
    public decimal RepaidPrincipal { get; set; }

    /// <summary>
    /// RepaidSerialNumber: Repayment No. (Borrowing Order)
    /// </summary>
    [JsonProperty("repaidSerialNumber")]
    public string RepaymentNo { get; set; }
}