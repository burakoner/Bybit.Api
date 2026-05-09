namespace Bybit.Api.Rfq;

/// <summary>
/// Bybit REST API RFQ Trading client.
/// </summary>
public class BybitRfqRestApiClient
{
    private const string _v5RfqCreateRfq = "v5/rfq/create-rfq";
    private const string _v5RfqConfig = "v5/rfq/config";
    private const string _v5RfqCancelRfq = "v5/rfq/cancel-rfq";
    private const string _v5RfqCancelAllRfq = "v5/rfq/cancel-all-rfq";
    private const string _v5RfqAcceptOtherQuote = "v5/rfq/accept-other-quote";
    private const string _v5RfqCreateQuote = "v5/rfq/create-quote";
    private const string _v5RfqExecuteQuote = "v5/rfq/execute-quote";
    private const string _v5RfqCancelQuote = "v5/rfq/cancel-quote";
    private const string _v5RfqCancelAllQuotes = "v5/rfq/cancel-all-quotes";
    private const string _v5RfqRfqRealtime = "v5/rfq/rfq-realtime";
    private const string _v5RfqRfqList = "v5/rfq/rfq-list";
    private const string _v5RfqQuoteRealtime = "v5/rfq/quote-realtime";
    private const string _v5RfqQuoteList = "v5/rfq/quote-list";
    private const string _v5RfqTradeList = "v5/rfq/trade-list";
    private const string _v5RfqPublicTrades = "v5/rfq/public-trades";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitRfqRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Create an RFQ.
    /// </summary>
    /// <param name="counterparties">Counterparty desk codes.</param>
    /// <param name="legs">Combination transaction legs.</param>
    /// <param name="rfqLinkId">Custom RFQ ID.</param>
    /// <param name="anonymous">Whether the inquiry is anonymous.</param>
    /// <param name="strategyType">Strategy type.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqCreateResult>> CreateRfqAsync(IEnumerable<string> counterparties, IEnumerable<BybitRfqLegRequest> legs, string? rfqLinkId = null, bool? anonymous = null, string? strategyType = null, CancellationToken ct = default)
    {
        return CreateRfqAsync(new BybitRfqCreateRequest(counterparties, legs)
        {
            RfqLinkId = rfqLinkId,
            Anonymous = anonymous,
            StrategyType = strategyType,
        }, ct);
    }

