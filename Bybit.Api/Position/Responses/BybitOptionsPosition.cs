namespace Bybit.Api.Position;

/// <summary>
/// Bybit Options Position
/// </summary>
public record BybitOptionsPosition
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Side
    /// </summary>
    public BybitPositionSide? Side { get; set; }

    /// <summary>
    /// Total open fee
    /// </summary>
    public decimal? TotalOpenFee { get; set; }

    /// <summary>
    /// Delivery fee
    /// </summary>
    public decimal? DeliveryFee { get; set; }

    /// <summary>
    /// Total close fee
    /// </summary>
    public decimal? TotalCloseFee { get; set; }

    /// <summary>
    /// Order qty
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// The closed time (ms)
    /// </summary>
    [JsonProperty("closeTime")]
    public long? CloseTimestamp { get; set; }

    /// <summary>
    /// The closed time (ms)
    /// </summary>
    public DateTime? CloseTime { get => CloseTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Average exit price
    /// </summary>
    [JsonProperty("avgExitPrice")]
    public decimal? AverageExitPrice { get; set; }

    /// <summary>
    /// Delivery price
    /// </summary>
    public decimal? DeliveryPrice { get; set; }

    /// <summary>
    /// The opened time (ms)
    /// </summary>
    [JsonProperty("openTime")]
    public long? OpenTimestamp { get; set; }

    /// <summary>
    /// The opened time (ms)
    /// </summary>
    public DateTime? OpenTime { get => OpenTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Average entry price
    /// </summary>
    [JsonProperty("avgEntryPrice")]
    public decimal? AverageEntryPrice { get; set; }

    /// <summary>
    /// Total PnL
    /// </summary>
    public decimal? TotalPnl { get; set; }
}
