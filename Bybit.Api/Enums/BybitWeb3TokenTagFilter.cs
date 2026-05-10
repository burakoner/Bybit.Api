namespace Bybit.Api.Enums;

/// <summary>
/// Web3 token tag filter.
/// </summary>
public enum BybitWeb3TokenTagFilter
{
    /// <summary>
    /// All tokens.
    /// </summary>
    [Map("0")]
    All = 0,

    /// <summary>
    /// New token sniping.
    /// </summary>
    [Map("1")]
    NewTokenSniping = 1,

    /// <summary>
    /// On-chain hot token.
    /// </summary>
    [Map("2")]
    OnChainHotToken = 2,
}
