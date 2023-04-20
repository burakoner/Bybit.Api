namespace Bybit.Api.Models.Wallet;

public class BybitDelivery
{
    public long DeliveryTimestamp { get; set; }
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }

    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<>))]
    public BybitOrderSide Side { get; set; }

    public decimal Position { get; set; }
    public decimal DeliveryPrice { get; set; }
    public decimal Strike { get; set; }
    public decimal Fee { get; set; }
    public decimal RealizedPnl { get; set; }
}
