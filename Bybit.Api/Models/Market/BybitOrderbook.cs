namespace Bybit.Api.Models.Market;

public class BybitOrderbook
{
    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("a")]
    public IEnumerable<BybitOrderbookRow> Asks { get; set; }

    [JsonProperty("b")]
    public IEnumerable<BybitOrderbookRow> Bids { get; set; }

    [JsonProperty("ts")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("u")]
    public long UpdateId { get; set; }
}

[JsonConverter(typeof(ArrayConverter))]
public class BybitOrderbookRow
{
    [ArrayProperty(0)]
    public decimal Price { get; set; }

    [ArrayProperty(1)]
    public decimal Size { get; set; }
}
