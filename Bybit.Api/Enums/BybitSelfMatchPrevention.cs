namespace Bybit.Api.Enums;

public enum BybitSelfMatchPrevention
{
    [Label("None")]
    Default,

    [Label("CancelMaker")]
    CancelMaker,

    [Label("CancelTaker")]
    CancelTaker,

    [Label("CancelBoth")]
    CancelBoth,
}