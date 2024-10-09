namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Kline Interval
/// </summary>
public enum BybitInterval
{
    /// <summary>
    /// One Minute
    /// </summary>
    [Map("1")]
    OneMinute = 60,

    /// <summary>
    /// Three Minutes
    /// </summary>
    [Map("3")]
    ThreeMinutes = 180,

    /// <summary>
    /// Five Minutes
    /// </summary>
    [Map("5")]
    FiveMinutes = 300,

    /// <summary>
    /// Fifteen Minutes
    /// </summary>
    [Map("15")]
    FifteenMinutes = 900,

    /// <summary>
    /// Thirty Minutes
    /// </summary>
    [Map("30")]
    ThirtyMinutes = 1800,

    /// <summary>
    /// One Hour
    /// </summary>
    [Map("60")]
    OneHour = 3600,

    /// <summary>
    /// Two Hours
    /// </summary>
    [Map("120")]
    TwoHours = 7200,

    /// <summary>
    /// Four Hours
    /// </summary>
    [Map("240")]
    FourHours = 14400,

    /// <summary>
    /// Six Hours
    /// </summary>
    [Map("360")]
    SixHours = 21600,

    /// <summary>
    /// Twelve Hours
    /// </summary>
    [Map("720")]
    TwelveHours = 43200,

    /// <summary>
    /// One Day
    /// </summary>
    [Map("D")]
    OneDay = 86400,

    /// <summary>
    /// One Week
    /// </summary>
    [Map("W")]
    OneWeek = 604800,

    /// <summary>
    /// One Month
    /// </summary>
    [Map("M")]
    OneMonth = 2592000,
}