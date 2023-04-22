using Bybit.Api.Models.Market;

namespace Bybit.Api.Helpers.Public;

public class BybitOrderBookUpdate
{
    [JsonIgnore]
    public BybitStreamType StreamType { get; set; }

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