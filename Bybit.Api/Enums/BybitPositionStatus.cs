namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Position Status
/// </summary>
public enum BybitPositionStatus
{
    /// <summary>
    /// Normal
    /// </summary>
    [Label("Normal")]
    Normal,

    /// <summary>
    /// in the liquidation progress
    /// </summary>
    [Label("Liq")]
    Liq,

    /// <summary>
    /// in the auto-deleverage progress
    /// </summary>
    [Label("Adl")]
    Adl,
}