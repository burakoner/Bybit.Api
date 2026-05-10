namespace Bybit.Api.Enums;

/// <summary>
/// Web3 trade type.
/// </summary>
public enum BybitWeb3TradeType
{
    /// <summary>
    /// All trade types.
    /// </summary>
    [Map("0")]
    All = 0,

    /// <summary>
    /// Purchase on-chain token with payment token.
    /// </summary>
    [Map("1")]
    Purchase = 1,

    /// <summary>
    /// Redeem on-chain token for payment token.
    /// </summary>
    [Map("2")]
    Redeem = 2,
}
