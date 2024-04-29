using Bybit.Api.Models.Market;

namespace Bybit.Api.Models.Socket;

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
    public List<BybitOrderbookRow> Asks { get; set; } = [];

    [JsonProperty("b")]
    public List<BybitOrderbookRow> Bids { get; set; } = [];
}