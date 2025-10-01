namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Slippage Tolerance Type
/// </summary>
public enum BybitSlippageToleranceType
{
    /// <summary>
    /// TickSize
    /// </summary>
    [Map("TickSize")]
    TickSize = 1,

    /// <summary>
    /// Percent
    /// </summary>
    [Map("Percent")]
    Percent = 2,
}