namespace Bybit.Api.Models.Lending;

/// <summary>
/// Bybit Lending Repay Order Container
/// </summary>
internal class BybitLendingRepayOrderContainer
{
    [JsonProperty("repayInfo")]
    public List<BybitLendingRepayOrder> Payload { get; set; } = [];
}

/// <summary>
/// Bybit Lending Repay Order
/// </summary>
public class BybitLendingRepayOrder
{
    /// <summary>
    /// Repaid order ID
    /// </summary>
    public string RepayOrderId { get; set; }

    /// <summary>
    /// Repaid timestamp (ms)
    /// </summary>
    [JsonProperty("repaidTime")]
    public long RepaidTimestamp { get; set; }

    /// <summary>
    /// Repaid timestamp
    /// </summary>
    public DateTime RepaidTime { get => RepaidTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Repaid coin
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Repaid principle
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Repaid interest
    /// </summary>
    public decimal Interest { get; set; }

    /// <summary>
    /// Repaid type. 1：normal repayment; 2：repaid by liquidation
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitLendingRepayType>))]
    public BybitLendingRepayType Type { get; set; }

    /// <summary>
    /// 1：outstanding; 2：paid off
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitLendingOrderStatus>))]
    public BybitLendingOrderStatus Status { get; set; }

}