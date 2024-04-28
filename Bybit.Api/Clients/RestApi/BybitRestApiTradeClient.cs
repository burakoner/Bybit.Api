using Bybit.Api.Models.Trade;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Rest API Trade Client
/// </summary>
public class BybitRestApiTradeClient
{
    // Trade Endpoints
    private const string _v5OrderCreateEndpoint = "v5/order/create";
    private const string _v5OrderAmendEndpoint = "v5/order/amend";
    private const string _v5OrderCancelEndpoint = "v5/order/cancel";
    private const string _v5OrderRealtimeEndpoint = "v5/order/realtime";
    private const string _v5OrderCancelAllEndpoint = "v5/order/cancel-all";
    private const string _v5OrderHistoryEndpoint = "v5/order/history";
    private const string _v5ExecutionListEndpoint = "/v5/execution/list";
    private const string _v5OrderCreateBatchEndpoint = "v5/order/create-batch";
    private const string _v5OrderAmendBatchEndpoint = "v5/order/amend-batch";
    private const string _v5OrderCancelBatchEndpoint = "v5/order/cancel-batch";
    private const string _v5OrderSpotBorrowCheckEndpoint = "v5/order/spot-borrow-check";
    private const string _v5OrderDisconnectedCancelAllEndpoint = "v5/order/disconnected-cancel-all";

    // Internal
    internal BybitRestApiBaseClient MainClient { get; }

