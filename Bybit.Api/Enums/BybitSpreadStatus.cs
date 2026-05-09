namespace Bybit.Api.Enums;

/// <summary>
/// Bybit spread instrument status.
/// </summary>
public enum BybitSpreadStatus
{
    /// <summary>
    /// Trading.
    /// </summary>
    [Map("Trading")]
    Trading = 1,

    /// <summary>
    /// Settling.
    /// </summary>
    [Map("Settling")]
    Settling = 2,
}
