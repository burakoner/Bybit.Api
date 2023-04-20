namespace Bybit.Api.Enums;

public enum BybitAccount
{
    [Label("SPOT")]
    Spot,

    [Label("CONTRACT")]
    Contract,

    [Label("INVESTMENT")]
    Investment,

    [Label("OPTION")]
    Option,

    [Label("UNIFIED")]
    Unified,

    [Label("FUND")]
    Fund,
}