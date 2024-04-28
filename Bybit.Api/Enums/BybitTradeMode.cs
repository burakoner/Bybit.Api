namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Trade Mode
/// </summary>
public enum BybitTradeMode
{
    /// <summary>
    /// Cross Margin
    /// </summary>
    [Label("0")]
    CrossMargin,

    /// <summary>
    /// Isolated Margin
    /// </summary>
    [Label("1")]
    IsolatedMargin,
}