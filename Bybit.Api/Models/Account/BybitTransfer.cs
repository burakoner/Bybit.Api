namespace Bybit.Api.Models.Account;

public class BybitTransfer
{
    public string TransferId { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    [JsonProperty("fromAccountType"), JsonConverter(typeof(LabelConverter<BybitAccount>))]
    public BybitAccount FromAccount { get; set; }

    [JsonProperty("toAccountType"), JsonConverter(typeof(LabelConverter<BybitAccount>))]
    public BybitAccount ToAccount { get; set; }

    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("status"), JsonConverter(typeof(LabelConverter<BybitTransferStatus>))]
    public BybitTransferStatus Status { get; set; }

    [JsonProperty("coin")]
    public long? FromUserId { get; set; }

    [JsonProperty("coin")]
    public long? ToUserId { get; set; }
}
