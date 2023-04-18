namespace Bybit.Api.Enums;

public enum BybitContractType
{
    [Label("InversePerpetual")]
    InversePerpetual,

    [Label("LinearPerpetual")]
    LinearPerpetual,

    [Label("LinearFutures")]
    LinearFutures,

    [Label("InverseFutures")]
    InverseFutures,
}