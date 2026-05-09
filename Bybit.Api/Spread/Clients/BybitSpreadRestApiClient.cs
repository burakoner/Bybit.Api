namespace Bybit.Api.Spread;

/// <summary>
/// Bybit REST API Spread Trading client.
/// </summary>
public class BybitSpreadRestApiClient
{
    private const string _v5SpreadInstrument = "v5/spread/instrument";
    private const string _v5SpreadOrderbook = "v5/spread/orderbook";
    private const string _v5SpreadTickers = "v5/spread/tickers";
    private const string _v5SpreadRecentTrade = "v5/spread/recent-trade";
    private const string _v5SpreadOrderCreate = "v5/spread/order/create";
    private const string _v5SpreadOrderAmend = "v5/spread/order/amend";
    private const string _v5SpreadOrderCancel = "v5/spread/order/cancel";
    private const string _v5SpreadOrderCancelAll = "v5/spread/order/cancel-all";
    private const string _v5SpreadOrderRealtime = "v5/spread/order/realtime";
    private const string _v5SpreadOrderHistory = "v5/spread/order/history";
    private const string _v5SpreadExecutionList = "v5/spread/execution/list";
    private const string _v5SpreadMaxQuantity = "v5/spread/max-qty";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitSpreadRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Query spread instruments.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="baseAsset">Base asset.</param>
    /// <param name="limit">Data size per page. [1, 500].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadInstrument>>> GetInstrumentsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetInstrumentsAsync(new BybitSpreadInstrumentRequest
        {
            Symbol = symbol,
            BaseAsset = baseAsset,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query spread instruments.
    /// </summary>
    /// <param name="request">Spread instrument query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadInstrument>>> GetInstrumentsAsync(BybitSpreadInstrumentRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 500);

        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("baseCoin", request.BaseAsset);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadInstrument>>(_.BuildUri(_v5SpreadInstrument), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadInstrument>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query spread orderbook depth data.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="limit">Limit size for each bid and ask. [1, 25].</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadOrderbook>> GetOrderbookAsync(string symbol, int? limit = null, CancellationToken ct = default)
    {
        return GetOrderbookAsync(new BybitSpreadOrderbookRequest(symbol)
        {
            Limit = limit,
        }, ct);
    }

    /// <summary>
    /// Query spread orderbook depth data.
    /// </summary>
    /// <param name="request">Spread orderbook query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadOrderbook>> GetOrderbookAsync(BybitSpreadOrderbookRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 25);

        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddOptional("limit", request.Limit);

        return await _.SendBybitRequest<BybitSpreadOrderbook>(_.BuildUri(_v5SpreadOrderbook), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query spread tickers.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadTicker>>> GetTickersAsync(string symbol, CancellationToken ct = default)
        => GetTickersAsync(new BybitSpreadTickerRequest(symbol), ct);

    /// <summary>
    /// Query spread tickers.
    /// </summary>
    /// <param name="request">Spread ticker query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadTicker>>> GetTickersAsync(BybitSpreadTickerRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadTicker>>(_.BuildUri(_v5SpreadTickers), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadTicker>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query recent public spread trades.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="limit">Data size per page. [1, 1000].</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadPublicTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default)
    {
        return GetRecentTradesAsync(new BybitSpreadRecentTradeRequest(symbol)
        {
            Limit = limit,
        }, ct);
    }

    /// <summary>
    /// Query recent public spread trades.
    /// </summary>
    /// <param name="request">Spread recent trade query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadPublicTrade>>> GetRecentTradesAsync(BybitSpreadRecentTradeRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 1000);

        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddOptional("limit", request.Limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadPublicTrade>>(_.BuildUri(_v5SpreadRecentTrade), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadPublicTrade>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Place a spread order.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="orderType">Order type.</param>
    /// <param name="quantity">Order quantity.</param>
    /// <param name="price">Order price.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="timeInForce">Time in force.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadOrderId>> PlaceOrderAsync(string symbol, BybitOrderSide side, BybitOrderType orderType, decimal quantity, decimal? price = null, string? clientOrderId = null, BybitTimeInForce? timeInForce = null, CancellationToken ct = default)
    {
        return PlaceOrderAsync(new BybitSpreadPlaceOrderRequest(symbol, side, orderType, quantity)
        {
            Price = price,
            ClientOrderId = clientOrderId,
            TimeInForce = timeInForce,
        }, ct);
    }

    /// <summary>
    /// Place a spread order.
    /// </summary>
    /// <param name="request">Spread place order request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadOrderId>> PlaceOrderAsync(BybitSpreadPlaceOrderRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddEnum("side", request.Side);
        parameters.AddEnum("orderType", request.OrderType);
        parameters.AddString("qty", request.Quantity);
        parameters.AddOptionalString("price", request.Price);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);
        parameters.AddOptionalEnum("timeInForce", request.TimeInForce);

        return await _.SendBybitRequest<BybitSpreadOrderId>(_.BuildUri(_v5SpreadOrderCreate), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Amend a spread order.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="orderId">Spread combination order ID.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="quantity">Amended order quantity.</param>
    /// <param name="price">Amended order price.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadOrderId>> AmendOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, decimal? quantity = null, decimal? price = null, CancellationToken ct = default)
    {
        return AmendOrderAsync(new BybitSpreadAmendOrderRequest(symbol)
        {
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            Quantity = quantity,
            Price = price,
        }, ct);
    }

    /// <summary>
    /// Amend a spread order.
    /// </summary>
    /// <param name="request">Spread amend order request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadOrderId>> AmendOrderAsync(BybitSpreadAmendOrderRequest request, CancellationToken ct = default)
    {
        ValidateOrderIdentifier(request.OrderId, request.ClientOrderId);
        if (request.Quantity == null && request.Price == null)
            throw new ArgumentException("Either Quantity or Price is required.", nameof(request));

        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);
        parameters.AddOptionalString("qty", request.Quantity);
        parameters.AddOptionalString("price", request.Price);

        return await _.SendBybitRequest<BybitSpreadOrderId>(_.BuildUri(_v5SpreadOrderAmend), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel a spread order.
    /// </summary>
    /// <param name="orderId">Spread combination order ID.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadOrderId>> CancelOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
    {
        return CancelOrderAsync(new BybitSpreadCancelOrderRequest
        {
            OrderId = orderId,
            ClientOrderId = clientOrderId,
        }, ct);
    }

    /// <summary>
    /// Cancel a spread order.
    /// </summary>
    /// <param name="request">Spread cancel order request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadOrderId>> CancelOrderAsync(BybitSpreadCancelOrderRequest request, CancellationToken ct = default)
    {
        ValidateOrderIdentifier(request.OrderId, request.ClientOrderId);

        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);

        return await _.SendBybitRequest<BybitSpreadOrderId>(_.BuildUri(_v5SpreadOrderCancel), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel spread orders.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="cancelAll">Whether to cancel all spread orders across symbols.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadCancelAllOrders>> CancelAllOrdersAsync(string? symbol = null, bool? cancelAll = null, CancellationToken ct = default)
    {
        return CancelAllOrdersAsync(new BybitSpreadCancelAllOrdersRequest
        {
            Symbol = symbol,
            CancelAll = cancelAll,
        }, ct);
    }

    /// <summary>
    /// Cancel spread orders.
    /// </summary>
    /// <param name="request">Spread cancel all orders request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadCancelAllOrders>> CancelAllOrdersAsync(BybitSpreadCancelAllOrdersRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(request.Symbol) && request.CancelAll != true)
            throw new ArgumentException("Either Symbol or CancelAll=true is required.", nameof(request));

        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("cancelAll", request.CancelAll);

        return await _.SendBybitRequest<BybitSpreadCancelAllOrders>(_.BuildUri(_v5SpreadOrderCancelAll), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query open spread orders.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="baseAsset">Base asset.</param>
    /// <param name="orderId">Spread combination order ID.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadOrder>>> GetOpenOrdersAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetOpenOrdersAsync(new BybitSpreadOrderQueryRequest
        {
            Symbol = symbol,
            BaseAsset = baseAsset,
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query open spread orders.
    /// </summary>
    /// <param name="request">Spread open order query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadOrder>>> GetOpenOrdersAsync(BybitSpreadOrderQueryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = CreateOrderQueryParameters(request.Symbol, request.BaseAsset, request.OrderId, request.ClientOrderId, request.Limit, request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadOrder>>(_.BuildUri(_v5SpreadOrderRealtime), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query spread order history.
    /// </summary>
    /// <param name="request">Spread order history query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadOrder>>> GetOrderHistoryAsync(BybitSpreadOrderHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = CreateOrderQueryParameters(request.Symbol, request.BaseAsset, request.OrderId, request.ClientOrderId, request.Limit, request.Cursor);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadOrder>>(_.BuildUri(_v5SpreadOrderHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query spread order history.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="baseAsset">Base asset.</param>
    /// <param name="orderId">Spread combination order ID.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadOrder>>> GetOrderHistoryAsync(string? symbol = null, string? baseAsset = null, string? orderId = null, string? clientOrderId = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetOrderHistoryAsync(new BybitSpreadOrderHistoryRequest
        {
            Symbol = symbol,
            BaseAsset = baseAsset,
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query spread trade history.
    /// </summary>
    /// <param name="request">Spread trade history query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSpreadExecution>>> GetTradeHistoryAsync(BybitSpreadTradeHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = CreateOrderQueryParameters(request.Symbol, null, request.OrderId, request.ClientOrderId, request.Limit, request.Cursor);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSpreadExecution>>(_.BuildUri(_v5SpreadExecutionList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSpreadExecution>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query spread trade history.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    /// <param name="orderId">Spread combination order ID.</param>
    /// <param name="clientOrderId">Client order ID.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitSpreadExecution>>> GetTradeHistoryAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetTradeHistoryAsync(new BybitSpreadTradeHistoryRequest
        {
            Symbol = symbol,
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query the maximum spread order quantity.
    /// </summary>
    /// <param name="symbol">Spread symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="orderPrice">Order price.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitSpreadMaxOrderQuantity>> GetMaxOrderQuantityAsync(string symbol, BybitSpreadMaxQuantitySide side, decimal orderPrice, CancellationToken ct = default)
        => GetMaxOrderQuantityAsync(new BybitSpreadMaxOrderQuantityRequest(symbol, side, orderPrice), ct);

    /// <summary>
    /// Query the maximum spread order quantity.
    /// </summary>
    /// <param name="request">Spread maximum order quantity request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpreadMaxOrderQuantity>> GetMaxOrderQuantityAsync(BybitSpreadMaxOrderQuantityRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddEnum("side", request.Side);
        parameters.AddString("orderPrice", request.OrderPrice);

        return await _.SendBybitRequest<BybitSpreadMaxOrderQuantity>(_.BuildUri(_v5SpreadMaxQuantity), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    private static ParameterCollection CreateOrderQueryParameters(string? symbol, string? baseAsset, string? orderId, string? clientOrderId, int? limit, string? cursor)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("orderLinkId", clientOrderId);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);
        return parameters;
    }

    private static void ValidateOrderIdentifier(string? orderId, string? clientOrderId)
    {
        if (string.IsNullOrEmpty(orderId) && string.IsNullOrEmpty(clientOrderId))
            throw new ArgumentException("Either OrderId or ClientOrderId is required.");
    }
}
