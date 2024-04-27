namespace Bybit.Api.Enums;

/// <summary>
/// Bybit order type
/// </summary>
public enum BybitOrderType
{
    /// <summary>
    /// Limit order
    /// </summary>
    [Label("Limit")]
    Limit,

    /// <summary>
    /// Market order
    /// </summary>
    [Label("Market")]
    Market,
}