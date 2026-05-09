namespace Bybit.Api.Enums;

/// <summary>
/// Bybit spread contract type.
/// </summary>
public enum BybitSpreadContractType
{
    /// <summary>
    /// Perpetual and spot combination.
    /// </summary>
    [Map("FundingRateArb")]
    FundingRateArbitrage = 1,

    /// <summary>
    /// Futures and spot combination.
    /// </summary>
    [Map("CarryTrade")]
    CarryTrade = 2,

    /// <summary>
    /// Different expiry futures combination.
    /// </summary>
    [Map("FutureSpread")]
    FutureSpread = 3,

    /// <summary>
    /// Futures and perpetual combination.
    /// </summary>
    [Map("PerpBasis")]
    PerpetualBasis = 4,
}
