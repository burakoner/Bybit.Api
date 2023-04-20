namespace Bybit.Api.Models.Wallet;

public class BybitInternalDeposit
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }
    
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitInternalDepositStatus>))]
    public BybitInternalDepositStatus Status { get; set; }

    public string Address { get; set; }

    [JsonProperty("createdTime")]
    public long? CreatedTimestamp { get; set; }
    public DateTime? CreatedTime { get => CreatedTimestamp?.ConvertFromMilliseconds(); }
}
