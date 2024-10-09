namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Unified Margin Status
/// </summary>
public enum BybitUnifiedMarginStatus
{
    /// <summary>
    /// Regular account
    /// </summary>
    [Map("1")]
    Regular = 1,

    /// <summary>
    /// Please ignore !!!
    /// </summary>
    [Map("2")]
    UnifiedMarginAccount = 2,

    /// <summary>
    /// Unified trade account, can trade linear perpetual, options and spot
    /// </summary>
    [Map("3")]
    UnifiedTradeAccount = 3,

    /// <summary>
    /// UTA Pro, the pro version of Unified trade account
    /// </summary>
    [Map("4")]
    UnifiedTradeAccountPro = 4,
}