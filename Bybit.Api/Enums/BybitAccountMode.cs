namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Account Mode
/// </summary>
public enum BybitAccountMode
{
    /// <summary>
    /// Classic Account
    /// </summary>
    [Map("1")]
    Classic = 1,
    
    /// <summary>
    /// UMA
    /// </summary>
    [Map("2")]
    UMA = 2,
    
    /// <summary>
    /// UTA
    /// </summary>
    [Map("3")]
    UTA = 3,

    /// <summary>
    /// UTA 1.0 Pro
    /// </summary>
    [Map("4")]
    UTA1Pro = 4,

    /// <summary>
    /// UTA 2.0
    /// </summary>
    [Map("5")]
    UTA2 = 5,

    /// <summary>
    /// UTA 2.0 Pro
    /// </summary>
    [Map("6")]
    UTA2Pro = 6,
}
