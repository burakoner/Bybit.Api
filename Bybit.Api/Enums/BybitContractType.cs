namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Contract Type
/// </summary>
public enum BybitContractType
{
    /// <summary>
    /// InversePerpetual
    /// </summary>
    [Label("InversePerpetual")]
    InversePerpetual,

    /// <summary>
    /// LinearPerpetual
    /// </summary>
    [Label("LinearPerpetual")]
    LinearPerpetual,

    /// <summary>
    /// LinearFutures
    /// </summary>
    [Label("LinearFutures")]
    LinearFutures,

    /// <summary>
    /// InverseFutures
    /// </summary>
    [Label("InverseFutures")]
    InverseFutures,
}