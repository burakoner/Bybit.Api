namespace Bybit.Api.Enums;

public enum BybitSubAccountStatus
{
    [Label("1")]
    Normal,

    [Label("2")]
    LoginBanned,

    [Label("4")]
    Frozen,
}