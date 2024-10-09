namespace Bybit.Api.Market;

/// <summary>
/// Bybit Delivery Price
/// </summary>
public class BybitMarketDeliveryPrice
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Delivery Price
    /// </summary>
    public decimal DeliveryPrice { get; set; }

    /// <summary>
    /// Delivery Time
    /// </summary>
    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }

    /// <summary>
    /// Delivery Time
    /// </summary>
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }
}