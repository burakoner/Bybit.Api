using Bybit.Api.Market;

namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit Order Book Update
/// </summary>
public class BybitOrderBookUpdate
{
    /// <summary>
    /// Stream Type
    /// </summary>
    [JsonIgnore]
    public BybitStreamType StreamType { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; }

    /// <summary>
    /// Update Id
    /// </summary>
    [JsonProperty("u")]
    public long UpdateId { get; set; }

    /// <summary>
    /// Sequence
    /// </summary>
    [JsonProperty("seq")]
    public long Sequence { get; set; }

    /// <summary>
    /// Asks
    /// </summary>
    [JsonProperty("a")]
    public List<BybitOrderbookRow> Asks { get; set; } = [];

    /// <summary>
    /// Bids
    /// </summary>
    [JsonProperty("b")]
    public List<BybitOrderbookRow> Bids { get; set; } = [];
}