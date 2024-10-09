namespace Bybit.Api.Account;

/// <summary>
/// Bybit Delivery Record
/// </summary>
public class BybitDeliveryRecord
{
    /// <summary>
    /// Delivery time (ms)
    /// </summary>
    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }

    /// <summary>
    /// Delivery time
    /// </summary>
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Executed size
    /// </summary>
    public decimal Position { get; set; }

    /// <summary>
    /// Delivery price
    /// </summary>
    public decimal DeliveryPrice { get; set; }

    /// <summary>
    /// Exercise price
    /// </summary>
    public decimal Strike { get; set; }

    /// <summary>
    /// Trading fee
    /// </summary>
    public decimal Fee { get; set; }

    /// <summary>
    /// Realized PnL of the delivery
    /// </summary>
    public decimal DeliveryRpl { get; set; }
}
