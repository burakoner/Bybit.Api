namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Position Index
/// </summary>
public enum BybitPositionIndex
{
    /// <summary>
    /// One-way mode position
    /// </summary>
    [Label("0")]
    OneWayModePosition,

    /// <summary>
    /// Buy side of hedge mode position
    /// </summary>
    [Label("1")]
    BuySideOfHedgeModePosition,

    /// <summary>
    /// Sell side of hedge mode position
    /// </summary>
    [Label("2")]
    SellSideOfHedgeModePosition,
}