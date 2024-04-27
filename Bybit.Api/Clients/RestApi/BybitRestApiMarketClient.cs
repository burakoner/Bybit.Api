using Bybit.Api.Models.Market;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Rest API Market Client
/// </summary>
public class BybitRestApiMarketClient
{
    // Market Endpoints
    private const string _v5PublicTimeEndpoint = "v5/public/time";
    private const string _v5MarketKlineEndpoint = "v5/market/kline";
    private const string _v5MarketMarkPriceKlineEndpoint = "v5/market/mark-price-kline";
    private const string _v5MarketIndexPriceKlineEndpoint = "v5/market/index-price-kline";
    private const string _v5MarketPremiumIndexPriceKlineEndpoint = "v5/market/premium-index-price-kline";
    private const string _v5InstrumentsInfoEndpoint = "v5/market/instruments-info";
    private const string _v5MarketOrderbookEndpoint = "v5/market/orderbook";
    private const string _v5MarketTickersEndpoint = "v5/market/tickers";
    private const string _v5MarketFundingHistoryEndpoint = "v5/market/funding/history";
    private const string _v5MarketRecentTradeEndpoint = "v5/market/recent-trade";
    private const string _v5MarketOpenInterestEndpoint = "v5/market/open-interest";
    private const string _v5MarketHistoricalVolatilityEndpoint = "v5/market/historical-volatility";
    private const string _v5MarketInsuranceEndpoint = "v5/market/insurance";
    private const string _v5MarketRiskLimitEndpoint = "v5/market/risk-limit";
    private const string _v5MarketDeliveryPriceEndpoint = "v5/market/delivery-price";
    private const string _v5MarketAccountRatioEndpoint = "/v5/market/account-ratio"; // TODO

