namespace Bybit.Api.Enums;

/// <summary>
/// Bybit account repayment type.
/// </summary>
public enum BybitAccountRepaymentType
{
    /// <summary>
    /// Repay floating-rate liabilities first, then fixed-rate liabilities.
    /// </summary>
    [Map("ALL")]
    All = 1,

    /// <summary>
    /// Repay fixed-rate liabilities only.
    /// </summary>
    [Map("FIXED")]
    Fixed = 2,

    /// <summary>
    /// Repay floating-rate liabilities only.
    /// </summary>
    [Map("FLEXIBLE")]
    Flexible = 3,
}
