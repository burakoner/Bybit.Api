using Bybit.Api.Common.Requests;

namespace Bybit.Api.Market;

/// <summary>
/// Bybit Order Book Update
/// </summary>
public record BybitOrderBookUpdate
{
    /// <summary>
    /// Stream Type
    /// </summary>
    [JsonIgnore]
    public BybitStreamType StreamType { get; set; }

    /// <summary>
    /// The timestamp (ms) that the system generates the data
    /// </summary>
    [JsonIgnore]
    public long Timestamp { get; set; }

    /// <summary>
    /// The timestamp that the system generates the data
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// The timestamp from the matching engine when this orderbook data is produced
    /// </summary>
    [JsonIgnore]
    public long? CreateTimestamp { get; set; }

    /// <summary>
    /// The timestamp from the matching engine when this orderbook data is produced
    /// </summary>
    [JsonIgnore]
    public DateTime? CreateTime { get => CreateTimestamp?.ConvertFromMilliseconds(); }

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
