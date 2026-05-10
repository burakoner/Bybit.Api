namespace Bybit.Api.Enums;

/// <summary>
/// Web3 notification display flag.
/// </summary>
public enum BybitWeb3MessageDisplay
{
    /// <summary>
    /// Do not display notification.
    /// </summary>
    [Map("0")]
    Hide = 0,

    /// <summary>
    /// Display notification.
    /// </summary>
    [Map("1")]
    Display = 1,
}
