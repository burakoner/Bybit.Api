namespace Bybit.Api.Enums;

public enum BybitExecutionType
{
    [Label("Trade")]
    Trade,

    [Label("AdlTrade")]
    AutoDeleveraging,

    [Label("Funding")]
    Funding,

    [Label("BustTrade")]
    BustTrade,

    [Label("Delivery")]
    Delivery,

    [Label("BlockTrade")]
    BlockTrade,
}