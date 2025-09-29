namespace Bybit.Api.System;

/// <summary>
/// Bybit System Product
/// </summary>
public enum BybitSystemProduct
{
    /// <summary>
    /// Futures
    /// </summary>
    [Map("1")]
    Futures = 1,

    /// <summary>
    /// Spot
    /// </summary>
    [Map("2")]
    Spot = 2,

    /// <summary>
    /// Option
    /// </summary>
    [Map("3")]
    Option = 3,

    /// <summary>
    /// Spread
    /// </summary>
    [Map("4")]
    Spread = 4,
}