namespace Bybit.Api.Enums;

/// <summary>
/// Bybit spread leg product type.
/// </summary>
public enum BybitSpreadLegProductType
{
    /// <summary>
    /// Futures.
    /// </summary>
    [Map("Futures")]
    Futures = 1,

    /// <summary>
    /// Spot.
    /// </summary>
    [Map("Spot")]
    Spot = 2,
}
