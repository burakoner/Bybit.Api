namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Contract Type
/// </summary>
public enum BybitContractType
{
    /// <summary>
    /// InversePerpetual
    /// </summary>
    [Map("InversePerpetual")]
    InversePerpetual = 1,

    /// <summary>
    /// LinearPerpetual
    /// </summary>
    [Map("LinearPerpetual")]
    LinearPerpetual = 2,

    /// <summary>
    /// InverseFutures
    /// </summary>
    [Map("InverseFutures")]
    InverseFutures = 3,

    /// <summary>
    /// LinearFutures
    /// </summary>
    [Map("LinearFutures")]
    LinearFutures = 4,
}