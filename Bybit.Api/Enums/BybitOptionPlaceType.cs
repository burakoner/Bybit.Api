namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Option Place Type
/// </summary>
public enum BybitOptionPlaceType
{
    /// <summary>
    /// Price
    /// </summary>
    [Map("price")]
    Price = 1,

    /// <summary>
    /// Implied Volatility
    /// </summary>
    [Map("iv")]
    ImpliedVolatility = 2,
}