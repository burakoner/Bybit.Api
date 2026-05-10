namespace Bybit.Api.Market;

/// <summary>
/// Bybit all liquidation stream update.
/// </summary>
public record BybitAllLiquidationUpdate
{
    /// <summary>
    /// Stream type.
    /// </summary>
    [JsonIgnore]
    public Bybit.Api.Common.Requests.BybitStreamType StreamType { get; set; }

    /// <summary>
    /// Stream generated timestamp in milliseconds.
    /// </summary>
    [JsonIgnore]
    public long StreamTimestamp { get; set; }

    /// <summary>
    /// Stream generated time.
    /// </summary>
    [JsonIgnore]
    public DateTime StreamTime { get => StreamTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// The updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("T")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// The updated time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol name.
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Liquidated position side.
    /// </summary>
    [JsonProperty("S")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Executed size.
    /// </summary>
    [JsonProperty("v")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Bankruptcy price.
    /// </summary>
    [JsonProperty("p")]
    public decimal Price { get; set; }
}
