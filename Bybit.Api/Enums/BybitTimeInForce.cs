namespace Bybit.Api.Enums;

public enum BybitTimeInForce
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