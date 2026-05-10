namespace Bybit.Api.Sbe;

/// <summary>
/// SBE position index.
/// </summary>
public enum BybitSbePositionIndex : byte
{
    /// <summary>
    /// One-way mode.
    /// </summary>
    OneWay = 0,

    /// <summary>
    /// Hedge mode buy side.
    /// </summary>
    HedgeBuy = 1,

    /// <summary>
    /// Hedge mode sell side.
    /// </summary>
    HedgeSell = 2,

    /// <summary>
    /// Unknown position index.
    /// </summary>
    Unknown = 253,

    /// <summary>
    /// Non-representable position index.
    /// </summary>
    NonRepresentable = 254,
}
