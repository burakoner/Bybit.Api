namespace Bybit.Api.Enums;

/// <summary>
/// Web3 asset trade flag.
/// </summary>
public enum BybitWeb3TradeFlag
{
    /// <summary>
    /// Not tradable.
    /// </summary>
    [Map("0")]
    NotTradable = 0,

    /// <summary>
    /// Tradable.
    /// </summary>
    [Map("1")]
    Tradable = 1,
}
