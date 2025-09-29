namespace Bybit.Api.Trade;

/// <summary>
/// Batch place order response model.
/// </summary>
public class BybitTradingBatchPlaceOrder
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order created time (ms)
    /// </summary>
    [JsonProperty("createAt"), JsonConverter(typeof(DateTimeConverter))]
    public long CreateAtTimestamp { get; set; }

    /// <summary>
    /// Order created time
    /// </summary>
    public DateTime CreateAtTime { get => CreateAtTimestamp.ConvertFromMilliseconds(); }
}