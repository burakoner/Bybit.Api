namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Rest API Asset Client
/// </summary>
public class BybitAssetRestApiClient
{
    // Asset
    private const string _v5AssetDeliveryRecord = "v5/asset/delivery-record";
    private const string _v5AssetSettlementRecord = "v5/asset/settlement-record";
    private const string _v5AssetExchangeOrderRecord = "v5/asset/exchange/order-record";
    private const string _v5AssetCoinQueryInfo = "v5/asset/coin/query-info";
    private const string _v5AssetTransferQuerySubMemberList = "v5/asset/transfer/query-sub-member-list";
    private const string _v5AssetFundingHistory = "v5/asset/fundinghistory";
    private const string _v5AssetPortfolioMargin = "v5/asset/portfolio-margin";
    private const string _v5AssetTotalMembersAssets = "v5/asset/total-members-assets";

    // Balances
    private const string _v5AssetTransferQueryAssetInfo = "v5/asset/transfer/query-asset-info";
    private const string _v5AssetTransferQueryAccountCoinsBalance = "v5/asset/transfer/query-account-coins-balance";
    private const string _v5AssetTransferQueryAccountCoinBalance = "v5/asset/transfer/query-account-coin-balance";
    private const string _v5AssetWithdrawWithdrawableAmount = "v5/asset/withdraw/withdrawable-amount";
    private const string _v5AssetAssetOverview = "v5/asset/asset-overview";

    // Transfers
    private const string _v5AssetTransferQueryTransferCoinList = "v5/asset/transfer/query-transfer-coin-list";
    private const string _v5AssetTransferInterTransfer = "v5/asset/transfer/inter-transfer";
    private const string _v5AssetTransferQueryInterTransferList = "v5/asset/transfer/query-inter-transfer-list";
    private const string _v5AssetTransferUniversalTransfer = "v5/asset/transfer/universal-transfer";
    private const string _v5AssetTransferQueryUniversalTransferList = "v5/asset/transfer/query-universal-transfer-list";

    // Deposit
    private const string _v5AssetDepositDepositToAccount = "v5/asset/deposit/deposit-to-account";
    private const string _v5AssetDepositQueryRecord = "v5/asset/deposit/query-record";
    private const string _v5AssetDepositQuerySubMemberRecord = "v5/asset/deposit/query-sub-member-record";
    private const string _v5AssetDepositQueryInternalRecord = "v5/asset/deposit/query-internal-record";
    private const string _v5AssetDepositQueryAddress = "v5/asset/deposit/query-address";
    private const string _v5AssetDepositQuerySubMemberAddress = "v5/asset/deposit/query-sub-member-address";
    private const string _v5AssetDepositQueryAllowedList = "v5/asset/deposit/query-allowed-list";

    // Withdraw
    private const string _v5AssetWithdrawQueryRecord = "v5/asset/withdraw/query-record";
    private const string _v5AssetWithdrawQueryAddress = "v5/asset/withdraw/query-address";
    private const string _v5AssetWithdrawVaspList = "v5/asset/withdraw/vasp/list";
    private const string _v5AssetWithdrawCreate = "v5/asset/withdraw/create";
    private const string _v5AssetWithdrawCancel = "v5/asset/withdraw/cancel";

    // Convert
    private const string _v5AssetExchangeQueryCoinList = "v5/asset/exchange/query-coin-list";
    private const string _v5AssetExchangeQuoteApply = "v5/asset/exchange/quote-apply";
    private const string _v5AssetExchangeConvertExecute = "v5/asset/exchange/convert-execute";
    private const string _v5AssetExchangeConvertResultQuery = "v5/asset/exchange/convert-result-query";
    private const string _v5AssetExchangeQueryConvertHistory = "v5/asset/exchange/query-convert-history";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitAssetRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    #region Helpers
    private static int? ToInt(bool? value)
    {
        return value.HasValue ? value.Value ? 1 : 0 : null;
    }

    private static string? GetWithdrawalAccountType(BybitAccountType? account)
    {
        if (account == null)
            return null;

        return account.Value == BybitAccountType.Unified
            ? "UTA"
            : MapConverter.GetString(account.Value);
    }

