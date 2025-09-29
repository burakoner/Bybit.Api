namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Bybit Lending Repay Order Container
/// </summary>
internal record BybitLoanRepayOrderContainer
{
    [JsonProperty("repayInfo")]
    public List<BybitLoanRepayOrder> Payload { get; set; } = [];
}

/// <summary>
/// Bybit Lending Repay Order
/// </summary>
public record BybitLoanRepayOrder
{
    /// <summary>
    /// Repaid order ID
    /// </summary>
    public string RepayOrderId { get; set; } = string.Empty;

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
    public string Token { get; set; } = string.Empty;

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
