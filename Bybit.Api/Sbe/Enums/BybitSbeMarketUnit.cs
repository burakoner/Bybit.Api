namespace Bybit.Api.Sbe;

/// <summary>
/// SBE market unit.
/// </summary>
public enum BybitSbeMarketUnit : byte
{
    /// <summary>
    /// Unknown market unit.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Base coin.
    /// </summary>
    BaseCoin = 1,

    /// <summary>
    /// Quote coin.
    /// </summary>
    QuoteCoin = 2,

    /// <summary>
    /// Non-representable market unit.
    /// </summary>
    NonRepresentable = 254,
}
