namespace Bybit.Api.Account;

/// <summary>
/// Bybit Rest API Account Client
/// </summary>
public class BybitAccountRestApiClient
{
    // Account Endpoints
    private const string _v5AccountWalletBalance = "v5/account/wallet-balance";
    private const string _v5AccountWithdrawal = "v5/account/withdrawal";
    private const string _v5AccountInstrumentsInfo = "v5/account/instruments-info";
    private const string _v5AccountUpgradeToUta = "v5/account/upgrade-to-uta";
    private const string _v5AccountBorrowHistory = "v5/account/borrow-history";
    private const string _v5AccountBorrow = "v5/account/borrow";
    private const string _v5AccountNoConvertRepay = "v5/account/no-convert-repay";
    private const string _v5AccountRepay = "v5/account/repay";
    private const string _v5AccountSetCollateralSwitch = "v5/account/set-collateral-switch";
    private const string _v5AccountSetCollateralSwitchBatch = "v5/account/set-collateral-switch-batch";
    private const string _v5AccountCollateralInfo = "v5/account/collateral-info";
    private const string _v5AssetCoinGreeks = "v5/asset/coin-greeks";
    private const string _v5AccountFeeRate = "v5/account/fee-rate";
    private const string _v5AccountInfo = "v5/account/info";
    private const string _v5AccountQueryDcpInfo = "v5/account/query-dcp-info";
    private const string _v5AccountTransactionLog = "v5/account/transaction-log";
    private const string _v5AccountContractTransactionLog = "v5/account/contract-transaction-log";
    private const string _v5AccountSmpGroup = "v5/account/smp-group";
    private const string _v5AccountSetMarginMode = "v5/account/set-margin-mode";
    private const string _v5AccountSetHedgingMode = "v5/account/set-hedging-mode";
    private const string _v5AccountUserSettingConfig = "v5/account/user-setting-config";
    private const string _v5AccountSetDeltaNeutralMode = "v5/account/set-delta-mode";
    private const string _v5AccountSetLimitPxAction = "v5/account/set-limit-px-action";
    private const string _v5AccountQuickRepayment = "v5/account/quick-repayment";
    private const string _v5AccountOptionAssetInfo = "v5/account/option-asset-info";
    private const string _v5AccountPayInfo = "v5/account/pay-info";
    private const string _v5AccountTradeInfoForAnalysis = "v5/account/trade-info-for-analysis";
    private const string _v5AccountMmpModify = "v5/account/mmp-modify";
    private const string _v5AccountMmpReset = "v5/account/mmp-reset";
    private const string _v5AccountMmpState = "v5/account/mmp-state";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitAccountRestApiClient(BybitRestApiClient root)
    {
        this._ = root.BaseClient;
    }
    #endregion

    #region Account Methods
    /// <summary>
    /// Obtain wallet balance, query asset information of each currency, and account risk rate information. By default, currency information with assets or liabilities of 0 is not returned.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountBalance>>> GetBalancesAsync(string? asset = null, CancellationToken ct = default)
    {
        return GetBalancesAsync(new BybitAccountWalletBalanceRequest { Asset = asset }, ct);
    }

