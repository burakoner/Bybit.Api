namespace Bybit.Api.Models.Tokens;

/// <summary>
/// Bybit Leveraged Token Order
/// </summary>
public class BybitLeverageTokenOrder
{
    /// <summary>
    /// Abbreviation of the LT, such as BTC3L
    /// </summary>
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// LT order type. 1: purchase, 2: redeem
    /// </summary>
    [JsonProperty("ltOrderType"), JsonConverter(typeof(LabelConverter<BybitLeverageTokenOrderType>))]
    public BybitLeverageTokenOrderType Type { get; set; }

    /// <summary>
    /// Order time
    /// </summary>
    [JsonProperty("orderTime")]
    public long OrderTimestamp { get; set; }

    /// <summary>
    /// Order time
    /// </summary>
    public DateTime OrderTime { get => OrderTimestamp.ConvertFromMilliseconds(); }
    
    /// <summary>
    /// Last update time of the order status
    /// </summary>
    [JsonProperty("updateTime")]
    public long? UpdateTimestamp { get; set; }

    /// <summary>
    /// Last update time of the order status
    /// </summary>
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }
    
    /// <summary>
    /// Order status. 1: completed, 2: in progress, 3: failed
    /// </summary>
    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLeverageTokenOrderStatus>))]
    public BybitLeverageTokenOrderStatus Status { get; set; }
    
    /// <summary>
    /// Trading fees
    /// </summary>
    [JsonProperty("fee")]
    public decimal Fee { get; set; }
    
    /// <summary>
    /// Order quantity of the LT
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }
    
    /// <summary>
    /// Filled value
    /// </summary>
    [JsonProperty("value")]
    public decimal Value { get; set; }
    
    /// <summary>
    /// Quote coin
    /// </summary>
    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }

    /// <summary>
    /// Serial number
    /// </summary>
    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }
}