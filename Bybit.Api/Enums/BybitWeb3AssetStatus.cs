namespace Bybit.Api.Enums;

/// <summary>
/// Web3 asset lifecycle status.
/// </summary>
public enum BybitWeb3AssetStatus
{
    /// <summary>
    /// Running.
    /// </summary>
    [Map("0")]
    Running = 0,

    /// <summary>
    /// Delisting soon.
    /// </summary>
    [Map("1")]
    DelistingSoon = 1,

    /// <summary>
    /// Delisted.
    /// </summary>
    [Map("2")]
    Delisted = 2,
}
