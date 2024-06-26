﻿namespace Bybit.Api.Models.Market;

/// <summary>
/// Bybit Delivery Price
/// </summary>
public class BybitDeliveryPrice
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
    public long Timestamp { get; set; }

    /// <summary>
    /// Delivery Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}