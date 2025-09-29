namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Bybit Lending Repay Order Container
/// </summary>
internal class BybitLoanRepayOrderContainer
{
    [JsonProperty("repayInfo")]
    public List<BybitLoanRepayOrder> Payload { get; set; } = [];
}

/// <summary>
/// Bybit Lending Repay Order
/// </summary>
public class BybitLoanRepayOrder
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
    public BybitLendingRepayType Type { get; set; }

    /// <summary>
    /// 1：outstanding; 2：paid off
    /// </summary>
    public BybitLendingOrderStatus Status { get; set; }

}
