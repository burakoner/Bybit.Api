namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card point direction.
/// </summary>
public enum BybitCardPointSide
{
    /// <summary>
    /// Earn points.
    /// </summary>
    [Map("1")]
    Earn = 1,

    /// <summary>
    /// Deduct points.
    /// </summary>
    [Map("2")]
    Deduct = 2,
}
