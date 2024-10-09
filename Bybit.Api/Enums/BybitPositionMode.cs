namespace Bybit.Api.Enums;

/// <summary>
/// Position Mode
/// </summary>
public enum BybitPositionMode
{
    /// <summary>
    /// Merged Single
    /// </summary>
    [Map("0")]
    MergedSingle = 0,

    /// <summary>
    /// Both Sides
    /// </summary>
    [Map("3")]
    BothSides = 3
}
