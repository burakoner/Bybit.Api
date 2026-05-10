namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card cashback display status.
/// </summary>
public enum BybitCardCashbackOrderShowStatus
{
    /// <summary>
    /// Unpaid.
    /// </summary>
    [Map("NO_PAY")]
    Unpaid,

    /// <summary>
    /// Pending.
    /// </summary>
    [Map("ORDER_PENDING_SHOW")]
    Pending,

    /// <summary>
    /// Success.
    /// </summary>
    [Map("ORDER_SUCCESS")]
    Success,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("ORDER_FAIL")]
    Failed,
}
