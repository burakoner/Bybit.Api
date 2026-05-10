namespace Bybit.Api.Enums;

/// <summary>
/// Web3 order type.
/// </summary>
public enum BybitWeb3OrderType
{
    /// <summary>
    /// Market order.
    /// </summary>
    [Map("1")]
    Market = 1,

    /// <summary>
    /// Limit order.
    /// </summary>
    [Map("2")]
    Limit = 2,
}
