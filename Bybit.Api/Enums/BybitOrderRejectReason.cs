namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Reject Reason
/// </summary>
public enum BybitOrderRejectReason
{
    /// <summary>
    /// No Error
    /// </summary>
    [Map("EC_NoError")]
    NoError = 1,

    /// <summary>
    /// Others
    /// </summary>
    [Map("EC_Others")]
    Others = 2,

    /// <summary>
    /// Unknown message type
    /// </summary>
    [Map("EC_UnknownMessageType")]
    UnknownMessageType = 3,

    /// <summary>
    /// Missing Client Order Id
    /// </summary>
    [Map("EC_MissingClOrdID")]
    MissingClOrdID = 4,

    /// <summary>
    /// Missing Original Client Order Id
    /// </summary>
    [Map("EC_MissingOrigClOrdID")]
    MissingOrigClOrdID = 5,

    /// <summary>
    /// Client Order Id and Original Client Order Id are the same
    /// </summary>
    [Map("EC_ClOrdIDOrigClOrdIDAreTheSame")]
    ClOrdIDOrigClOrdIDAreTheSame = 6,

    /// <summary>
    /// Duplicated Client Order Id
    /// </summary>
    [Map("EC_DuplicatedClOrdID")]
    DuplicatedClOrdID = 7,

    /// <summary>
    /// Original Client Order Id does not exist
    /// </summary>
    [Map("EC_OrigClOrdIDDoesNotExist")]
    OrigClOrdIDDoesNotExist = 8,

    /// <summary>
    /// Too Late To Cancel
    /// </summary>
    [Map("EC_TooLateToCancel")]
    TooLateToCancel = 9,

    /// <summary>
    /// Unknown Order Type
    /// </summary>
    [Map("EC_UnknownOrderType")]
    UnknownOrderType = 10,

    /// <summary>
    /// Unknown Order Side
    /// </summary>
    [Map("EC_UnknownSide")]
    UnknownSide = 11,

    /// <summary>
    /// Unknown Time In Force
    /// </summary>
    [Map("EC_UnknownTimeInForce")]
    UnknownTimeInForce = 12,

    /// <summary>
    /// Wrongly Routed
    /// </summary>
    [Map("EC_WronglyRouted")]
    WronglyRouted = 13,

    /// <summary>
    /// Market Order Price Is Not Zero
    /// </summary>
    [Map("EC_MarketOrderPriceIsNotZero")]
    MarketOrderPriceIsNotZero = 14,

    /// <summary>
    /// Invalid Price for Limit Order
    /// </summary>
    [Map("EC_LimitOrderInvalidPrice")]
    LimitOrderInvalidPrice = 15,

    /// <summary>
    /// Not Enough Quantity to Fill
    /// </summary>
    [Map("EC_NoEnoughQtyToFill")]
    NoEnoughQtyToFill = 16,

    /// <summary>
    /// No Immediate Quantity to Fill
    /// </summary>
    [Map("EC_NoImmediateQtyToFill")]
    NoImmediateQtyToFill = 17,

    /// <summary>
    /// Per Cancel Request
    /// </summary>
    [Map("EC_PerCancelRequest")]
    PerCancelRequest = 18,

    /// <summary>
    /// Market Order Cannot Be Post Only
    /// </summary>
    [Map("EC_MarketOrderCannotBePostOnly")]
    MarketOrderCannotBePostOnly = 19,

    /// <summary>
    /// Post Only will take liquidity
    /// </summary>
    [Map("EC_PostOnlyWillTakeLiquidity")]
    PostOnlyWillTakeLiquidity = 20,

    /// <summary>
    /// Cancel Replace Order
    /// </summary>
    [Map("EC_CancelReplaceOrder")]
    CancelReplaceOrder = 21,

    /// <summary>
    /// Invalid Symbol Status
    /// </summary>
    [Map("EC_InvalidSymbolStatus")]
    InvalidSymbolStatus = 22,

    /// <summary>
    /// Cancel For No Full Fill
    /// </summary>
    [Map("EC_CancelForNoFullFill")]
    CancelForNoFullFill = 23,
}