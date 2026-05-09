namespace Bybit.Api.Enums;

/// <summary>
/// Fixed-rate borrow repayment type.
/// </summary>
public enum BybitFixedBorrowRepayType
{
    /// <summary>
    /// No automatic repayment.
    /// </summary>
    [Map("0")]
    None = 0,

    /// <summary>
    /// Auto repayment.
    /// </summary>
    [Map("1")]
    AutoRepayment = 1,

    /// <summary>
    /// Transfer to flexible loan.
    /// </summary>
    [Map("2")]
    TransferToFlexibleLoan = 2,
}
