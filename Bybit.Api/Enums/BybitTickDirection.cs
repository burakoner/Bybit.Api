namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Tick Direction
/// </summary>
public enum BybitTickDirection
{
    /// <summary>
    /// price rise
    /// </summary>
    [Label("PlusTick")]
    PlusTick,

    /// <summary>
    /// trade occurs at the same price as the previous trade, which occurred at a price higher than that for the trade preceding it
    /// </summary>
    [Label("ZeroPlusTick")]
    ZeroPlusTick,

    /// <summary>
    /// price drop
    /// </summary>
    [Label("MinusTick")]
    MinusTick,

    /// <summary>
    /// trade occurs at the same price as the previous trade, which occurred at a price lower than that for the trade preceding it
    /// </summary>
    [Label("ZeroMinusTick")]
    ZeroMinusTick,
}