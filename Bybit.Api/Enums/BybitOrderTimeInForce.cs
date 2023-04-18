namespace Bybit.Api.Enums;

public enum BybitOrderTimeInForce
{
    [Label("GTC")]
    GoodTillCancel,

    [Label("IOC")]
    ImmediateOrCancel,

    [Label("FOK")]
    FillOrKill,

    [Label("PostOnly")]
    PostOnly,
}