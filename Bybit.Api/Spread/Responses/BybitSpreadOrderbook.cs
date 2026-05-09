namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread orderbook.
/// </summary>
public record BybitSpreadOrderbook
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Bid levels.
    /// </summary>
    [JsonProperty("b")]
    public List<BybitSpreadOrderbookRow> Bids { get; set; } = [];

    /// <summary>
    /// Ask levels.
    /// </summary>
    [JsonProperty("a")]
    public List<BybitSpreadOrderbookRow> Asks { get; set; } = [];

    /// <summary>
    /// System generated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("ts")]
    public long Timestamp { get; set; }

    /// <summary>
    /// System generated time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Update ID.
    /// </summary>
    [JsonProperty("u")]
    public long UpdateId { get; set; }

    /// <summary>
    /// Cross sequence.
    /// </summary>
    [JsonProperty("seq")]
    public long CrossSequence { get; set; }

    /// <summary>
    /// Matching engine timestamp in milliseconds.
    /// </summary>
    [JsonProperty("cts")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Matching engine time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }
}

/// <summary>
/// Bybit spread orderbook row.
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public record BybitSpreadOrderbookRow
{
    /// <summary>
    /// Price.
    /// </summary>
    [ArrayProperty(0)]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    [ArrayProperty(1)]
    public decimal Quantity { get; set; }
}
