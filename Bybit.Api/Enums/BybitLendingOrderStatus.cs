namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Lending Order Status
/// </summary>
public enum BybitLendingOrderStatus
{
    /// <summary>
    /// Outstanding
    /// </summary>
    [Map("1")]
    Outstanding = 1,

    /// <summary>
    /// Paid off
    /// </summary>
    [Map("2")]
    PaidOff = 2,
}