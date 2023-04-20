using ApiSharp.Extensions;
using Bybit.Api.Models.Trading;
using System;
using System.Data;

namespace Bybit.Api.Clients.RestApi;

public class BybitTradingRestApiClient
{
    // Trade Endpoints
    protected const string v5OrderCreateEndpoint = "v5/order/create";
    protected const string v5OrderAmendEndpoint = "v5/order/amend";
    protected const string v5OrderCancelEndpoint = "v5/order/cancel";
    protected const string v5OrderRealtimeEndpoint = "v5/order/realtime";
    protected const string v5OrderCancelAllEndpoint = "v5/order/cancel-all";
    protected const string v5OrderHistoryEndpoint = "v5/order/history";
    protected const string v5OrderCreateBatchEndpoint = "v5/order/create-batch";
    protected const string v5OrderAmendBatchEndpoint = "v5/order/amend-batch";
    protected const string v5OrderCancelBatchEndpoint = "v5/order/cancel-batch";
    protected const string v5OrderSpotBorrowCheckEndpoint = "v5/order/spot-borrow-check";
    protected const string v5OrderDisconnectedCancelAllEndpoint = "v5/order/disconnected-cancel-all";

    // Position Endpoints
    protected const string v5PositionListEndpoint = "v5/position/list";
    protected const string v5PositionSetLeverageEndpoint = "v5/position/set-leverage";
    protected const string v5PositionSwitchIsolatedEndpoint = "v5/position/switch-isolated";
    protected const string v5PositionSetTpslModeEndpoint = "v5/position/set-tpsl-mode";
    protected const string v5PositionSwitchModeEndpoint = "v5/position/switch-mode";
    protected const string v5PositionSetRiskLimitEndpoint = "v5/position/set-risk-limit";
    protected const string v5PositionTradingStopEndpoint = "v5/position/trading-stop";
    protected const string v5PositionSetAutoAddMarginEndpoint = "v5/position/set-auto-add-margin";
    protected const string v5ExecutionListEndpoint = "v5/execution/list";
    protected const string v5PositionClosedPnlEndpoint = "v5/position/closed-pnl";

    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitTradingRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    #region Trade Methods
    /// <summary>
    /// This endpoint supports to create the order for spot, spot margin, USDT perpetual, USDC perpetual, USDC futures, inverse futures and options.
    /// <para><a href="https://bybit-exchange.github.io/docs/v5/order/create-order" /></para>
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="side">Buy, Sell</param>
    /// <param name="type">Market, Limit</param>
    /// <param name="quantity">Order quantity. For Spot Market Buy order, please note that qty should be quote curreny amount</param>
    /// <param name="price">Order price. If you have net position, price needs to be greater than liquidation price</param>
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
    /// <param name="orderImpliedVolatility">Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well</param>
    /// <param name="timeInForce">Time in force. Market order will use IOC directly. If not passed, GTC is used by default</param>
    /// <param name="positionIndex">Used to identify positions in different position modes. Under hedge-mode, this param is required</param>
    /// <param name="clientOrderId">User customised order ID. A max of 36 characters. Combinations of numbers, letters (upper and lower cases), dashes, and underscores are supported.
    /// • Future orderLinkId rules:
    /// »» optional param
    /// »» The same orderLinkId can be used for both USDC PERP and USDT PERP.
    /// »» An orderLinkId can be reused once the original order is either Filled or Cancelled
    /// • Option orderLinkId rules:
    /// »» required param
    /// »» always unique</param>
    /// <param name="takeProfitPrice">Take profit price</param>
    /// <param name="stopLossPrice">Stop loss price</param>
    /// <param name="takeProfitTriggerBy">The price type to trigger take profit. MarkPrice, IndexPrice, default: LastPrice</param>
    /// <param name="stopLossTriggerBy">The price type to trigger stop loss. MarkPrice, IndexPrice, default: LastPrice</param>
    /// <param name="reduceOnly">What is a reduce-only order? true means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set</param>
    /// <param name="closeOnTrigger">What is a close on trigger order? For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.</param>
    /// <param name="mmp">Market maker protection. option only. true means set the order as a market maker protection order. What is mmp?</param>
    /// <param name="smp">Smp execution type. What is SMP?</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitOrderResponse>> PlaceOrderAsync(
        BybitCategory category,
        string symbol,
        BybitOrderSide side,
        BybitOrderType type,
        decimal quantity,
        decimal? price = null,
        bool? isLeverage = null,
        BybitTriggerDirection? triggerDirection = null,
        BybitOrderFilter? orderFilter = null,
        decimal? triggerPrice = null,
        BybitTriggerPrice? triggerBy = null,
        decimal? orderImpliedVolatility = null,
        BybitTimeInForce? timeInForce = null,
        BybitPositionIndex? positionIndex = null,
        string clientOrderId = null,
        decimal? takeProfitPrice = null,
        decimal? stopLossPrice = null,
        BybitTriggerPrice? takeProfitTriggerBy = null,
        BybitTriggerPrice? stopLossTriggerBy = null,
        bool? reduceOnly = null,
        bool? closeOnTrigger = null,
        bool? mmp = null,
        BybitSelfMatchPrevention? smp = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "side", side.GetLabel() },
            { "orderType", type.GetLabel() },
            { "qty", quantity.ToString(CI) },
        };
        parameters.AddOptionalParameter("isLeverage", isLeverage != null ? isLeverage == true ? 1 : 0 : null);
        parameters.AddOptionalParameter("price", price?.ToString(CI));
        parameters.AddOptionalParameter("triggerDirection", triggerDirection?.GetLabel());
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CI));
        parameters.AddOptionalParameter("triggerBy", triggerBy?.GetLabel());
        parameters.AddOptionalParameter("orderIv", orderImpliedVolatility?.ToString(CI));
        parameters.AddOptionalParameter("timeInForce", timeInForce?.GetLabel());
        parameters.AddOptionalParameter("positionIdx", positionIndex?.GetLabel());
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CI));
        parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CI));
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("reduceOnly", reduceOnly);
        parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
        parameters.AddOptionalParameter("mmp", mmp);
        parameters.AddOptionalParameter("smpType", smp?.GetLabel());

        return await MainClient.SendBybitRequest<BybitOrderResponse>(MainClient.GetUri(v5OrderCreateEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitOrderResponse>> AmendOrderAsync(
        BybitCategory category,
        string symbol,
        string orderId = null,
        string clientOrderId = null,

        decimal? orderImpliedVolatility = null,
        decimal? triggerPrice = null,
        decimal? quantity = null,
        decimal? price = null,

        decimal? takeProfitPrice = null,
        decimal? stopLossPrice = null,

        BybitTriggerPrice? takeProfitTriggerBy = null,
        BybitTriggerPrice? stopLossTriggerBy = null,
        BybitTriggerPrice? triggerBy = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("qty", quantity?.ToString(CI));
        parameters.AddOptionalParameter("price", price?.ToString(CI));
        parameters.AddOptionalParameter("orderIv", orderImpliedVolatility?.ToString(CI));
        parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CI));
        parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CI));
        parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CI));
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("triggerBy", triggerBy?.GetLabel());

        return await MainClient.SendBybitRequest<BybitOrderResponse>(MainClient.GetUri(v5OrderAmendEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitOrderResponse>> CancelOrderAsync(
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

        return await MainClient.SendBybitRequest<BybitOrderResponse>(MainClient.GetUri(v5OrderCancelEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOrder>>> GetOpenOrdersAsync(
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

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOrder>>(MainClient.GetUri(v5OrderRealtimeEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitOrderResponse>>> CancelAllOrdersAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string settleAsset = null,
        BybitOrderFilter? orderFilter = null,
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

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitOrderResponse>>(MainClient.GetUri(v5OrderCancelAllEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitOrderResponse>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOrder>>> GetOrderHistoryAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string orderId = null,
        string clientOrderId = null,
        BybitOrderFilter? orderFilter = null,
        BybitOrderStatus? orderStatus = null,
        long? startTimestamp = null,
        long? endTimestamp = null,
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
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", clientOrderId);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("orderStatus", orderStatus?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTimestamp);
        parameters.AddOptionalParameter("endTime", endTimestamp);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOrder>>(MainClient.GetUri(v5OrderHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchOrderError>>>> PlaceBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchPlaceOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchPlaceOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderCreateBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchOrderError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchPlaceOrderResponse>, IEnumerable<BybitBatchOrderError>>
        {
            Result = result.Data.Result.Payload,
            ReturnExtraInfo = result.Data.ReturnExtraInfo.Payload
        });
    }

    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchOrderError>>>> AmendBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchAmendOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchAmendOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderAmendBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchOrderError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchAmendOrderResponse>, IEnumerable<BybitBatchOrderError>>
        {
            Result = result.Data.Result.Payload,
            ReturnExtraInfo = result.Data.ReturnExtraInfo.Payload
        });
    }

    public async Task<RestCallResult<BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchOrderError>>>> CancelBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchCancelOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchCancelOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderCancelBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchOrderError>>>(null);
        return result.As(new BybitRestApiResponse<IEnumerable<BybitBatchCancelOrderResponse>, IEnumerable<BybitBatchOrderError>>
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

        return await MainClient.SendBybitRequest<BybitBorrowQuota>(MainClient.GetUri(v5OrderSpotBorrowCheckEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
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

        return await MainClient.SendBybitRequest<object>(MainClient.GetUri(v5OrderDisconnectedCancelAllEndpoint), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
    #endregion

    #region Position Methods

    public async Task<RestCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(BybitCategory category, string symbol = null, string baseAsset = null, string settleAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("settleCoin", settleAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitPosition>>(MainClient.GetUri(v5PositionListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitPosition>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult> SetLeverageAsync(BybitCategory category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "buyLeverage", buyLeverage.ToString(CI) },
            { "sellLeverage", sellLeverage.ToString(CI) }
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSetLeverageEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SwitchCrossIsolatedMarginAsync(BybitCategory category, string symbol, BybitTradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "tradeMode", tradeMode.GetLabel() },
            { "buyLeverage", buyLeverage.ToString(CI) },
            { "sellLeverage", sellLeverage.ToString(CI) }
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSwitchIsolatedEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitTakeProfitStopLoss>> SetTakeProfitStopLossModeAsync(BybitCategory category, string symbol, BybitTakeProfitStopLossMode tpSlMode, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "tpSlMode", tpSlMode.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTakeProfitStopLoss>(MainClient.GetUri(v5PositionSetTpslModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SwitchPositionModeAsync(BybitCategory category, BybitPositionMode mode, string symbol = null, string asset = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "mode", mode.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("coin", asset);

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSwitchModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRiskLimit>> SetRiskLimitAsync(
        BybitCategory category,
        string symbol,
        long riskId,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "riskId", riskId }
        };

        parameters.AddOptionalParameter("positionIdx", positionIndex.GetLabel());

        return await MainClient.SendBybitRequest<BybitRiskLimit>(MainClient.GetUri(v5PositionSetRiskLimitEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetTradingStopAsync(
        BybitCategory category,
        string symbol,
        BybitPositionIndex positionIndex,
        decimal? takeProfit = null,
        decimal? stopLoss = null,
        decimal? trailingStop = null,
        BybitTriggerPrice? takeProfitTrigger = null,
        BybitTriggerPrice? stopLossTrigger = null,
        decimal? activePrice = null,
        decimal? takeProfitQuantity = null,
        decimal? stopLossQuantity = null,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "positionIdx", positionIndex.GetLabel() }
        };

        parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CI));
        parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CI));
        parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CI));
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTrigger?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTrigger?.GetLabel());
        parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CI));
        parameters.AddOptionalParameter("tpSize", takeProfitQuantity?.ToString(CI));
        parameters.AddOptionalParameter("slSize", stopLossQuantity?.ToString(CI));

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionTradingStopEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetAutoAddMarginAsync(
        BybitCategory category,
        string symbol,
        bool autoAddMargin,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "autoAddMargin", autoAddMargin ? "1" : "0" }
        };

        parameters.AddOptionalParameter("positionIdx", positionIndex?.GetLabel());
        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSetAutoAddMarginEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitUserTrade>>> GetUserTradesAsync(
        BybitCategory category,
        string symbol = null,
        string baseAsset = null,
        string orderId = null,
        string clientOrderId = null,
        long? startTime = null,
        long? endTime = null,
        BybitExecutionType? executionType = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
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

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitUserTrade>>(MainClient.GetUri(v5ExecutionListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitProfitAndLoss>>> GetClosedProfitLossAsync(
        BybitCategory category,
        string symbol = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", EnumConverter.GetString(category) }
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitProfitAndLoss>>(MainClient.GetUri(v5PositionClosedPnlEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
    #endregion

}