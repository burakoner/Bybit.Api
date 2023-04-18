namespace Bybit.Api.Models.Market;

public class BybitDeliveryPrice
{
    public string Symbol { get; set; }
    public decimal DeliveryPrice { get; set; }
    [JsonProperty("deliveryTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}