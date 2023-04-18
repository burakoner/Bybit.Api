using Bybit.Api.Models.Trade;

namespace Bybit.Api.Clients.RestApi;

public class BybitTradeRestApiClient
{
    // Market Endpoints
    protected string v5OrderCreateEndpoint = "v5/order/create";
    protected string v5OrderAmendEndpoint = "v5/order/amend";
    protected string v5OrderCancelEndpoint = "v5/order/cancel";
    protected string v5OrderRealtimeEndpoint = "v5/order/realtime";
    protected string v5OrderCancelAllEndpoint = "v5/order/cancel-all";
    protected string v5OrderHistoryEndpoint = "v5/order/history";
    protected string v5OrderCreateBatchEndpoint = "v5/order/create-batch";
    protected string v5OrderAmendBatchEndpoint = "v5/order/amend-batch";
    protected string v5OrderCancelBatchEndpoint = "v5/order/cancel-batch";
    protected string v5OrderSpotBorrowCheckEndpoint = "v5/order/spot-borrow-check";
    protected string v5OrderDisconnectedCancelAllEndpoint = "v5/order/disconnected-cancel-all";

    // Internal
    internal BybitRestApiClient RootClient { get; }
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return RootClient.CI; } }

    internal BybitTradeRestApiClient(BybitRestApiClient root)
    {
        this.RootClient = root;
        this.MainClient = root.MainClient;
    }

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
        BybitOrderTimeInForce? timeInForce = null,
        BybitOrderPositionIndex? positionIndex = null,
        string orderLinkId = "",
        decimal? takeProfitPrice = null,
        decimal? stopLossPrice = null,
        BybitTriggerPrice? takeProfitTriggerBy = null,
        BybitTriggerPrice? stopLossTriggerBy = null,
        bool? reduceOnly = null,
        bool? closeOnTrigger = null,
        bool? mmp = null,
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
        if (isLeverage.HasValue) parameters.AddOptionalParameter("isLeverage", isLeverage.Value ? 1 : 0);
        parameters.AddOptionalParameter("price", price?.ToString(CI));
        parameters.AddOptionalParameter("triggerDirection", triggerDirection?.GetLabel());
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("triggerPrice", triggerPrice?.ToString(CI));
        parameters.AddOptionalParameter("triggerBy", triggerBy?.GetLabel());
        parameters.AddOptionalParameter("orderIv", orderImpliedVolatility?.ToString(CI));
        parameters.AddOptionalParameter("timeInForce", timeInForce?.GetLabel());
        parameters.AddOptionalParameter("positionIdx", positionIndex?.GetLabel());
        parameters.AddOptionalParameter("orderLinkId", orderLinkId);
        parameters.AddOptionalParameter("takeProfit", takeProfitPrice?.ToString(CI));
        parameters.AddOptionalParameter("stopLoss", stopLossPrice?.ToString(CI));
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTriggerBy?.GetLabel());
        parameters.AddOptionalParameter("reduceOnly", reduceOnly);
        parameters.AddOptionalParameter("closeOnTrigger", closeOnTrigger);
        parameters.AddOptionalParameter("mmp", mmp);

        return await MainClient.SendBybitRequest<BybitOrderResponse>(MainClient.GetUri(v5OrderCreateEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitOrderResponse>> AmendOrderAsync(
        BybitCategory category,
        string symbol,
        long? orderId = null,
        string orderLinkId = "",

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
        parameters.AddOptionalParameter("orderLinkId", orderLinkId);
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
        long? orderId = null,
        string orderLinkId = "",
        BybitOrderFilter? orderFilter = null,

        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", orderLinkId);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());

        return await MainClient.SendBybitRequest<BybitOrderResponse>(MainClient.GetUri(v5OrderCancelEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOrder>>> GetOpenOrdersAsync(
        BybitCategory category,
        string symbol = "",
        string baseCoin = "",
        string settleCoin = "",
        long? orderId = null,
        string orderLinkId = "",
        BybitQueryOpenOnly? openOnly = null,
        BybitOrderFilter? orderFilter = null,
        int? limit = null,
        string cursor = "",
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("settleCoin", settleCoin);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", orderLinkId);
        parameters.AddOptionalParameter("openOnly", openOnly?.GetLabel());
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOrder>>(MainClient.GetUri(v5OrderRealtimeEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiListResponse<BybitOrderResponse>>> CancelAllOrdersAsync(
        BybitCategory category,
        string symbol = "",
        string baseCoin = "",
        string settleCoin = "",
        BybitOrderFilter? orderFilter = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("settleCoin", settleCoin);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());

        return await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitOrderResponse>>(MainClient.GetUri(v5OrderCancelAllEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOrder>>> GetOrderHistoryAsync(
        BybitCategory category,
        string symbol = "",
        string baseCoin = "",
        long? orderId = null,
        string orderLinkId = "",
        BybitOrderFilter? orderFilter = null,
        BybitOrderStatus? orderStatus = null,
        long? startTimestamp = null,
        long? endTimestamp = null,
        int? limit = null,
        string cursor = "",
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("orderLinkId", orderLinkId);
        parameters.AddOptionalParameter("orderFilter", orderFilter?.GetLabel());
        parameters.AddOptionalParameter("orderStatus", orderStatus?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTimestamp);
        parameters.AddOptionalParameter("endTime", endTimestamp);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOrder>>(MainClient.GetUri(v5OrderHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiResponse<BybitRestApiListResponse<BybitBatchPlaceOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>>> PlaceBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchPlaceOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        return await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchPlaceOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderCreateBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiResponse<BybitRestApiListResponse<BybitBatchAmendOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>>> AmendBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchAmendOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        return await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchAmendOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderAmendBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiResponse<BybitRestApiListResponse<BybitBatchCancelOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>>> CancelBatchOrdersAsync(
        BybitCategory category,
        IEnumerable<BybitBatchCancelOrderRequest> requests,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "request", requests },
        };

        return await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBatchCancelOrderResponse>, BybitRestApiListResponse<BybitBatchOrderError>>(MainClient.GetUri(v5OrderCancelBatchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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

}