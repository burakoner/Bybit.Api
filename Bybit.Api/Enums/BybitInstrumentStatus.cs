namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Instrument Status
/// </summary>
public enum BybitInstrumentStatus
{
    /// <summary>
    /// Pre Launch
    /// </summary>
    [Map("PreLaunch")]
    PreLaunch = 1,

    /// <summary>
    /// Trading
    /// </summary>
    [Map("Trading")]
    Trading = 2,

    /// <summary>
    /// Settling
    /// </summary>
    [Map("Settling")]
    Settling = 3,

    /// <summary>
    /// Delivering
    /// </summary>
    [Map("Delivering")]
    Delivering = 4,

    /// <summary>
    /// Closed
    /// </summary>
    [Map("Closed")]
    Closed = 5,
}