    /// <summary>
    /// Create an RFQ.
    /// </summary>
    /// <param name="request">Create RFQ request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqCreateResult>> CreateRfqAsync(BybitRfqCreateRequest request, CancellationToken ct = default)
    {
        ValidateRequiredList(request.Counterparties, nameof(request.Counterparties));
        ValidateRequiredList(request.Legs, nameof(request.Legs));
        foreach (var leg in request.Legs)
            ValidateRfqCategory(leg.Category);

        var parameters = new ParameterCollection
        {
            { "counterparties", request.Counterparties },
            { "list", request.Legs },
        };
        parameters.AddOptional("rfqLinkId", request.RfqLinkId);
        parameters.AddOptional("anonymous", request.Anonymous);
        parameters.AddOptional("strategyType", request.StrategyType);

        return await _.SendBybitRequest<BybitRfqCreateResult>(_.BuildUri(_v5RfqCreateRfq), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query RFQ configuration.
    /// </summary>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqConfig>> GetRfqConfigAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitRfqConfig>(_.BuildUri(_v5RfqConfig), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel an RFQ.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="rfqLinkId">Custom inquiry ID.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqId>> CancelRfqAsync(string? rfqId = null, string? rfqLinkId = null, CancellationToken ct = default)
    {
        return CancelRfqAsync(new BybitRfqCancelRequest
        {
            RfqId = rfqId,
            RfqLinkId = rfqLinkId,
        }, ct);
    }

    /// <summary>
    /// Cancel an RFQ.
    /// </summary>
    /// <param name="request">Cancel RFQ request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqId>> CancelRfqAsync(BybitRfqCancelRequest request, CancellationToken ct = default)
    {
        ValidateRfqIdentifier(request.RfqId, request.RfqLinkId);

        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", request.RfqId);
        parameters.AddOptional("rfqLinkId", request.RfqLinkId);

        return await _.SendBybitRequest<BybitRfqId>(_.BuildUri(_v5RfqCancelRfq), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel all active RFQs.
    /// </summary>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqCancelAllResult>>> CancelAllRfqsAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<List<BybitRfqCancelAllResult>>(_.BuildUri(_v5RfqCancelAllRfq), HttpMethod.Post, ct, true, bodyParameters: new ParameterCollection()).ConfigureAwait(false);
    }

    /// <summary>
    /// Accept non-LP quotes for an RFQ.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqId>> AcceptOtherQuoteAsync(string rfqId, CancellationToken ct = default)
        => AcceptOtherQuoteAsync(new BybitRfqAcceptOtherQuoteRequest(rfqId), ct);

    /// <summary>
    /// Accept non-LP quotes for an RFQ.
    /// </summary>
    /// <param name="request">Accept non-LP quote request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqId>> AcceptOtherQuoteAsync(BybitRfqAcceptOtherQuoteRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "rfqId", request.RfqId },
        };

        return await _.SendBybitRequest<BybitRfqId>(_.BuildUri(_v5RfqAcceptOtherQuote), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Create a quote.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteBuyList">Buy direction quote legs.</param>
    /// <param name="quoteSellList">Sell direction quote legs.</param>
    /// <param name="quoteLinkId">Custom quote ID.</param>
    /// <param name="anonymous">Whether the quote is anonymous.</param>
    /// <param name="expireIn">Duration of the quote in seconds. [10, 120].</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqQuoteResult>> CreateQuoteAsync(string rfqId, IEnumerable<BybitRfqQuoteLegRequest>? quoteBuyList = null, IEnumerable<BybitRfqQuoteLegRequest>? quoteSellList = null, string? quoteLinkId = null, bool? anonymous = null, int? expireIn = null, CancellationToken ct = default)
    {
        return CreateQuoteAsync(new BybitRfqCreateQuoteRequest(rfqId)
        {
            QuoteBuyList = quoteBuyList?.ToList(),
            QuoteSellList = quoteSellList?.ToList(),
            QuoteLinkId = quoteLinkId,
            Anonymous = anonymous,
            ExpireIn = expireIn,
        }, ct);
    }

    /// <summary>
    /// Create a quote.
    /// </summary>
    /// <param name="request">Create quote request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqQuoteResult>> CreateQuoteAsync(BybitRfqCreateQuoteRequest request, CancellationToken ct = default)
    {
        request.ExpireIn?.ValidateIntBetween(nameof(request.ExpireIn), 10, 120);
        if ((request.QuoteBuyList == null || request.QuoteBuyList.Count == 0) && (request.QuoteSellList == null || request.QuoteSellList.Count == 0))
            throw new ArgumentException("At least one quote buy or sell leg is required.", nameof(request));

        ValidateQuoteLegCategories(request.QuoteBuyList);
        ValidateQuoteLegCategories(request.QuoteSellList);

        var parameters = new ParameterCollection
        {
            { "rfqId", request.RfqId },
        };
        parameters.AddOptional("quoteLinkId", request.QuoteLinkId);
        parameters.AddOptional("anonymous", request.Anonymous);
        parameters.AddOptional("expireIn", request.ExpireIn);
        parameters.AddOptional("quoteBuyList", request.QuoteBuyList);
        parameters.AddOptional("quoteSellList", request.QuoteSellList);

        return await _.SendBybitRequest<BybitRfqQuoteResult>(_.BuildUri(_v5RfqCreateQuote), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Execute a quote.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="quoteSide">Quote side to execute.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqExecuteQuoteResult>> ExecuteQuoteAsync(string rfqId, string quoteId, BybitOrderSide quoteSide, CancellationToken ct = default)
        => ExecuteQuoteAsync(new BybitRfqExecuteQuoteRequest(rfqId, quoteId, quoteSide), ct);

    /// <summary>
    /// Execute a quote.
    /// </summary>
    /// <param name="request">Execute quote request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqExecuteQuoteResult>> ExecuteQuoteAsync(BybitRfqExecuteQuoteRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "rfqId", request.RfqId },
            { "quoteId", request.QuoteId },
        };
        parameters.AddEnum("quoteSide", request.QuoteSide);

        return await _.SendBybitRequest<BybitRfqExecuteQuoteResult>(_.BuildUri(_v5RfqExecuteQuote), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel a quote.
    /// </summary>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteLinkId">Custom quote ID.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitRfqQuoteCancelResult>> CancelQuoteAsync(string? quoteId = null, string? rfqId = null, string? quoteLinkId = null, CancellationToken ct = default)
    {
        return CancelQuoteAsync(new BybitRfqCancelQuoteRequest
        {
            QuoteId = quoteId,
            RfqId = rfqId,
            QuoteLinkId = quoteLinkId,
        }, ct);
    }

    /// <summary>
    /// Cancel a quote.
    /// </summary>
    /// <param name="request">Cancel quote request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitRfqQuoteCancelResult>> CancelQuoteAsync(BybitRfqCancelQuoteRequest request, CancellationToken ct = default)
    {
        ValidateQuoteIdentifier(request.QuoteId, request.RfqId, request.QuoteLinkId);

        var parameters = new ParameterCollection();
        parameters.AddOptional("quoteId", request.QuoteId);
        parameters.AddOptional("rfqId", request.RfqId);
        parameters.AddOptional("quoteLinkId", request.QuoteLinkId);

        return await _.SendBybitRequest<BybitRfqQuoteCancelResult>(_.BuildUri(_v5RfqCancelQuote), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel all active quotes.
    /// </summary>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqQuoteCancelAllResult>>> CancelAllQuotesAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<List<BybitRfqQuoteCancelAllResult>>(_.BuildUri(_v5RfqCancelAllQuotes), HttpMethod.Post, ct, true, bodyParameters: new ParameterCollection()).ConfigureAwait(false);
    }

    /// <summary>
    /// Query real-time RFQs.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="rfqLinkId">Custom inquiry ID.</param>
    /// <param name="traderType">Trader type.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqInfo>>> GetRfqsRealtimeAsync(string? rfqId = null, string? rfqLinkId = null, BybitRfqTraderType? traderType = null, CancellationToken ct = default)
    {
        return GetRfqsRealtimeAsync(new BybitRfqQueryRequest
        {
            RfqId = rfqId,
            RfqLinkId = rfqLinkId,
            TraderType = traderType,
        }, ct);
    }

    /// <summary>
    /// Query real-time RFQs.
    /// </summary>
    /// <param name="request">RFQ query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqInfo>>> GetRfqsRealtimeAsync(BybitRfqQueryRequest request, CancellationToken ct = default)
    {
        var parameters = CreateRfqQueryParameters(request, includeStatus: false, includePagination: false);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqInfo>>(_.BuildUri(_v5RfqRfqRealtime), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqInfo>>(default!);
        return result.As(result.Data.List);
    }

    /// <summary>
    /// Query historical RFQs.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="rfqLinkId">Custom inquiry ID.</param>
    /// <param name="traderType">Trader type.</param>
    /// <param name="status">RFQ status.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqInfo>>> GetRfqsAsync(string? rfqId = null, string? rfqLinkId = null, BybitRfqTraderType? traderType = null, BybitRfqStatus? status = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetRfqsAsync(new BybitRfqQueryRequest
        {
            RfqId = rfqId,
            RfqLinkId = rfqLinkId,
            TraderType = traderType,
            Status = status,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query historical RFQs.
    /// </summary>
    /// <param name="request">RFQ query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqInfo>>> GetRfqsAsync(BybitRfqQueryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = CreateRfqQueryParameters(request, includeStatus: true, includePagination: true);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqInfo>>(_.BuildUri(_v5RfqRfqList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqInfo>>(default!);
        return result.As(result.Data.List, result.Data.Cursor);
    }

    /// <summary>
    /// Query real-time quotes.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="quoteLinkId">Custom quote ID.</param>
    /// <param name="traderType">Trader type.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqQuote>>> GetQuotesRealtimeAsync(string? rfqId = null, string? quoteId = null, string? quoteLinkId = null, BybitRfqTraderType? traderType = null, CancellationToken ct = default)
    {
        return GetQuotesRealtimeAsync(new BybitRfqQuoteQueryRequest
        {
            RfqId = rfqId,
            QuoteId = quoteId,
            QuoteLinkId = quoteLinkId,
            TraderType = traderType,
        }, ct);
    }

    /// <summary>
    /// Query real-time quotes.
    /// </summary>
    /// <param name="request">Quote query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqQuote>>> GetQuotesRealtimeAsync(BybitRfqQuoteQueryRequest request, CancellationToken ct = default)
    {
        var parameters = CreateQuoteQueryParameters(request, includeStatus: false, includePagination: false);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqQuote>>(_.BuildUri(_v5RfqQuoteRealtime), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqQuote>>(default!);
        return result.As(result.Data.List);
    }

    /// <summary>
    /// Query historical quotes.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="quoteLinkId">Custom quote ID.</param>
    /// <param name="traderType">Trader type.</param>
    /// <param name="status">Quote status.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqQuote>>> GetQuotesAsync(string? rfqId = null, string? quoteId = null, string? quoteLinkId = null, BybitRfqTraderType? traderType = null, BybitRfqStatus? status = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetQuotesAsync(new BybitRfqQuoteQueryRequest
        {
            RfqId = rfqId,
            QuoteId = quoteId,
            QuoteLinkId = quoteLinkId,
            TraderType = traderType,
            Status = status,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query historical quotes.
    /// </summary>
    /// <param name="request">Quote query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqQuote>>> GetQuotesAsync(BybitRfqQuoteQueryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = CreateQuoteQueryParameters(request, includeStatus: true, includePagination: true);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqQuote>>(_.BuildUri(_v5RfqQuoteList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqQuote>>(default!);
        return result.As(result.Data.List, result.Data.Cursor);
    }

    /// <summary>
    /// Query RFQ trade history.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="rfqLinkId">Custom inquiry ID.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="quoteLinkId">Custom quote ID.</param>
    /// <param name="traderType">Trader type.</param>
    /// <param name="status">Trade status.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqTrade>>> GetTradeHistoryAsync(string? rfqId = null, string? rfqLinkId = null, string? quoteId = null, string? quoteLinkId = null, BybitRfqTraderType? traderType = null, BybitRfqStatus? status = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetTradeHistoryAsync(new BybitRfqTradeHistoryRequest
        {
            RfqId = rfqId,
            RfqLinkId = rfqLinkId,
            QuoteId = quoteId,
            QuoteLinkId = quoteLinkId,
            TraderType = traderType,
            Status = status,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query RFQ trade history.
    /// </summary>
    /// <param name="request">Trade history request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqTrade>>> GetTradeHistoryAsync(BybitRfqTradeHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", request.RfqId);
        parameters.AddOptional("rfqLinkId", request.RfqLinkId);
        parameters.AddOptional("quoteId", request.QuoteId);
        parameters.AddOptional("quoteLinkId", request.QuoteLinkId);
        parameters.AddOptionalEnum("traderType", request.TraderType);
        parameters.AddOptionalEnum("status", request.Status);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqTrade>>(_.BuildUri(_v5RfqTradeList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqTrade>>(default!);
        return result.As(result.Data.List, result.Data.Cursor);
    }

    /// <summary>
    /// Query recently executed RFQ public trades.
    /// </summary>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Data size per page. [1, 100].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitRfqPublicTrade>>> GetPublicTradesAsync(long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetPublicTradesAsync(new BybitRfqPublicTradeRequest
        {
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query recently executed RFQ public trades.
    /// </summary>
    /// <param name="request">Public trade query request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitRfqPublicTrade>>> GetPublicTradesAsync(BybitRfqPublicTradeRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitRfqListResponse<BybitRfqPublicTrade>>(_.BuildUri(_v5RfqPublicTrades), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitRfqPublicTrade>>(default!);
        return result.As(result.Data.List, result.Data.Cursor);
    }

    private static ParameterCollection CreateRfqQueryParameters(BybitRfqQueryRequest request, bool includeStatus, bool includePagination)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", request.RfqId);
        parameters.AddOptional("rfqLinkId", request.RfqLinkId);
        parameters.AddOptionalEnum("traderType", request.TraderType);
        if (includeStatus)
            parameters.AddOptionalEnum("status", request.Status);
        if (includePagination)
        {
            parameters.AddOptional("limit", request.Limit);
            parameters.AddOptional("cursor", request.Cursor);
        }

        return parameters;
    }

    private static ParameterCollection CreateQuoteQueryParameters(BybitRfqQuoteQueryRequest request, bool includeStatus, bool includePagination)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("rfqId", request.RfqId);
        parameters.AddOptional("quoteId", request.QuoteId);
        parameters.AddOptional("quoteLinkId", request.QuoteLinkId);
        parameters.AddOptionalEnum("traderType", request.TraderType);
        if (includeStatus)
            parameters.AddOptionalEnum("status", request.Status);
        if (includePagination)
        {
            parameters.AddOptional("limit", request.Limit);
            parameters.AddOptional("cursor", request.Cursor);
        }

        return parameters;
    }

    private static void ValidateRfqIdentifier(string? rfqId, string? rfqLinkId)
    {
        if (string.IsNullOrEmpty(rfqId) && string.IsNullOrEmpty(rfqLinkId))
            throw new ArgumentException("Either RfqId or RfqLinkId is required.");
    }

    private static void ValidateQuoteIdentifier(string? quoteId, string? rfqId, string? quoteLinkId)
    {
        if (string.IsNullOrEmpty(quoteId) && string.IsNullOrEmpty(rfqId) && string.IsNullOrEmpty(quoteLinkId))
            throw new ArgumentException("Either QuoteId, QuoteLinkId, or RfqId is required.");
    }

    private static void ValidateQuoteLegCategories(IEnumerable<BybitRfqQuoteLegRequest>? legs)
    {
        if (legs == null)
            return;

        foreach (var leg in legs)
            ValidateRfqCategory(leg.Category);
    }

    private static void ValidateRfqCategory(BybitCategory category)
    {
        if (category.IsNotIn(BybitCategory.Spot, BybitCategory.Linear, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for RFQ Trading.");
    }

    private static void ValidateRequiredList<T>(ICollection<T> values, string name)
    {
        if (values.Count == 0)
            throw new ArgumentException($"{name} is required.", name);
    }
}
