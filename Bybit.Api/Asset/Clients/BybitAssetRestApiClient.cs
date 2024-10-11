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

    // Balances
    private const string _v5AssetTransferQueryAssetInfo = "v5/asset/transfer/query-asset-info";
    private const string _v5AssetTransferQueryAccountCoinsBalance = "v5/asset/transfer/query-account-coins-balance";
    private const string _v5AssetTransferQueryAccountCoinBalance = "v5/asset/transfer/query-account-coin-balance";
    private const string _v5AssetWithdrawWithdrawableAmount = "v5/asset/withdraw/withdrawable-amount";

    // Transfers
    private const string _v5AssetTransferQueryTransferCoinList = "v5/asset/transfer/query-transfer-coin-list";
    private const string _v5AssetTransferInterTransfer = "v5/asset/transfer/inter-transfer";
    private const string _v5AssetTransferQueryInterTransferList = "v5/asset/transfer/query-inter-transfer-list";
    private const string _v5AssetTransferUniversalTransfer = "v5/asset/transfer/universal-transfer";
    private const string _v5AssetTransferQueryUniversalTransferList = "v5/asset/transfer/query-universal-transfer-list";

    // Deposit
    private const string _v5AssetDepositQueryAllowedList = "v5/asset/deposit/query-allowed-list";
    private const string _v5AssetDepositDepositToAccount = "v5/asset/deposit/deposit-to-account";
    private const string _v5AssetDepositQueryRecord = "v5/asset/deposit/query-record";
    private const string _v5AssetDepositQuerySubMemberRecord = "v5/asset/deposit/query-sub-member-record";
    private const string _v5AssetDepositQueryInternalRecord = "v5/asset/deposit/query-internal-record";
    private const string _v5AssetDepositQueryAddress = "v5/asset/deposit/query-address";
    private const string _v5AssetDepositQuerySubMemberAddress = "v5/asset/deposit/query-sub-member-address";

    // Withdraw
    private const string _v5AssetWithdrawQueryRecord = "v5/asset/withdraw/query-record";
    private const string _v5AssetWithdrawVaspList = "v5/asset/withdraw/vasp/list"; // TODO
    private const string _v5AssetWithdrawCreate = "v5/asset/withdraw/create";
    private const string _v5AssetWithdrawCancel = "v5/asset/withdraw/cancel";

    // Convert
    private const string _v5AsseExchangeQueryCoinList = "v5/asset/exchange/query-coin-list"; // TODO
    private const string _v5AsseExchangeQuoteApply = "v5/asset/exchange/quote-apply"; // TODO
    private const string _v5AsseExchangeConvertExecute = "v5/asset/exchange/convert-execute"; // TODO
    private const string _v5AsseExchangeConvertResultQuery = "v5/asset/exchange/convert-result-query"; // TODO
    private const string _v5AsseExchangeQueryConvertHistory = "v5/asset/exchange/query-convert-history"; // TODO

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitAssetRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    #region Asset Methods
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
    public async Task<BybitRestCallResult<List<BybitAssetDelivery>>> GetDeliveryHistoryAsync(BybitCategory category, string symbol = null, long? startTime = null, long? endTime = null, long? expiryDate = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("expDate", expiryDate);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDelivery>>(_.BuildUri(_v5AssetDeliveryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDelivery>>(null);
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
    public async Task<BybitRestCallResult<List<BybitAssetSettlement>>> GetSettlementHistoryAsync(BybitCategory category, string symbol = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetSettlement>>(_.BuildUri(_v5AssetSettlementRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetSettlement>>(null);
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
    public async Task<BybitRestCallResult<List<BybitAssetExchange>>> GetExchangeHistoryAsync(string fromAsset = null, string toAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("fromCoin", fromAsset);
        parameters.AddOptional("toCoin", toAsset);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetExchange>>(_.BuildUri(_v5AssetExchangeOrderRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetExchange>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query coin information, including chain information, withdraw and deposit status.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAsset>>> GetAssetAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAsset>>(_.BuildUri(_v5AssetCoinQueryInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAsset>>(null);
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
    /// Query asset information
    /// </summary>
    /// <param name="asset">Coin name</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public async Task<BybitRestCallResult<BybitAssetSpotBalance>> GetSpotBalancesAsync(string asset = null, CancellationToken ct = default)
    {
        var account = BybitAccountType.Spot;
        if (account.IsNotIn(BybitAccountType.Spot))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", account);
        parameters.AddOptional("coin", asset);

        var result = await _.SendBybitRequest<BybitAssetCategoryBalance>(_.BuildUri(_v5AssetTransferQueryAssetInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitAssetSpotBalance>(null);
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
        string memberId = null, string asset = null, bool? withBonus = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("accountType", account);
        parameters.AddOptional("coin", asset);
        parameters.AddOptional("memberId", memberId);
        parameters.AddOptional("withBonus", withBonus.HasValue ? withBonus.Value ? 1 : 0 : null);

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
        string memberId = null,
        string toMemberId = null,

        bool? withBonus = null,
        bool? withTransferSafeAmount = null,
        bool? withLtvTransferSafeAmount = null,

        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("coin", asset);
        parameters.AddEnum("accountType", account);
        parameters.AddOptional("memberId", memberId);
        parameters.AddOptional("toMemberId", toMemberId);
        parameters.AddOptionalEnum("toAccountType", toAccount);
        parameters.AddOptional("withBonus", withBonus.HasValue ? withBonus.Value ? 1 : 0 : null);
        parameters.AddOptional("withTransferSafeAmount", withTransferSafeAmount.HasValue ? withTransferSafeAmount.Value ? 1 : 0 : null);
        parameters.AddOptional("withLtvTransferSafeAmount", withLtvTransferSafeAmount.HasValue ? withLtvTransferSafeAmount.Value ? 1 : 0 : null);

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
        if (!result) return result.As<List<string>>(null);
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
        string transferId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
        };
        parameters.AddString("amount", quantity);
        parameters.AddEnum("fromAccountType", fromAccount);
        parameters.AddEnum("toAccountType", toAccount);

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
    public async Task<BybitRestCallResult<List<BybitAssetTransferInternal>>> GetInternalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("transferId", transferId);
        parameters.AddOptional("coin", asset);
        parameters.AddOptionalEnum("status", status);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetTransferInternal>>(_.BuildUri(_v5AssetTransferQueryInterTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetTransferInternal>>(null);
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
    public async Task<BybitRestCallResult<BybitAssetTransferId>> UniversalTransferAsync(string asset, decimal quantity, string fromMemberId, string toMemberId, BybitAccountType fromAccount, BybitAccountType toAccount, string transferId = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
            { "fromMemberId", fromMemberId },
            { "toMemberId", toMemberId },
        };
        parameters.AddString("amount", quantity);
        parameters.AddEnum("fromAccountType", fromAccount);
        parameters.AddEnum("toAccountType", toAccount);

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
    public async Task<BybitRestCallResult<List<BybitAssetTransferUniversal>>> GetUniversalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? transferStatus = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("transferId", transferId);
        parameters.AddOptional("coin", asset);
        parameters.AddOptionalEnum("status", transferStatus);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetTransferUniversal>>(_.BuildUri(_v5AssetTransferQueryUniversalTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetTransferUniversal>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
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
    public async Task<BybitRestCallResult<List<BybitAssetDepositAllow>>> GetDepositAllowedAssetsAsync(string asset = null, string network = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 35);
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);
        parameters.AddOptional("chain", network);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDepositAllow>>(_.BuildUri(_v5AssetDepositQueryAllowedList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDepositAllow>>(null);
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
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("coin", asset);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDeposit>>(_.BuildUri(_v5AssetDepositQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDeposit>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query subaccount's deposit records by main UID's API key.
    /// </summary>
    /// <param name="subMemberId">Sub UID</param>
    /// <param name="asset">Coin</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 50]. Default: 50</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAssetDeposit>>> GetDepositsAsync(long subUserId, string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection
        {
            { "subMemberId", subUserId },
        };
        parameters.AddOptional("coin", asset);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDeposit>>(_.BuildUri(_v5AssetDepositQuerySubMemberRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDeposit>>(null);
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
    public async Task<BybitRestCallResult<List<BybitAssetDepositInternal>>> GetInternalDepositsAsync(string asset = null, string txID = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("txID", txID);
        parameters.AddOptional("coin", asset);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetDepositInternal>>(_.BuildUri(_v5AssetDepositQueryInternalRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetDepositInternal>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query the deposit address information of MASTER account.
    /// </summary>
    /// <param name="asset">Coin</param>
    /// <param name="chain">Please use the value of >> chain from coin-info endpoint</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAssetDepositAddress>> GetDepositAddressAsync(string asset, string chain = null, CancellationToken ct = default)
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
    public async Task<BybitRestCallResult<BybitAssetDepositAddress>> GetDepositAddressAsync(long subUserId, string asset, string chain = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", asset },
            { "chainType", chain },
            { "subMemberId", subUserId },
        };
        return await _.SendBybitRequest<BybitAssetDepositAddress>(_.BuildUri(_v5AssetDepositQuerySubMemberAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
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
        string withdrawId = null,
        string transactionId = null,
        string asset = null,
        BybitWithdrawalType? type = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 50);
        var parameters = new ParameterCollection();
        parameters.AddOptional("withdrawID", withdrawId);
        parameters.AddOptional("txID", transactionId);
        parameters.AddOptional("coin", asset);
        parameters.AddOptionalEnum("withdrawType", type);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("cursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAssetWithdrawal>>(_.BuildUri(_v5AssetWithdrawQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetWithdrawal>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
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
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<long?>> WithdrawAsync(
        string asset,
        decimal quantity,
        string address,
        string tag = null,
        string chain = null,
        int? forceChain = null,
        BybitAccountType? account = null,
        int? feeType = null,
        string requestId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "coin", asset },
            { "address", address },
            { "chain", chain },
            { "timestamp", DateTime.UtcNow.ConvertToMilliseconds() }
        };
        parameters.AddString("amount", quantity);
        parameters.AddOptional("tag", tag);
        parameters.AddOptional("forceChain", forceChain);
        parameters.AddOptionalEnum("accountType", account);
        parameters.AddOptional("feeType", feeType);
        parameters.AddOptional("requestId", requestId);

        var result = await _.SendBybitRequest<BybitAssetWithdrawalId>(_.BuildUri(_v5AssetWithdrawCreate), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<long?>(null);
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
    #endregion

}