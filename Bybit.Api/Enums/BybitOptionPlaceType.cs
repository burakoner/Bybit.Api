namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Option Place Type
/// </summary>
public enum BybitOptionPlaceType
{
    /// <summary>
    /// Price
    /// </summary>
    [Label("price")]
    Price,

    /// <summary>
    /// Implied Volatility
    /// </summary>
    [Label("iv")]
    ImpliedVolatility,
}