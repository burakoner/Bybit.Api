namespace Bybit.Api.Enums;

public enum BybitUnifiedMarginAccount
{
    /// <summary>
    /// Regular account
    /// </summary>
    [Label("1")]
    Regular,

    /// <summary>
    /// Unified margin account, can only trade linear perpetual and options.
    /// </summary>
    [Label("2")]
    UnifiedMarginAccount,

    /// <summary>
    /// Unified trade account, can trade linear perpetual, options and spot
    /// </summary>
    [Label("3")]
    UnifiedTradeAccount
}