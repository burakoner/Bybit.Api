namespace Bybit.Api.Enums;

public enum BybitOrderStatus
{
    [Label("Created")]
    Created,

    [Label("New")]
    New,

    [Label("Rejected")]
    Rejected,

    [Label("PartiallyFilled")]
    PartiallyFilled,

    [Label("PartiallyFilledCanceled")]
    PartiallyFilledCanceled,

    [Label("Filled")]
    Filled,

    [Label("Cancelled")]
    Cancelled,

    [Label("Untriggered")]
    Untriggered,

    [Label("Triggered")]
    Triggered,

    [Label("Deactivated")]
    Deactivated,

    [Label("Active")]
    Active,
}