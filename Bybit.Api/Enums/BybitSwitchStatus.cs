namespace Bybit.Api.Enums;

/// <summary>
/// Bybit ON/OFF switch status.
/// </summary>
public enum BybitSwitchStatus
{
    /// <summary>
    /// Enabled.
    /// </summary>
    [Map("ON")]
    On = 1,

    /// <summary>
    /// Disabled.
    /// </summary>
    [Map("OFF")]
    Off = 2,
}
