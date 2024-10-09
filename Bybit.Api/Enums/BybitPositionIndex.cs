namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Position Index
/// </summary>
public enum BybitPositionIndex
{
    /// <summary>
    /// One-way mode position
    /// </summary>
    [Map("0")]
    OneWayModePosition = 0,

    /// <summary>
    /// Buy side of hedge mode position
    /// </summary>
    [Map("1")]
    BuySideOfHedgeModePosition = 1,

    /// <summary>
    /// Sell side of hedge mode position
    /// </summary>
    [Map("2")]
    SellSideOfHedgeModePosition = 2,
}