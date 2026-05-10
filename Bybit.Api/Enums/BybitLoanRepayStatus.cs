namespace Bybit.Api.Enums;

/// <summary>
/// Institutional loan repayment order status.
/// </summary>
public enum BybitLoanRepayStatus
{
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
