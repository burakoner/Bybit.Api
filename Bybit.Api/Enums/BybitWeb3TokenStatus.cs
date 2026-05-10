namespace Bybit.Api.Enums;

/// <summary>
/// Web3 token status.
/// </summary>
public enum BybitWeb3TokenStatus
{
    /// <summary>
    /// Not listed.
    /// </summary>
    [Map("0")]
    NotListed = 0,

    /// <summary>
    /// Listed.
    /// </summary>
    [Map("1")]
    Listed = 1,

    /// <summary>
    /// Delisting.
    /// </summary>
    [Map("2")]
    Delisting = 2,

    /// <summary>
    /// In delivery.
    /// </summary>
    [Map("3")]
    InDelivery = 3,

    /// <summary>
    /// Delisted.
    /// </summary>
    [Map("4")]
    Delisted = 4,
}
