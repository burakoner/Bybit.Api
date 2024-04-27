namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Category
/// </summary>
public enum BybitCategory
{
    /// <summary>
    /// Spot
    /// </summary>
    [Label("spot")]
    Spot,

    /// <summary>
    /// Linear perpetual, including USDC perp.
    /// </summary>
    [Label("linear")]
    Linear,

    /// <summary>
    /// Inverse futures, including inverse perpetual, inverse futures.
    /// </summary>
    [Label("inverse")]
    Inverse,

    /// <summary>
    /// USDC Option
    /// </summary>
    [Label("option")]
    Option,
}