namespace Bybit.Api.Enums;

public enum BybitInstrumentStatus
{
    [Label("PreLaunch")]
    PreLaunch,

    [Label("Trading")]
    Trading,

    [Label("Settling")]
    Settling,

    [Label("Delivering")]
    Delivering,

    [Label("Closed")]
    Closed,
}