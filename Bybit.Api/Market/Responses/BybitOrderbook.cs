namespace Bybit.Api.Market;

/// <summary>
/// Bybit Orderbook
/// </summary>
public class BybitOrderbook
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; }

    /// <summary>
    /// Ask, seller. Order by price asc
    /// </summary>
    [JsonProperty("a")]
    public List<BybitOrderbookRow> Asks { get; set; } = [];

    /// <summary>
    /// Bid, buyer. Sort by price desc
    /// </summary>
    [JsonProperty("b")]
    public List<BybitOrderbookRow> Bids { get; set; } = [];

    /// <summary>
    /// The timestamp (ms) that the system generates the data
    /// </summary>
    [JsonProperty("ts")]
    public long Timestamp { get; set; }

    /// <summary>
    /// The timestamp (ms) that the system generates the data
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Update ID, is always in sequence
    /// For contract, it is corresponding to u in the wss 500-level orderbook
    /// For spot, it is corresponding to u in the wss 200-level orderbook
    /// </summary>
    [JsonProperty("u")]
    public long UpdateId { get; set; }

    /// <summary>
    /// Cross sequence
    /// You can use this field to compare different levels orderbook data, and for the smaller seq, then it means the data is generated earlier.
    /// Option does not have this field currently
    /// </summary>
    [JsonProperty("seq")]
    public long CrossSequence { get; set; }

    /// <summary>
    /// The timestamp from the match engine when this orderbook data is produced. It can be correlated with T from public trade channel. linear, inverse, spot have this field
    /// </summary>
    [JsonProperty("cts")]
    public long? CreateTimestamp { get; set; }

    /// <summary>
    /// The timestamp from the match engine when this orderbook data is produced. It can be correlated with T from public trade channel. linear, inverse, spot have this field
    /// </summary>
    public DateTime? CreateTime { get => CreateTimestamp?.ConvertFromMilliseconds(); }

}

/// <summary>
/// Bybit Orderbook Row
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public class BybitOrderbookRow
{
    /// <summary>
    /// Price
    /// </summary>
    [ArrayProperty(0)]
    public decimal Price { get; set; }

    /// <summary>
    /// Size
    /// </summary>
    [ArrayProperty(1)]
    public decimal Quantity { get; set; }
}
