namespace Bybit.Api.Enums;

/// <summary>
/// Bybit account repayment result status.
/// </summary>
public enum BybitAccountRepaymentStatus
{
    /// <summary>
    /// Processing.
    /// </summary>
    [Map("P")]
    Processing = 1,

    /// <summary>
    /// Success.
    /// </summary>
    [Map("SU")]
    Success = 2,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("FA")]
    Failed = 3,
}