    private static ParameterCollection GetWithdrawParameters(BybitAssetWithdrawRequest request)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", request.Asset },
            { "address", request.Address },
            { "timestamp", DateTime.UtcNow.ConvertToMilliseconds() }
        };

        parameters.AddString("amount", request.Quantity);
        parameters.AddOptional("chain", request.Chain);
        parameters.AddOptional("tag", request.Tag);
        parameters.AddOptional("forceChain", request.ForceChain);
        parameters.AddOptionalEnum("accountType", request.AccountType);
        parameters.AddOptional("feeType", request.FeeType);
        parameters.AddOptional("requestId", request.RequestId);
        parameters.AddOptional("transactionPurpose", request.TransactionPurpose);
        parameters.AddOptional("beneficiary", request.Beneficiary);
        return parameters;
    }
    #endregion

    #region Asset Methods
    /// <summary>
    /// Return transaction log in Funding Account.
    /// </summary>
    /// <param name="createTimeFrom">Start timestamp in seconds</param>
    /// <param name="createTimeTo">End timestamp in seconds</param>
    /// <param name="limit">Limit for data size per page. [1, 100]. Default: 10</param>
    /// <param name="cursor">Cursor, used for pagination</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAssetFundingTransaction>>> GetFundingHistoryAsync(long? createTimeFrom = null, long? createTimeTo = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFundingHistoryAsync(new BybitAssetFundingHistoryRequest
        {
            CreateTimeFrom = createTimeFrom,
            CreateTimeTo = createTimeTo,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Return transaction log in Funding Account.
    /// </summary>
    /// <param name="request">Funding account transaction history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetFundingTransaction>>> GetFundingHistoryAsync(BybitAssetFundingHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptionalString("createTimeFrom", request.CreateTimeFrom);
        parameters.AddOptionalString("createTimeTo", request.CreateTimeTo);
        parameters.AddOptionalString("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetFundingTransaction>>(_.BuildUri(_v5AssetFundingHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetFundingTransaction>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query delivery records of USDC futures and Options, sorted by deliveryTime in descending order
    /// </summary>
    /// <param name="category">Product type. option, linear</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end time. timestamp (ms)</param>
    /// <param name="expiryDate">Expiry date. 25MAR22. Default: return all</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAssetDelivery>>> GetDeliveryHistoryAsync(BybitCategory category, string? symbol = null, long? startTime = null, long? endTime = null, long? expiryDate = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetDeliveryHistoryAsync(new BybitAssetDeliveryHistoryRequest(category)
        {
            Symbol = symbol,
            StartTime = startTime,
            EndTime = endTime,
            ExpiryDate = expiryDate?.ToString(CultureInfo.InvariantCulture),
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query delivery records of USDC futures and Options, sorted by deliveryTime in descending order
    /// </summary>
    /// <param name="request">Delivery history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAssetDelivery>>> GetDeliveryHistoryAsync(BybitAssetDeliveryHistoryRequest request, CancellationToken ct = default)
    {
        if (request.Category.IsNotIn(BybitCategory.Linear, BybitCategory.Option))
            throw new NotSupportedException($"{request.Category} is not supported for this endpoint.");

        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("expDate", request.ExpiryDate);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDelivery>>(_.BuildUri(_v5AssetDeliveryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDelivery>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query session settlement records of USDC perpetual and futures
    /// </summary>
    /// <param name="category">Product type. linear</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end time. timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAssetSettlement>>> GetSettlementHistoryAsync(BybitCategory category, string? symbol = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetSettlementHistoryAsync(new BybitAssetSettlementHistoryRequest(category)
        {
            Symbol = symbol,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query session settlement records of USDC perpetual and futures
    /// </summary>
    /// <param name="request">Settlement history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<List<BybitAssetSettlement>>> GetSettlementHistoryAsync(BybitAssetSettlementHistoryRequest request, CancellationToken ct = default)
    {
        if (request.Category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{request.Category} is not supported for this endpoint.");

        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.AddOptional("symbol", request.Symbol);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetSettlement>>(_.BuildUri(_v5AssetSettlementRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetSettlement>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query the coin exchange records.
    /// </summary>
    /// <param name="fromAsset">The currency to convert from. e.g,BTC</param>
    /// <param name="toAsset">The currency to convert to. e.g,USDT</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 10</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetExchange>>> GetExchangeHistoryAsync(string? fromAsset = null, string? toAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetExchangeHistoryAsync(new BybitAssetExchangeHistoryRequest
        {
            FromAsset = fromAsset,
            ToAsset = toAsset,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the coin exchange records.
    /// </summary>
    /// <param name="request">Exchange history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetExchange>>> GetExchangeHistoryAsync(BybitAssetExchangeHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("fromCoin", request.FromAsset);
        parameters.AddOptional("toCoin", request.ToAsset);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetExchange>>(_.BuildUri(_v5AssetExchangeOrderRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetExchange>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query coin information, including chain information, withdraw and deposit status.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAsset>>> GetAssetAsync(string? asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAsset>>(_.BuildUri(_v5AssetCoinQueryInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAsset>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query the sub UIDs under a main UID. It returns up to 2000 sub accounts, if you need more, please call this endpoint.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetSubUserIds>> GetSubUsersAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitAssetSubUserIds>(_.BuildUri(_v5AssetTransferQuerySubMemberList), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Query portfolio margin account balance and asset PnL range information.
    /// </summary>
    /// <param name="baseAsset">Base coin, for example BTC or ETH</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetPortfolioMargin>> GetPortfolioMarginAsync(string? baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("baseCoin", baseAsset);

        return await _.SendBybitRequest<BybitAssetPortfolioMargin>(_.BuildUri(_v5AssetPortfolioMargin), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query total assets for members.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetTotalMembersAssets>> GetTotalMembersAssetsAsync(string? asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        return await _.SendBybitRequest<BybitAssetTotalMembersAssets>(_.BuildUri(_v5AssetTotalMembersAssets), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query asset information
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<BybitAssetSpotBalance>> GetSpotBalancesAsync(string? asset = null, CancellationToken ct = default)
    {
        var account = BybitAccountType.Spot;
        if (account.IsNotIn(BybitAccountType.Spot))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", account);
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitAssetCategoryBalance>(_.BuildUri(_v5AssetTransferQueryAssetInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitAssetSpotBalance>(default!);
        return result.As(result.Data.Spot);
    }
    
    /// <summary>
    /// You could get all coin balance of all account types under the master account, and sub account.
    /// </summary>
    /// <param name="account">Account type</param>
    /// <param name="memberId">User Id. It is required when you use master api key to check sub account coin balance</param>
    /// <param name="asset">Coin name</param>
    /// <param name="withBonus">0(default): not query bonus. 1: query bonus</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<BybitAssetBalances>> GetAssetBalancesAsync(
        BybitAccountType account,
        string? memberId = null, string? asset = null, bool? withBonus = null, CancellationToken ct = default)
    {
        return await GetAssetBalancesAsync(new BybitAssetBalancesRequest(account)
        {
            MemberId = memberId,
            Asset = asset,
            WithBonus = withBonus,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// You could get all coin balance of all account types under the master account, and sub account.
    /// </summary>
    /// <param name="request">All coins balance request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetBalances>> GetAssetBalancesAsync(BybitAssetBalancesRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", request.Account);
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("memberId", request.MemberId);
        parameters.AddOptional("withBonus", ToInt(request.WithBonus));

        return await _.SendBybitRequest<BybitAssetBalances>(_.BuildUri(_v5AssetTransferQueryAccountCoinsBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the balance of a specific coin in a specific account type. Supports querying sub UID's balance. Also, you can check the transferable amount from master to sub account, sub to master account or sub to sub account, especially for user who has an institutional loan.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="account">Account type</param>
    /// <param name="toAccount">To account type. Required when querying the transferable balance between different account types</param>
    /// <param name="memberId">UID. Required when querying sub UID balance with master api key</param>
    /// <param name="toMemberId">UID. Required when querying the transferable balance between different UIDs</param>
    /// <param name="withBonus">0(default): not query bonus. 1: query bonus</param>
    /// <param name="withTransferSafeAmount">hether query delay withdraw/transfer safe amount</param>
    /// <param name="withLtvTransferSafeAmount">For OTC loan users in particular, you can check the transferable amount under risk level</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetBalance>> GetAssetBalanceAsync(
        string asset,
        BybitAccountType account,
        BybitAccountType? toAccount = null,
        string? memberId = null,
        string? toMemberId = null,

        bool? withBonus = null,
        bool? withTransferSafeAmount = null,
        bool? withLtvTransferSafeAmount = null,

        CancellationToken ct = default)
    {
        return await GetAssetBalanceAsync(new BybitAssetBalanceRequest(asset, account)
        {
            ToAccount = toAccount,
            MemberId = memberId,
            ToMemberId = toMemberId,
            WithBonus = withBonus,
            WithTransferSafeAmount = withTransferSafeAmount,
            WithLtvTransferSafeAmount = withLtvTransferSafeAmount,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the balance of a specific coin in a specific account type.
    /// </summary>
    /// <param name="request">Single coin balance request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetBalance>> GetAssetBalanceAsync(BybitAssetBalanceRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddParameter("coin", request.Asset);
        parameters.AddEnum("accountType", request.Account);
        parameters.AddOptional("memberId", request.MemberId);
        parameters.AddOptional("toMemberId", request.ToMemberId);
        parameters.AddOptionalEnum("toAccountType", request.ToAccount);
        parameters.AddOptional("withBonus", ToInt(request.WithBonus));
        parameters.AddOptional("withTransferSafeAmount", ToInt(request.WithTransferSafeAmount));
        parameters.AddOptional("withLtvTransferSafeAmount", ToInt(request.WithLtvTransferSafeAmount));

        return await _.SendBybitRequest<BybitAssetBalance>(_.BuildUri(_v5AssetTransferQueryAccountCoinBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Withdrawable Amount
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetWithdrawableAmount>> GetWithdrawableQuantityAsync(string asset, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", asset }
        };

        return await _.SendBybitRequest<BybitAssetWithdrawableAmount>(_.BuildUri(_v5AssetWithdrawWithdrawableAmount), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query asset overview grouped by account and category.
    /// </summary>
    /// <param name="memberId">UID</param>
    /// <param name="valuationCurrency">Valuation currency</param>
    /// <param name="accountType">Bybit account type label</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAssetOverview>> GetAssetOverviewAsync(string? memberId = null, string? valuationCurrency = null, string? accountType = null, CancellationToken ct = default)
    {
        return GetAssetOverviewAsync(new BybitAssetOverviewRequest
        {
            MemberId = memberId,
            ValuationCurrency = valuationCurrency,
            AccountType = accountType,
        }, ct);
    }

    /// <summary>
    /// Query asset overview grouped by account and category.
    /// </summary>
    /// <param name="request">Asset overview request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetOverview>> GetAssetOverviewAsync(BybitAssetOverviewRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("memberId", request.MemberId);
        parameters.AddOptional("valuationCurrency", request.ValuationCurrency);
        parameters.AddOptional("accountType", request.AccountType);

        return await _.SendBybitRequest<BybitAssetOverview>(_.BuildUri(_v5AssetAssetOverview), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Query the transferable coin list between each account type
    /// </summary>
    /// <param name="fromAccount">From account type</param>
    /// <param name="toAccount">To account type</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<string>>> GetTransferableAssetsAsync(BybitAccountType fromAccount, BybitAccountType toAccount, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("fromAccountType", fromAccount);
        parameters.AddEnum("toAccountType", toAccount);

        var result = await _.SendBybitRequest<BybitListResponse<string>>(_.BuildUri(_v5AssetTransferQueryTransferCoinList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<string>>(default!);
        return result.As(result.Data.Payload);
    }
    
    /// <summary>
    /// Create the internal transfer between different account types under the same UID.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="quantity">Amount</param>
    /// <param name="fromAccount">From account type</param>
    /// <param name="toAccount">To account type</param>
    /// <param name="transferId">UUID. Please manually generate a UUID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetTransferId>> InternalTransferAsync(
        string asset,
        decimal quantity,
        BybitAccountType fromAccount,
        BybitAccountType toAccount,
        string? transferId = null,
        CancellationToken ct = default)
    {
        return await InternalTransferAsync(new BybitAssetInternalTransferRequest(asset, quantity, fromAccount, toAccount)
        {
            TransferId = transferId,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Create the internal transfer between different account types under the same UID.
    /// </summary>
    /// <param name="request">Internal transfer request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetTransferId>> InternalTransferAsync(BybitAssetInternalTransferRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "transferId", request.TransferId ?? Guid.NewGuid().ToString() },
            { "coin", request.Asset },
        };
        parameters.AddString("amount", request.Quantity);
        parameters.AddEnum("fromAccountType", request.FromAccount);
        parameters.AddEnum("toAccountType", request.ToAccount);

        return await _.SendBybitRequest<BybitAssetTransferId>(_.BuildUri(_v5AssetTransferInterTransfer), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the internal transfer records between different account types under the same UID.
    /// </summary>
    /// <param name="transferId">UUID. Use the one you generated in createTransfer</param>
    /// <param name="asset">Coin</param>
    /// <param name="status">Transfer status</param>
    /// <param name="startTime">The start timestamp (ms) Note: the query logic is actually effective based on second level</param>
    /// <param name="endTime">The end timestamp (ms) Note: the query logic is actually effective based on second level</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetTransferInternal>>> GetInternalTransfersAsync(string? transferId = null, string? asset = null, BybitTransferStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetInternalTransfersAsync(new BybitAssetInternalTransferHistoryRequest
        {
            TransferId = transferId,
            Asset = asset,
            Status = status,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the internal transfer records between different account types under the same UID.
    /// </summary>
    /// <param name="request">Internal transfer history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetTransferInternal>>> GetInternalTransfersAsync(BybitAssetInternalTransferHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("transferId", request.TransferId);
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptionalEnum("status", request.Status);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetTransferInternal>>(_.BuildUri(_v5AssetTransferQueryInterTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetTransferInternal>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Transfer between sub-sub or main-sub.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="quantity">Amount</param>
    /// <param name="fromMemberId">From UID</param>
    /// <param name="toMemberId">To UID</param>
    /// <param name="fromAccount">From account type</param>
    /// <param name="toAccount">To account type</param>
    /// <param name="transferId">UUID. Please manually generate a UUID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetTransferId>> UniversalTransferAsync(string asset, decimal quantity, string fromMemberId, string toMemberId, BybitAccountType fromAccount, BybitAccountType toAccount, string? transferId = null, CancellationToken ct = default)
    {
        return await UniversalTransferAsync(new BybitAssetUniversalTransferRequest(asset, quantity, fromMemberId, toMemberId, fromAccount, toAccount)
        {
            TransferId = transferId,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Transfer between sub-sub or main-sub.
    /// </summary>
    /// <param name="request">Universal transfer request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetTransferId>> UniversalTransferAsync(BybitAssetUniversalTransferRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "transferId", request.TransferId ?? Guid.NewGuid().ToString() },
            { "coin", request.Asset },
            { "fromMemberId", request.FromMemberId },
            { "toMemberId", request.ToMemberId },
        };
        parameters.AddString("amount", request.Quantity);
        parameters.AddEnum("fromAccountType", request.FromAccount);
        parameters.AddEnum("toAccountType", request.ToAccount);

        return await _.SendBybitRequest<BybitAssetTransferId>(_.BuildUri(_v5AssetTransferUniversalTransfer), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Query universal transfer records
    /// </summary>
    /// <param name="transferId">UUID. Use the one you generated in createTransfer</param>
    /// <param name="asset">Coin</param>
    /// <param name="transferStatus">Transfer status. SUCCESS,FAILED,PENDING</param>
    /// <param name="startTime">The start timestamp (ms) Note: the query logic is actually effective based on second level</param>
    /// <param name="endTime">The end timestamp (ms) Note: the query logic is actually effective based on second level</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetTransferUniversal>>> GetUniversalTransfersAsync(string? transferId = null, string? asset = null, BybitTransferStatus? transferStatus = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetUniversalTransfersAsync(new BybitAssetUniversalTransferHistoryRequest
        {
            TransferId = transferId,
            Asset = asset,
            Status = transferStatus,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query universal transfer records
    /// </summary>
    /// <param name="request">Universal transfer history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetTransferUniversal>>> GetUniversalTransfersAsync(BybitAssetUniversalTransferHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("transferId", request.TransferId);
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptionalEnum("status", request.Status);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetTransferUniversal>>(_.BuildUri(_v5AssetTransferQueryUniversalTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetTransferUniversal>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }
    
    /// <summary>
    /// Set auto transfer account after deposit. The same function as the setting for Deposit on web GUI
    /// </summary>
    /// <param name="account">Account type</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<bool?>> SetDepositAccountAsync(BybitAccountType account, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccountType.Unified, BybitAccountType.Spot, BybitAccountType.Contract, BybitAccountType.Fund))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", account);

        var result = await _.SendBybitRequest<BybitAssetStatus>(_.BuildUri(_v5AssetDepositDepositToAccount), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }

    /// <summary>
    /// Query deposit records.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(string? asset = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetDepositsAsync(new BybitAssetDepositHistoryRequest
        {
            Asset = asset,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query deposit records.
    /// </summary>
    /// <param name="request">Deposit history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(BybitAssetDepositHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDeposit>>(_.BuildUri(_v5AssetDepositQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDeposit>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query subaccount's deposit records by main UID's API key.
    /// </summary>
    /// <param name="subUserId">Sub UID</param>
    /// <param name="asset">Coin</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(long subUserId, string? asset = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetDepositsAsync(new BybitAssetSubDepositHistoryRequest(subUserId)
        {
            Asset = asset,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query subaccount's deposit records by main UID's API key.
    /// </summary>
    /// <param name="request">Subaccount deposit history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(BybitAssetSubDepositHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection
        {
            { "subMemberId", request.SubUserId },
        };
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDeposit>>(_.BuildUri(_v5AssetDepositQuerySubMemberRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDeposit>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query deposit records within the Bybit platform. These transactions are not on the blockchain.
    /// </summary>
    /// <param name="asset">oin name: for example, BTC. Default value: all</param>
    /// <param name="txID">Internal transfer transaction ID</param>
    /// <param name="startTime">Start time (ms). Default value: 30 days before the current time</param>
    /// <param name="endTime">End time (ms). Default value: current time</param>
    /// <param name="limit">Number of items per page, [1, 50]. Default value: 50</param>
    /// <param name="cursor">Cursor, used for pagination</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDepositInternal>>> GetInternalDepositsAsync(string? asset = null, string? txID = null, long? startTime = null, long? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetInternalDepositsAsync(new BybitAssetInternalDepositHistoryRequest
        {
            Asset = asset,
            TransactionId = txID,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query deposit records within the Bybit platform.
    /// </summary>
    /// <param name="request">Internal deposit history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDepositInternal>>> GetInternalDepositsAsync(BybitAssetInternalDepositHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("txID", request.TransactionId);
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDepositInternal>>(_.BuildUri(_v5AssetDepositQueryInternalRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDepositInternal>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query the deposit address information of MASTER account.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="chain">Please use the value of >> chain from coin-info endpoint</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetDepositAddress>> GetDepositAddressAsync(string asset, string? chain = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", asset }
        };
        parameters.AddOptional("chainType", chain);

        return await _.SendBybitRequest<BybitAssetDepositAddress>(_.BuildUri(_v5AssetDepositQueryAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the deposit address information of SUB account.
    /// </summary>
    /// <param name="subUserId">Sub user ID</param>
    /// <param name="asset">Coin</param>
    /// <param name="chain">Please use the value of chain from coin-info endpoint</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetDepositAddress>> GetDepositAddressAsync(long subUserId, string asset, string? chain = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", asset },
            { "subMemberId", subUserId },
        };
        parameters.AddOptional("chainType", chain);
        return await _.SendBybitRequest<BybitAssetDepositAddress>(_.BuildUri(_v5AssetDepositQuerySubMemberAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query allowed deposit coin information. To find out paired chain of coin, please refer coin info api.
    /// </summary>
    /// <param name="asset">Coin. coin and chain must be paired if passed</param>
    /// <param name="network">Chain. coin and chain must be paired if passed</param>
    /// <param name="limit">Limit for data size per page. [1, 35]. Default: 10</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDepositAllow>>> GetDepositAllowedAssetsAsync(string? asset = null, string? network = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return await GetDepositAllowedAssetsAsync(new BybitAssetDepositAllowedRequest
        {
            Asset = asset,
            Network = network,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query allowed deposit coin information.
    /// </summary>
    /// <param name="request">Allowed deposit coin request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDepositAllow>>> GetDepositAllowedAssetsAsync(BybitAssetDepositAllowedRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 35);
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("chain", request.Network);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDepositAllow>>(_.BuildUri(_v5AssetDepositQueryAllowedList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDepositAllow>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query withdrawal records.
    /// </summary>
    /// <param name="withdrawId">Withdraw ID</param>
    /// <param name="transactionId">Transaction hash ID</param>
    /// <param name="asset">Coin</param>
    /// <param name="type">Withdraw type. 0(default): on chain. 1: off chain. 2: all</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">	The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetWithdrawal>>> GetWithdrawalsAsync(
        string? withdrawId = null,
        string? transactionId = null,
        string? asset = null,
        BybitWithdrawalType? type = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken ct = default)
    {
        return await GetWithdrawalsAsync(new BybitAssetWithdrawalHistoryRequest
        {
            WithdrawId = withdrawId,
            TransactionId = transactionId,
            Asset = asset,
            Type = type,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Query withdrawal records.
    /// </summary>
    /// <param name="request">Withdrawal history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetWithdrawal>>> GetWithdrawalsAsync(BybitAssetWithdrawalHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("withdrawID", request.WithdrawId);
        parameters.AddOptional("txID", request.TransactionId);
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptionalEnum("withdrawType", request.Type);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetWithdrawal>>(_.BuildUri(_v5AssetWithdrawQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetWithdrawal>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query withdrawal addresses in the address book.
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="chain">Chain name</param>
    /// <param name="addressType">Address type</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 50</param>
    /// <param name="cursor">Cursor</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAssetWithdrawalAddress>>> GetWithdrawalAddressesAsync(string? asset = null, string? chain = null, int? addressType = null, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetWithdrawalAddressesAsync(new BybitAssetWithdrawalAddressRequest
        {
            Asset = asset,
            Chain = chain,
            AddressType = addressType,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query withdrawal addresses in the address book.
    /// </summary>
    /// <param name="request">Withdrawal address list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetWithdrawalAddress>>> GetWithdrawalAddressesAsync(BybitAssetWithdrawalAddressRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("chain", request.Chain);
        parameters.AddOptional("addressType", request.AddressType);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetWithdrawalAddress>>(_.BuildUri(_v5AssetWithdrawQueryAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetWithdrawalAddress>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query the available VASPs.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetVasp>>> GetVaspsAsync(CancellationToken ct = default)
    {
        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetVasp>>(_.BuildUri(_v5AssetWithdrawVaspList), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetVasp>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Withdraw assets from your Bybit account. You can make an off-chain transfer if the target wallet address is from Bybit. This means that no blockchain fee will be charged.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="quantity">Withdraw amount</param>
    /// <param name="address">forceChain=0 or 1: fill wallet address, and make sure you add address in the address book first. Please note that the address is case sensitive, so use the exact same address added in address book
    /// forceChain=2: fill Bybit UID, and it can only be another Bybit main account UID. Make sure you add UID in the address book first</param>
    /// <param name="tag">Tag
    /// Required if tag exists in the wallet address list.
    /// Note: please do not set a tag/memo in the address book if the chain does not support tag</param>
    /// <param name="chain">Chain
    /// forceChain=0 or 1: this field is required
    /// forceChain=2: this field can be null</param>
    /// <param name="forceChain">Whether or not to force an on-chain withdrawal
    /// 0(default): If the address is parsed out to be an internal address, then internal transfer
    /// 1: Force the withdrawal to occur on-chain
    /// 2: Use UID to withdraw</param>
    /// <param name="account">Select the wallet to be withdrawn from
    /// SPOT：spot wallet (default)
    /// FUND：Funding wallet</param>
    /// <param name="feeType">Handling fee option
    /// 0(default): input amount is the actual amount received, so you have to calculate handling fee manually
    /// 1: input amount is not the actual amount you received, the system will help to deduct the handling fee automatically</param>
    /// <param name="requestId">Customised ID, globally unique, it is used for idempotent verification
    /// A combination of letters (case sensitive) and numbers, which can be pure letters or pure numbers and the length must be between 1 and 32 digits</param>
    /// <param name="transactionPurpose">Purpose of the withdrawal transaction</param>
    /// <param name="beneficiaryName">Receiver exchange user KYC name</param>
    /// <param name="vaspEntityId">Receiver exchange entity ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<long?>> WithdrawAsync(
        string asset,
        decimal quantity,
        string address,
        string? tag = null,
        string? chain = null,
        int? forceChain = null,
        BybitAccountType? account = null,
        int? feeType = null,
        string? requestId = null,
        string? transactionPurpose = null,
        string? beneficiaryName = null,
        string? vaspEntityId = null,
        CancellationToken ct = default)
    {
        var request = new BybitAssetWithdrawRequest(asset, quantity, address)
        {
            Tag = tag,
            Chain = chain,
            ForceChain = forceChain,
            FeeType = feeType,
            RequestId = requestId,
            TransactionPurpose = transactionPurpose,
            Beneficiary = beneficiaryName == null && vaspEntityId == null
                ? null
                : new BybitAssetWithdrawalBeneficiary
                {
                    Name = beneficiaryName,
                    VaspEntityId = vaspEntityId,
                },
        };

        var accountType = GetWithdrawalAccountType(account);
        if (accountType != null)
        {
            var parameters = GetWithdrawParameters(request);
            parameters["accountType"] = accountType;
            var legacyResult = await _.SendBybitRequest<BybitAssetWithdrawalId>(_.BuildUri(_v5AssetWithdrawCreate), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
            if (!legacyResult) return legacyResult.As<long?>(null);
            return legacyResult.As(legacyResult.Data.NumericId);
        }

        var result = await WithdrawWithIdAsync(request, ct).ConfigureAwait(false);
        if (!result) return result.As<long?>(null);
        return result.As(result.Data.NumericId);
    }

    /// <summary>
    /// Withdraw assets from your Bybit account and return the string withdrawal ID.
    /// </summary>
    /// <param name="request">Withdrawal request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetWithdrawalId>> WithdrawWithIdAsync(BybitAssetWithdrawRequest request, CancellationToken ct = default)
    {
        var parameters = GetWithdrawParameters(request);

        return await _.SendBybitRequest<BybitAssetWithdrawalId>(_.BuildUri(_v5AssetWithdrawCreate), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Withdraw assets from your Bybit account and return the string withdrawal ID.
    /// </summary>
    /// <param name="request">Withdrawal request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<string>> WithdrawAsync(BybitAssetWithdrawRequest request, CancellationToken ct = default)
    {
        var result = await WithdrawWithIdAsync(request, ct).ConfigureAwait(false);
        if (!result) return result.As<string>(default!);
        return result.As(result.Data.Id);
    }

    /// <summary>
    /// Cancel the withdrawal
    /// </summary>
    /// <param name="id">Withdrawal ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<bool?>> CancelWithdrawalAsync(string id, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "id", id },
        };

        var result = await _.SendBybitRequest<BybitAssetStatus>(_.BuildUri(_v5AssetWithdrawCancel), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }

    /// <summary>
    /// Query for the list of coins you can convert to/from.
    /// </summary>
    /// <param name="accountType">Convert wallet type</param>
    /// <param name="asset">Coin name</param>
    /// <param name="side">0: from coin list, 1: to coin list</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAssetConvertCoin>>> GetConvertCoinsAsync(string accountType, string? asset = null, int? side = null, CancellationToken ct = default)
    {
        return GetConvertCoinsAsync(new BybitAssetConvertCoinListRequest(accountType)
        {
            Asset = asset,
            Side = side,
        }, ct);
    }

    /// <summary>
    /// Query for the list of coins you can convert to/from.
    /// </summary>
    /// <param name="request">Convert coin list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetConvertCoin>>> GetConvertCoinsAsync(BybitAssetConvertCoinListRequest request, CancellationToken ct = default)
    {
        if (request.Side.HasValue)
            request.Side.Value.ValidateIntBetween(nameof(request.Side), 0, 1);

        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", request.Asset);
        parameters.AddOptional("side", request.Side);
        parameters.AddParameter("accountType", request.AccountType);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetConvertCoin>>(_.BuildUri(_v5AssetExchangeQueryCoinList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetConvertCoin>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Request a convert quote.
    /// </summary>
    /// <param name="request">Convert quote request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetConvertQuote>> RequestConvertQuoteAsync(BybitAssetConvertQuoteRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "accountType", request.AccountType },
            { "fromCoin", request.FromAsset },
            { "toCoin", request.ToAsset },
            { "requestCoin", request.RequestAsset },
        };
        parameters.AddString("requestAmount", request.RequestQuantity);
        parameters.AddOptional("fromCoinType", request.FromAssetType);
        parameters.AddOptional("toCoinType", request.ToAssetType);
        parameters.AddOptional("paramType", request.ParameterType);
        parameters.AddOptional("paramValue", request.ParameterValue);
        parameters.AddOptional("requestId", request.RequestId);

        return await _.SendBybitRequest<BybitAssetConvertQuote>(_.BuildUri(_v5AssetExchangeQuoteApply), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Confirm a convert quote.
    /// </summary>
    /// <param name="quoteTransactionId">Quote transaction ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAssetConvertExecution>> ConfirmConvertQuoteAsync(string quoteTransactionId, CancellationToken ct = default)
    {
        return ConfirmConvertQuoteAsync(new BybitAssetConvertExecuteRequest(quoteTransactionId), ct);
    }

    /// <summary>
    /// Confirm a convert quote.
    /// </summary>
    /// <param name="request">Confirm convert quote request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetConvertExecution>> ConfirmConvertQuoteAsync(BybitAssetConvertExecuteRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "quoteTxId", request.QuoteTransactionId },
        };

        return await _.SendBybitRequest<BybitAssetConvertExecution>(_.BuildUri(_v5AssetExchangeConvertExecute), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query a convert status by quote transaction ID.
    /// </summary>
    /// <param name="quoteTransactionId">Quote transaction ID</param>
    /// <param name="accountType">Convert wallet type</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAssetConvertTransaction>> GetConvertStatusAsync(string quoteTransactionId, string accountType, CancellationToken ct = default)
    {
        return GetConvertStatusAsync(new BybitAssetConvertStatusRequest(quoteTransactionId, accountType), ct);
    }

    /// <summary>
    /// Query a convert status by quote transaction ID.
    /// </summary>
    /// <param name="request">Convert status request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetConvertTransaction>> GetConvertStatusAsync(BybitAssetConvertStatusRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "quoteTxId", request.QuoteTransactionId },
            { "accountType", request.AccountType },
        };

        var result = await _.SendBybitRequest<BybitAssetConvertResult>(_.BuildUri(_v5AssetExchangeConvertResultQuery), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitAssetConvertTransaction>(default!);
        return result.As(result.Data.Result);
    }

    /// <summary>
    /// Query convert history.
    /// </summary>
    /// <param name="accountType">Convert wallet type, or comma separated types</param>
    /// <param name="index">Page index, starting from 1</param>
    /// <param name="limit">Page size, max 100</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAssetConvertTransaction>>> GetConvertHistoryAsync(string? accountType = null, int? index = null, int? limit = null, CancellationToken ct = default)
    {
        return GetConvertHistoryAsync(new BybitAssetConvertHistoryRequest
        {
            AccountType = accountType,
            Index = index,
            Limit = limit,
        }, ct);
    }

    /// <summary>
    /// Query convert history.
    /// </summary>
    /// <param name="request">Convert history request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetConvertTransaction>>> GetConvertHistoryAsync(BybitAssetConvertHistoryRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("accountType", request.AccountType);
        parameters.AddOptional("index", request.Index);
        parameters.AddOptional("limit", request.Limit);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetConvertTransaction>>(_.BuildUri(_v5AssetExchangeQueryConvertHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetConvertTransaction>>(default!);
        return result.As(result.Data.Payload);
    }
    #endregion

}
