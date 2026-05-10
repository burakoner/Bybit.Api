namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Bybit REST API Pre-upgrade client.
/// </summary>
public class BybitPreUpgradeRestApiClient
{
    private const long SevenDaysMilliseconds = 7L * 24 * 60 * 60 * 1000;

    private const string _v5PreUpgradeOrderHistory = "v5/pre-upgrade/order/history";
    private const string _v5PreUpgradeExecutionList = "v5/pre-upgrade/execution/list";
    private const string _v5PreUpgradeClosedPnl = "v5/pre-upgrade/position/closed-pnl";
    private const string _v5PreUpgradeTransactionLog = "v5/pre-upgrade/account/transaction-log";
    private const string _v5PreUpgradeDeliveryRecord = "v5/pre-upgrade/asset/delivery-record";
    private const string _v5PreUpgradeSettlementRecord = "v5/pre-upgrade/asset/settlement-record";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }

    internal BybitPreUpgradeRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get pre-upgrade order history.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="baseAsset">Base coin. Used for option queries.</param>
    /// <param name="orderId">Order ID.</param>
    /// <param name="clientOrderId">User customised order ID.</param>
    /// <param name="orderFilter">Order filter.</param>
    /// <param name="orderStatus">Order status. Not supported for spot.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeOrder>>> GetOrderHistoryAsync(
        BybitCategory category,
        string? symbol = null,
        string? baseAsset = null,
        string? orderId = null,
        string? clientOrderId = null,
        BybitOrderFilter? orderFilter = null,
        BybitOrderStatus? orderStatus = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken ct = default)
    {
        return GetOrderHistoryAsync(new BybitPreUpgradeOrderHistoryRequest(category)
        {
            Symbol = symbol,
            BaseAsset = baseAsset,
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            OrderFilter = orderFilter,
            OrderStatus = orderStatus,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade order history.
    /// </summary>
    /// <param name="request">Pre-upgrade order history request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeOrder>>> GetOrderHistoryAsync(BybitPreUpgradeOrderHistoryRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option, BybitCategory.Spot);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        ValidateRequiredPair(request.StartTime, request.EndTime, nameof(request.StartTime), nameof(request.EndTime));
        ValidateSevenDayWindow(request.StartTime, request.EndTime);

        var parameters = CreateHistoryParameters(request.Category, request.Symbol, request.BaseAsset, request.OrderId, request.ClientOrderId, request.StartTime, request.EndTime, request.Limit, request.Cursor);
        parameters.AddOptionalEnum("orderFilter", request.OrderFilter);
        parameters.AddOptionalEnum("orderStatus", request.OrderStatus);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeOrder>>(_.BuildUri(_v5PreUpgradeOrderHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get pre-upgrade trade history.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="orderId">Order ID.</param>
    /// <param name="clientOrderId">User customised order ID.</param>
    /// <param name="baseAsset">Base coin. Used for option queries.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="executionType">Execution type.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeExecution>>> GetTradeHistoryAsync(
        BybitCategory category,
        string? symbol = null,
        string? orderId = null,
        string? clientOrderId = null,
        string? baseAsset = null,
        long? startTime = null,
        long? endTime = null,
        BybitExecutionType? executionType = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken ct = default)
    {
        return GetTradeHistoryAsync(new BybitPreUpgradeTradeHistoryRequest(category)
        {
            Symbol = symbol,
            OrderId = orderId,
            ClientOrderId = clientOrderId,
            BaseAsset = baseAsset,
            StartTime = startTime,
            EndTime = endTime,
            ExecutionType = executionType,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade trade history.
    /// </summary>
    /// <param name="request">Pre-upgrade trade history request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeExecution>>> GetTradeHistoryAsync(BybitPreUpgradeTradeHistoryRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option, BybitCategory.Spot);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        ValidateSevenDayWindow(request.StartTime, request.EndTime);

        var parameters = CreateHistoryParameters(request.Category, request.Symbol, request.BaseAsset, request.OrderId, request.ClientOrderId, request.StartTime, request.EndTime, request.Limit, request.Cursor);
        parameters.AddOptionalEnum("execType", request.ExecutionType);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeExecution>>(_.BuildUri(_v5PreUpgradeExecutionList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeExecution>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get pre-upgrade closed PnL.
    /// </summary>
    /// <param name="category">Product type. Supports linear and inverse.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeClosedPnl>>> GetClosedPnlAsync(BybitCategory category, string symbol, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetClosedPnlAsync(new BybitPreUpgradeClosedPnlRequest(category, symbol)
        {
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade closed PnL.
    /// </summary>
    /// <param name="request">Pre-upgrade closed PnL request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeClosedPnl>>> GetClosedPnlAsync(BybitPreUpgradeClosedPnlRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Linear, BybitCategory.Inverse);
        ValidateRequired(request.Symbol, nameof(request.Symbol));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        ValidateSevenDayWindow(request.StartTime, request.EndTime);

        var parameters = new ParameterCollection
        {
            { "symbol", request.Symbol },
        };
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeClosedPnl>>(_.BuildUri(_v5PreUpgradeClosedPnl), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeClosedPnl>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get pre-upgrade transaction log.
    /// </summary>
    /// <param name="category">Product type. Supports linear and option.</param>
    /// <param name="baseAsset">Base coin.</param>
    /// <param name="type">Transaction log type.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeTransaction>>> GetTransactionLogAsync(BybitCategory category, string? baseAsset = null, BybitTransactionType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetTransactionLogAsync(new BybitPreUpgradeTransactionLogRequest(category)
        {
            BaseAsset = baseAsset,
            Type = type,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade transaction log.
    /// </summary>
    /// <param name="request">Pre-upgrade transaction log request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeTransaction>>> GetTransactionLogAsync(BybitPreUpgradeTransactionLogRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Linear, BybitCategory.Option);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        ValidateSevenDayWindow(request.StartTime, request.EndTime);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("baseCoin", request.BaseAsset);
        parameters.AddOptionalEnum("type", request.Type);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeTransaction>>(_.BuildUri(_v5PreUpgradeTransactionLog), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeTransaction>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get pre-upgrade option delivery records.
    /// </summary>
    /// <param name="category">Product type. Supports option.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="expiryDate">Expiry date, e.g. 25MAR22.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeDelivery>>> GetDeliveryRecordsAsync(BybitCategory category, string? symbol = null, string? expiryDate = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetDeliveryRecordsAsync(new BybitPreUpgradeDeliveryRecordRequest(category)
        {
            Symbol = symbol,
            ExpiryDate = expiryDate,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade option delivery records.
    /// </summary>
    /// <param name="request">Pre-upgrade delivery record request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeDelivery>>> GetDeliveryRecordsAsync(BybitPreUpgradeDeliveryRecordRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Option);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("expDate", request.ExpiryDate);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeDelivery>>(_.BuildUri(_v5PreUpgradeDeliveryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeDelivery>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get pre-upgrade USDC session settlement records.
    /// </summary>
    /// <param name="category">Product type. Supports linear.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="limit">Data size per page. [1, 50].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitPreUpgradeSettlement>>> GetSettlementRecordsAsync(BybitCategory category, string? symbol = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetSettlementRecordsAsync(new BybitPreUpgradeSettlementRecordRequest(category)
        {
            Symbol = symbol,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get pre-upgrade USDC session settlement records.
    /// </summary>
    /// <param name="request">Pre-upgrade settlement record request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitPreUpgradeSettlement>>> GetSettlementRecordsAsync(BybitPreUpgradeSettlementRecordRequest request, CancellationToken ct = default)
    {
        ValidateCategory(request.Category, BybitCategory.Linear);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitPreUpgradeSettlement>>(_.BuildUri(_v5PreUpgradeSettlementRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitPreUpgradeSettlement>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    private static ParameterCollection CreateHistoryParameters(BybitCategory category, string? symbol, string? baseAsset, string? orderId, string? clientOrderId, long? startTime, long? endTime, int? limit, string? cursor)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("orderLinkId", clientOrderId);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);
        return parameters;
    }

    private static void ValidateCategory(BybitCategory category, params BybitCategory[] allowed)
    {
        if (category.IsNotIn(allowed))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");
    }

    private static void ValidateRequired(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{name} is required.", name);
    }

    private static void ValidateRequiredPair(long? first, long? second, string firstName, string secondName)
    {
        if (first.HasValue != second.HasValue)
            throw new ArgumentException($"{firstName} and {secondName} must be provided together.");
    }

    private static void ValidateSevenDayWindow(long? startTime, long? endTime)
    {
        if (!startTime.HasValue || !endTime.HasValue)
            return;

        if (endTime.Value < startTime.Value)
            throw new ArgumentException("EndTime must be greater than or equal to StartTime.");
        if (endTime.Value - startTime.Value > SevenDaysMilliseconds)
            throw new ArgumentException("The time range cannot exceed 7 days.");
    }
}
