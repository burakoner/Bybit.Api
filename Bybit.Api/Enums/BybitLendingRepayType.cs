namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Lending Repay Type
/// </summary>
public enum BybitLendingRepayType
{
    /// <summary>
    /// Normal repayment
    /// </summary>
    [Label("1")]
    NormalRepayment,

    /// <summary>
    /// Repaid by liquidation
    /// </summary>
    [Label("2")]
    RepaidByLiquidation,
}