    // Internal
    internal BybitRestApiBaseClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitRestApiMarketClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }
    
    /// <summary>
    /// Get Bybit Server Time
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default)
        => await MainClient.SendBybitRequest<BybitTime>(MainClient.GetUri(_v5PublicTimeEndpoint), HttpMethod.Get, ct).ConfigureAwait(false);

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
    public async Task<RestCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
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
    public async Task<RestCallResult<IEnumerable<BybitKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Spot, BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitKline>>(MainClient.GetUri(_v5MarketKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitKline>>(null);
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
    public async Task<RestCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
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
    public async Task<RestCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitMarkPriceKline>>(MainClient.GetUri(_v5MarketMarkPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitMarkPriceKline>>(null);
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
    public async Task<RestCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
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
    public async Task<RestCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitIndexPriceKline>>(MainClient.GetUri(_v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="category">Product type. linear</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W</param>
    /// <param name="start">The start timestamp (ms)</param>
    /// <param name="end">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 1000]. Default: 200</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<IEnumerable<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
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
    public async Task<RestCallResult<IEnumerable<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitPremiumIndexPriceKline>>(MainClient.GetUri(_v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitPremiumIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query for the instrument specification of online trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="status">Symbol status filter. spot/linear/inverse has Trading only</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<IEnumerable<BybitSpotInstrument>>> GetSpotInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitSpotInstrument>>(MainClient.GetUri(_v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotInstrument>>(null);
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
    public async Task<RestCallResult<BybitCursorResponse<BybitLinearInverseInstrument>>> GetLinearInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(_v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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
    public async Task<RestCallResult<BybitCursorResponse<BybitLinearInverseInstrument>>> GetInverseInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(_v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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
    public async Task<RestCallResult<BybitCursorResponse<BybitOptionInstrument>>> GetOptionInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int limit = 500, string cursor = null, CancellationToken ct = default)
    {
        limit.ValidateIntBetween(nameof(limit), 1, 1000);
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitOptionInstrument>>(MainClient.GetUri(_v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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
    public async Task<RestCallResult<BybitOrderbook>> GetOrderbookAsync(BybitCategory category, string symbol, int? limit = null, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) limit?.ValidateIntBetween(nameof(limit), 1, 200);
        if (category == BybitCategory.Linear) limit?.ValidateIntBetween(nameof(limit), 1, 500);
        if (category == BybitCategory.Inverse) limit?.ValidateIntBetween(nameof(limit), 1, 500);
        if (category == BybitCategory.Option) limit?.ValidateIntBetween(nameof(limit), 1, 25);

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("limit", limit);

        return await MainClient.SendBybitRequest<BybitOrderbook>(MainClient.GetUri(_v5MarketOrderbookEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query for the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
    /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
    /// If category=option, symbol or baseCoin must be passed.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<IEnumerable<BybitSpotTicker>>> GetSpotTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitSpotTicker>>(MainClient.GetUri(_v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotTicker>>(null);
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
    public async Task<RestCallResult<IEnumerable<BybitLinearInverseTicker>>> GetLinearTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitLinearInverseTicker>>(MainClient.GetUri(_v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLinearInverseTicker>>(null);
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
    public async Task<RestCallResult<IEnumerable<BybitLinearInverseTicker>>> GetInverseTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitLinearInverseTicker>>(MainClient.GetUri(_v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLinearInverseTicker>>(null);
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
    public async Task<RestCallResult<IEnumerable<BybitOptionTicker>>> GetOptionTickersAsync(string symbol = null, string baseAsset = null, string expDate = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("expDate", expDate);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitOptionTicker>>(MainClient.GetUri(_v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitOptionTicker>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitFundingRate>>> GetFundingRateHistoryAsync(BybitCategory category, string symbol, DateTime startTime, DateTime endTime, int limit = 200, CancellationToken ct = default)
        => await GetFundingRateHistoryAsync(category, symbol, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitFundingRate>>> GetFundingRateHistoryAsync(BybitCategory category, string symbol, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitFundingRate>>(MainClient.GetUri(_v5MarketFundingHistoryEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitFundingRate>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitTrade>>> GetPublicTradingHistoryAsync(BybitCategory category, string symbol = null, string baseAsset = null, BybitOptionType? optionType = null, int? limit = null, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) limit?.ValidateIntBetween(nameof(limit), 1, 60);
        if (category == BybitCategory.Linear) limit?.ValidateIntBetween(nameof(limit), 1, 1000);
        if (category == BybitCategory.Inverse) limit?.ValidateIntBetween(nameof(limit), 1, 1000);
        if (category == BybitCategory.Option) limit?.ValidateIntBetween(nameof(limit), 1, 1000);

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("optionType", optionType?.GetLabel());
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitTrade>>(MainClient.GetUri(_v5MarketRecentTradeEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitTrade>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<BybitCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, DateTime startTime, DateTime endTime, int limit = 200, string cursor = null, CancellationToken ct = default)
        => await GetOpenInterestAsync(category, symbol, interval, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, cursor, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, long? startTime = null, long? endTime = null, int limit = 200, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "intervalTime", interval.GetLabel() },
            { "limit", limit },
        };
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitOpenInterest>>(MainClient.GetUri(_v5MarketOpenInterestEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(BybitCategory category, DateTime startTime, DateTime endTime, string baseAsset = null, BybitPeriod? period = null, CancellationToken ct = default)
        => await GetHistoricalVolatilityAsync(category, baseAsset, period, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(BybitCategory category, string baseAsset = null, BybitPeriod? period = null, long? startTime = null, long? endTime = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("period", period?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);

        return await MainClient.SendBybitRequest<IEnumerable<BybitHistoricalVolatility>>(MainClient.GetUri(_v5MarketHistoricalVolatilityEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<IEnumerable<BybitInsurance>>> GetInsuranceAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitUpdateResponse<BybitInsurance>>(MainClient.GetUri(_v5MarketInsuranceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitInsurance>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(BybitCategory category, string symbol = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitCategoryResponse<BybitRiskLimit>>(MainClient.GetUri(_v5MarketRiskLimitEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitRiskLimit>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<BybitCursorResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(BybitCategory category, string symbol = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitCursorResponse<BybitDeliveryPrice>>(MainClient.GetUri(_v5MarketDeliveryPriceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

}
