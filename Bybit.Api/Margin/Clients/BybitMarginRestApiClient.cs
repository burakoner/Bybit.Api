namespace Bybit.Api.Margin;

/// <summary>
/// Bybit Spot Margin Trade API Client.
/// </summary>
public class BybitMarginRestApiClient
{
    // Spot Margin Trade (UTA) Endpoints
    private const string _v5SpotMarginTradeData = "v5/spot-margin-trade/data";
    private const string _v5SpotMarginTradeCollateral = "v5/spot-margin-trade/collateral";
    private const string _v5SpotMarginTradeCurrencyData = "v5/spot-margin-trade/currency-data";
    private const string _v5SpotMarginTradeInterestRateHistory = "v5/spot-margin-trade/interest-rate-history";
    private const string _v5SpotMarginTradeSwitchMode = "v5/spot-margin-trade/switch-mode";
    private const string _v5SpotMarginTradeSetLeverage = "v5/spot-margin-trade/set-leverage";
    private const string _v5SpotMarginTradeState = "v5/spot-margin-trade/state";
    private const string _v5SpotMarginTradeMaxBorrowable = "v5/spot-margin-trade/max-borrowable";
    private const string _v5SpotMarginTradePositionTiers = "v5/spot-margin-trade/position-tiers";
    private const string _v5SpotMarginTradeCoinState = "v5/spot-margin-trade/coinstate";
    private const string _v5SpotMarginTradeRepaymentAvailableAmount = "v5/spot-margin-trade/repayment-available-amount";
    private const string _v5SpotMarginTradeSetAutoRepayMode = "v5/spot-margin-trade/set-auto-repay-mode";
    private const string _v5SpotMarginTradeGetAutoRepayMode = "v5/spot-margin-trade/get-auto-repay-mode";
    private const string _v5SpotMarginTradeFixedBorrowOrderQuote = "v5/spot-margin-trade/fixedborrow-order-quote";
    private const string _v5SpotMarginTradeFixedBorrow = "v5/spot-margin-trade/fixedborrow";
    private const string _v5SpotMarginTradeFixedBorrowRenew = "v5/spot-margin-trade/fixedborrow-renew";
    private const string _v5SpotMarginTradeFixedBorrowOrderInfo = "v5/spot-margin-trade/fixedborrow-order-info";
    private const string _v5SpotMarginTradeFixedBorrowContractInfo = "v5/spot-margin-trade/fixedborrow-contract-info";
    private const string _v5SpotMarginTradeLiability = "v5/spot-margin-trade/liability";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitMarginRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get VIP margin data. This endpoint does not require authentication.
    /// </summary>
    /// <param name="vipLevel">VIP level.</param>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginVipData>>> GetVipMarginDataAsync(string? vipLevel = null, string? currency = null, CancellationToken ct = default)
    {
        var request = new BybitMarginVipDataRequest
        {
            VipLevel = vipLevel,
            Currency = currency,
        };

        return await GetVipMarginDataAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get VIP margin data. This endpoint does not require authentication.
    /// </summary>
    /// <param name="request">VIP margin data request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginVipData>>> GetVipMarginDataAsync(BybitMarginVipDataRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("vipLevel", request.VipLevel);
        parameters.AddOptional("currency", request.Currency);

        var result = await _.SendBybitRequest<BybitMarginVipDataContainer>(_.BuildUri(_v5SpotMarginTradeData), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginVipData>>(default!);
        return result.As(result.Data.VipCoinList);
    }

    /// <summary>
    /// Get tiered collateral ratio. This endpoint does not require authentication.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginTieredCollateralRatio>>> GetTieredCollateralRatiosAsync(string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginTieredCollateralRatio>>(_.BuildUri(_v5SpotMarginTradeCollateral), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginTieredCollateralRatio>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get currency data.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginCurrencyData>>> GetCurrencyDataAsync(string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginCurrencyData>>(_.BuildUri(_v5SpotMarginTradeCurrencyData), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginCurrencyData>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get historical interest rate.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="vipLevel">VIP level.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginInterestRate>>> GetHistoricalInterestRatesAsync(string currency, string? vipLevel = null, long? startTime = null, long? endTime = null, CancellationToken ct = default)
    {
        var request = new BybitMarginInterestRateHistoryRequest(currency)
        {
            VipLevel = vipLevel,
            StartTime = startTime,
            EndTime = endTime,
        };

        return await GetHistoricalInterestRatesAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get historical interest rate.
    /// </summary>
    /// <param name="request">Historical interest rate request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginInterestRate>>> GetHistoricalInterestRatesAsync(BybitMarginInterestRateHistoryRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("currency", request.Currency);
        parameters.AddOptional("vipLevel", request.VipLevel);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginInterestRate>>(_.BuildUri(_v5SpotMarginTradeInterestRateHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginInterestRate>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Turn on / off spot margin trade.
    /// </summary>
    /// <param name="spotMarginMode">True to turn on, false to turn off.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpotMarginMode>> SwitchMarginModeAsync(bool spotMarginMode, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "spotMarginMode", spotMarginMode ? "1" : "0" },
        };

        return await _.SendBybitRequest<BybitSpotMarginMode>(_.BuildUri(_v5SpotMarginTradeSwitchMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set the user's maximum leverage in spot cross margin.
    /// </summary>
    /// <param name="leverage">Leverage. [2, 10]</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetLeverageAsync(decimal leverage, CancellationToken ct = default)
        => await SetLeverageAsync(new BybitMarginSetLeverageRequest(leverage), ct).ConfigureAwait(false);

    /// <summary>
    /// Set the user's maximum leverage in spot cross margin.
    /// </summary>
    /// <param name="leverage">Leverage. [2, 10]</param>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetLeverageAsync(decimal leverage, string? currency, CancellationToken ct = default)
        => await SetLeverageAsync(new BybitMarginSetLeverageRequest(leverage) { Currency = currency }, ct).ConfigureAwait(false);

    /// <summary>
    /// Set the user's maximum leverage in spot cross margin.
    /// </summary>
    /// <param name="request">Set leverage request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetLeverageAsync(BybitMarginSetLeverageRequest request, CancellationToken ct = default)
    {
        request.Leverage.ValidateDecimalBetween(nameof(request.Leverage), 2, 10);
        var parameters = new ParameterCollection();
        parameters.AddString("leverage", request.Leverage);
        parameters.AddOptional("currency", request.Currency);

        return await _.SendBybitRequest(_.BuildUri(_v5SpotMarginTradeSetLeverage), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the Spot margin status and leverage.
    /// </summary>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginStatus>> GetStatusAndLeverageAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitMarginStatus>(_.BuildUri(_v5SpotMarginTradeState), HttpMethod.Get, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Get max borrowable amount.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginMaxBorrowableAmount>> GetMaxBorrowableAmountAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "currency", currency },
        };

        return await _.SendBybitRequest<BybitMarginMaxBorrowableAmount>(_.BuildUri(_v5SpotMarginTradeMaxBorrowable), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get position tiers.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginPositionTier>>> GetPositionTiersAsync(string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginPositionTier>>(_.BuildUri(_v5SpotMarginTradePositionTiers), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginPositionTier>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get coin state.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginCoinState>>> GetCoinStateAsync(string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginCoinState>>(_.BuildUri(_v5SpotMarginTradeCoinState), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginCoinState>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get available amount to repay.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginRepaymentAvailableAmount>> GetAvailableAmountToRepayAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "currency", currency },
        };

        return await _.SendBybitRequest<BybitMarginRepaymentAvailableAmount>(_.BuildUri(_v5SpotMarginTradeRepaymentAvailableAmount), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set spot automatic repayment mode.
    /// </summary>
    /// <param name="autoRepayMode">Auto repay mode.</param>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginAutoRepayMode>>> SetAutoRepayModeAsync(bool autoRepayMode, string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "autoRepayMode", autoRepayMode ? "1" : "0" },
        };
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitMarginAutoRepayModeContainer>(_.BuildUri(_v5SpotMarginTradeSetAutoRepayMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginAutoRepayMode>>(default!);
        return result.As(result.Data.Data);
    }

    /// <summary>
    /// Get spot automatic repayment mode.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginAutoRepayMode>>> GetAutoRepayModeAsync(string? currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.SendBybitRequest<BybitMarginAutoRepayModeContainer>(_.BuildUri(_v5SpotMarginTradeGetAutoRepayMode), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginAutoRepayMode>>(default!);
        return result.As(result.Data.Data);
    }

    /// <summary>
    /// Get fixed-rate borrow order quote.
    /// </summary>
    /// <param name="orderCurrency">Coin name.</param>
    /// <param name="term">Fixed term in days.</param>
    /// <param name="orderBy">Sort field.</param>
    /// <param name="sort">Sort direction.</param>
    /// <param name="limit">Limit for data size per page.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowQuote>>> GetFixedBorrowOrderQuotesAsync(string orderCurrency, int? term = null, BybitFixedBorrowOrderBy? orderBy = null, BybitSortDirection? sort = null, int? limit = null, CancellationToken ct = default)
    {
        var request = new BybitMarginFixedBorrowQuoteRequest(orderCurrency)
        {
            Term = term,
            OrderBy = orderBy,
            Sort = sort,
            Limit = limit,
        };

        return await GetFixedBorrowOrderQuotesAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed-rate borrow order quote.
    /// </summary>
    /// <param name="request">Fixed-rate borrow order quote request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowQuote>>> GetFixedBorrowOrderQuotesAsync(BybitMarginFixedBorrowQuoteRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = new ParameterCollection
        {
            { "orderCurrency", request.OrderCurrency },
        };
        parameters.AddOptionalString("term", request.Term);
        parameters.AddOptionalEnum("orderBy", request.OrderBy);
        parameters.AddOptionalEnum("sort", request.Sort);
        parameters.AddOptional("limit", request.Limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginFixedBorrowQuote>>(_.BuildUri(_v5SpotMarginTradeFixedBorrowOrderQuote), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginFixedBorrowQuote>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Fixed-rate borrow.
    /// </summary>
    /// <param name="orderCurrency">Currency to borrow.</param>
    /// <param name="orderAmount">Amount to borrow.</param>
    /// <param name="annualRate">Annual interest rate.</param>
    /// <param name="term">Fixed term in days.</param>
    /// <param name="repayType">Repayment type.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginFixedBorrowOrderId>> BorrowFixedRateAsync(string orderCurrency, decimal orderAmount, decimal annualRate, int term, BybitFixedBorrowRepayType? repayType = null, CancellationToken ct = default)
    {
        var request = new BybitMarginFixedBorrowRequest(orderCurrency, orderAmount, annualRate, term)
        {
            RepayType = repayType,
        };

        return await BorrowFixedRateAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Fixed-rate borrow.
    /// </summary>
    /// <param name="request">Fixed-rate borrow request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginFixedBorrowOrderId>> BorrowFixedRateAsync(BybitMarginFixedBorrowRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("orderCurrency", request.OrderCurrency);
        parameters.AddString("orderAmount", request.OrderAmount);
        parameters.AddString("annualRate", request.AnnualRate);
        parameters.AddString("term", request.Term);
        parameters.AddOptionalEnum("repayType", request.RepayType);

        return await _.SendBybitRequest<BybitMarginFixedBorrowOrderId>(_.BuildUri(_v5SpotMarginTradeFixedBorrow), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Renew fixed-rate borrow.
    /// </summary>
    /// <param name="loanId">Loan ID.</param>
    /// <param name="quantity">Renewal quantity.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<string>> RenewFixedRateBorrowAsync(string loanId, decimal? quantity = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "loanId", loanId },
        };
        parameters.AddOptionalString("qty", quantity);

        return await _.SendBybitRequest<string>(_.BuildUri(_v5SpotMarginTradeFixedBorrowRenew), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed-rate borrow order info.
    /// </summary>
    /// <param name="orderId">Loan order ID.</param>
    /// <param name="orderCurrency">Loan coin name.</param>
    /// <param name="state">Borrow order state.</param>
    /// <param name="term">Fixed term in days.</param>
    /// <param name="limit">Limit for data size per page.</param>
    /// <param name="cursor">Cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowOrder>>> GetFixedBorrowOrderInfoAsync(string? orderId = null, string? orderCurrency = null, BybitFixedBorrowOrderState? state = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        var request = new BybitMarginFixedBorrowOrderInfoRequest
        {
            OrderId = orderId,
            OrderCurrency = orderCurrency,
            State = state,
            Term = term,
            Limit = limit,
            Cursor = cursor,
        };

        return await GetFixedBorrowOrderInfoAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed-rate borrow order info.
    /// </summary>
    /// <param name="request">Fixed-rate borrow order info request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowOrder>>> GetFixedBorrowOrderInfoAsync(BybitMarginFixedBorrowOrderInfoRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = CreateFixedBorrowInfoParameters(request.OrderId, request.OrderCurrency, request.Term, request.Limit, request.Cursor);
        parameters.AddOptionalEnum("state", request.State);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginFixedBorrowOrder>>(_.BuildUri(_v5SpotMarginTradeFixedBorrowOrderInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginFixedBorrowOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed-rate borrow contract info.
    /// </summary>
    /// <param name="orderId">Loan order ID.</param>
    /// <param name="orderCurrency">Loan coin name.</param>
    /// <param name="term">Fixed term in days.</param>
    /// <param name="limit">Limit for data size per page.</param>
    /// <param name="cursor">Cursor.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowContract>>> GetFixedBorrowContractInfoAsync(string? orderId = null, string? orderCurrency = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        var request = new BybitMarginFixedBorrowContractInfoRequest
        {
            OrderId = orderId,
            OrderCurrency = orderCurrency,
            Term = term,
            Limit = limit,
            Cursor = cursor,
        };

        return await GetFixedBorrowContractInfoAsync(request, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed-rate borrow contract info.
    /// </summary>
    /// <param name="request">Fixed-rate borrow contract info request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitMarginFixedBorrowContract>>> GetFixedBorrowContractInfoAsync(BybitMarginFixedBorrowContractInfoRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = CreateFixedBorrowInfoParameters(request.OrderId, request.OrderCurrency, request.Term, request.Limit, request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitMarginFixedBorrowContract>>(_.BuildUri(_v5SpotMarginTradeFixedBorrowContractInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMarginFixedBorrowContract>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get liability info.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitMarginLiabilityInfo>> GetLiabilityInfoAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "currency", currency },
        };

        return await _.SendBybitRequest<BybitMarginLiabilityInfo>(_.BuildUri(_v5SpotMarginTradeLiability), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    private static ParameterCollection CreateFixedBorrowInfoParameters(string? orderId, string? orderCurrency, int? term, int? limit, string? cursor)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("orderCurrency", orderCurrency);
        parameters.AddOptionalString("term", term);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        return parameters;
    }
}
