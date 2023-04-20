namespace Bybit.Api.Models.LToken;

public class BybitLeveragedTokenOrder
{
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }

    [JsonProperty("ltOrderType"), JsonConverter(typeof(LabelConverter<BybitLtOrderType>))]
    public BybitLtOrderType Type { get; set; }

    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLtOrderStatus>))]
    public BybitLtOrderStatus Status { get; set; }

    [JsonProperty("orderTime")]
    public long OrderTimestamp { get; set; }
    public DateTime OrderTime { get => OrderTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("updateTime")]
    public long? UpdateTimestamp { get; set; }
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("fee")]
    public decimal Fee { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("value")]
    public decimal Value { get; set; }

    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }
}