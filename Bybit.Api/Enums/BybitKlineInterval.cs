namespace Bybit.Api.Enums;

public enum BybitKlineInterval
{
    [Label("1")]
    OneMinute,

    [Label("3")]
    ThreeMinutes,

    [Label("5")]
    FiveMinutes,

    [Label("15")]
    FifteenMinutes,

    [Label("30")]
    ThirtyMinutes,

    [Label("60")]
    OneHour,

    [Label("120")]
    TwoHours,

    [Label("240")]
    FourHours,

    [Label("360")]
    SixHours,

    [Label("720")]
    TwelveHours,

    [Label("D")]
    OneDay,

    [Label("W")]
    OneWeek,

    [Label("M")]
    OneMonth,
}