namespace Bybit.Api.Enums;

/// <summary>
/// Crypto loan collateral adjustment direction.
/// </summary>
public enum BybitCryptoLoanAdjustmentDirection
{
    /// <summary>
    /// Add collateral.
    /// </summary>
    [Map("0")]
    AddCollateral = 0,

    /// <summary>
    /// Reduce collateral.
    /// </summary>
    [Map("1")]
    ReduceCollateral = 1,
}
