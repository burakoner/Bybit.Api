namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Instrument Status
/// </summary>
public enum BybitInstrumentStatus
{
    /// <summary>
    /// Pre Launch
    /// </summary>
    [Label("PreLaunch")]
    PreLaunch,

    /// <summary>
    /// Trading
    /// </summary>
    [Label("Trading")]
    Trading,

    /// <summary>
    /// Settling
    /// </summary>
    [Label("Settling")]
    Settling,

    /// <summary>
    /// Delivering
    /// </summary>
    [Label("Delivering")]
    Delivering,

    /// <summary>
    /// Closed
    /// </summary>
    [Label("Closed")]
    Closed,
}