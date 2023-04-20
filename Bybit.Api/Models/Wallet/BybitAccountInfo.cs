namespace Bybit.Api.Models.Wallet;

public class BybitAccountInfo
{
    [JsonProperty("unifiedMarginStatus"), JsonConverter(typeof(LabelConverter<BybitUnifiedMarginAccount>))]
    public BybitUnifiedMarginAccount UnifiedMarginAccount { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitMarginMode>))]
    public BybitMarginMode MarginMode { get; set; }

    [JsonProperty("updatedTime")]
    public long UpdateTimestamp { get; set; }
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }
}
