namespace Bybit.Api.Enums;

/// <summary>
/// Bybit disconnect cancel all product scope.
/// </summary>
public enum BybitDcpProduct
{
    /// <summary>
    /// Options orders.
    /// </summary>
    [Map("OPTIONS")]
    Options = 1,

    /// <summary>
    /// Derivatives orders.
    /// </summary>
    [Map("DERIVATIVES")]
    Derivatives = 2,

    /// <summary>
    /// Spot orders.
    /// </summary>
    [Map("SPOT")]
    Spot = 3,
}
