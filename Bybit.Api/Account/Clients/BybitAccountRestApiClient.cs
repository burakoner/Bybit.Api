namespace Bybit.Api.Account;

/// <summary>
/// Bybit Rest API Account Client
/// </summary>
public class BybitAccountRestApiClient
{
    // Account Endpoints
    private const string _v5AccountWalletBalance = "v5/account/wallet-balance";
    private const string _v5AccountUpgradeToUta = "v5/account/upgrade-to-uta";
    private const string _v5AccountBorrowHistory = "v5/account/borrow-history";
    private const string _v5AccountQuickRepayment = "v5/account/quick-repayment"; // TODO
    private const string _v5AccountSetCollateralSwitch = "v5/account/set-collateral-switch"; // TODO
    private const string _v5AccountSetCollateralSwitchBatch = "v5/account/set-collateral-switch-batch"; // TODO
    private const string _v5AccountCollateralInfo = "v5/account/collateral-info";
    private const string _v5AssetCoinGreeks = "v5/asset/coin-greeks";
    private const string _v5AccountFeeRate = "v5/account/fee-rate";
    private const string _v5AccountInfo = "v5/account/info";
    private const string _v5AccountTransactionLog = "v5/account/transaction-log";
    private const string _v5AccountContractTransactionLog = "v5/account/contract-transaction-log"; // TODO
    private const string _v5AccountSmpGroup = "v5/account/smp-group"; // TODO
    private const string _v5AccountSetMarginMode = "v5/account/set-margin-mode";
    private const string _v5AccountSetHedgingMode = "v5/account/set-hedging-mode"; // TODO
    private const string _v5AccountMmpModify = "v5/account/mmp-modify";
    private const string _v5AccountMmpReset = "v5/account/mmp-reset";
    private const string _v5AccountMmpState = "v5/account/mmp-state";

    #region Internal
    internal BybitRestApiBaseClient _ { get; }
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
    public async Task<BybitRestCallResult<List<BybitBalance>>> GetBalancesAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", BybitAccountType.Unified);
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitBalance>>(_.BuildUri(_v5AccountWalletBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBalance>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Upgrade Unified Account
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUnifiedUpgrade>> UpgradeToUnifiedAccountAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitUnifiedUpgrade>(_.BuildUri(_v5AccountUpgradeToUta), HttpMethod.Post, ct, true).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult<List<BybitBorrowHistory>>> GetBorrowHistoryAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntValues(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", asset);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitBorrowHistory>>(_.BuildUri(_v5AccountBorrowHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBorrowHistory>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get the collateral information of the current unified margin account, including loan interest rate, loanable amount, collateral conversion rate, whether it can be mortgaged as margin, etc.
    /// </summary>
    /// <param name="asset">Asset currency of all current collateral</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitCollateralInfo>>> GetCollateralInfoAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitCollateralInfo>>(_.BuildUri(_v5AccountCollateralInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitCollateralInfo>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get current account Greeks information
    /// </summary>
    /// <param name="baseAsset">Base coin. If not passed, all supported base coin greeks will be returned by default</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitGreeks>>> GetAssetGreeksAsync(string baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("baseCoin", baseAsset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitGreeks>>(_.BuildUri(_v5AssetCoinGreeks), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitGreeks>>(null);
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
    public async Task<BybitRestCallResult<List<BybitFeeRate>>> GetFeeRateAsync(BybitCategory category, string symbol = null, string baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("baseCoin", baseAsset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitFeeRate>>(_.BuildUri(_v5AccountFeeRate), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitFeeRate>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query the margin mode configuration of the account.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAccountInfo>(_.BuildUri(_v5AccountInfo), HttpMethod.Get, ct, true).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult<List<BybitTransaction>>> GetTransactionHistoryAsync(BybitAccountType? account = null, BybitCategory? category = null, string asset = null, string baseAsset = null, BybitTransactionType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntValues(nameof(limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddOptionalEnum("accountType", account);
        parameters.AddOptionalEnum("category", category);
        parameters.AddOptional("currency", asset);
        parameters.AddOptional("baseCoin", baseAsset);
        parameters.AddOptionalEnum("type", type);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitTransaction>>(_.BuildUri(_v5AccountTransactionLog), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTransaction>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Set Margin Mode
    /// </summary>
    /// <param name="marginMode">Margin mode</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitReason>>> SetMarginModeAsync(BybitMarginMode marginMode, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("setMarginMode", marginMode);

        return await _.SendBybitRequest<List<BybitReason>>(_.BuildUri(_v5AccountSetMarginMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult> SetMarketMakerProtectionAsync(string baseAsset, int window, int frozenPeriod, decimal quantityLimit, decimal deltaLimit, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "baseCoin", baseAsset },
            { "window", window },
            { "frozenPeriod", frozenPeriod },
            { "qtyLimit", quantityLimit },
            { "deltaLimit", deltaLimit },
        };

        return await _.SendBybitRequest(_.BuildUri(_v5AccountMmpModify), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Resets Market Maker Protection
    /// </summary>
    /// <param name="baseAsset">Base coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> ResetMarketMakerProtectionAsync(string baseAsset, CancellationToken ct = default)
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
    public async Task<BybitRestCallResult<List<BybitMmpState>>> GetMarketMakerProtectionAsync(string baseAsset, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "baseCoin", baseAsset },
        };

        var result = await _.SendBybitRequest<BybitListResponse<BybitMmpState>>(_.BuildUri(_v5AccountMmpState), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitMmpState>>(null);
        return result.As(result.Data.Payload);
    }
    #endregion

}