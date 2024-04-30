namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit trade stream
/// </summary>
public class BybitTradeUpdate
{
    /// <summary>
    /// Trade ID
    /// </summary>
    [JsonProperty("i")]
    public string Id { get; set; }

    /// <summary>
    /// The timestamp (ms) that the order is filled
    /// </summary>
    [JsonProperty("T")]
    public long Timestamp { get; set; }

    /// <summary>
    /// The timestamp (ms) that the order is filled
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; }

    /// <summary>
    /// Side of taker. Buy,Sell
    /// </summary>
    [JsonProperty("S"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Trade price
    /// </summary>
    [JsonProperty("p")]
    public decimal Price { get; set; }

    /// <summary>
    /// Trade size
    /// </summary>
    [JsonProperty("v")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Direction of price change. Unique field for future
    /// </summary>
    [JsonProperty("L"), JsonConverter(typeof(LabelConverter<BybitTickDirection>))]
    public BybitTickDirection Direction { get; set; }

    /// <summary>
    /// Whether it is a block trade order or not
    /// </summary>
    [JsonProperty("BT")]
    public bool BlockTrade { get; set; }

    /// <summary>
    /// Mark price, unique field for option
    /// </summary>
    [JsonProperty("mP")]
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Index price, unique field for option
    /// </summary>
    [JsonProperty("iP")]
    public decimal? IndexPrice { get; set; }

    /// <summary>
    /// Mark iv, unique field for option
    /// </summary>
    [JsonProperty("mIv")]
    public decimal? MarkIv { get; set; }

    /// <summary>
    /// iv, unique field for option
    /// </summary>
    [JsonProperty("iv")]
    public decimal? Iv { get; set; }
}
