namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Margin Mode
/// </summary>
public enum BybitMarginMode
{
    /// <summary>
    /// Isolated
    /// </summary>
    [Label("ISOLATED_MARGIN")]
    Isolated,

    /// <summary>
    /// Regular (i.e. Cross margin)
    /// </summary>
    [Label("REGULAR_MARGIN")]
    Regular,

    /// <summary>
    /// Portfolio
    /// </summary>
    [Label("PORTFOLIO_MARGIN")]
    Portfolio,
}