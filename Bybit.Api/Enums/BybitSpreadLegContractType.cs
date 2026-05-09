namespace Bybit.Api.Enums;

/// <summary>
/// Bybit spread leg contract type.
/// </summary>
public enum BybitSpreadLegContractType
{
    /// <summary>
    /// Linear perpetual.
    /// </summary>
    [Map("LinearPerpetual")]
    LinearPerpetual = 1,

    /// <summary>
    /// Linear futures.
    /// </summary>
    [Map("LinearFutures")]
    LinearFutures = 2,

    /// <summary>
    /// Spot.
    /// </summary>
    [Map("Spot")]
    Spot = 3,
}
