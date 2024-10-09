namespace Bybit.Api.Market;

/// <summary>
/// Bybit Withdrawal Type
/// </summary>
public enum BybitPreListingPhase
{
    /// <summary>
    /// Pre-market trading is not started
    /// </summary>
    [Map("NotStarted")]
    NotStarted= 1,

    /// <summary>
    /// Pre-market trading is finished
    /// After the auction, if the pre-market contract fails to enter continues trading phase, it will be delisted and phase="Finished"
    /// After the continuous trading, if the pre-market contract fails to be converted to official contract, it will be delisted and phase="Finished"
    /// </summary>
    [Map("Finished")]
    Finished = 2,

    /// <summary>
    /// Auction phase of pre-market trading
    /// only timeInForce=GTC, orderType=Limit order is allowed to submit
    /// TP/SL are not supported; Conditional orders are not supported
    /// cannot modify the order at this stage
    /// order price range: [preOpenPrice x 0.5, maxPrice]
    /// </summary>
    [Map("CallAuction")]
    CallAuction = 3,

    /// <summary>
    /// Auction no cancel phase of pre-market trading
    /// only timeInForce=GTC, orderType=Limit order is allowed to submit
    /// TP/SL are not supported; Conditional orders are not supported
    /// cannot modify and cancel the order at this stage
    /// order price range: Buy [lastPrice x 0.5, markPrice x 1.1], Sell [markPrice x 0.9, maxPrice]
    /// </summary>
    [Map("CallAuctionNoCancel")]
    CallAuctionNoCancel = 4,

    /// <summary>
    /// cross matching phase
    /// cannot create, modify and cancel the order at this stage
    /// Candle data is released from this stage
    /// </summary>
    [Map("CrossMatching")]
    CrossMatching = 5,

    /// <summary>
    /// Continuous trading phase
    /// There is no restriction to create, amend, cancel orders
    /// orderbook, public trade data is released from this stage
    /// </summary>
    [Map("ContinuousTrading")]
    ContinuousTrading = 6,
}