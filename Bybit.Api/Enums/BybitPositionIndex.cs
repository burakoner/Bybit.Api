namespace Bybit.Api.Enums;

public enum BybitPositionIndex
{
    [Label("0")]
    OneWayModePosition,

    [Label("1")]
    BuySideOfHedgeModePosition,

    [Label("2")]
    SellSideOfHedgeModePosition,
}