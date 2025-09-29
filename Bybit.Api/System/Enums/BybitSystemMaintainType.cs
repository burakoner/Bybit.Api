namespace Bybit.Api.System;

/// <summary>
/// Bybit System Maintain Type
/// </summary>
public enum BybitSystemMaintainType
{
    /// <summary>
    /// Planned maintenance
    /// </summary>
    [Map("1")]
    PlannedMaintenance = 1,

    /// <summary>
    /// Temporary maintenance
    /// </summary>
    [Map("2")]
    TemporaryMaintenance = 2,

    /// <summary>
    /// Incident
    /// </summary>
    [Map("3")]
    Incident = 3,
}