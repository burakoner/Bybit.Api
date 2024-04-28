namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Reject Reason
/// </summary>
public enum BybitOrderRejectReason
{
    /// <summary>
    /// No Error
    /// </summary>
    [Label("EC_NoError")]
    NoError,

    /// <summary>
    /// Others
    /// </summary>
    [Label("EC_Others")]
    Others,

    /// <summary>
    /// Unknown message type
    /// </summary>
    [Label("EC_UnknownMessageType")]
    UnknownMessageType,

    /// <summary>
    /// Missing Client Order Id
    /// </summary>
    [Label("EC_MissingClOrdID")]
    MissingClOrdID,

    /// <summary>
    /// Missing Original Client Order Id
    /// </summary>
    [Label("EC_MissingOrigClOrdID")]
    MissingOrigClOrdID,

    /// <summary>
    /// Client Order Id and Original Client Order Id are the same
    /// </summary>
    [Label("EC_ClOrdIDOrigClOrdIDAreTheSame")]
    ClOrdIDOrigClOrdIDAreTheSame,

    /// <summary>
    /// Duplicated Client Order Id
    /// </summary>
    [Label("EC_DuplicatedClOrdID")]
    DuplicatedClOrdID,

    /// <summary>
    /// Original Client Order Id does not exist
    /// </summary>
    [Label("EC_OrigClOrdIDDoesNotExist")]
    OrigClOrdIDDoesNotExist,

    /// <summary>
    /// Too Late To Cancel
    /// </summary>
    [Label("EC_TooLateToCancel")]
    TooLateToCancel,

    /// <summary>
    /// Unknown Order Type
    /// </summary>
    [Label("EC_UnknownOrderType")]
    UnknownOrderType,

    /// <summary>
    /// Unknown Order Side
    /// </summary>
    [Label("EC_UnknownSide")]
    UnknownSide,

    /// <summary>
    /// Unknown Time In Force
    /// </summary>
    [Label("EC_UnknownTimeInForce")]
    UnknownTimeInForce,

    /// <summary>
    /// Wrongly Routed
    /// </summary>
    [Label("EC_WronglyRouted")]
    WronglyRouted,

    /// <summary>
    /// Market Order Price Is Not Zero
    /// </summary>
    [Label("EC_MarketOrderPriceIsNotZero")]
    MarketOrderPriceIsNotZero,

    /// <summary>
    /// Invalid Price for Limit Order
    /// </summary>
    [Label("EC_LimitOrderInvalidPrice")]
    LimitOrderInvalidPrice,

    /// <summary>
    /// Not Enough Quantity to Fill
    /// </summary>
    [Label("EC_NoEnoughQtyToFill")]
    NoEnoughQtyToFill,

    /// <summary>
    /// No Immediate Quantity to Fill
    /// </summary>
    [Label("EC_NoImmediateQtyToFill")]
    NoImmediateQtyToFill,

    /// <summary>
    /// Per Cancel Request
    /// </summary>
    [Label("EC_PerCancelRequest")]
    PerCancelRequest,

    /// <summary>
    /// Market Order Cannot Be Post Only
    /// </summary>
    [Label("EC_MarketOrderCannotBePostOnly")]
    MarketOrderCannotBePostOnly,

    /// <summary>
    /// Post Only will take liquidity
    /// </summary>
    [Label("EC_PostOnlyWillTakeLiquidity")]
    PostOnlyWillTakeLiquidity,

    /// <summary>
    /// Cancel Replace Order
    /// </summary>
    [Label("EC_CancelReplaceOrder")]
    CancelReplaceOrder,

    /// <summary>
    /// Invalid Symbol Status
    /// </summary>
    [Label("EC_InvalidSymbolStatus")]
    InvalidSymbolStatus,

    /// <summary>
    /// Cancel For No Full Fill
    /// </summary>
    [Label("EC_CancelForNoFullFill")]
    CancelForNoFullFill,
}