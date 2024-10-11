namespace Bybit.Api.Market;

/// <summary>
/// Bybit Rest API Market Client
/// </summary>
public class BybitMarketRestApiClient
{
    // Market Endpoints
    private const string _v5MarketTime = "v5/market/time";
    private const string _v5MarketKline = "v5/market/kline";
    private const string _v5MarketMarkPriceKline = "v5/market/mark-price-kline";
    private const string _v5MarketIndexPriceKline = "v5/market/index-price-kline";
    private const string _v5MarketPremiumIndexPriceKline = "v5/market/premium-index-price-kline";
    private const string _v5InstrumentsInfo = "v5/market/instruments-info";
    private const string _v5MarketOrderbook = "v5/market/orderbook";
    private const string _v5MarketTickers = "v5/market/tickers";
    private const string _v5MarketFundingHistory = "v5/market/funding/history";
    private const string _v5MarketRecentTrade = "v5/market/recent-trade";
    private const string _v5MarketOpenInterest = "v5/market/open-interest";
    private const string _v5MarketHistoricalVolatility = "v5/market/historical-volatility";
    private const string _v5MarketInsurance = "v5/market/insurance";
    private const string _v5MarketRiskLimit = "v5/market/risk-limit";
    private const string _v5MarketDeliveryPrice = "v5/market/delivery-price";
    private const string _v5MarketAccountRatio = "/v5/market/account-ratio";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitMarketRestApiClient(BybitRestApiClient root)
    {
        this._ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get Bybit Server Time
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarketTime>> GetServerTimeAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitMarketTime>(_.BuildUri(_v5MarketTime), HttpMethod.Get, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical klines (also known as candles/candlesticks). Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical klines (also known as candles/candlesticks). Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Spot, BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("interval", interval);
        parameters.AddOptional("start", start);
        parameters.AddOptional("end", end);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketKline>>(_.BuildUri(_v5MarketKline), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for historical mark price klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetMarkKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical mark price klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("interval", interval);
        parameters.AddOptional("start", start);
        parameters.AddOptional("end", end);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketMarkPriceKline>>(_.BuildUri(_v5MarketMarkPriceKline), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketMarkPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for historical index price klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical index price klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse. When category is not passed, use linear by default</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("interval", interval);
        parameters.AddOptional("start", start);
        parameters.AddOptional("end", end);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketIndexPriceKline>>(_.BuildUri(_v5MarketIndexPriceKline), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for historical premium index klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category">Product type. linear</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetPremiumIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical premium index klines. Charts are returned in groups based on the requested interval.
    /// </summary>
    /// <param name="category"></param>
    /// <param name="symbol"></param>
    /// <param name="interval"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="limit"></param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("interval", interval);
        parameters.AddOptional("start", start);
        parameters.AddOptional("end", end);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketPremiumIndexPriceKline>>(_.BuildUri(_v5MarketPremiumIndexPriceKline), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketPremiumIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the instrument specification of online trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="status">Symbol status filter. spot/linear/inverse has Trading only</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 500</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketSpotInstrument>>> GetSpotInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null,int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Spot);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketSpotInstrument>>(_.BuildUri(_v5InstrumentsInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketSpotInstrument>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the instrument specification of online trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="status">Symbol status filter. spot/linear/inverse has Trading only</param>
    /// <param name="baseAsset">Base coin. Apply tolinear,inverse,option only. option: it returns BTC by default</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 500</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketFuturesInstrument>>> GetLinearInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Linear);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketFuturesInstrument>>(_.BuildUri(_v5InstrumentsInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketFuturesInstrument>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query for the instrument specification of online trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="status">Symbol status filter. spot/linear/inverse has Trading only</param>
    /// <param name="baseAsset">Base coin. Apply tolinear,inverse,option only. option: it returns BTC by default</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 500</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketFuturesInstrument>>> GetInverseInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Inverse);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketFuturesInstrument>>(_.BuildUri(_v5InstrumentsInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketFuturesInstrument>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query for the instrument specification of online trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="status">Symbol status filter. spot/linear/inverse has Trading only</param>
    /// <param name="baseAsset">Base coin. Apply tolinear,inverse,option only. option: it returns BTC by default</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 500</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketOptionInstrument>>> GetOptionInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Option);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketOptionInstrument>>(_.BuildUri(_v5InstrumentsInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketOptionInstrument>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query for orderbook depth data.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// Contract: 500-level of orderbook data
    /// Spot: 200-level of orderbook data
    /// Option: 25-level of orderbook data
    /// </summary>
    /// <param name="category">Product type. spot, linear, inverse, option</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="limit">Limit size for each bid and ask
    /// spot: [1, 200]. Default: 1.
    /// linear &amp; inverse: [1, 500]. Default: 25.
    /// option: [1, 25]. Default: 1.</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarketOrderbook>> GetOrderbookAsync(BybitCategory category, string symbol, int? limit = null, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) limit?.ValidateIntBetween(nameof(limit), 1, 200);
        if (category == BybitCategory.Linear) limit?.ValidateIntBetween(nameof(limit), 1, 500);
        if (category == BybitCategory.Inverse) limit?.ValidateIntBetween(nameof(limit), 1, 500);
        if (category == BybitCategory.Option) limit?.ValidateIntBetween(nameof(limit), 1, 25);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddOptional("limit", limit);

        return await _.SendBybitRequest<BybitMarketOrderbook>(_.BuildUri(_v5MarketOrderbook), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Query for the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// If category=option, symbol or baseCoin must be passed.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketSpotTicker>>> GetSpotTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Spot);
        parameters.AddOptional("symbol", symbol);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketSpotTicker>>(_.BuildUri(_v5MarketTickers), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketSpotTicker>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// If category=option, symbol or baseCoin must be passed.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketFuturesTicker>>> GetLinearTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Linear);
        parameters.AddOptional("symbol", symbol);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketFuturesTicker>>(_.BuildUri(_v5MarketTickers), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketFuturesTicker>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// If category=option, symbol or baseCoin must be passed.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketFuturesTicker>>> GetInverseTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Inverse);
        parameters.AddOptional("symbol", symbol);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketFuturesTicker>>(_.BuildUri(_v5MarketTickers), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketFuturesTicker>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// If category=option, symbol or baseCoin must be passed.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="baseAsset">Base coin. Apply to option only</param>
    /// <param name="expDate">Expiry date. e.g., 25DEC22. Apply to option only</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketOptionTicker>>> GetOptionTickersAsync(string symbol = null, string baseAsset = null, string expDate = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", BybitCategory.Option);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("expDate", expDate);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketOptionTicker>>(_.BuildUri(_v5MarketTickers), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketOptionTicker>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for historical funding rates. Each symbol has a different funding interval. For example, if the interval is 8 hours and the current time is UTC 12, then it returns the last funding rate, which settled at UTC 8.
    /// To query the funding rate interval, please refer to the instruments-info endpoint.
    /// Covers: USDT and USDC perpetual / Inverse perpetual
    /// 
    /// INFO
    /// Passing only startTime returns an error.
    /// Passing only endTime returns 200 records up till endTime.
    /// Passing neither returns 200 records up till the current time.
    /// </summary>
    /// <param name="category">Product type. linear,inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketFundingHistory>>> GetFundingHistoryAsync(BybitCategory category, string symbol, DateTime startTime, DateTime endTime, int limit = 200, CancellationToken ct = default)
        => await GetFundingHistoryAsync(category, symbol, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);

    /// <summary>
    /// Query for historical funding rates. Each symbol has a different funding interval. For example, if the interval is 8 hours and the current time is UTC 12, then it returns the last funding rate, which settled at UTC 8.
    /// To query the funding rate interval, please refer to the instruments-info endpoint.
    /// Covers: USDT and USDC perpetual / Inverse perpetual
    /// 
    /// INFO
    /// Passing only startTime returns an error.
    /// Passing only endTime returns 200 records up till endTime.
    /// Passing neither returns 200 records up till the current time.
    /// </summary>
    /// <param name="category">Product type. linear,inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketFundingHistory>>> GetFundingHistoryAsync(BybitCategory category, string symbol, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketFundingHistory>>(_.BuildUri(_v5MarketFundingHistory), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketFundingHistory>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query recent public trading data in Bybit.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// You can download archived historical trades from the website
    /// </summary>
    /// <param name="category">Product type. spot,linear,inverse,option</param>
    /// <param name="symbol">Symbol name
    /// required for spot/linear/inverse
    /// optional for option</param>
    /// <param name="baseAsset">Base coin
    /// Apply to option only
    /// If the field is not passed, return BTC data by default</param>
    /// <param name="optionType">Option type. Call or Put. Apply to option only</param>
    /// <param name="limit">Limit for data size per page
    /// spot: [1,60], default: 60
    /// others: [1,1000], default: 500</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketTrade>>> GetTradingHistoryAsync(BybitCategory category, string symbol = null, string baseAsset = null, BybitOptionType? optionType = null, int? limit = null, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) limit?.ValidateIntBetween(nameof(limit), 1, 60);
        if (category == BybitCategory.Linear) limit?.ValidateIntBetween(nameof(limit), 1, 1000);
        if (category == BybitCategory.Inverse) limit?.ValidateIntBetween(nameof(limit), 1, 1000);
        if (category == BybitCategory.Option) limit?.ValidateIntBetween(nameof(limit), 1, 1000);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptionalEnum("optionType", optionType);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketTrade>>(_.BuildUri(_v5MarketRecentTrade), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketTrade>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get the open interest of each symbol.
    /// Covers: USDT perpetual / USDC contract / Inverse contract
    /// 
    /// INFO
    /// The upper limit time you can query is the launch time of the symbol.
    /// </summary>
    /// <param name="category">Product type. linear,inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Interval time. 5min,15min,30min,1h,4h,1d</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 50</param>
    /// <param name="cursor">Cursor. Used to paginate</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitRecordPeriod period, DateTime startTime, DateTime endTime, int limit = 50, string cursor = null, CancellationToken ct = default)
        => await GetOpenInterestAsync(category, symbol, period, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, cursor, ct).ConfigureAwait(false);

    /// <summary>
    /// Get the open interest of each symbol.
    /// Covers: USDT perpetual / USDC contract / Inverse contract
    /// 
    /// INFO
    /// The upper limit time you can query is the launch time of the symbol.
    /// </summary>
    /// <param name="category">Product type. linear,inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Interval time. 5min,15min,30min,1h,4h,1d</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 50</param>
    /// <param name="cursor">Cursor. Used to paginate</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitRecordPeriod period, long? startTime = null, long? endTime = null, int limit = 50, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("intervalTime", period);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("cursor", cursor);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketOpenInterest>>(_.BuildUri(_v5MarketOpenInterest), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketOpenInterest>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get Historical Volatility
    /// Query option historical volatility
    /// 
    /// Covers: Option
    /// 
    /// INFO
    /// The data is hourly.
    /// If both startTime and endTime are not specified, it will return the most recent 1 hours worth of data.
    /// startTime and endTime are a pair of params. Either both are passed or they are not passed at all.
    /// This endpoint can query the last 2 years worth of data, but make sure [endTime - startTime] &lt;= 30 days.
    /// </summary>
    /// <param name="category">Product type. option</param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="baseAsset">Base coin. Default: return BTC data</param>
    /// <param name="period">Period. If not specified, it will return data with a 7-day average by default</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketVolatility>>> GetVolatilityAsync(BybitCategory category, DateTime startTime, DateTime endTime, string baseAsset = null, BybitOptionPeriod? period = null, CancellationToken ct = default)
        => await GetVolatilityAsync(category, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), baseAsset, period, ct).ConfigureAwait(false);

    /// <summary>
    /// Get Historical Volatility
    /// Query option historical volatility
    /// 
    /// Covers: Option
    /// 
    /// INFO
    /// The data is hourly.
    /// If both startTime and endTime are not specified, it will return the most recent 1 hours worth of data.
    /// startTime and endTime are a pair of params. Either both are passed or they are not passed at all.
    /// This endpoint can query the last 2 years worth of data, but make sure [endTime - startTime] &lt;= 30 days.
    /// </summary>
    /// <param name="category">Product type. option</param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="baseAsset">Base coin. Default: return BTC data</param>
    /// <param name="period">Period. If not specified, it will return data with a 7-day average by default</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketVolatility>>> GetVolatilityAsync(BybitCategory category, long? startTime = null, long? endTime = null, string baseAsset = null, BybitOptionPeriod? period = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptionalEnum("period", period);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);

        return await _.SendBybitRequest<List<BybitMarketVolatility>>(_.BuildUri(_v5MarketHistoricalVolatility), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query for Bybit insurance pool data (BTC/USDT/USDC etc). The data is updated every 24 hours.
    /// 
    /// INFO
    /// Since the insurance pool data is updated every 24 hours, it is possible that you get ADL trade but the insruance pool still has sufficient funds.
    /// </summary>
    /// <param name="asset">coin. Default: return all insurance coins</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarketInsurance>>> GetInsuranceAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketInsurance>>(_.BuildUri(_v5MarketInsurance), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketInsurance>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get Risk Limit
    /// Query for the risk limit.
    /// Covers: USDT perpetual / USDC contract / Inverse contract
    /// </summary>
    /// <param name="category">Product type. linear,inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketRiskLimit>>> GetRiskLimitAsync(BybitCategory category, string symbol = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketRiskLimit>>(_.BuildUri(_v5MarketRiskLimit), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketRiskLimit>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get the delivery price.
    /// Covers: USDC futures / Inverse futures / Option
    /// 
    /// INFO
    /// Option: only returns those symbols are being "DELIVERING" (UTC8~UTC12) when "symbol" is not specified;
    /// </summary>
    /// <param name="category">Product type. linear, inverse, option</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="baseAsset">Base coin. Default: BTC. valid for option only</param>
    /// <param name="limit">Limit for data size per page. [1, 200]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketDeliveryPrice>>> GetDeliveryPriceAsync(BybitCategory category, string symbol = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketDeliveryPrice>>(_.BuildUri(_v5MarketDeliveryPrice), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketDeliveryPrice>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get Long Short Ratio
    /// </summary>
    /// <param name="category">Product type. linear(USDT Perpetual),inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Data recording period. 5min, 15min, 30min, 1h, 4h, 1d</param>
    /// <param name="limit">Limit for data size per page. [1, 500]. Default: 50</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitMarketLongShortRatio>>> GetLongShortRatioAsync(BybitCategory category, string symbol, BybitRecordPeriod period, int limit = 50, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 500);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("symbol", symbol);
        parameters.AddEnum("period", period);
        parameters.Add("limit", limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarketLongShortRatio>>(_.BuildUri(_v5MarketAccountRatio), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarketLongShortRatio>>(null);
        return result.As(result.Data.Payload);
    }

}
