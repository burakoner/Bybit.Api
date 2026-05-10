namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade delivery record item.
/// </summary>
public record BybitPreUpgradeDelivery
{
    /// <summary>
    /// Delivery timestamp in milliseconds.
    /// </summary>
    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }

    /// <summary>
    /// Delivery time.
    /// </summary>
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Side.
    /// </summary>
    public BybitOrderSide? Side { get; set; }

    /// <summary>
    /// Executed size.
    /// </summary>
    public decimal? Position { get; set; }

    /// <summary>
    /// Delivery price.
    /// </summary>
    public decimal? DeliveryPrice { get; set; }

    /// <summary>
    /// Exercise price.
    /// </summary>
    public decimal? Strike { get; set; }

    /// <summary>
    /// Trading fee.
    /// </summary>
    public decimal? Fee { get; set; }

    /// <summary>
    /// Realised PnL of the delivery.
    /// </summary>
    public decimal? DeliveryRpl { get; set; }
}
