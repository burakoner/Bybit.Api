namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Option Type
/// </summary>
public enum BybitOptionType
{
    /// <summary>
    /// Call
    /// </summary>
    [Map("Call")]
    Call = 1,

    /// <summary>
    /// Put
    /// </summary>
    [Map("Put")]
    Put = 2,
}