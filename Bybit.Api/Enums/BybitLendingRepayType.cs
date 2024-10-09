namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Lending Repay Type
/// </summary>
public enum BybitLendingRepayType
{
    /// <summary>
    /// Normal repayment
    /// </summary>
    [Map("1")]
    NormalRepayment = 1,

    /// <summary>
    /// Repaid by liquidation
    /// </summary>
    [Map("2")]
    RepaidByLiquidation = 2,
}