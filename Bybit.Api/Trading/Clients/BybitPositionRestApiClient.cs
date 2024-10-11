namespace Bybit.Api.Trading;

/// <summary>
/// Bybit Rest API Position Client
/// </summary>
public class BybitPositionRestApiClient
{
    // Position Endpoints
    private const string _v5PositionList = "v5/position/list";
    private const string _v5PositionSetLeverage = "v5/position/set-leverage";
    private const string _v5PositionSwitchIsolated = "v5/position/switch-isolated";
    private const string _v5PositionSwitchMode = "v5/position/switch-mode";
    private const string _v5PositionSetRiskLimit = "v5/position/set-risk-limit";
    private const string _v5PositionTradingStop = "v5/position/trading-stop";
    private const string _v5PositionSetAutoAddMargin = "v5/position/set-auto-add-margin";
    private const string _v5PositionAddMargin = "v5/position/add-margin";
    private const string _v5PositionClosedPnl = "v5/position/closed-pnl";
    private const string _v5PositionMovePositions = "v5/position/move-positions";
    private const string _v5PositionMoveHistory = "v5/position/move-history";
    private const string _v5PositionConfirmPendingMmr = "v5/position/confirm-pending-mmr";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitPositionRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    #region Position Methods
    /// <summary>
    /// Get Position Info
    /// Query real-time position data, such as position size, cumulative realizedPNL.
    /// 
    /// Unified account covers: USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: USDT perpetual / Inverse contract
    /// 
    /// INFO
    /// Regarding inverse contracts,
    /// - you can query all holding positions with "/v5/position/list?category=inverse";
    /// - symbol parameter is supported to be passed with multiple symbols up to 10
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse, option
    /// Classic account: linear, inverse</param>
    /// <param name="symbol">Symbol name
    /// If symbol passed, it returns data regardless of having position or not.
    /// If symbol=null and settleCoin specified, it returns position size greater than zero.</param>
    /// <param name="baseAsset">Base coin. option only. Return all option positions if not passed</param>
    /// <param name="settleAsset">Settle coin. For linear, either symbol or settleCoin is required. symbol has a higher priority</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitTradingPosition>>> GetPositionsAsync(
        BybitCategory category, 
        string symbol = null, 
        string baseAsset = null, 
        string settleAsset = null, 
        int? limit = null, 
        string cursor = null, 
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("settleCoin", settleAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitTradingPosition>>(_.BuildUri(_v5PositionList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTradingPosition>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Set the leverage
    /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="buyLeverage">Buy Leverage</param>
    /// <param name="sellLeverage">Sell Leverage</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult> SetLeverageAsync(BybitCategory category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddString("buyLeverage", buyLeverage);
        parameters.AddString("sellLeverage", sellLeverage);

        return await _.SendBybitRequest(_.BuildUri(_v5PositionSetLeverage), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Switch Cross/Isolated Margin
    /// Select cross margin mode or isolated margin mode per symbol level
    /// 
    /// Unified account covers: Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: inverse
    /// Classic account: linear, inverse. Please note that category is not involved with business logic</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="tradeMode">0: cross margin. 1: isolated margin</param>
    /// <param name="buyLeverage"></param>
    /// <param name="sellLeverage"></param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult> SwitchMarginModeAsync(BybitCategory category, string symbol, BybitTradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("tradeMode", tradeMode);
        parameters.AddString("buyLeverage", buyLeverage);
        parameters.AddString("sellLeverage", sellLeverage);

        return await _.SendBybitRequest(_.BuildUri(_v5PositionSwitchIsolated), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Switch Position Mode
    /// It supports to switch the position mode for USDT perpetual and Inverse futures. If you are in one-way Mode, you can only open one position on Buy or Sell side. If you are in hedge mode, you can open both Buy and Sell side positions simultaneously.
    /// Unified account covers: USDT perpetual / Inverse Futures
    /// Classic account covers: USDT perpetual / Inverse Futures
    /// 
    /// TIP
    /// Priority for configuration to take effect: symbol > coin > system default
    /// System default: one-way mode
    /// If the request is by coin (settleCoin), then all symbols based on this setteCoin that do not have position and open order will be batch switched, and new listed symbol based on this settleCoin will be the same mode you set.
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, USDT Perp; inverse, Inverse Futures
    /// Classic account: linear, USDT Perp; inverse, Inverse Futures. Please note that category is not involved with business logic</param>
    /// <param name="mode">Position mode. 0: Merged Single. 3: Both Sides</param>
    /// <param name="symbol">Symbol name. Either symbol or coin is required. symbol has a higher priority</param>
    /// <param name="asset">Coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult> SwitchPositionModeAsync(BybitCategory category, BybitPositionMode mode, string symbol = null, string asset = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("mode", mode);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("coin", asset);

        return await _.SendBybitRequest(_.BuildUri(_v5PositionSwitchMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set Trading Stop
    /// Set the take profit, stop loss or trailing stop for the position.
    /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// 
    /// TIP
    /// Passing these parameters will create conditional orders by the system internally. The system will cancel these orders if the position is closed, and adjust the qty according to the size of the open position.
    /// 
    /// INFO
    /// New version of TP/SL function supports both holding entire position TP/SL orders and holding partial position TP/SL orders.
    /// Full position TP/SL orders: This API can be used to modify the parameters of existing TP/SL orders.
    /// Partial position TP/SL orders: This API can only add partial position TP/SL orders.
    /// 
    /// NOTE
    /// Under the new version of Tp/SL function, when calling this API to perform one-sided take profit or stop loss modification on existing TP/SL orders on the holding position, it will cause the paired tp/sl orders to lose binding relationship. This means that when calling the cancel API through the tp/sl order ID, it will only cancel the corresponding one-sided take profit or stop loss order ID.
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse
    /// Classic account: linear, inverse. Please note that category is not involved with business logic</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="positionIndex">Used to identify positions in different position modes.</param>
    /// <param name="takeProfitStopLossMode">TP/SL mode. Full: entire position TP/SL, Partial: partial position TP/SL</param>
    /// <param name="takeProfitTrigger">Take profit trigger price type</param>
    /// <param name="takeProfitOrderType">The order type when take profit is triggered. Market(default), Limit. For tpslMode=Full, it only supports tpOrderType=Market</param>
    /// <param name="takeProfitPrice">Cannot be less than 0, 0 means cancel TP</param>
    /// <param name="takeProfitLimitPrice">The limit order price when take profit price is triggered. Only works when tpslMode=Partial and tpOrderType=Limit</param>
    /// <param name="takeProfitQuantity">Take profit size. Valid in TP/SL partial mode. Note: the value of tpSize and slSize must equal</param>
    /// <param name="stopLossTrigger">Stop loss trigger price type</param>
    /// <param name="stopLossOrderType">The order type when stop loss is triggered. Market(default), Limit. For tpslMode=Full, it only supports slOrderType=Market</param>
    /// <param name="stopLossPrice">Cannot be less than 0, 0 means cancel SL</param>
    /// <param name="stopLossLimitPrice">The limit order price when stop loss price is triggered. Only works when tpslMode=Partial and slOrderType=Limit</param>
    /// <param name="stopLossQuantity">Stop loss size. Valid in TP/SL partial mode. Note: the value of tpSize and slSize must equal</param>
    /// <param name="trailingStopDistance">Trailing stop by price distance. Cannot be less than 0, 0 means cancel TS</param>
    /// <param name="trailingStopPrice">Trailing stop trigger price. Trailing stop will be triggered when this price is reached only</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult> SetTradingStopAsync(
        BybitCategory category,
        string symbol,
        BybitPositionIndex positionIndex,
        BybitTakeProfitStopLossMode? takeProfitStopLossMode = null,

        BybitTriggerPrice? takeProfitTrigger = null,
        BybitOrderType? takeProfitOrderType = null,
        decimal? takeProfitPrice = null,
        decimal? takeProfitLimitPrice = null,
        decimal? takeProfitQuantity = null,

        BybitTriggerPrice? stopLossTrigger = null,
        BybitOrderType? stopLossOrderType = null,
        decimal? stopLossPrice = null,
        decimal? stopLossLimitPrice = null,
        decimal? stopLossQuantity = null,

        decimal? trailingStopDistance = null,
        decimal? trailingStopPrice = null,

        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("positionIdx", positionIndex);

        parameters.AddOptionalEnum("tpslMode", takeProfitStopLossMode);

        parameters.AddOptionalEnum("tpTriggerBy", takeProfitTrigger);
        parameters.AddOptionalEnum("tpOrderType", takeProfitOrderType);
        parameters.AddOptionalString("takeProfit", takeProfitPrice);
        parameters.AddOptionalString("tpLimitPrice", takeProfitLimitPrice);
        parameters.AddOptionalString("tpSize", takeProfitQuantity);

        parameters.AddOptionalEnum("slTriggerBy", stopLossTrigger);
        parameters.AddOptionalEnum("slOrderType", stopLossOrderType);
        parameters.AddOptionalString("stopLoss", stopLossPrice);
        parameters.AddOptionalString("slLimitPrice", stopLossLimitPrice);
        parameters.AddOptionalString("slSize", stopLossQuantity);

        parameters.AddOptionalString("trailingStop", trailingStopDistance);
        parameters.AddOptionalString("activePrice", trailingStopPrice);

        return await _.SendBybitRequest(_.BuildUri(_v5PositionTradingStop), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Turn on/off auto-add-margin for isolated margin position
    /// Unified account covers: USDT perpetual / USDC perpetual / USDC futures
    /// Classic account covers: USDT perpetual
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear
    /// Classic account: linear</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="autoAddMargin">Turn on/off.</param>
    /// <param name="positionIndex">Used to identify positions in different position modes. For hedge mode position, this param is required</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetAutoAddMarginAsync(
        BybitCategory category,
        string symbol,
        bool autoAddMargin,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.Add("autoAddMargin", autoAddMargin ? 1 : 0);
        parameters.AddOptionalEnum("positionIdx", positionIndex);
        return await _.SendBybitRequest(_.BuildUri(_v5PositionSetAutoAddMargin), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Add Or Reduce Margin
    /// Manually add or reduce margin for isolated margin position
    /// 
    /// Unified account covers: USDT perpetual / USDC perpetual / USDC futures / Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse
    /// Classic account: linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="margin">Add or reduce. To add, then 10; To reduce, then -10. Support up to 4 decimal</param>
    /// <param name="positionIndex">Used to identify positions in different position modes. For hedge mode position, this param is required</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitTradingPosition>> AddMarginAsync(
        BybitCategory category,
        string symbol,
        decimal margin,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddString("margin", margin);
        parameters.AddOptionalEnum("positionIdx", positionIndex);
        return await _.SendBybitRequest<BybitTradingPosition>(_.BuildUri(_v5PositionAddMargin), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Query user's closed profit and loss records
    /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// 
    /// INFO
    /// Classic account: the results are sorted by updatedTime in descending order.
    /// Unified account (except Inverse contract): the results are sorted by createdTime in descending order, this will be constant with classic account afterwards
    /// Unified account (linear, spot, option) supports getting the past 730 days historical data
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse
    /// Classic account: linear, inverse. Please note that category is not involved with business logic</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The start timestamp (ms)
    /// startTime and endTime are not passed, return 7 days by default
    /// Only startTime is passed, return range between startTime and startTime+7 days
    /// Only endTime is passed, return range between endTime-7 days and endTime
    /// If both are passed, the rule is endTime - startTime &lt;= 7 days</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 100]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitTradingProfitAndLoss>>> GetClosedPnlAsync(
        BybitCategory category,
        string symbol = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitTradingProfitAndLoss>>(_.BuildUri(_v5PositionClosedPnl), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTradingProfitAndLoss>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// You can move positions between sub-master, master-sub, or sub-sub UIDs when necessary
    /// Unified account covers: USDT perpetual / USDC contract / Spot / Option
    /// 
    /// INFO
    /// The endpoint can only be called by master UID api key
    /// UIDs must be the same master-sub account relationship
    /// The trades generated from move-position endpoint will not be displayed in the Recent Trade (Rest API &amp; Websocket)
    /// There is no trading fee
    /// fromUid and toUid both should be Unified trading accounts, and they need to be one-way mode when moving the positions
    /// Please note that once executed, you will get execType=MovePosition entry from Get Trade History, Get Closed Pnl, and stream from Execution.
    /// </summary>
    /// <param name="fromUid">From UID
    /// Must be UTA
    /// Must be in one-way mode for Futures</param>
    /// <param name="toUid">To UID
    /// Must be UTA
    /// Must be in one-way mode for Futures</param>
    /// <param name="list">Object. Up to 25 legs per request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitTradingMovePosition>> MovePositionsAsync(string fromUid, string toUid, IEnumerable<BybitMovePositionRequest> list, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "fromUid", fromUid },
            { "toUid", toUid },
            { "list", list },
        };

        return await _.SendBybitRequest<BybitTradingMovePosition>(_.BuildUri(_v5PositionMovePositions), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Move Position History
    /// You can query moved position data by master UID api key
    /// Unified account covers: USDT perpetual / USDC contract / Spot / Option
    /// </summary>
    /// <param name="category">Product type. linear, spot, option</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The order creation start timestamp. The interval is 7 days</param>
    /// <param name="endTime">The order creation end timestamp. The interval is 7 days</param>
    /// <param name="status">Order status. Processing, Filled, Rejected</param>
    /// <param name="blockTradeId">Block trade ID</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitTradingMoveHistory>>> GetMoveHistoryAsync(
        BybitCategory category,
        string symbol = null,
        long? startTime = null,
        long? endTime = null,
        BybitMoveStatus? status = null,
        string blockTradeId = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("blockTradeId", blockTradeId);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitTradingMoveHistory>>(_.BuildUri(_v5PositionMoveHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTradingMoveHistory>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Confirm New Risk Limit
    /// It is only applicable when the user is marked as only reducing positions (please see the isReduceOnly field in the Get Position Info interface). After the user actively adjusts the risk level, this interface is called to try to calculate the adjusted risk level, and if it passes (retCode=0), the system will remove the position reduceOnly mark. You are recommended to call Get Position Info to check isReduceOnly field.
    /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
    /// Classic account covers: USDT perpetual / Inverse contract
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse
    /// Classic account: linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> ConfirmNewRiskLimitAsync(BybitCategory category, string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);

        return await _.SendBybitRequest(_.BuildUri(_v5PositionConfirmPendingMmr), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }
    
    #endregion

}