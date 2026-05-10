namespace Bybit.Api.Enums;

/// <summary>
/// Crypto loan repayment type.
/// </summary>
public enum BybitCryptoLoanRepayType
{
    /// <summary>
    /// Repaid by user.
    /// </summary>
    [Map("1")]
    User = 1,

    /// <summary>
    /// Repaid by liquidation.
    /// </summary>
    [Map("2")]
    Liquidation = 2,

    /// <summary>
    /// Automatic repayment.
    /// </summary>
    [Map("3")]
    AutoRepay = 3,

    /// <summary>
    /// Overdue repayment.
    /// </summary>
    [Map("4")]
    OverdueRepay = 4,

    /// <summary>
    /// Repaid by delisting.
    /// </summary>
    [Map("5")]
    Delisting = 5,

    /// <summary>
    /// Repaid by delayed liquidation.
    /// </summary>
    [Map("6")]
    DelayLiquidation = 6,

    /// <summary>
    /// Repaid by collateral currency.
    /// </summary>
    [Map("7")]
    Collateral = 7,

    /// <summary>
    /// Transferred to flexible loan.
    /// </summary>
    [Map("8")]
    TransferToFlexibleLoan = 8,
}
