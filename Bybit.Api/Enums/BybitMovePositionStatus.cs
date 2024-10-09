namespace Bybit.Api.Enums;

/// <summary>
/// Bybit move position status
/// </summary>
public enum BybitMovePositionStatus
{
    /// <summary>
    /// Processing
    /// </summary>
    [Map("Processing")]
    Processing = 1,

    /// <summary>
    /// Filled
    /// </summary>
    [Map("Filled")]
    Filled = 2,

    /// <summary>
    /// Rejected
    /// </summary>
    [Map("Rejected")]
    Rejected = 3
}