namespace Bybit.Api.Models.Wallet;

public class BybitWithdrawal
{
    [JsonProperty("withdrawId")]
    public string Id { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("chain")]
    public string Network { get; set; }

    [JsonProperty("amount")]
    public decimal Quantity { get; set; }
    
    [JsonProperty("txID")]
    public string TransactionId { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitWithdrawalStatus>))]
    public BybitWithdrawalStatus Status { get; set; }

    [JsonProperty("toAddress")]
    public string Address { get; set; }
    public string Tag { get; set; }
    public decimal? WithdrawFee { get; set; }

    [JsonProperty("withdrawType")]
    [JsonConverter(typeof(LabelConverter<BybitWithdrawalType>))]
    public BybitWithdrawalType Type { get; set; }

    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

}