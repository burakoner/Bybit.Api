using Bybit.Api.Models.Market;

namespace Bybit.Api.Stream.Spot;

public class BybitOrderBookUpdate : BybitCategoryStream
{
    [JsonProperty("s")]
    public string Symbol { get; set; }

    [JsonProperty("u")]
    public long UpdateId { get; set; }

    [JsonProperty("seq")]
    public long CrossSequence { get; set; }

    [JsonProperty("a")]
    public IEnumerable<BybitOrderbookRow> Asks { get; set; } = Array.Empty<BybitOrderbookRow>();

    [JsonProperty("b")]
    public IEnumerable<BybitOrderbookRow> Bids { get; set; } = Array.Empty<BybitOrderbookRow>();
}