namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Sub Account Status
/// </summary>
public enum BybitSubAccountStatus
{
    /// <summary>
    /// Normal
    /// </summary>
    [Map("1")]
    Normal = 1,

    /// <summary>
    /// Banned
    /// </summary>
    [Map("2")]
    LoginBanned = 2,

    /// <summary>
    /// Frozen
    /// </summary>
    [Map("4")]
    Frozen = 4,
}