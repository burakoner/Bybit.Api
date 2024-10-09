namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Margin Trading Status
/// </summary>
public enum BybitMarginTradingStatus
{
    /// <summary>
    /// None
    /// </summary>
    [Map("none")]
    None = 0,

    /// <summary>
    /// Both
    /// </summary>
    [Map("both")]
    Both = 1,

    /// <summary>
    /// UTA Only
    /// </summary>
    [Map("utaOnly")]
    UtaOnly = 2,

    /// <summary>
    /// Normal Spot Only
    /// </summary>
    [Map("normalSpotOnly")]
    SpotOnly = 3,
}