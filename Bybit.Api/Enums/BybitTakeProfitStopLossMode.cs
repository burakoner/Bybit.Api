namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Take Profit Stop Loss Mode
/// </summary>
public enum BybitTakeProfitStopLossMode
{
    /// <summary>
    /// Full
    /// </summary>
    [Map("Full")]
    Full = 1,

    /// <summary>
    /// Partial
    /// </summary>
    [Map("Partial")]
    Partial = 2,
}