namespace Bybit.Api.Market;

/// <summary>
/// Bybit order price limit.
/// </summary>
public record BybitMarketOrderPriceLimit
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Highest bid price.
    /// </summary>
    [JsonProperty("buyLmt")]
    public decimal BuyLimit { get; set; }

    /// <summary>
    /// Lowest ask price.
    /// </summary>
    [JsonProperty("sellLmt")]
    public decimal SellLimit { get; set; }

    /// <summary>
    /// Timestamp in milliseconds.
    /// </summary>
    [JsonProperty("ts")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Time.
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}
