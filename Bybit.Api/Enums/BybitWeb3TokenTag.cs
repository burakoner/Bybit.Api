namespace Bybit.Api.Enums;

/// <summary>
/// Web3 token tag.
/// </summary>
public enum BybitWeb3TokenTag
{
    /// <summary>
    /// No tag.
    /// </summary>
    [Map("0")]
    NoTag = 0,

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
