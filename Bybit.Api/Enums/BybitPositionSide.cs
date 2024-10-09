namespace Bybit.Api.Enums;

/// <summary>
/// BybitPositionSide
/// </summary>
public enum BybitPositionSide
{
    /// <summary>
    /// None
    /// </summary>
    [Map("None")]
    None = 0,

    /// <summary>
    /// Buy
    /// </summary>
    [Map("Buy")]
    Buy = 1,

    /// <summary>
    /// Sell
    /// </summary>
    [Map("Sell")]
    Sell = 2,
}