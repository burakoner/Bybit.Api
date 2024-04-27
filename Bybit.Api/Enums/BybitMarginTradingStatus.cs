namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Margin Trading Status
/// </summary>
public enum BybitMarginTradingStatus
{
    /// <summary>
    /// None
    /// </summary>
    [Label("none")]
    None,

    /// <summary>
    /// Both
    /// </summary>
    [Label("both")]
    Both,

    /// <summary>
    /// UTA Only
    /// </summary>
    [Label("utaOnly")]
    UtaOnly,

    /// <summary>
    /// Normal Spot Only
    /// </summary>
    [Label("normalSpotOnly")]
    SpotOnly,
}