namespace Bybit.Api.Common;

/// <summary>
/// Bybit Order Side
/// </summary>
public enum BybitOrderSide
{
    /// <summary>
    /// Buy
    /// </summary>
    [Map("Buy")]
    Buy = 1,

    /// <summary>
    /// Sell
    /// </summary>
    [Map("Sell")]
    Sell = 2,
}