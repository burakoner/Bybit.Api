namespace Bybit.Api.Enums;

public enum BybitOrderRejectReason
{
    [Label("EC_NoError")]
    NoError,

    [Label("EC_Others")]
    Others,

    [Label("EC_UnknownMessageType")]
    UnknownMessageType,

    [Label("EC_MissingClOrdID")]
    MissingClOrdID,

    [Label("EC_MissingOrigClOrdID")]
    MissingOrigClOrdID,

    [Label("EC_ClOrdIDOrigClOrdIDAreTheSame")]
    ClOrdIDOrigClOrdIDAreTheSame,

    [Label("EC_DuplicatedClOrdID")]
    DuplicatedClOrdID,

    [Label("EC_OrigClOrdIDDoesNotExist")]
    OrigClOrdIDDoesNotExist,

    [Label("EC_TooLateToCancel")]
    TooLateToCancel,

    [Label("EC_UnknownOrderType")]
    UnknownOrderType,

    [Label("EC_UnknownSide")]
    UnknownSide,

    [Label("EC_UnknownTimeInForce")]
    UnknownTimeInForce,

    [Label("EC_WronglyRouted")]
    WronglyRouted,

    [Label("EC_MarketOrderPriceIsNotZero")]
    MarketOrderPriceIsNotZero,

    [Label("EC_LimitOrderInvalidPrice")]
    LimitOrderInvalidPrice,

    [Label("EC_NoEnoughQtyToFill")]
    NoEnoughQtyToFill,

    [Label("EC_NoImmediateQtyToFill")]
    NoImmediateQtyToFill,

    [Label("EC_PerCancelRequest")]
    PerCancelRequest,

    [Label("EC_MarketOrderCannotBePostOnly")]
    MarketOrderCannotBePostOnly,

    [Label("EC_PostOnlyWillTakeLiquidity")]
    PostOnlyWillTakeLiquidity,

    [Label("EC_CancelReplaceOrder")]
    CancelReplaceOrder,

    [Label("EC_InvalidSymbolStatus")]
    InvalidSymbolStatus,
}