    internal BybitRestApiTradeClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }

    #region Trade Methods
    /// <summary>
    /// This endpoint supports to create the order for spot, spot margin, USDT perpetual, USDC perpetual, USDC futures, inverse futures and options.
    /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/create-order" /></para>
    /// 
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// INFO
    /// 
    /// Supported order type (orderType):
    /// Limit order: orderType=Limit, it is necessary to specify order qty and price.
    /// Market order: orderType=Market, execute at the best price in the Bybit market until the transaction is completed. When selecting a market order, the "price" can be empty. In the futures trading system, in order to protect the serious slippage of the market order, the Bybit trading system will convert the market order into a limit order for matching. will be cancelled. The slippage threshold refers to the percentage that the order price deviates from the latest transaction price. The current threshold is set to 3% for BTC contracts and 5% for other contracts.
    /// 
    /// Supported timeInForce strategy:
    /// GTC
    /// IOC
    /// FOK
    /// PostOnly: If the order would be filled immediately when submitted, it will be cancelled. The purpose of this is to protect your order during the submission process. If the matching system cannot entrust the order to the order book due to price changes on the market, it will be cancelled. For the PostOnly order type, the quantity that can be submitted in a single order is more than other types of orders, please refer to the parameter lotSizeFilter > postOnlyMaxOrderQty in the instruments-info endpoint.
    /// 
    /// How to create conditional order:
    /// When submitting an order, if triggerPrice is set, the order will be automatically converted into a conditional order. In addition, the conditional order does not occupy the margin. If the margin is insufficient after the conditional order is triggered, the order will be cancelled.
    /// Take profit / Stop loss: You can set TP/SL while placing orders. Besides, you could modify the position's TP/SL.
    /// Order quantity: The quantity of perpetual contracts you are going to buy/sell. For the order quantity, Bybit only supports positive number at present
    /// Order price: Place a limit order, this parameter is required. If you have position, the price should be higher than the liquidation price. For the minimum unit of the price change, please refer to the priceFilter > tickSize field in the instruments-info endpoint.
    /// orderLinkId: You can customize the active order ID. We can link this ID to the order ID in the system. Once the active order is successfully created, we will send the unique order ID in the system to you. Then, you can use this order ID to cancel active orders, and if both orderId and orderLinkId are entered in the parameter input, Bybit will prioritize the orderId to process the corresponding order. Meanwhile, your customized order ID should be no longer than 36 characters and should be unique.
    /// Open orders up limit:
    /// Futures: Each account can hold a maximum of 500 active orders simultaneously. This is contract-specific, so the following situation is allowed: the same account can hold 300 BTCUSD active orders and 280 ETHUSD active orders at the same time. For conditional orders, each account can hold a maximum of 10 active orders simultaneously. When the upper limit of orders is reached, you can still place orders with parameters of reduceOnly or closeOnTrigger.
    /// Spot: 500 orders in total, including a maximum of 30 open TP/SL orders, a maximum of 30 open conditional orders
    /// Option: a maximum of 50 open orders
    /// 
    /// Rate limit:
    /// Please refer to rate limit table. If you need to raise the rate limit, please contact your client manager or submit an application via here
    /// Risk control limit notice:
    /// Bybit will monitor on your API requests. When the total number of orders of a single user (aggregated the number of orders across main account and sub-accounts) within a day (UTC 0 - UTC 24) exceeds a certain upper limit, the platform will reserve the right to remind, warn, and impose necessary restrictions. Customers who use API default to acceptance of these terms and have the obligation to cooperate with adjustments.
    /// 
    /// SPOT STOP ORDER
    /// Spot supports TP/SL order, Conditional order, however, the system logic is different between Classic account and Unified account
    /// Classic account: When the stop order is created, you will get an order ID. After it is triggered, you will get a new order ID
    /// Unified account: When the stop order is created, you will get an order ID. After it is triggered, the order ID will not be changed
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="side">Buy, Sell</param>
    /// <param name="type">Market, Limit</param>
    /// <param name="quantity">Order quantity. For Spot Market Buy order, please note that qty should be quote curreny amount</param>
    /// <param name="marketUnit">The unit for qty when create Spot market orders for UTA account. Currently, TP/SL and conditional orders are not supported.
    /// baseCoin: for example, buy BTCUSDT, then "qty" unit is BTC
    /// quoteCoin: for example, sell BTCUSDT, then "qty" unit is USDT</param>
    /// <param name="price">Order price. If you have net position, price needs to be greater than liquidation price</param>
    /// <param name="clientOrderId">User customised order ID. A max of 36 characters. Combinations of numbers, letters (upper and lower cases), dashes, and underscores are supported.
    /// • Future orderLinkId rules:
    /// »» optional param
    /// »» The same orderLinkId can be used for both USDC PERP and USDT PERP.
    /// »» An orderLinkId can be reused once the original order is either Filled or Cancelled
    /// • Option orderLinkId rules:
    /// »» required param
    /// »» always unique</param>
    /// <param name="isLeverage">Whether to borrow. Valid for Unified spot only. 0(default): false then spot trading, 1: true then margin trading</param>
    /// <param name="triggerDirection">Conditional order param. Used to identify the expected direction of the conditional order.</param>
    /// <param name="orderFilter">Valid for spot only. Order,tpslOrder. If not passed, Order by default</param>
    /// <param name="triggerPrice">
    /// • For futures, it is the conditional order trigger price. <br/>
    /// »» If you expect the price to rise to trigger your conditional order, make sure: triggerPrice &gt; market price <br/>
    /// »» Else, triggerPrice &lt; market price <br/>
    /// • For spot, it is the TP/SL order trigger price
    /// </param>
    /// <param name="triggerBy">Conditional order param. Trigger price type. LastPrice, IndexPrice, MarkPrice</param>
    /// <param name="orderIv">Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well</param>
    /// <param name="timeInForce">Time in force. Market order will use IOC directly. If not passed, GTC is used by default</param>
    /// <param name="positionIndex">Used to identify positions in different position modes. Under hedge-mode, this param is required</param>
    /// <param name="reduceOnly">What is a reduce-only order? true means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set</param>
    /// <param name="closeOnTrigger">What is a close on trigger order? For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
    /// <param name="mmp">Market maker protection. option only. true means set the order as a market maker protection order. What is mmp?</param>
    /// <param name="smp">Smp execution type. What is SMP?</param>
    /// <param name="takeProfitStopLossMode">TP/SL mode
    /// Full: entire position for TP/SL. Then, tpOrderType or slOrderType must be Market
    /// Partial: partial position tp/sl (as there is no size option, so it will create tp/sl orders with the qty you actually fill). Limit TP/SL order are supported. Note: When create limit tp/sl, tpslMode is required and it must be Partial
    /// Valid for linear &amp; inverse</param>
    /// <param name="takeProfitOrderType">The order type when take profit is triggered
    /// linear & inverse: Market(default), Limit. For tpslMode=Full, it only supports tpOrderType=Market
    /// Spot(UTA):
    /// Market: when you set "takeProfit",
    /// Limit: when you set "takeProfit" and "tpLimitPrice"</param>
    /// <param name="takeProfitTriggerBy">The price type to trigger take profit. MarkPrice, IndexPrice, default: LastPrice</param>
    /// <param name="takeProfitPrice">Take profit price
    /// linear &amp; inverse: support UTA and classic account
    /// spot(UTA): Spot Limit order supports take profit, stop loss or limit take profit, limit stop loss when creating an order</param>
    /// <param name="takeProfitLimitPrice">The limit order price when take profit price is triggered
    /// linear & inverse: only works when tpslMode=Partial and tpOrderType=Limit
    /// Spot(UTA): it is required when the order has takeProfit and tpOrderType=Limit</param>
    /// <param name="stopLossOrderType">The order type when stop loss is triggered
    /// linear &amp; inverse: Market(default), Limit. For tpslMode=Full, it only supports slOrderType=Market
    /// Spot(UTA):
    /// Market: when you set "stopLoss",
    /// Limit: when you set "stopLoss" and "slLimitPrice"</param>
    /// <param name="stopLossTriggerBy">The price type to trigger stop loss. MarkPrice, IndexPrice, default: LastPrice</param>
    /// <param name="stopLossPrice">Stop loss price</param>
    /// <param name="stopLossLimitPrice">The limit order price when stop loss price is triggered
    /// linear & inverse: only works when tpslMode=Partial and slOrderType=Limit
    /// Spot(UTA): it is required when the order has stopLoss and slOrderType=Limit</param>
    /// <param name="takeProfitPrice">Take profit price</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitOrderId>> PlaceOrderAsync(
        BybitCategory category,
        string symbol,

        BybitOrderSide side,
        BybitOrderType type,
        decimal quantity,
        BybitMarketUnit? marketUnit = null,
        decimal? price = null,
        string clientOrderId = null,
        bool? isLeverage = null,

        BybitTriggerDirection? triggerDirection = null,
        BybitOrderFilter? orderFilter = null,
        decimal? triggerPrice = null,
        BybitTriggerPrice? triggerBy = null,
        decimal? orderIv = null,
        BybitTimeInForce? timeInForce = null,
        BybitPositionIndex? positionIndex = null,

        bool? reduceOnly = null,
        bool? closeOnTrigger = null,
        bool? mmp = null,
        BybitSelfMatchPrevention? smp = null,

        BybitTakeProfitStopLossMode? takeProfitStopLossMode = null,
        BybitOrderType? takeProfitOrderType = null,
        BybitTriggerPrice? takeProfitTriggerBy = null,
        decimal? takeProfitPrice = null,
        decimal? takeProfitLimitPrice = null,

        BybitOrderType? stopLossOrderType = null,
        BybitTriggerPrice? stopLossTriggerBy = null,
        decimal? stopLossPrice = null,
        decimal? stopLossLimitPrice = null,

        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "side", side.GetLabel() },
            { "orderType", type.GetLabel() },
            { "qty", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("marketUnit", marketUnit?.GetLabel());
        parameters.AddOptionalParameter("isLeverage", isLeverage != null ? isLeverage == true ? 1 : 0 : null);

        parameters.AddOptionalParameter("price", price?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("triggerDirection", triggerDirection?.GetLabel());
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("triggerBy", triggerBy?.GetLabel());
        parameters.AddOptionalParameter("orderIv", orderIv?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("timeInForce", timeInForce?.GetLabel());
        parameters.AddOptionalParameter("positionIdx", positionIndex?.GetLabel());

        parameters.AddOptionalParameter("reduceOnly", reduceOnly);
        parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
        parameters.AddOptionalParameter("mmp", mmp);
        parameters.AddOptionalParameter("smpType", smp?.GetLabel());

        parameters.AddOptionalParameter("tpslMode", takeProfitStopLossMode?.GetLabel());
        parameters.AddOptionalParameter("tpOrderType", takeProfitOrderType?.GetLabel());
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("tpLimitPrice", takeProfitLimitPrice?.ToString(BybitConstants.BybitCultureInfo));

        parameters.AddOptionalParameter("slOrderType", stopLossOrderType?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("slLimitPrice", stopLossLimitPrice?.ToString(BybitConstants.BybitCultureInfo));

        return await MainClient.SendBybitRequest<BybitOrderId>(MainClient.GetUri(_v5OrderCreateEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Amend Order
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// IMPORTANT
    /// You can only modify unfilled or partially filled orders.
    /// 
    /// WEBSOCKET LOGIC FOR SPOT
    /// Classic account: if the original Spot order is a PostOnly order, and after the modification, the order becomes a taker order, then you will receive orderStatus="New" ws message first, followed by orderStatus="Rejected" ws message.
    /// Unified account: if the original Spot order is a PostOnly order, and after the modification, the order becomes a taker order, then you will directly receive orderStatus="Rejected" ws message.
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: linear, inverse, spot, option
    /// Classic account: linear, inverse, spot</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="orderId">Order ID. Either orderId or clientOrderId is required</param>
    /// <param name="clientOrderId">User customised order ID. Either orderId or clientOrderId is required</param>
    /// <param name="orderIv">Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed</param>
    /// <param name="quantity">Order quantity after modification. Do not pass it if not modify the qty</param>
    /// <param name="price">Order price after modification. Do not pass it if not modify the price</param>
    /// <param name="triggerPrice">For Perps & Futures, it is the conditional order trigger price. If you expect the price to rise to trigger your conditional order, make sure:
    /// triggerPrice > market price
    /// Else, triggerPrice &lt; market price
    /// For spot, it is the TP/SL and Conditional order trigger price</param>
    /// <param name="triggerBy">Trigger price type</param>
    /// <param name="takeProfitStopLossMode">TP/SL mode
    /// Full: entire position for TP/SL. Then, tpOrderType or slOrderType must be Market
    /// Partial: partial position tp/sl. Limit TP/SL order are supported. Note: When create limit tp/sl, tpslMode is required and it must be Partial
    /// Valid for linear & inverse</param>
    /// <param name="takeProfitTriggerBy">The price type to trigger take profit. When set a take profit, this param is required if no initial value for the order</param>
    /// <param name="takeProfitPrice">Take profit price after modification. If pass "0", it means cancel the existing take profit of the order. Do not pass it if you do not want to modify the take profit. valid for spot(UTA), linear, inverse</param>
    /// <param name="takeProfitLimitPrice">Limit order price when take profit is triggered. Only working when original order sets partial limit tp/sl. valid for spot(UTA), linear, inverse</param>
    /// <param name="stopLossTriggerBy">The price type to trigger stop loss. When set a take profit, this param is required if no initial value for the order</param>
    /// <param name="stopLossPrice">Stop loss price after modification. If pass "0", it means cancel the existing stop loss of the order. Do not pass it if you do not want to modify the stop loss. valid for spot(UTA), linear, inverse</param>
    /// <param name="stopLossLimitPrice">Limit order price when stop loss is triggered. Only working when original order sets partial limit tp/sl. valid for spot(UTA), linear, inverse</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitOrderId>> AmendOrderAsync(
        BybitCategory category,
        string symbol,
        string orderId = null,
        string clientOrderId = null,

        decimal? orderIv = null,
        decimal? quantity = null,
        decimal? price = null,

        decimal? triggerPrice = null,
        BybitTriggerPrice? triggerBy = null,
        BybitTakeProfitStopLossMode? takeProfitStopLossMode = null,

        BybitTriggerPrice? takeProfitTriggerBy = null,
        decimal? takeProfitPrice = null,
        decimal? takeProfitLimitPrice = null,

        BybitTriggerPrice? stopLossTriggerBy = null,
        decimal? stopLossPrice = null,
        decimal? stopLossLimitPrice = null,

        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("orderIv", orderIv?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("qty", quantity?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("price", price?.ToString(BybitConstants.BybitCultureInfo));

        parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("triggerBy", triggerBy?.GetLabel());
        parameters.AddOptionalParameter("tpslMode", takeProfitStopLossMode?.GetLabel());

        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("tpLimitPrice", takeProfitLimitPrice?.ToString(BybitConstants.BybitCultureInfo));

        parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(BybitConstants.BybitCultureInfo));
        parameters.AddOptionalParameter("slLimitPrice", stopLossLimitPrice?.ToString(BybitConstants.BybitCultureInfo));

        return await MainClient.SendBybitRequest<BybitOrderId>(MainClient.GetUri(_v5OrderAmendEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel Order
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// IMPORTANT
    /// You must specify orderId or orderLinkId to cancel the order.
    /// If orderId and orderLinkId do not match, the system will process orderId first.
    /// You can only cancel unfilled or partially filled orders.
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="orderId">Order ID. Either orderId or orderLinkId is required</param>
    /// <param name="clientOrderId">User customised order ID. Either orderId or orderLinkId is required</param>
    /// <param name="orderFilter">Valid for spot only. Order,tpslOrder,StopOrder. If not passed, Order by default</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitOrderId>> CancelOrderAsync(
        BybitCategory category,
        string symbol,
        string orderId = null,
        string clientOrderId = null,
        BybitOrderFilter? orderFilter = null,

        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());

        return await MainClient.SendBybitRequest<BybitOrderId>(MainClient.GetUri(_v5OrderCancelEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Open Orders
    /// Query unfilled or partially filled orders in real-time. To query older order records, please use the order history interface.
    /// 
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// TIP
    /// This endpoint also allows for querying filled, canceled, and rejected orders to the most recent 500 orders for spot, linear, and option categories. The inverse category is not subject to this limitation.
    /// You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
    /// The records are sorted by the createdTime from newest to oldest.
    /// 
    /// INFO
    /// Classic account spot can return open orders only
    /// After a server release or restart, filled, canceled, and rejected orders of Unified account should only be queried through order history.
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse</param>
    /// <param name="symbol">Symbol name. For linear, either symbol, baseCoin, settleCoin is required</param>
    /// <param name="baseAsset">Base coin
    /// Supports linear, inverse & option
    /// option: it returns all option open orders by default</param>
    /// <param name="settleAsset">Settle coin
    /// linear: either symbol, baseCoin or settleCoin is required
    /// spot: not supported</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">User customised order ID</param>
    /// <param name="openOnly">Unified account & Classic account: 0(default) - query open orders only
    /// Unified account - spot / linear / option: 1
    /// Unified account - inverse & Classic account - linear / inverse: 2
    /// return cancelled, rejected or totally filled orders, a maximum of 500 records are kept under each account. If the Bybit service is restarted due to an update, this part of the data will be cleared and accumulated again, but the order records will still be queried in order history
    /// Classic spot: not supported</param>
    /// <param name="orderFilter">Order: active order, StopOrder: conditional order for Futures and Spot, tpslOrder: spot TP/SL order, OcoOrder: Spot oco order, BidirectionalTpslOrder: Spot bidirectional TPSL order
    /// Classic account spot: return Order active order by default
    /// Others: all kinds of orders by default</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitCursorResponse<BybitOrder>>> GetOpenOrdersAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string settleAsset = null,
        string orderId = null,
        string clientOrderId = null,
        BybitQueryOpenOnly? openOnly = null,
        BybitOrderFilter? orderFilter = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("settleCoin", settleAsset);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("openOnly", openOnly?.GetLabel());
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitOrder>>(MainClient.GetUri(_v5OrderRealtimeEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel all open orders
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// INFO
    /// Support cancel orders by symbol/baseCoin/settleCoin. If you pass multiple of these params, the system will process one of param, which priority is symbol > baseCoin > settleCoin.
    /// NOTE: category=option, you can cancel all option open orders without passing any of those three params. However, for linear and inverse, you must specify one of those three params
    /// NOTE: category=spot, you can cancel all spot open orders (normal order by default) without passing other params.
    /// 
    /// INFO
    /// Spot: Classic account - cancel up to 500 orders; Unified account - no limit
    /// Futures: Classic account - cancel up to 500 orders; Unified account - cancel up to 500 orders
    /// Options: Unified account - no limit
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse</param>
    /// <param name="symbol">Symbol name. linear & inverse: Required if not passing baseCoin or settleCoin</param>
    /// <param name="baseAsset">Base coin
    /// linear &amp; inverse(Classic account): If cancel all by baseCoin, it will cancel all linear & inverse orders. Required if not passing symbol or settleCoin
    /// linear &amp; inverse(Unified account): If cancel all by baseCoin, it will cancel all corresponding category orders. Required if not passing symbol or settleCoin
    /// Classic spot: invalid</param>
    /// <param name="settleAsset">Settle coin
    /// linear &amp; inverse: Required if not passing symbol or baseCoin
    /// Does not support spot</param>
    /// <param name="orderFilter">category=spot, you can pass Order, tpslOrder, StopOrder, OcoOrder, BidirectionalTpslOrder. If not passed, Order by default
    /// category=linear or inverse, you can pass Order, StopOrder. If not passed, all kinds of orders will be cancelled, like active order, conditional order, TP/SL order and trailing stop order
    /// category=option, you can pass Order. No matter it is passed or not, always cancel all orders</param>
    /// <param name="stopOrderType">Stop order type Stop
    /// Only used for category=linear or inverse and orderFilter=StopOrder,you can cancel conditional orders except TP/SL order and Trailing stop orders with this param</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<IEnumerable<BybitOrderId>>> CancelOrdersAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string settleAsset = null,
        BybitOrderFilter? orderFilter = null,
        BybitStopOrderType? stopOrderType = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("settleCoin", settleAsset);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("stopOrderType", stopOrderType?.GetLabel());

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitOrderId>>(MainClient.GetUri(_v5OrderCancelAllEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitOrderId>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get Order History
    /// Query order history. As order creation/cancellation is asynchronous, the data returned from this endpoint may delay. If you want to get real-time order information, you could query this endpoint or rely on the websocket stream (recommended).
    /// 
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// TIP
    /// The orders in the last 7 days: UTA(linear,spot,option) supports querying all closed status except "Cancelled", "Rejected", "Deactivated" status, UTA(inverse) and Classic account supports querying all status
    /// 24 hours: UTA(linear,spot,option) for the orders with "Cancelled" (fully cancelled order), "Rejected", "Deactivated" can query last 24 hours data
    /// The orders beyond 7 days: supports querying orders which have fills only, i.e., fully filled, partial filled but cancelled finally orders can be queried.
    /// You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
    /// 
    /// INFO
    /// Classic Spot: can get closed order status only
    /// Classic Spot: market maker can only get recent 3 days order history, please go to web to export. Retail client can get up to 180 days data
    /// Classic Spot: Cancelled, Rejected, Deactivated orders save up to 7 days
    /// Unified account (linear, spot, option) supports getting the past 730 days historical data
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="baseAsset">Base coin. Unified account - inverse & Classic account does not support this param</param>
    /// <param name="settleAsset">Settle coin. Unified account - inverse & Classic account does not support this param</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">User customised order ID</param>
    /// <param name="orderFilter">Order: active order, StopOrder: conditional order for Futures and Spot, tpslOrder: spot TP/SL order, OcoOrder: Spot OCO orders, BidirectionalTpslOrder: Bidirectional TPSL order
    /// Classic account spot: return Order active order by default
    /// Others: all kinds of orders by default</param>
    /// <param name="orderStatus">Classic spot: not supported
    /// UTA(linear,spot,option): return all closed status orders if not passed
    /// UTA(inverse) and classic account: return all status orders if not passed</param>
    /// <param name="startTime">The start timestamp (ms). Classic spot trading does not support startTime and endTime
    /// startTime and endTime are not passed, return 7 days by default
    /// Only startTime is passed, return range between startTime and startTime+7 days
    /// Only endTime is passed, return range between endTime-7 days and endTime
    /// If both are passed, the rule is endTime - startTime <= 7 days</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitCursorResponse<BybitOrder>>> GetOrderHistoryAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string settleAsset = null,
        string orderId = null,
        string clientOrderId = null,
        BybitOrderFilter? orderFilter = null,
        BybitOrderStatus? orderStatus = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("settleCoin", settleAsset);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("orderStatus", orderStatus?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitOrder>>(MainClient.GetUri(_v5OrderHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Trade History
    /// Query users' execution records, sorted by execTime in descending order. However, for Classic spot, they are sorted by execId in descending order.
    /// 
    /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
    /// Classic account covers: Spot / USDT perpetual / Inverse contract
    /// 
    /// TIP
    /// Response items will have sorting issues When 'execTime' is the same, it is recommended to sort according to execId+OrderId+leavesQty. This issue is currently being optimized and will be released. If you want to receive real-time execution information, Use the websocket stream (recommended).
    /// You may have multiple executions in a single order.
    /// You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
    /// 
    /// INFO
    /// Classic Spot supports getting the past 180 days historical data
    /// Unified account (linear, spot, option) supports getting the past 730 days historical data
    /// </summary>
    /// <param name="category">Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">User customised order ID. Classic account does not support this param</param>
    /// <param name="baseAsset">Base coin. Unified account - inverse and Classic account do not support this param</param>
    /// <param name="startTime">The start timestamp (ms)
    /// Classic Spot: supports the interval up to 180 days
    /// Others:
    /// - startTime and endTime are not passed, return 7 days by default;
    /// - Only startTime is passed, return range between startTime and startTime+7 days;
    /// - Only endTime is passed, return range between endTime-7 days and endTime;
    /// - If both are passed, the rule is endTime - startTime <= 7 days</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="executionType">Execution type. Classic spot is not supported</param>
    /// <param name="limit">Limit for data size per page. [1, 100]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitCursorResponse<BybitExecution>>> GetTradeHistoryAsync(
        BybitCategory category,
        string symbol = null,
        string orderId = null,
        string clientOrderId = null,
        string baseAsset = null,
        long? startTime = null,
        long? endTime = null,
        BybitExecutionType? executionType = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);
        var parameters = new Dictionary<string, object>()
        {
            { "category", category.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("execType", executionType?.GetLabel());
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitExecution>>(MainClient.GetUri(_v5ExecutionListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Batch Place Order
    /// Covers: Spot (UTA, UTA Pro) / Option (UTA, UTA Pro) / USDT Perpetual, USDC Perpetual, USDC Futures (UTA Pro)
    /// 
    /// TIP
    /// This endpoint allows you to place more than one order in a single request.
    /// - Make sure you have sufficient funds in your account when placing an order. Once an order is placed, according to the funds required by the order, the funds in your account will be frozen by the corresponding amount during the life cycle of the order.
    /// - A maximum of 20 orders (option) & 10 orders (linear) & 10 orders (spot) can be placed per request. The returned data list is divided into two lists. The first list indicates whether or not the order creation was successful and the second list details the created order information. The structure of the two lists are completely consistent.
    /// 
    /// INFO
    /// Check the rate limit instruction when category=linear or spot here
    /// Risk control limit notice:
    /// Bybit will monitor on your API requests. When the total number of orders of a single user (aggregated the number of orders across main account and sub-accounts) within a day (UTC 0 - UTC 24) exceeds a certain upper limit, the platform will reserve the right to remind, warn, and impose necessary restrictions. Customers who use API default to acceptance of these terms and have the obligation to cooperate with adjustments.
    /// </summary>
    /// <param name="category">Product type. linear, option, spot</param>
    /// <param name="requests">Order Requests</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchError>>>> PlaceBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchPlaceOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitBatchPlaceOrderResponse>, BybitListResponse<BybitBatchError>>(MainClient.GetUri(_v5OrderCreateBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchError>>
        {
            Result = result.Data.Result.Payload,
            ReturnExtraInfo = result.Data.ReturnExtraInfo.Payload
        });
    }

    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchError>>>> AmendBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchAmendOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitBatchAmendOrderResponse>, BybitListResponse<BybitBatchError>>(MainClient.GetUri(_v5OrderAmendBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchError>>
        {
            Result = result.Data.Result.Payload,
            ReturnExtraInfo = result.Data.ReturnExtraInfo.Payload
        });
    }

    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchError>>>> CancelBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchCancelOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitBatchCancelOrderResponse>, BybitListResponse<BybitBatchError>>(MainClient.GetUri(_v5OrderCancelBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchError>>
        {
            Result = result.Data.Result.Payload,
            ReturnExtraInfo = result.Data.ReturnExtraInfo.Payload
        });
    }

    public async Task<RestCallResult<BybitBorrowQuota>> GetBorrowQuotaAsync(
        BybitCategory category,
        string symbol,
        BybitOrderSide side,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Spot))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "side", side.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitBorrowQuota>(MainClient.GetUri(_v5OrderSpotBorrowCheckEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<object>> SetDisconnectCancelAllAsync(
        BybitCategory category,
        int timeWindow,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "timeWindow", timeWindow },
        };

        return await MainClient.SendBybitRequest<object>(MainClient.GetUri(_v5OrderDisconnectedCancelAllEndpoint), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
    #endregion

}
