using Bybit.Api.Common.Requests;

namespace Bybit.Api.Market;

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
    public string Symbol { get; set; } = string.Empty;

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
    public List<BybitMarketOrderbookRow> Asks { get; set; } = [];

    /// <summary>
    /// Bids
    /// </summary>
    [JsonProperty("b")]
    public List<BybitMarketOrderbookRow> Bids { get; set; } = [];
}