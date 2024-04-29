namespace Bybit.Api.Models.Account;

public class BybitOnchainDeposit
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chain")]
    public string Network { get; set; }

    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    [JsonProperty("txID")]
    public string TransactionId { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOnchainDepositStatus>))]
    public BybitOnchainDepositStatus Status { get; set; }

    public string Tag { get; set; }
    public decimal? DepositFee { get; set; }
    public string ToAddress { get; set; }

    [JsonProperty("successAt")]
    public long? SuccessTimestamp { get; set; }
    public DateTime? SuccessTime { get => SuccessTimestamp?.ConvertFromMilliseconds(); }

    public int Confirmations { get; set; }

    [JsonProperty("txIndex")]
    public string TransactionIndex { get; set; }
    public string BlockHash { get; set; }
}
