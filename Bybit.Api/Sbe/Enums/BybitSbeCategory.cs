namespace Bybit.Api.Sbe;

/// <summary>
/// SBE product category.
/// </summary>
public enum BybitSbeCategory : byte
{
    /// <summary>
    /// Unknown category.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Spot.
    /// </summary>
    Spot = 1,

    /// <summary>
    /// USDT/USDC contracts.
    /// </summary>
    Linear = 2,

    /// <summary>
    /// Coin-margin contracts.
    /// </summary>
    Inverse = 3,

    /// <summary>
    /// Option.
    /// </summary>
    Option = 4,

    /// <summary>
    /// Non-representable category.
    /// </summary>
    NonRepresentable = 254,
}
