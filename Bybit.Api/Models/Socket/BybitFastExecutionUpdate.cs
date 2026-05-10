namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit fast execution update.
/// </summary>
public record BybitFastExecutionUpdate
{
    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Is maker order.
    /// </summary>
    public bool IsMaker { get; set; }

    /// <summary>
    /// User customized order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Execution ID.
    /// </summary>
    [JsonProperty("execId")]
    public string TradeId { get; set; } = string.Empty;

    /// <summary>
    /// Execution price.
    /// </summary>
    [JsonProperty("execPrice")]
    public decimal Price { get; set; }

    /// <summary>
    /// Execution quantity.
    /// </summary>
    [JsonProperty("execQty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Execution timestamp in milliseconds.
    /// </summary>
    [JsonProperty("execTime")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Execution time.
    /// </summary>
    [JsonIgnore]
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Cross sequence.
    /// </summary>
    [JsonProperty("seq")]
    public long Sequence { get; set; }
}
