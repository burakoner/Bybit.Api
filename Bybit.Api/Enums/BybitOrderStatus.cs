namespace Bybit.Api.Enums;

/// <summary>
/// BybitOrderStatus
/// </summary>
public enum BybitOrderStatus
{
    /// <summary>
    /// Created
    /// </summary>
    [Map("Created")]
    Created = 1,

    /// <summary>
    /// New
    /// </summary>
    [Map("New")]
    New = 2,

    /// <summary>
    /// Rejected
    /// </summary>
    [Map("Rejected")]
    Rejected = 3,

    /// <summary>
    /// PartiallyFilled
    /// </summary>
    [Map("PartiallyFilled")]
    PartiallyFilled = 4,

    /// <summary>
    /// PartiallyFilledCanceled
    /// </summary>
    [Map("PartiallyFilledCanceled")]
    PartiallyFilledCanceled = 5,

    /// <summary>
    /// Filled
    /// </summary>
    [Map("Filled")]
    Filled = 6,

    /// <summary>
    /// Cancelled
    /// </summary>
    [Map("Cancelled")]
    Cancelled = 7,

    /// <summary>
    /// Untriggered
    /// </summary>
    [Map("Untriggered")]
    Untriggered = 8,

    /// <summary>
    /// Triggered
    /// </summary>
    [Map("Triggered")]
    Triggered = 9,

    /// <summary>
    /// Deactivated
    /// </summary>
    [Map("Deactivated")]
    Deactivated = 10,

    /// <summary>
    /// Active
    /// </summary>
    [Map("Active")]
    Active = 11,
}