namespace Bybit.Api.Models.Market;

public class BybitTrade
{
    public string Symbol { get; set; }

    [JsonProperty("execId")]
    public long ExecutionId { get; set; }

    public decimal Price { get; set; }
    public decimal Size { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    [JsonProperty("time")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    public bool IsBlockTrade { get; set; }
}
