namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Broker business type.
/// </summary>
public enum BybitBrokerBusinessType
{
    /// <summary>
    /// Spot trading.
    /// </summary>
    [Map("SPOT")]
    Spot,

    /// <summary>
    /// Derivatives trading.
    /// </summary>
    [Map("DERIVATIVES")]
    Derivatives,

    /// <summary>
    /// Options trading.
    /// </summary>
    [Map("OPTIONS")]
    Options,

    /// <summary>
    /// Convert trading.
    /// </summary>
    [Map("CONVERT")]
    Convert,
}
