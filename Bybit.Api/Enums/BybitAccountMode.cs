namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Account Mode
/// </summary>
public enum BybitAccountMode
{
    /// <summary>
    /// Classic Account
    /// </summary>
    [Label("1")]
    Classic,
    
    /// <summary>
    /// UMA
    /// </summary>
    [Label("2")]
    UMA,
    
    /// <summary>
    /// UTA
    /// </summary>
    [Label("3")]
    UTA,
}