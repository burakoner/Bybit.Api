namespace Bybit.Api.System;

/// <summary>
/// Bybit System Environment
/// </summary>
public enum BybitSystemEnvironment
{
    /// <summary>
    /// Production
    /// </summary>
    [Map("1")]
    Production = 1,

    /// <summary>
    /// Production Demo service
    /// </summary>
    [Map("2")]
    ProductionDemo = 2,
}