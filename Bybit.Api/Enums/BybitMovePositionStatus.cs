namespace Bybit.Api.Enums;

/// <summary>
/// Bybit move position status
/// </summary>
public enum BybitMovePositionStatus
{
    /// <summary>
    /// Processing
    /// </summary>
    [Label("Processing")]
    Processing,

    /// <summary>
    /// Filled
    /// </summary>
    [Label("Filled")]
    Filled,

    /// <summary>
    /// Rejected
    /// </summary>
    [Label("Rejected")]
    Rejected
}