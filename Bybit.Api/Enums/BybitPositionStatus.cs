namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Position Status
/// </summary>
public enum BybitPositionStatus
{
    /// <summary>
    /// Normal
    /// </summary>
    [Map("Normal")]
    Normal = 1,

    /// <summary>
    /// in the liquidation progress
    /// </summary>
    [Map("Liq")]
    Liq = 2,

    /// <summary>
    /// in the auto-deleverage progress
    /// </summary>
    [Map("Adl")]
    Adl = 3,
}