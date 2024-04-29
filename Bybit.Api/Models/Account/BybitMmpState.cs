namespace Bybit.Api.Models.Account;

public class BybitMmpState
{
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; }

    public bool MmpEnabled { get; set; }
    public int Window { get; set; }
    public int FrozenPeriod { get; set; }

    [JsonProperty("qtyLimit")]
    public decimal QuantityLimit { get; set; }

    [JsonProperty("qtyLimit")]
    public decimal DeltaLimit { get; set; }

    public bool MmpFrozen { get; set; }

    [JsonProperty("mmpFrozenUntil")]
    public long MmpFrozenUntilTimestamp { get; set; }
    public DateTime MmpFrozenUntilTime { get => MmpFrozenUntilTimestamp.ConvertFromMilliseconds(); }
}
