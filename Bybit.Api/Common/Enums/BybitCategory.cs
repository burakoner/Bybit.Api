namespace Bybit.Api.Common;

/// <summary>
/// Bybit Category
/// </summary>
public enum BybitCategory
{
    /// <summary>
    /// Spot
    /// </summary>
    [Map("spot")]
    Spot = 1,

    /// <summary>
    /// Linear perpetual, including USDC perp.
    /// </summary>
    [Map("linear")]
    Linear = 2,

    /// <summary>
    /// Inverse futures, including inverse perpetual, inverse futures.
    /// </summary>
    [Map("inverse")]
    Inverse = 3,

    /// <summary>
    /// USDC Option
    /// Not compatible with Classic Account
    /// </summary>
    [Map("option")]
    Option = 4,
}