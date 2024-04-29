namespace Bybit.Api.Models.Market;

/// <summary>
/// Bybit Trade History
/// </summary>
public class BybitPublicTrade
{
    /// <summary>
    /// Trade Id
    /// </summary>
    [JsonProperty("execId")]
    public long TradeId { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Price of the trade
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity of the trade
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("time")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Whether the trade is block trade
    /// </summary>
    public bool IsBlockTrade { get; set; }

    /// <summary>
    /// [Option only] Mark price
    /// </summary>
    [JsonProperty("mP")]
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// [Option only] Index price
    /// </summary>
    [JsonProperty("iP")]
    public decimal? IndexPrice { get; set; }

    /// <summary>
    /// [Option only] Mark iv
    /// </summary>
    [JsonProperty("mIv")]
    public decimal? MarkIv { get; set; }

    /// <summary>
    /// [Option only] Index iv
    /// </summary>
    [JsonProperty("iv")]
    public decimal? IndexIv { get; set; }
}
