namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Trade Mode
/// </summary>
public enum BybitTradeMode
{
    /// <summary>
    /// Cross Margin
    /// </summary>
    [Map("0")]
    CrossMargin = 0,

    /// <summary>
    /// Isolated Margin
    /// </summary>
    [Map("1")]
    IsolatedMargin = 1,
}