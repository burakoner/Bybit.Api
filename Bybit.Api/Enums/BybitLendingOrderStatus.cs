namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Lending Order Status
/// </summary>
public enum BybitLendingOrderStatus
{
    /// <summary>
    /// Outstanding
    /// </summary>
    [Label("1")]
    Outstanding,

    /// <summary>
    /// Paid off
    /// </summary>
    [Label("2")]
    PaidOff,
}