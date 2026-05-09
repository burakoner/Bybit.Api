namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread public trade.
/// </summary>
public record BybitSpreadPublicTrade
{
    /// <summary>
    /// Execution ID.
    /// </summary>
    [JsonProperty("execId")]
    public string TradeId { get; set; } = string.Empty;

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Trade price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Trade quantity.
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Taker side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Trade timestamp in milliseconds.
    /// </summary>
    [JsonProperty("time")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Trade time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Cross sequence.
    /// </summary>
    [JsonProperty("seq")]
    public string Sequence { get; set; } = string.Empty;
}
