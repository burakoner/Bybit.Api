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
    /// Unified trading account 1.0
    /// </summary>
    [Map("3")]
    UnifiedTradingAccount_1_0 = 3,

    /// <summary>
    /// Unified trading account 1.0 (pro version)
    /// </summary>
    [Map("4")]
    UnifiedTradingAccountPro_1_0 = 4,

    /// <summary>
    /// Unified trading account 2.0
    /// </summary>
    [Map("5")]
    UnifiedTradingAccount_2_0 = 5,

    /// <summary>
    /// Unified trading account 2.0 (pro version)
    /// </summary>
    [Map("6")]
    UnifiedTradingAccountPro_2_0 = 6,
}