namespace Bybit.Api.Sbe;

/// <summary>
/// SBE order type.
/// </summary>
public enum BybitSbeOrderType : byte
{
    /// <summary>
    /// Unknown order type.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Market order.
    /// </summary>
    Market = 1,

    /// <summary>
    /// Limit order.
    /// </summary>
    Limit = 2,

    /// <summary>
    /// Non-representable order type.
    /// </summary>
    NonRepresentable = 254,
}
