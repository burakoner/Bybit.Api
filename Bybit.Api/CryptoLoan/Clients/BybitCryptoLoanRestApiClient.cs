namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Bybit REST API Crypto Loan client.
/// </summary>
public class BybitCryptoLoanRestApiClient
{
    private const string _v5CryptoLoanCommonLoanableData = "v5/crypto-loan-common/loanable-data";
    private const string _v5CryptoLoanCommonCollateralData = "v5/crypto-loan-common/collateral-data";
    private const string _v5CryptoLoanCommonMaxCollateralAmount = "v5/crypto-loan-common/max-collateral-amount";
    private const string _v5CryptoLoanCommonAdjustLtv = "v5/crypto-loan-common/adjust-ltv";
    private const string _v5CryptoLoanCommonAdjustmentHistory = "v5/crypto-loan-common/adjustment-history";
    private const string _v5CryptoLoanCommonPosition = "v5/crypto-loan-common/position";
    private const string _v5CryptoLoanCommonMaxLoan = "v5/crypto-loan-common/max-loan";
    private const string _v5CryptoLoanFlexibleBorrow = "v5/crypto-loan-flexible/borrow";
    private const string _v5CryptoLoanFlexibleRepay = "v5/crypto-loan-flexible/repay";
    private const string _v5CryptoLoanFlexibleRepayCollateral = "v5/crypto-loan-flexible/repay-collateral";
    private const string _v5CryptoLoanFlexibleOngoingCoin = "v5/crypto-loan-flexible/ongoing-coin";
    private const string _v5CryptoLoanFlexibleBorrowHistory = "v5/crypto-loan-flexible/borrow-history";
    private const string _v5CryptoLoanFlexibleRepaymentHistory = "v5/crypto-loan-flexible/repayment-history";
    private const string _v5CryptoLoanFixedSupplyOrderQuote = "v5/crypto-loan-fixed/supply-order-quote";
    private const string _v5CryptoLoanFixedBorrowOrderQuote = "v5/crypto-loan-fixed/borrow-order-quote";
    private const string _v5CryptoLoanFixedBorrow = "v5/crypto-loan-fixed/borrow";
    private const string _v5CryptoLoanFixedRenew = "v5/crypto-loan-fixed/renew";
    private const string _v5CryptoLoanFixedSupply = "v5/crypto-loan-fixed/supply";
    private const string _v5CryptoLoanFixedBorrowOrderCancel = "v5/crypto-loan-fixed/borrow-order-cancel";
    private const string _v5CryptoLoanFixedSupplyOrderCancel = "v5/crypto-loan-fixed/supply-order-cancel";
    private const string _v5CryptoLoanFixedBorrowContractInfo = "v5/crypto-loan-fixed/borrow-contract-info";
    private const string _v5CryptoLoanFixedSupplyContractInfo = "v5/crypto-loan-fixed/supply-contract-info";
    private const string _v5CryptoLoanFixedBorrowOrderInfo = "v5/crypto-loan-fixed/borrow-order-info";
    private const string _v5CryptoLoanFixedRenewInfo = "v5/crypto-loan-fixed/renew-info";
    private const string _v5CryptoLoanFixedSupplyOrderInfo = "v5/crypto-loan-fixed/supply-order-info";
    private const string _v5CryptoLoanFixedFullyRepay = "v5/crypto-loan-fixed/fully-repay";
    private const string _v5CryptoLoanFixedRepayCollateral = "v5/crypto-loan-fixed/repay-collateral";
    private const string _v5CryptoLoanFixedRepaymentHistory = "v5/crypto-loan-fixed/repayment-history";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitCryptoLoanRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get borrowable coins. This endpoint does not require authentication.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanBorrowableCoin>>> GetBorrowableCoinsAsync(string? vipLevel = null, string? currency = null, CancellationToken ct = default)
        => GetBorrowableCoinsAsync(new BybitCryptoLoanBorrowableCoinsRequest { VipLevel = vipLevel, Currency = currency }, ct);

