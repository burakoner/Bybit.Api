namespace Bybit.Api.Market;

/// <summary>
/// Bybit order price limit stream update.
/// </summary>
public record BybitOrderPriceLimitUpdate
{
    /// <summary>
    /// Stream generated timestamp in milliseconds.
    /// </summary>
    [JsonIgnore]
    public long Timestamp { get; set; }

    /// <summary>
    /// Stream generated time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

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
}