    /// <summary>
    /// Obtain wallet balance, query asset information of each currency, and account risk rate information.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAccountBalance>>> GetBalancesAsync(BybitAccountWalletBalanceRequest request, CancellationToken ct = default)
    {
        if (request.AccountType.IsNotIn(BybitAccountType.Unified))
            throw new NotSupportedException($"{request.AccountType} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", request.AccountType);
        parameters.AddOptional("coin", request.Asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountBalance>>(_.BuildUri(_v5AccountWalletBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountBalance>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get unified account transferable amount.
    /// </summary>
    /// <param name="assets">Coin names. Multiple coins can be separated by comma.</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountTransferableAmount>> GetTransferableAmountAsync(string assets, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("coinName", assets);

        return await _.SendBybitRequest<BybitAccountTransferableAmount>(_.BuildUri(_v5AccountWithdrawal), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get account spot instruments.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountSpotInstrument>>> GetAccountSpotInstrumentsAsync(string? symbol = null, CancellationToken ct = default)
    {
        return GetAccountSpotInstrumentsAsync(new BybitAccountInstrumentsRequest(BybitCategory.Spot) { Symbol = symbol }, ct);
    }

    /// <summary>
    /// Get account spot instruments.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAccountSpotInstrument>>> GetAccountSpotInstrumentsAsync(BybitAccountInstrumentsRequest request, CancellationToken ct = default)
    {
        if (request.Category.IsNotIn(BybitCategory.Spot))
            throw new NotSupportedException($"{request.Category} is not supported for this endpoint.");

        var parameters = CreateInstrumentsParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountSpotInstrument>>(_.BuildUri(_v5AccountInstrumentsInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountSpotInstrument>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get account linear or inverse instruments.
    /// </summary>
    /// <param name="category">Product type. linear, inverse</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="limit">Limit for data size per page. [1, 200]</param>
    /// <param name="cursor">Cursor for pagination</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountFuturesInstrument>>> GetAccountFuturesInstrumentsAsync(BybitCategory category, string? symbol = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetAccountFuturesInstrumentsAsync(new BybitAccountInstrumentsRequest(category)
        {
            Symbol = symbol,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get account linear or inverse instruments.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAccountFuturesInstrument>>> GetAccountFuturesInstrumentsAsync(BybitAccountInstrumentsRequest request, CancellationToken ct = default)
    {
        if (request.Category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{request.Category} is not supported for this endpoint.");

        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 200);
        var parameters = CreateInstrumentsParameters(request);
        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountFuturesInstrument>>(_.BuildUri(_v5AccountInstrumentsInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountFuturesInstrument>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Upgrade Unified Account
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountUpgrade>> UpgradeToUnifiedAccountAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAccountUpgrade>(_.BuildUri(_v5AccountUpgradeToUta), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Borrow History
    /// </summary>
    /// <param name="asset">Currency</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end time. timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountBorrow>>> GetBorrowHistoryAsync(string? asset = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetBorrowHistoryAsync(new BybitAccountBorrowHistoryRequest
        {
            Asset = asset,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get Borrow History
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountBorrow>>> GetBorrowHistoryAsync(BybitAccountBorrowHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", request.Asset);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountBorrow>>(_.BuildUri(_v5AccountBorrowHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountBorrow>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Manually borrow liabilities for unified account.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="amount">Borrow amount</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAccountManualBorrow>> ManualBorrowAsync(string asset, decimal amount, CancellationToken ct = default)
    {
        return ManualBorrowAsync(new BybitAccountManualBorrowRequest(asset, amount), ct);
    }

    /// <summary>
    /// Manually borrow liabilities for unified account.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountManualBorrow>> ManualBorrowAsync(BybitAccountManualBorrowRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("coin", request.Asset);
        parameters.AddString("amount", request.Amount);

        return await _.SendBybitRequest<BybitAccountManualBorrow>(_.BuildUri(_v5AccountBorrow), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Manually repay without asset conversion.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="amount">Repay amount</param>
    /// <param name="repaymentType">Repayment type</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAccountRepay>> ManualRepayWithoutConversionAsync(string asset, decimal? amount = null, BybitAccountRepaymentType? repaymentType = null, CancellationToken ct = default)
    {
        return ManualRepayWithoutConversionAsync(new BybitAccountNoConvertRepayRequest(asset)
        {
            Amount = amount,
            RepaymentType = repaymentType,
        }, ct);
    }

    /// <summary>
    /// Manually repay without asset conversion.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountRepay>> ManualRepayWithoutConversionAsync(BybitAccountNoConvertRepayRequest request, CancellationToken ct = default)
    {
        var parameters = CreateRepayParameters(request.Asset, request.Amount, request.RepaymentType);
        return await _.SendBybitRequest<BybitAccountRepay>(_.BuildUri(_v5AccountNoConvertRepay), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Manually repay liabilities. Repayment may convert assets automatically.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="amount">Repay amount</param>
    /// <param name="repaymentType">Repayment type</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAccountRepay>> ManualRepayAsync(string? asset = null, decimal? amount = null, BybitAccountRepaymentType? repaymentType = null, CancellationToken ct = default)
    {
        return ManualRepayAsync(new BybitAccountManualRepayRequest
        {
            Asset = asset,
            Amount = amount,
            RepaymentType = repaymentType,
        }, ct);
    }

    /// <summary>
    /// Manually repay liabilities. Repayment may convert assets automatically.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountRepay>> ManualRepayAsync(BybitAccountManualRepayRequest request, CancellationToken ct = default)
    {
        var parameters = CreateRepayParameters(request.Asset, request.Amount, request.RepaymentType);
        return await _.SendBybitRequest<BybitAccountRepay>(_.BuildUri(_v5AccountRepay), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set collateral coin switch.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="collateralSwitch">Collateral switch status</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult> SetCollateralCoinAsync(string asset, BybitSwitchStatus collateralSwitch, CancellationToken ct = default)
    {
        return SetCollateralCoinAsync(new BybitAccountSetCollateralRequest(asset, collateralSwitch), ct);
    }

    /// <summary>
    /// Set collateral coin switch.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetCollateralCoinAsync(BybitAccountSetCollateralRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("coin", request.Asset);
        parameters.AddEnum("collateralSwitch", request.CollateralSwitch);

        return await _.SendBybitRequest(_.BuildUri(_v5AccountSetCollateralSwitch), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Batch set collateral coin switches.
    /// </summary>
    /// <param name="items">Collateral switch items</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountBatchSetCollateralResult>>> BatchSetCollateralCoinsAsync(IEnumerable<BybitAccountBatchSetCollateralItem> items, CancellationToken ct = default)
    {
        return BatchSetCollateralCoinsAsync(new BybitAccountBatchSetCollateralRequest(items), ct);
    }

    /// <summary>
    /// Batch set collateral coin switches.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountBatchSetCollateralResult>>> BatchSetCollateralCoinsAsync(BybitAccountBatchSetCollateralRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("request", request.Items);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountBatchSetCollateralResult>>(_.BuildUri(_v5AccountSetCollateralSwitchBatch), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountBatchSetCollateralResult>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get the collateral information of the current unified margin account, including loan interest rate, loanable amount, collateral conversion rate, whether it can be mortgaged as margin, etc.
    /// </summary>
    /// <param name="asset">Asset currency of all current collateral</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountCollateralInfo>>> GetCollateralInfoAsync(string? asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountCollateralInfo>>(_.BuildUri(_v5AccountCollateralInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountCollateralInfo>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get current account Greeks information
    /// </summary>
    /// <param name="baseAsset">Base coin. If not passed, all supported base coin greeks will be returned by default</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountGreeks>>> GetGreeksAsync(string? baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("baseCoin", baseAsset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountGreeks>>(_.BuildUri(_v5AssetCoinGreeks), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountGreeks>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get the trading fee rate.
    /// </summary>
    /// <param name="category">Product type. spot, linear, inverse, option</param>
    /// <param name="symbol">Symbol name. Valid for linear, inverse, spot</param>
    /// <param name="baseAsset">Base coin. SOL, BTC, ETH. Valid for option</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountFeeRate>>> GetFeeRateAsync(BybitCategory category, string? symbol = null, string? baseAsset = null, CancellationToken ct = default)
    {
        return GetFeeRateAsync(new BybitAccountFeeRateRequest(category)
        {
            Symbol = symbol,
            BaseAsset = baseAsset,
        }, ct);
    }

    /// <summary>
    /// Get the trading fee rate.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountFeeRate>>> GetFeeRateAsync(BybitAccountFeeRateRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("baseCoin", request.BaseAsset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountFeeRate>>(_.BuildUri(_v5AccountFeeRate), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountFeeRate>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query the margin mode configuration of the account.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccount>> GetAccountAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAccount>(_.BuildUri(_v5AccountInfo), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Query disconnect-cancel-all configuration.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountDcpInfo>>> GetDcpInfoAsync(CancellationToken ct = default)
    {
        var result = await _.SendBybitRequest<BybitAccountDcpInfoResult>(_.BuildUri(_v5AccountQueryDcpInfo), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountDcpInfo>>(default!);
        return result.As(result.Data.DcpInfos);
    }

    /// <summary>
    /// Query transaction logs in Unified account, it supports up to 2 years data
    /// </summary>
    /// <param name="account">Account Type. UNIFIED</param>
    /// <param name="category">Product type. spot,linear,option</param>
    /// <param name="asset">Currency</param>
    /// <param name="baseAsset">BaseCoin. e.g., BTC of BTCPERP</param>
    /// <param name="type">Types of transaction logs</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountTransaction>>> GetTransactionsAsync(BybitAccountType? account = null, BybitCategory? category = null, string? asset = null, string? baseAsset = null, BybitTransactionType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetTransactionsAsync(new BybitAccountTransactionsRequest
        {
            Account = account,
            Category = category,
            Asset = asset,
            BaseAsset = baseAsset,
            Type = type,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query transaction logs in Unified account, it supports up to 2 years data.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountTransaction>>> GetTransactionsAsync(BybitAccountTransactionsRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddOptionalEnum("accountType", request.Account);
        parameters.AddOptionalEnum("category", request.Category);
        parameters.AddOptional("currency", request.Asset);
        parameters.AddOptional("baseCoin", request.BaseAsset);
        parameters.AddOptionalEnum("type", request.Type);
        parameters.AddOptional("transSubType", request.TransactionSubType);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountTransaction>>(_.BuildUri(_v5AccountTransactionLog), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountTransaction>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query transaction logs in the derivatives wallet (classic account), and inverse derivatives account (upgraded to UTA)
    /// </summary>
    /// <param name="asset">Currency</param>
    /// <param name="baseAsset">BaseCoin. e.g., BTC of BTCPERP</param>
    /// <param name="type">Types of transaction logs</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAccountTransactionClassic>>> GetClassicAccountTransactionsAsync(string? asset = null, string? baseAsset = null, BybitTransactionType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetClassicAccountTransactionsAsync(new BybitAccountClassicTransactionsRequest
        {
            Asset = asset,
            BaseAsset = baseAsset,
            Type = type,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query transaction logs in the derivatives wallet (classic account), and inverse derivatives account (upgraded to UTA).
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountTransactionClassic>>> GetClassicAccountTransactionsAsync(BybitAccountClassicTransactionsRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", request.Asset);
        parameters.AddOptional("baseCoin", request.BaseAsset);
        parameters.AddOptionalEnum("type", request.Type);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountTransactionClassic>>(_.BuildUri(_v5AccountContractTransactionLog), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountTransactionClassic>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get account SMP group.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountSmpGroup>> GetSmpGroupAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAccountSmpGroup>(_.BuildUri(_v5AccountSmpGroup), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Set Margin Mode
    /// </summary>
    /// <param name="marginMode">Margin mode</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountReason>>> SetMarginModeAsync(BybitMarginMode marginMode, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("setMarginMode", marginMode);

        var result = await _.SendBybitRequest<BybitAccountSetMarginModeResult>(_.BuildUri(_v5AccountSetMarginMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountReason>>(default!);
        return result.As(result.Data.Reasons);
    }

    /// <summary>
    /// Set unified account spot hedging.
    /// </summary>
    /// <param name="hedgingMode">Spot hedging status</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetSpotHedgingAsync(BybitSwitchStatus hedgingMode, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("setHedgingMode", hedgingMode);

        return await _.SendBybitRequest(_.BuildUri(_v5AccountSetHedgingMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get trade behavior configuration.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountUserSettingConfig>> GetTradeBehaviorConfigAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAccountUserSettingConfig>(_.BuildUri(_v5AccountUserSettingConfig), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Set delta neutral mode.
    /// </summary>
    /// <param name="enabled">Whether delta neutral mode is enabled</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetDeltaNeutralModeAsync(bool enabled, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "deltaEnable", enabled ? "1" : "0" },
        };

        return await _.SendBybitRequest(_.BuildUri(_v5AccountSetDeltaNeutralMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set limit price behavior.
    /// </summary>
    /// <param name="category">Product type. spot, linear, inverse</param>
    /// <param name="modifyEnable">Whether to enable limit price protection</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult> SetPriceLimitBehaviorAsync(BybitCategory category, bool modifyEnable, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Spot, BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("modifyEnable", modifyEnable);

        return await _.SendBybitRequest(_.BuildUri(_v5AccountSetLimitPxAction), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Repay liabilities for the parent UID.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountRepayLiability>>> RepayLiabilityAsync(string? asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountRepayLiability>>(_.BuildUri(_v5AccountQuickRepayment), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountRepayLiability>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get option asset information.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountOptionAssetInfo>>> GetOptionAssetInfoAsync(CancellationToken ct = default)
    {
        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountOptionAssetInfo>>(_.BuildUri(_v5AccountOptionAssetInfo), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountOptionAssetInfo>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get account pay information.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountPayInfo>> GetPayInfoAsync(string? asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        return await _.SendBybitRequest<BybitAccountPayInfo>(_.BuildUri(_v5AccountPayInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get trade info for analysis.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">Query start timestamp (ms)</param>
    /// <param name="endTime">Query end timestamp (ms)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAccountTradeAnalysis>> GetTradeAnalysisAsync(string symbol, long? startTime = null, long? endTime = null, CancellationToken ct = default)
    {
        return GetTradeAnalysisAsync(new BybitAccountTradeAnalysisRequest(symbol)
        {
            StartTime = startTime,
            EndTime = endTime,
        }, ct);
    }

    /// <summary>
    /// Get trade info for analysis.
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountTradeAnalysis>> GetTradeAnalysisAsync(BybitAccountTradeAnalysisRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", request.Symbol);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);

        return await _.SendBybitRequest<BybitAccountTradeAnalysis>(_.BuildUri(_v5AccountTradeInfoForAnalysis), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Sets Market Maker Protection
    /// </summary>
    /// <param name="baseAsset">Base coin</param>
    /// <param name="window">Time window (ms)</param>
    /// <param name="frozenPeriod">Frozen period (ms). "0" means the trade will remain frozen until manually reset</param>
    /// <param name="quantityLimit">Trade qty limit (positive and up to 2 decimal places)</param>
    /// <param name="deltaLimit">Delta limit (positive and up to 2 decimal places)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult> SetMmpAsync(string baseAsset, int window, int frozenPeriod, decimal quantityLimit, decimal deltaLimit, CancellationToken ct = default)
    {
        return SetMmpAsync(new BybitAccountSetMmpRequest(baseAsset, window, frozenPeriod, quantityLimit, deltaLimit), ct);
    }

    /// <summary>
    /// Sets Market Maker Protection
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetMmpAsync(BybitAccountSetMmpRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("baseCoin", request.BaseAsset);
        parameters.AddString("window", request.Window);
        parameters.AddString("frozenPeriod", request.FrozenPeriod);
        parameters.AddString("qtyLimit", request.QuantityLimit);
        parameters.AddString("deltaLimit", request.DeltaLimit);

        return await _.SendBybitRequest(_.BuildUri(_v5AccountMmpModify), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Resets Market Maker Protection
    /// </summary>
    /// <param name="baseAsset">Base coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> ResetMmpAsync(string baseAsset, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "baseCoin", baseAsset },
        };

        return await _.SendBybitRequest(_.BuildUri(_v5AccountMmpReset), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets Market Maker Protection
    /// </summary>
    /// <param name="baseAsset">Base coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAccountMmp>>> GetMmpAsync(string baseAsset, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "baseCoin", baseAsset },
        };

        var result = await _.SendBybitRequest<BybitListResponse<BybitAccountMmp>>(_.BuildUri(_v5AccountMmpState), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAccountMmp>>(default!);
        return result.As(result.Data.Payload);
    }
    #endregion

    private static ParameterCollection CreateInstrumentsParameters(BybitAccountInstrumentsRequest request)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);
        return parameters;
    }

    private static ParameterCollection CreateRepayParameters(string? asset, decimal? amount, BybitAccountRepaymentType? repaymentType)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);
        parameters.AddOptionalString("amount", amount);
        parameters.AddOptionalEnum("repaymentType", repaymentType);
        return parameters;
    }
}
