namespace Bybit.Api.Sbe;

/// <summary>
/// SBE side.
/// </summary>
public enum BybitSbeSide : byte
{
    /// <summary>
    /// Unknown side.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Buy side.
    /// </summary>
    Buy = 1,

    /// <summary>
    /// Sell side.
    /// </summary>
    Sell = 2,

    /// <summary>
    /// Non-representable side.
    /// </summary>
    NonRepresentable = 254,
}
