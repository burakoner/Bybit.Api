using Bybit.Api.Models.Market;

namespace Bybit.Api.Clients.RestApi;

public class BybitMarketRestApiClient
{
    // Market Endpoints
    protected const string v5MarketKlineEndpoint = "v5/market/kline";
    protected const string v5MarketMarkPriceKlineEndpoint = "v5/market/mark-price-kline";
    protected const string v5MarketIndexPriceKlineEndpoint = "v5/market/index-price-kline";
    protected const string v5MarketPremiumIndexPriceKlineEndpoint = "v5/market/premium-index-price-kline";
    protected const string v5InstrumentsInfoEndpoint = "v5/market/instruments-info";
    protected const string v5MarketOrderbookEndpoint = "v5/market/orderbook";
    protected const string v5MarketTickersEndpoint = "v5/market/tickers";
    protected const string v5MarketFundingHistoryEndpoint = "v5/market/funding/history";
    protected const string v5MarketRecentTradeEndpoint = "v5/market/recent-trade";
    protected const string v5MarketOpenInterestEndpoint = "v5/market/open-interest";
    protected const string v5MarketHistoricalVolatilityEndpoint = "v5/market/historical-volatility";
    protected const string v5MarketInsuranceEndpoint = "v5/market/insurance";
    protected const string v5MarketRiskLimitEndpoint = "v5/market/risk-limit";
    protected const string v5MarketDeliveryPriceEndpoint = "v5/market/delivery-price";
    protected const string v5MarketAccountRatioEndpoint = "/v5/market/account-ratio"; // TODO

    // Internal
    internal BaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitMarketRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }


    public async Task<RestCallResult<IEnumerable<BybitPriceKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitPriceKline>>> GetKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitPriceKline>>(MainClient.GetUri(v5MarketKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitPriceKline>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetMarkKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitMarkPriceKline>>> GetMarkKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitMarkPriceKline>>(MainClient.GetUri(v5MarketMarkPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitMarkPriceKline>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitIndexPriceKline>>> GetIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitIndexPriceKline>>(MainClient.GetUri(v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<IEnumerable<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, DateTime start, DateTime end, int limit = 200, CancellationToken ct = default)
        => await GetPremiumIndexKlinesAsync(category, symbol, interval, start.ConvertToMilliseconds(), end.ConvertToMilliseconds(), limit, ct).ConfigureAwait(false);
    public async Task<RestCallResult<IEnumerable<BybitPremiumIndexPriceKline>>> GetPremiumIndexKlinesAsync(BybitCategory category, string symbol, BybitKlineInterval interval, long? start = null, long? end = null, int limit = 200, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitPremiumIndexPriceKline>>(MainClient.GetUri(v5MarketIndexPriceKlineEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitPremiumIndexPriceKline>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitSpotInstrument>>> GetSpotInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitSpotInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotInstrument>>(null);
        return result.As(result.Data.Payload);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>> GetLinearInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>> GetInverseInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitLinearInverseInstrument>>(MainClient.GetUri(v5InstrumentsInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOptionInstrument>>> GetOptionInstrumentsAsync(string symbol = null, BybitInstrumentStatus? status = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("baseCoin", baseAsset);
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


    public async Task<RestCallResult<IEnumerable<BybitSpotTicker>>> GetSpotTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Spot.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitSpotTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotTicker>>(null);
        return result.As(result.Data.Payload);
    }
    public async Task<RestCallResult<IEnumerable<BybitFuturesTicker>>> GetLinearTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Linear.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitFuturesTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitFuturesTicker>>(null);
        return result.As(result.Data.Payload);
    }
    public async Task<RestCallResult<IEnumerable<BybitFuturesTicker>>> GetInverseTickersAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Inverse.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitFuturesTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitFuturesTicker>>(null);
        return result.As(result.Data.Payload);
    }
    public async Task<RestCallResult<IEnumerable<BybitOptionTicker>>> GetOptionTickersAsync(string symbol = null, string baseAsset = null, string expDate = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", BybitCategory.Option.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("expDate", expDate);

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitOptionTicker>>(MainClient.GetUri(v5MarketTickersEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitFundingRate>>(MainClient.GetUri(v5MarketFundingHistoryEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitTrade>>(MainClient.GetUri(v5MarketRecentTradeEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitTrade>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, DateTime startTime, DateTime endTime, int limit = 200, string cursor = null, CancellationToken ct = default)
        => await GetOpenInterestAsync(category, symbol, interval, startTime.ConvertToMilliseconds(), endTime.ConvertToMilliseconds(), limit, cursor, ct).ConfigureAwait(false);
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOpenInterest>>> GetOpenInterestAsync(BybitCategory category, string symbol, BybitInterestInterval interval, long? startTime = null, long? endTime = null, int limit = 200, string cursor = null, CancellationToken ct = default)
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

        return await MainClient.SendBybitRequest<IEnumerable<BybitHistoricalVolatility>>(MainClient.GetUri(v5MarketHistoricalVolatilityEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }


    public async Task<RestCallResult<IEnumerable<BybitInsurance>>> GetInsuranceAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitRestApiUpdateResponse<BybitInsurance>>(MainClient.GetUri(v5MarketInsuranceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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

        var result = await MainClient.SendBybitRequest<BybitRestApiCategoryResponse<BybitRiskLimit>>(MainClient.GetUri(v5MarketRiskLimitEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitRiskLimit>>(null);
        return result.As(result.Data.Payload);
    }


    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(BybitCategory category, string symbol = null, string baseAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
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

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitDeliveryPrice>>(MainClient.GetUri(v5MarketDeliveryPriceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

}
