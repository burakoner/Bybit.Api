namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Record Interval
/// </summary>
public enum BybitRecordPeriod
{
    /// <summary>
    /// Five Minutes
    /// </summary>
    [Map("5min")]
    FiveMinutes = 300,

    /// <summary>
    /// Fifteen Minutes
    /// </summary>
    [Map("15min")]
    FifteenMinutes = 900,

    /// <summary>
    /// Thirty Minutes
    /// </summary>
    [Map("30min")]
    ThirtyMinutes = 1800,

    /// <summary>
    /// One Hour
    /// </summary>
    [Map("1h")]
    OneHour = 3600,

    /// <summary>
    /// Four Hours
    /// </summary>
    [Map("4h")]
    FourHours = 14400,

    /// <summary>
    /// One Day
    /// </summary>
    [Map("1d")]
    OneDay = 86400,
}