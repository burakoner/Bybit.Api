namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Copy Trading Support
/// </summary>
public enum BybitCopyTradingSupport
{
    /// <summary>
    /// Regardless of normal account or UTA account, this trading pair does not support copy trading
    /// </summary>
    [Label("none")]
    None,
    /// <summary>
    /// For both normal account and UTA account, this trading pair supports copy trading
    /// </summary>
    [Label("both")]
    Both,
    /// <summary>
    /// Only for UTA account,this trading pair supports copy trading
    /// </summary>
    [Label("utaOnly")]
    UtaOnly,
    /// <summary>
    /// Only for normal account, this trading pair supports copy trading
    /// </summary>
    [Label("normalOnly")]
    NormalOnly
}