namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card transaction status.
/// </summary>
public enum BybitCardTransactionStatus
{
    /// <summary>
    /// Initialised.
    /// </summary>
    [Map("-1")]
    Init = -1,

    /// <summary>
    /// Pending.
    /// </summary>
    [Map("0")]
    Pending = 0,

    /// <summary>
    /// Success.
    /// </summary>
    [Map("1")]
    Success = 1,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("2")]
    Failed = 2,
}
