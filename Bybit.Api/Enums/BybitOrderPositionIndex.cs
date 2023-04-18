namespace Bybit.Api.Enums;

public enum BybitOrderPositionIndex
{
    [Label("0")]
    OneWayModePosition,

    [Label("1")]
    BuySideOfHedgeModePosition,

    [Label("2")]
    SellSideOfHedgeModePosition,
}