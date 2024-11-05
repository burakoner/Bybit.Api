namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit Kline Stream
/// </summary>
public class BybitKlineUpdate
{
    /// <summary>
    /// The start timestamp (ms)
    /// </summary>
    [JsonProperty("start")]
    public long OpenTimestamp { get; set; }

    /// <summary>
    /// The start timestamp
    /// </summary>
    public DateTime OpenTime { get => OpenTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// The end timestamp (ms)
    /// </summary>
    [JsonProperty("end")]
    public long CloseTimestamp { get; set; }

    /// <summary>
    /// The end timestamp
    /// </summary>
    public DateTime CloseTime { get => CloseTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Kline interval
    /// </summary>
    [JsonProperty("interval")]
    public BybitInterval Interval { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [JsonProperty("open")]
    public decimal Open { get; set; }

    /// <summary>
    /// Highest price
    /// </summary>
    [JsonProperty("high")]
    public decimal High { get; set; }

    /// <summary>
    /// Lowest price
    /// </summary>
    [JsonProperty("low")]
    public decimal Low { get; set; }

    /// <summary>
    /// Close price
    /// </summary>
    [JsonProperty("close")]
    public decimal Close { get; set; }

    /// <summary>
    /// Trade volume
    /// </summary>
    [JsonProperty("volume")]
    public decimal Volume { get; set; }

    /// <summary>
    /// Quote Volume
    /// </summary>
    [JsonProperty("turnover")]
    public decimal QuoteVolume { get; set; }

    /// <summary>
    /// Weather the tick is ended or not
    /// </summary>
    [JsonProperty("confirm")]
    public bool Confirm { get; set; }
    
    /// <summary>
    /// The timestamp (ms) of the last matched order in the candle
    /// </summary>
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    /// <summary>
    /// The timestamp (ms) of the last matched order in the candle
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}