    /// <summary>
    /// Get borrowable coins. This endpoint does not require authentication.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanBorrowableCoin>>> GetBorrowableCoinsAsync(BybitCryptoLoanBorrowableCoinsRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("vipLevel", request.VipLevel);
        parameters.AddOptional("currency", request.Currency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanBorrowableCoin>>(_.BuildUri(_v5CryptoLoanCommonLoanableData), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanBorrowableCoin>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get collateral coins. This endpoint does not require authentication.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanCollateralData>> GetCollateralCoinsAsync(string? currency = null, CancellationToken ct = default)
        => GetCollateralCoinsAsync(new BybitCryptoLoanCollateralCoinsRequest { Currency = currency }, ct);

    /// <summary>
    /// Get collateral coins. This endpoint does not require authentication.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanCollateralData>> GetCollateralCoinsAsync(BybitCryptoLoanCollateralCoinsRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", request.Currency);

        return await _.SendBybitRequest<BybitCryptoLoanCollateralData>(_.BuildUri(_v5CryptoLoanCommonCollateralData), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get the maximum allowed collateral reduction amount.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanMaxCollateralAmount>> GetMaxCollateralReductionAmountAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "currency", currency },
        };

        return await _.SendBybitRequest<BybitCryptoLoanMaxCollateralAmount>(_.BuildUri(_v5CryptoLoanCommonMaxCollateralAmount), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Adjust collateral amount.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanAdjustmentId>> AdjustCollateralAsync(string currency, decimal amount, BybitCryptoLoanAdjustmentDirection direction, CancellationToken ct = default)
        => AdjustCollateralAsync(new BybitCryptoLoanAdjustCollateralRequest(currency, amount, direction), ct);

    /// <summary>
    /// Adjust collateral amount.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanAdjustmentId>> AdjustCollateralAsync(BybitCryptoLoanAdjustCollateralRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "currency", request.Currency },
        };
        parameters.AddString("amount", request.Amount);
        parameters.AddEnum("direction", request.Direction);

        return await _.SendBybitRequest<BybitCryptoLoanAdjustmentId>(_.BuildUri(_v5CryptoLoanCommonAdjustLtv), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get collateral adjustment history.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanCollateralAdjustment>>> GetCollateralAdjustmentHistoryAsync(string? adjustId = null, string? collateralCurrency = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetCollateralAdjustmentHistoryAsync(new BybitCryptoLoanAdjustmentHistoryRequest
        {
            AdjustId = adjustId,
            CollateralCurrency = collateralCurrency,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get collateral adjustment history.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanCollateralAdjustment>>> GetCollateralAdjustmentHistoryAsync(BybitCryptoLoanAdjustmentHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("adjustId", request.AdjustId);
        parameters.AddOptional("collateralCurrency", request.CollateralCurrency);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanCollateralAdjustment>>(_.BuildUri(_v5CryptoLoanCommonAdjustmentHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanCollateralAdjustment>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get crypto loan position.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanPosition>> GetPositionAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitCryptoLoanPosition>(_.BuildUri(_v5CryptoLoanCommonPosition), HttpMethod.Get, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Obtain maximum loan amount.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanMaxLoanAmount>> GetMaxLoanAmountAsync(string currency, IEnumerable<BybitCryptoLoanMaxLoanCollateralRequestItem>? collateralList = null, CancellationToken ct = default)
        => GetMaxLoanAmountAsync(new BybitCryptoLoanMaxLoanAmountRequest(currency) { CollateralList = collateralList?.ToList() }, ct);

    /// <summary>
    /// Obtain maximum loan amount.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanMaxLoanAmount>> GetMaxLoanAmountAsync(BybitCryptoLoanMaxLoanAmountRequest request, CancellationToken ct = default)
    {
        ValidateCollateralList(request.CollateralList, nameof(request.CollateralList));

        var parameters = new ParameterCollection
        {
            { "currency", request.Currency },
        };
        parameters.AddOptional("collateralList", request.CollateralList);

        return await _.SendBybitRequest<BybitCryptoLoanMaxLoanAmount>(_.BuildUri(_v5CryptoLoanCommonMaxLoan), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Borrow flexible crypto loan.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanOrderId>> BorrowFlexibleAsync(string loanCurrency, decimal loanAmount, IEnumerable<BybitCryptoLoanCollateralRequestItem>? collateralList = null, CancellationToken ct = default)
        => BorrowFlexibleAsync(new BybitCryptoLoanFlexibleBorrowRequest(loanCurrency, loanAmount) { CollateralList = collateralList?.ToList() }, ct);

    /// <summary>
    /// Borrow flexible crypto loan.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanOrderId>> BorrowFlexibleAsync(BybitCryptoLoanFlexibleBorrowRequest request, CancellationToken ct = default)
    {
        ValidateCollateralList(request.CollateralList, nameof(request.CollateralList));

        var parameters = new ParameterCollection
        {
            { "loanCurrency", request.LoanCurrency },
        };
        parameters.AddString("loanAmount", request.LoanAmount);
        parameters.AddOptional("collateralList", request.CollateralList);

        return await _.SendBybitRequest<BybitCryptoLoanOrderId>(_.BuildUri(_v5CryptoLoanFlexibleBorrow), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Repay flexible crypto loan.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanRepayId>> RepayFlexibleAsync(string loanCurrency, decimal amount, CancellationToken ct = default)
        => RepayFlexibleAsync(new BybitCryptoLoanRepayRequest(loanCurrency, amount), ct);

    /// <summary>
    /// Repay flexible crypto loan.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanRepayId>> RepayFlexibleAsync(BybitCryptoLoanRepayRequest request, CancellationToken ct = default)
    {
        var parameters = CreateRepaymentParameters(request.LoanCurrency, request.Amount);
        return await _.SendBybitRequest<BybitCryptoLoanRepayId>(_.BuildUri(_v5CryptoLoanFlexibleRepay), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Repay flexible crypto loan with collateral.
    /// </summary>
    public Task<BybitRestCallResult> RepayFlexibleWithCollateralAsync(string loanCurrency, string collateralCoin, decimal amount, CancellationToken ct = default)
        => RepayFlexibleWithCollateralAsync(new BybitCryptoLoanCollateralRepaymentRequest(loanCurrency, collateralCoin, amount), ct);

    /// <summary>
    /// Repay flexible crypto loan with collateral.
    /// </summary>
    public async Task<BybitRestCallResult> RepayFlexibleWithCollateralAsync(BybitCryptoLoanCollateralRepaymentRequest request, CancellationToken ct = default)
    {
        var parameters = CreateCollateralRepaymentParameters(request.LoanCurrency, request.CollateralCoin, request.Amount, null);
        return await _.SendBybitRequest(_.BuildUri(_v5CryptoLoanFlexibleRepayCollateral), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get ongoing flexible crypto loans.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleLoan>>> GetFlexibleLoansAsync(string? loanCurrency = null, CancellationToken ct = default)
        => GetFlexibleLoansAsync(new BybitCryptoLoanFlexibleLoansRequest { LoanCurrency = loanCurrency }, ct);

    /// <summary>
    /// Get ongoing flexible crypto loans.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleLoan>>> GetFlexibleLoansAsync(BybitCryptoLoanFlexibleLoansRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("loanCurrency", request.LoanCurrency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFlexibleLoan>>(_.BuildUri(_v5CryptoLoanFlexibleOngoingCoin), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFlexibleLoan>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get flexible crypto loan borrowing history.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleBorrow>>> GetFlexibleBorrowHistoryAsync(string? orderId = null, string? loanCurrency = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFlexibleBorrowHistoryAsync(new BybitCryptoLoanFlexibleBorrowHistoryRequest
        {
            OrderId = orderId,
            LoanCurrency = loanCurrency,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get flexible crypto loan borrowing history.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleBorrow>>> GetFlexibleBorrowHistoryAsync(BybitCryptoLoanFlexibleBorrowHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateHistoryParameters(request.LoanCurrency, request.Limit, request.Cursor);
        parameters.AddOptional("orderId", request.OrderId);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFlexibleBorrow>>(_.BuildUri(_v5CryptoLoanFlexibleBorrowHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFlexibleBorrow>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get flexible crypto loan repayment history.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleRepayment>>> GetFlexibleRepaymentHistoryAsync(string? repayId = null, string? loanCurrency = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFlexibleRepaymentHistoryAsync(new BybitCryptoLoanFlexibleRepaymentHistoryRequest
        {
            RepayId = repayId,
            LoanCurrency = loanCurrency,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get flexible crypto loan repayment history.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFlexibleRepayment>>> GetFlexibleRepaymentHistoryAsync(BybitCryptoLoanFlexibleRepaymentHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateHistoryParameters(request.LoanCurrency, request.Limit, request.Cursor);
        parameters.AddOptional("repayId", request.RepayId);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFlexibleRepayment>>(_.BuildUri(_v5CryptoLoanFlexibleRepaymentHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFlexibleRepayment>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed crypto loan lending market. This endpoint does not require authentication.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedMarketQuote>>> GetFixedLendingMarketAsync(string orderCurrency, BybitFixedBorrowOrderBy orderBy, int? term = null, BybitSortDirection? sort = null, int? limit = null, CancellationToken ct = default)
        => GetFixedLendingMarketAsync(new BybitCryptoLoanFixedMarketRequest(orderCurrency, orderBy) { Term = term, Sort = sort, Limit = limit }, ct);

    /// <summary>
    /// Get fixed crypto loan lending market. This endpoint does not require authentication.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedMarketQuote>>> GetFixedLendingMarketAsync(BybitCryptoLoanFixedMarketRequest request, CancellationToken ct = default)
    {
        var parameters = CreateFixedMarketParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedMarketQuote>>(_.BuildUri(_v5CryptoLoanFixedSupplyOrderQuote), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedMarketQuote>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get fixed crypto loan borrowing market. This endpoint does not require authentication.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedMarketQuote>>> GetFixedBorrowingMarketAsync(string orderCurrency, BybitFixedBorrowOrderBy orderBy, int? term = null, BybitSortDirection? sort = null, int? limit = null, CancellationToken ct = default)
        => GetFixedBorrowingMarketAsync(new BybitCryptoLoanFixedMarketRequest(orderCurrency, orderBy) { Term = term, Sort = sort, Limit = limit }, ct);

    /// <summary>
    /// Get fixed crypto loan borrowing market. This endpoint does not require authentication.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedMarketQuote>>> GetFixedBorrowingMarketAsync(BybitCryptoLoanFixedMarketRequest request, CancellationToken ct = default)
    {
        var parameters = CreateFixedMarketParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedMarketQuote>>(_.BuildUri(_v5CryptoLoanFixedBorrowOrderQuote), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedMarketQuote>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Create fixed crypto loan borrow order.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanOrderId>> BorrowFixedAsync(string orderCurrency, decimal orderAmount, decimal annualRate, int term, bool? autoRepay = null, BybitFixedBorrowRepayType? repayType = null, IEnumerable<BybitCryptoLoanCollateralRequestItem>? collateralList = null, CancellationToken ct = default)
    {
        return BorrowFixedAsync(new BybitCryptoLoanFixedBorrowRequest(orderCurrency, orderAmount, annualRate, term)
        {
            AutoRepay = autoRepay,
            RepayType = repayType,
            CollateralList = collateralList?.ToList(),
        }, ct);
    }

    /// <summary>
    /// Create fixed crypto loan borrow order.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanOrderId>> BorrowFixedAsync(BybitCryptoLoanFixedBorrowRequest request, CancellationToken ct = default)
    {
        ValidateCollateralList(request.CollateralList, nameof(request.CollateralList));

        var parameters = new ParameterCollection
        {
            { "orderCurrency", request.OrderCurrency },
        };
        parameters.AddString("orderAmount", request.OrderAmount);
        parameters.AddString("annualRate", request.AnnualRate);
        parameters.AddString("term", request.Term);
        if (request.AutoRepay != null)
            parameters.Add("autoRepay", request.AutoRepay.Value ? "true" : "false");
        parameters.AddOptionalEnum("repayType", request.RepayType);
        parameters.AddOptional("collateralList", request.CollateralList);

        return await _.SendBybitRequest<BybitCryptoLoanOrderId>(_.BuildUri(_v5CryptoLoanFixedBorrow), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Renew fixed crypto loan borrow order.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanOrderId>> RenewFixedBorrowAsync(string loanId, IEnumerable<BybitCryptoLoanCollateralRequestItem>? collateralList = null, CancellationToken ct = default)
        => RenewFixedBorrowAsync(new BybitCryptoLoanFixedRenewRequest(loanId) { CollateralList = collateralList?.ToList() }, ct);

    /// <summary>
    /// Renew fixed crypto loan borrow order.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanOrderId>> RenewFixedBorrowAsync(BybitCryptoLoanFixedRenewRequest request, CancellationToken ct = default)
    {
        ValidateCollateralList(request.CollateralList, nameof(request.CollateralList));

        var parameters = new ParameterCollection
        {
            { "loanId", request.LoanId },
        };
        parameters.AddOptional("collateralList", request.CollateralList);

        return await _.SendBybitRequest<BybitCryptoLoanOrderId>(_.BuildUri(_v5CryptoLoanFixedRenew), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Create fixed crypto loan supply order.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanOrderId>> SupplyFixedAsync(string orderCurrency, decimal orderAmount, decimal annualRate, int term, BybitCryptoLoanSupplyAvailableSource? availableSource = null, CancellationToken ct = default)
        => SupplyFixedAsync(new BybitCryptoLoanFixedSupplyRequest(orderCurrency, orderAmount, annualRate, term) { AvailableSource = availableSource }, ct);

    /// <summary>
    /// Create fixed crypto loan supply order.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanOrderId>> SupplyFixedAsync(BybitCryptoLoanFixedSupplyRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "orderCurrency", request.OrderCurrency },
        };
        parameters.AddString("orderAmount", request.OrderAmount);
        parameters.AddString("annualRate", request.AnnualRate);
        parameters.AddString("term", request.Term);
        parameters.AddOptionalEnum("availableSource", request.AvailableSource);

        return await _.SendBybitRequest<BybitCryptoLoanOrderId>(_.BuildUri(_v5CryptoLoanFixedSupply), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel fixed crypto loan borrow order.
    /// </summary>
    public async Task<BybitRestCallResult> CancelFixedBorrowOrderAsync(string orderId, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "orderId", orderId },
        };

        return await _.SendBybitRequest(_.BuildUri(_v5CryptoLoanFixedBorrowOrderCancel), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel fixed crypto loan supply order.
    /// </summary>
    public Task<BybitRestCallResult> CancelFixedSupplyOrderAsync(string orderId, BybitCryptoLoanRefundedAccount? refundedAccount = null, CancellationToken ct = default)
        => CancelFixedSupplyOrderAsync(new BybitCryptoLoanFixedCancelSupplyRequest(orderId) { RefundedAccount = refundedAccount }, ct);

    /// <summary>
    /// Cancel fixed crypto loan supply order.
    /// </summary>
    public async Task<BybitRestCallResult> CancelFixedSupplyOrderAsync(BybitCryptoLoanFixedCancelSupplyRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "orderId", request.OrderId },
        };
        parameters.AddOptionalEnum("refundedAccount", request.RefundedAccount);

        return await _.SendBybitRequest(_.BuildUri(_v5CryptoLoanFixedSupplyOrderCancel), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed crypto loan borrow contract information.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedBorrowContract>>> GetFixedBorrowContractsAsync(string? orderId = null, string? loanId = null, string? orderCurrency = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFixedBorrowContractsAsync(new BybitCryptoLoanFixedBorrowContractsRequest
        {
            OrderId = orderId,
            LoanId = loanId,
            OrderCurrency = orderCurrency,
            Term = term,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get fixed crypto loan borrow contract information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedBorrowContract>>> GetFixedBorrowContractsAsync(BybitCryptoLoanFixedBorrowContractsRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateFixedContractParameters(request.OrderId, request.OrderCurrency, request.Term, request.Limit, request.Cursor);
        parameters.AddOptional("loanId", request.LoanId);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedBorrowContract>>(_.BuildUri(_v5CryptoLoanFixedBorrowContractInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedBorrowContract>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed crypto loan supply contract information.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedSupplyContract>>> GetFixedSupplyContractsAsync(string? orderId = null, string? supplyId = null, string? supplyCurrency = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFixedSupplyContractsAsync(new BybitCryptoLoanFixedSupplyContractsRequest
        {
            OrderId = orderId,
            SupplyId = supplyId,
            SupplyCurrency = supplyCurrency,
            Term = term,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get fixed crypto loan supply contract information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedSupplyContract>>> GetFixedSupplyContractsAsync(BybitCryptoLoanFixedSupplyContractsRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateFixedContractParameters(request.OrderId, null, request.Term, request.Limit, request.Cursor);
        parameters.AddOptional("supplyId", request.SupplyId);
        parameters.AddOptional("supplyCurrency", request.SupplyCurrency);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedSupplyContract>>(_.BuildUri(_v5CryptoLoanFixedSupplyContractInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedSupplyContract>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed crypto loan borrow order information.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedBorrowOrder>>> GetFixedBorrowOrdersAsync(string? orderId = null, string? orderCurrency = null, BybitCryptoLoanFixedOrderState? state = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        => GetFixedBorrowOrdersAsync(new BybitCryptoLoanFixedOrdersRequest { OrderId = orderId, OrderCurrency = orderCurrency, State = state, Term = term, Limit = limit, Cursor = cursor }, ct);

    /// <summary>
    /// Get fixed crypto loan borrow order information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedBorrowOrder>>> GetFixedBorrowOrdersAsync(BybitCryptoLoanFixedOrdersRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateFixedOrderParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedBorrowOrder>>(_.BuildUri(_v5CryptoLoanFixedBorrowOrderInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedBorrowOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed crypto loan renew order information.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedRenewOrder>>> GetFixedRenewOrdersAsync(string? orderId = null, string? orderCurrency = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        => GetFixedRenewOrdersAsync(new BybitCryptoLoanFixedRenewOrdersRequest { OrderId = orderId, OrderCurrency = orderCurrency, Limit = limit, Cursor = cursor }, ct);

    /// <summary>
    /// Get fixed crypto loan renew order information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedRenewOrder>>> GetFixedRenewOrdersAsync(BybitCryptoLoanFixedRenewOrdersRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("orderCurrency", request.OrderCurrency);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedRenewOrder>>(_.BuildUri(_v5CryptoLoanFixedRenewInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedRenewOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get fixed crypto loan supply order information.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedSupplyOrder>>> GetFixedSupplyOrdersAsync(string? orderId = null, string? orderCurrency = null, BybitCryptoLoanFixedOrderState? state = null, int? term = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
        => GetFixedSupplyOrdersAsync(new BybitCryptoLoanFixedOrdersRequest { OrderId = orderId, OrderCurrency = orderCurrency, State = state, Term = term, Limit = limit, Cursor = cursor }, ct);

    /// <summary>
    /// Get fixed crypto loan supply order information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedSupplyOrder>>> GetFixedSupplyOrdersAsync(BybitCryptoLoanFixedOrdersRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateFixedOrderParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedSupplyOrder>>(_.BuildUri(_v5CryptoLoanFixedSupplyOrderInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedSupplyOrder>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Fully repay fixed crypto loan.
    /// </summary>
    public Task<BybitRestCallResult<BybitCryptoLoanRepayId>> RepayFixedAsync(string? loanId = null, string? loanCurrency = null, CancellationToken ct = default)
        => RepayFixedAsync(new BybitCryptoLoanFixedRepayRequest { LoanId = loanId, LoanCurrency = loanCurrency }, ct);

    /// <summary>
    /// Fully repay fixed crypto loan.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCryptoLoanRepayId>> RepayFixedAsync(BybitCryptoLoanFixedRepayRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(request.LoanId) && string.IsNullOrEmpty(request.LoanCurrency))
            throw new ArgumentException("Either loanId or loanCurrency is required.", nameof(request));

        var parameters = new ParameterCollection();
        parameters.AddOptional("loanId", request.LoanId);
        parameters.AddOptional("loanCurrency", request.LoanCurrency);

        return await _.SendBybitRequest<BybitCryptoLoanRepayId>(_.BuildUri(_v5CryptoLoanFixedFullyRepay), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Repay fixed crypto loan with collateral.
    /// </summary>
    public Task<BybitRestCallResult> RepayFixedWithCollateralAsync(string loanCurrency, string collateralCoin, decimal amount, string? loanId = null, CancellationToken ct = default)
        => RepayFixedWithCollateralAsync(new BybitCryptoLoanCollateralRepaymentRequest(loanCurrency, collateralCoin, amount) { LoanId = loanId }, ct);

    /// <summary>
    /// Repay fixed crypto loan with collateral.
    /// </summary>
    public async Task<BybitRestCallResult> RepayFixedWithCollateralAsync(BybitCryptoLoanCollateralRepaymentRequest request, CancellationToken ct = default)
    {
        var parameters = CreateCollateralRepaymentParameters(request.LoanCurrency, request.CollateralCoin, request.Amount, request.LoanId);
        return await _.SendBybitRequest(_.BuildUri(_v5CryptoLoanFixedRepayCollateral), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get fixed crypto loan repayment history.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitCryptoLoanFixedRepayment>>> GetFixedRepaymentHistoryAsync(string? repayId = null, string? loanCurrency = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFixedRepaymentHistoryAsync(new BybitCryptoLoanFixedRepaymentHistoryRequest
        {
            RepayId = repayId,
            LoanCurrency = loanCurrency,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get fixed crypto loan repayment history.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitCryptoLoanFixedRepayment>>> GetFixedRepaymentHistoryAsync(BybitCryptoLoanFixedRepaymentHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = CreateHistoryParameters(request.LoanCurrency, request.Limit, request.Cursor);
        parameters.AddOptional("repayId", request.RepayId);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCryptoLoanFixedRepayment>>(_.BuildUri(_v5CryptoLoanFixedRepaymentHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCryptoLoanFixedRepayment>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    private static ParameterCollection CreateFixedMarketParameters(BybitCryptoLoanFixedMarketRequest request)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = new ParameterCollection
        {
            { "orderCurrency", request.OrderCurrency },
        };
        parameters.AddEnum("orderBy", request.OrderBy);
        parameters.AddOptionalString("term", request.Term);
        parameters.AddOptionalEnum("sort", request.Sort);
        parameters.AddOptional("limit", request.Limit);

        return parameters;
    }

    private static ParameterCollection CreateRepaymentParameters(string loanCurrency, decimal amount)
    {
        var parameters = new ParameterCollection
        {
            { "loanCurrency", loanCurrency },
        };
        parameters.AddString("amount", amount);

        return parameters;
    }

    private static ParameterCollection CreateCollateralRepaymentParameters(string loanCurrency, string collateralCoin, decimal amount, string? loanId)
    {
        var parameters = CreateRepaymentParameters(loanCurrency, amount);
        parameters.Add("collateralCoin", collateralCoin);
        parameters.AddOptional("loanId", loanId);

        return parameters;
    }

    private static ParameterCollection CreateHistoryParameters(string? loanCurrency, int? limit, string? cursor)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("loanCurrency", loanCurrency);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        return parameters;
    }

    private static ParameterCollection CreateFixedContractParameters(string? orderId, string? orderCurrency, int? term, int? limit, string? cursor)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("orderCurrency", orderCurrency);
        parameters.AddOptionalString("term", term);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        return parameters;
    }

    private static ParameterCollection CreateFixedOrderParameters(BybitCryptoLoanFixedOrdersRequest request)
    {
        var parameters = CreateFixedContractParameters(request.OrderId, request.OrderCurrency, request.Term, request.Limit, request.Cursor);
        parameters.AddOptionalEnum("state", request.State);

        return parameters;
    }

    private static void ValidateCollateralList<T>(List<T>? collateralList, string parameterName)
    {
        if (collateralList != null && collateralList.Count > 100)
            throw new ArgumentException("Collateral list supports up to 100 items.", parameterName);
    }
}
