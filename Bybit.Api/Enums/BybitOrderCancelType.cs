namespace Bybit.Api.Enums;

public enum BybitOrderCancelType
{
    [Label("CancelByUser")]
    CancelByUser,

    [Label("CancelByReduceOnly")]
    CancelByReduceOnly,

    [Label("CancelByPrepareLiq")]
    CancelByPrepareLiq,

    [Label("CancelAllBeforeLiq")]
    CancelAllBeforeLiq,

    [Label("CancelByPrepareAdl")]
    CancelByPrepareAdl,

    [Label("CancelAllBeforeAdl")]
    CancelAllBeforeAdl,

    [Label("CancelByAdmin")]
    CancelByAdmin,

    [Label("CancelByTpSlTsClear")]
    CancelByTpSlTsClear,

    [Label("CancelByPzSideCh")]
    CancelByPzSideCh,
}