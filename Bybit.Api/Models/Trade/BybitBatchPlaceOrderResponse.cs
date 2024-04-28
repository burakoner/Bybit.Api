namespace Bybit.Api.Models.Trade;

/// <summary>
/// Batch place order response model.
/// </summary>
public class BybitBatchPlaceOrderResponse
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// User customised order ID
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }

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