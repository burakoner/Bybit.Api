namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Margin Mode
/// </summary>
public enum BybitMarginMode
{
    /// <summary>
    /// Isolated
    /// </summary>
    [Map("ISOLATED_MARGIN")]
    Isolated = 1,

    /// <summary>
    /// Regular (i.e. Cross margin)
    /// </summary>
    [Map("REGULAR_MARGIN")]
    Regular = 2,

    /// <summary>
    /// Portfolio
    /// </summary>
    [Map("PORTFOLIO_MARGIN")]
    Portfolio = 3,
}