namespace Bybit.Api.Enums;

/// <summary>
/// Bybit RFQ status.
/// </summary>
public enum BybitRfqStatus
{
    /// <summary>
    /// Active.
    /// </summary>
    [Map("Active")]
    Active = 1,

    /// <summary>
    /// Pending fill.
    /// </summary>
    [Map("PendingFill")]
    PendingFill = 2,

    /// <summary>
    /// Canceled.
    /// </summary>
    [Map("Canceled")]
    Canceled = 3,

    /// <summary>
    /// Filled.
    /// </summary>
    [Map("Filled")]
    Filled = 4,

    /// <summary>
    /// Expired.
    /// </summary>
    [Map("Expired")]
    Expired = 5,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("Failed")]
    Failed = 6,
}
