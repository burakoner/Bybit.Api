namespace Bybit.Api.Models.Lending;

internal class BybitLendingRepayOrderContainer
{
    [JsonProperty("repayInfo")]
    public List<BybitLendingRepayOrder> Payload { get; set; } = [];
}

public class BybitLendingRepayOrder
{
    public string RepayOrderId { get; set; }

    [JsonProperty("repaidTime")]
    public long RepaidTimestamp { get; set; }
    public DateTime RepaidTime { get => RepaidTimestamp.ConvertFromMilliseconds(); }

    public string Token { get; set; }
    public decimal Quantity { get; set; }
    public decimal Interest { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitLendingRepayType>))]
    public BybitLendingRepayType Type { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitLendingOrderStatus>))]
    public BybitLendingOrderStatus Status { get; set; }

}