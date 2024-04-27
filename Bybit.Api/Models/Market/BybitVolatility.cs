namespace Bybit.Api.Models.Market;

/// <summary>
/// Bybit Volatility
/// </summary>
public class BybitVolatility
{
    /// <summary>
    /// Period
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOptionPeriod>))]
    public BybitOptionPeriod Period { get; set; }

    /// <summary>
    /// Volatility
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Timestamp (ms)
    /// </summary>
    [JsonProperty("time")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}