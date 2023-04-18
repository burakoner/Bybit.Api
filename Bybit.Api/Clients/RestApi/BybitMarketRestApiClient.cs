using Bybit.Api.Models.Market;

namespace Bybit.Api.Clients.RestApi;

public class BybitMarketRestApiClient
{
    // Market Endpoints
    protected string v5MarketKlineEndpoint = "v5/market/kline";
    protected string v5MarketMarkPriceKlineEndpoint = "v5/market/mark-price-kline";
    protected string v5MarketIndexPriceKlineEndpoint = "v5/market/index-price-kline";
    protected string v5MarketPremiumIndexPriceKlineEndpoint = "v5/market/premium-index-price-kline";
    protected string v5InstrumentsInfoEndpoint = "v5/market/instruments-info";
    protected string v5MarketOrderbookEndpoint = "v5/market/orderbook";
    protected string v5MarketTickersEndpoint = "v5/market/tickers";
    protected string v5MarketFundingHistoryEndpoint = "v5/market/funding/history";
    protected string v5MarketRecentTradeEndpoint = "v5/market/recent-trade";
    protected string v5MarketOpenInterestEndpoint = "v5/market/open-interest";
    protected string v5MarketHistoricalVolatilityEndpoint = "v5/market/historical-volatility";
    protected string v5MarketInsuranceEndpoint = "v5/market/insurance";
    protected string v5MarketRiskLimitEndpoint = "v5/market/risk-limit";
    protected string v5MarketDeliveryPriceEndpoint = "v5/market/delivery-price";

    // Internal
    internal BybitRestApiClient RootClient { get; }
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return RootClient.CI; } }

    internal BybitMarketRestApiClient(BybitRestApiClient root)
    {
        this.RootClient = root;
        this.MainClient = root.MainClient;
    }


    public async Task<RestCallResult<BybitKlineContainer<BybitPriceKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitKlineContainer<BybitPriceKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Spot, BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
            { "limit", limit },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);

        return await MainClient.SendBybitRequest<BybitKlineContainer<BybitPriceKline>>(MainClient.GetUri(v5MarketKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitKlineContainer<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetMarkKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitKlineContainer<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
            { "limit", limit },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);

        return await MainClient.SendBybitRequest<BybitKlineContainer<BybitMarkPriceKline>>(MainClient.GetUri(v5MarketMarkPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitKlineContainer<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitKlineContainer<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
            { "limit", limit },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);

        return await MainClient.SendBybitRequest<BybitKlineContainer<BybitIndexPriceKline>>(MainClient.GetUri(v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitKlineContainer<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetPremiumIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitKlineContainer<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "interval", interval.GetLabel() },
            { "limit", limit },
        };
        parameters.AddOptionalParameter("start", start);
        parameters.AddOptionalParameter("end", end);

        return await MainClient.SendBybitRequest<BybitKlineContainer<BybitPremiumIndexPriceKline>>(MainClient.GetUri(v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitSpotInstrument>>> GetSpotInstrumentsAsync(string symbol = "", BybitInstrumentStatus? status = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitSpotInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>> GetLinearInstrumentsAsync(string symbol = "", BybitInstrumentStatus? status = null, string baseCoin = "", int? limit = null, string cursor = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>> GetInverseInstrumentsAsync(string symbol = "", BybitInstrumentStatus? status = null, string baseCoin = "", int? limit = null, string cursor = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOptionInstrument>>> GetOptionInstrumentsAsync(string symbol = "", BybitInstrumentStatus? status = null, string baseCoin = "", int? limit = null, string cursor = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOptionInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitOrderbook>> GetOrderbookAsync(BybitCategory category, string symbol, int? limit = null, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) limit?.ValidateIntBetween(nameof(limit), 1, 50);
        if (category == BybitCategory.Linear) limit?.ValidateIntBetween(nameof(limit), 1, 200);
        if (category == BybitCategory.Inverse) limit?.ValidateIntBetween(nameof(limit), 1, 200);
        if (category == BybitCategory.Option) limit?.ValidateIntBetween(nameof(limit), 1, 25);

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
        };
        parameters.AddOptionalParameter("limit", limit);

        return await MainClient.SendBybitRequest<BybitOrderbook>(MainClient.GetUri(v5MarketOrderbookEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitSpotTicker>>> GetSpotTickersAsync(string symbol = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitSpotTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitLinearInverseTicker>>> GetLinearTickersAsync(string symbol = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitLinearInverseTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitLinearInverseTicker>>> GetInverseTickersAsync(string symbol = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitLinearInverseTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitOptionTicker>>> GetOptionTickersAsync(string symbol = "", string baseCoin = "", string expDate = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("expDate", expDate);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitOptionTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitFundingRate>>> GetFundingRateHistoryAsync(BybitCategory category, string symbol, DateTime startTime, DateTime endTime, int limit = 200, CancellationToken ct = default)
        => await GetFundingRateHistoryAsync(category, symbol, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitFundingRate>>> GetFundingRateHistoryAsync(BybitCategory category, string symbol, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
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

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitFundingRate>>(MainClient.GetUri(v5MarketFundingHistoryEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitTrade>>> GetPublicTradingHistoryAsync(BybitCategory category, string symbol = "", string baseCoin = "", BybitOptionType? optionType = null, int? limit = null, CancellationToken ct = default)
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
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("optionType", optionType?.GetLabel());
        parameters.AddOptionalParameter("limit", limit);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitTrade>>(MainClient.GetUri(v5MarketRecentTradeEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, DateTime startTime, DateTime endTime, int limit = 200, string cursor = "", CancellationToken ct = default)
        => await GetOpenInterestAsync(category, symbol, interval, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, cursor, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, long? startTime = null, long? endTime = null, int limit = 200, string cursor = "", CancellationToken ct = default)
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

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOpenInterest>>(MainClient.GetUri(v5MarketOpenInterestEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(BybitCategory category, DateTime startTime, DateTime endTime, string baseCoin = "", BybitPeriod? period = null, CancellationToken ct = default)
        => await GetHistoricalVolatilityAsync(category, baseCoin, period, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitHistoricalVolatility>>> GetHistoricalVolatilityAsync(BybitCategory category, string baseCoin = "", BybitPeriod? period = null, long? startTime = null, long? endTime = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("period", period?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);

        return await MainClient.SendBybitRequest<IEnumerable<BybitHistoricalVolatility>>(MainClient.GetUri(v5MarketHistoricalVolatilityEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiUpdateResponse<BybitInsurance>>> GetInsuranceAsync(string coin = "", CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", coin);

        return await MainClient.SendBybitRequest<BybitRestApiUpdateResponse<BybitInsurance>>(MainClient.GetUri(v5MarketInsuranceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCategoryResponse<BybitRiskLimit>>> GetRiskLimitAsync(BybitCategory category, string symbol = "", CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        return await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitRiskLimit>>(MainClient.GetUri(v5MarketRiskLimitEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(BybitCategory category, string symbol = "", string baseCoin = "", int? limit = null, string cursor = "", CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 200);
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseCoin);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitDeliveryPrice>>(MainClient.GetUri(v5MarketDeliveryPriceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

}
