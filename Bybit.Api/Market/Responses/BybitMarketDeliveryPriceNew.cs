namespace Bybit.Api.Market;

/// <summary>
/// Bybit Delivery Price (New)
/// </summary>
public record BybitMarketDeliveryPriceNew
{
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