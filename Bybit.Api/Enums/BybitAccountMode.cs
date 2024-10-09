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
}