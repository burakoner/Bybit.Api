namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Copy Trading Support
/// </summary>
public enum BybitCopyTradingSupport
{
    /// <summary>
    /// Regardless of normal account or UTA account, this trading pair does not support copy trading
    /// </summary>
    [Map("none")]
    None = 0,

    /// <summary>
    /// For both normal account and UTA account, this trading pair supports copy trading
    /// </summary>
    [Map("both")]
    Both = 1,

    /// <summary>
    /// Only for UTA account,this trading pair supports copy trading
    /// </summary>
    [Map("utaOnly")]
    UtaOnly = 2,

    /// <summary>
    /// Only for normal account, this trading pair supports copy trading
    /// </summary>
    [Map("normalOnly")]
    NormalOnly = 3
}