namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Tick Direction
/// </summary>
public enum BybitTickDirection
{
    /// <summary>
    /// price rise
    /// </summary>
    [Map("PlusTick")]
    PlusTick = 1,

    /// <summary>
    /// trade occurs at the same price as the previous trade, which occurred at a price higher than that for the trade preceding it
    /// </summary>
    [Map("ZeroPlusTick")]
    ZeroPlusTick = 2,

    /// <summary>
    /// price drop
    /// </summary>
    [Map("MinusTick")]
    MinusTick = 3,

    /// <summary>
    /// trade occurs at the same price as the previous trade, which occurred at a price lower than that for the trade preceding it
    /// </summary>
    [Map("ZeroMinusTick")]
    ZeroMinusTick = 4,
}