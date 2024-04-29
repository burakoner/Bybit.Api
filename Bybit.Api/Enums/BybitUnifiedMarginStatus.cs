namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Unified Margin Status
/// </summary>
public enum BybitUnifiedMarginStatus
{
    /// <summary>
    /// Regular account
    /// </summary>
    [Label("1")]
    Regular,

    /// <summary>
    /// Please ignore !!!
    /// </summary>
    [Label("2")]
    UnifiedMarginAccount,

    /// <summary>
    /// Unified trade account, can trade linear perpetual, options and spot
    /// </summary>
    [Label("3")]
    UnifiedTradeAccount,

    /// <summary>
    /// UTA Pro, the pro version of Unified trade account
    /// </summary>
    [Label("4")]
    UnifiedTradeAccountPro,
}