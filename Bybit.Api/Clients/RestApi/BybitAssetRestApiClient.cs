using Bybit.Api.Models.Wallet;

namespace Bybit.Api.Clients.RestApi;

public class BybitAssetRestApiClient
{
    // Asset Endpoints
    protected const string v5AssetExchangeOrderRecordEndpoint = "v5/asset/exchange/order-record";
    protected const string v5AssetDeliveryRecordEndpoint = "v5/asset/delivery-record";
    protected const string v5AssetSettlementRecordEndpoint = "v5/asset/settlement-record";
    protected const string v5AssetTransferQueryAssetInfoEndpoint = "v5/asset/transfer/query-asset-info";
    protected const string v5AssetTransferQueryAccountCoinsBalanceEndpoint = "v5/asset/transfer/query-account-coins-balance";
    protected const string v5AssetTransferQueryAccountCoinBalanceEndpoint = "v5/asset/transfer/query-account-coin-balance";
    protected const string v5AssetTransferQueryTransferCoinListEndpoint = "v5/asset/transfer/query-transfer-coin-list";
    protected const string v5AssetTransferInterTransferEndpoint = "v5/asset/transfer/inter-transfer";
    protected const string v5AssetTransferQueryInterTransferListEndpoint = "v5/asset/transfer/query-inter-transfer-list";
    protected const string v5AssetTransferQuerySubMemberListEndpoint = "v5/asset/transfer/query-sub-member-list";
    protected const string v5AssetTransferSaveTransferSubMemberEndpoint = "v5/asset/transfer/save-transfer-sub-member";
    protected const string v5AssetTransferUniversalTransferEndpoint = "v5/asset/transfer/universal-transfer";
    protected const string v5AssetTransferQueryUniversalTransferListEndpoint = "v5/asset/transfer/query-universal-transfer-list";
    protected const string v5AssetDepositQueryAllowedListEndpoint = "v5/asset/deposit/query-allowed-list";
    protected const string v5AssetDepositDepositToAccountEndpoint = "v5/asset/deposit/deposit-to-account";
    protected const string v5AssetDepositQueryRecordEndpoint = "v5/asset/deposit/query-record";
    protected const string v5AssetDepositQuerySubMemberRecordEndpoint = "v5/asset/deposit/query-sub-member-record";
    protected const string v5AssetDepositQueryInternalRecordEndpoint = "v5/asset/deposit/query-internal-record";
    protected const string v5AssetDepositQueryAddressEndpoint = "v5/asset/deposit/query-address";
    protected const string v5AssetDepositQuerySubMemberAddressEndpoint = "v5/asset/deposit/query-sub-member-address";
    protected const string v5AssetCoinQueryInfoEndpoint = "v5/asset/coin/query-info";
    protected const string v5AssetWithdrawQueryRecordEndpoint = "v5/asset/withdraw/query-record";
    protected const string v5AssetWithdrawWithdrawableAmountEndpoint = "v5/asset/withdraw/withdrawable-amount";
    protected const string v5AssetWithdrawCreateEndpoint = "v5/asset/withdraw/create";
    protected const string v5AssetWithdrawCancelEndpoint = "v5/asset/withdraw/cancel";

    // Internal
    internal BaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitAssetRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    #region Asset Methods
    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitAssetExchange>>> GetAssetExchangeHistoryAsync(string fromAsset = null, string toAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("fromCoin", fromAsset);
        parameters.AddOptionalParameter("toCoin", toAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitAssetExchange>>(MainClient.GetUri(v5AssetExchangeOrderRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitDelivery>>> GetDeliveryHistoryAsync(BybitCategory category, string symbol = null, long? expiryDate = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() }
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("expDate", expiryDate);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitDelivery>>(MainClient.GetUri(v5AssetDeliveryRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitSettlement>>> GetSettlementHistoryAsync(BybitCategory category, string symbol = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "category", category.GetLabel() }
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitSettlement>>(MainClient.GetUri(v5AssetSettlementRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitCategoryAssetBalance>> GetSpotAssetBalancesAsync(BybitAccount account, string asset = null, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccount.Spot))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() }
        };
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitCategoryAssetBalances>(MainClient.GetUri(v5AssetTransferQueryAssetInfoEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitCategoryAssetBalance>(null);
        return result.As(result.Data.Spot);
    }

    public async Task<RestCallResult<BybitAssetBalances>> GetAssetBalancesAsync(BybitAccount account, string userId = null, string asset = null, bool? withBonus = null, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccount.Spot))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() }
        };
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("memberId", userId);
        parameters.AddOptionalParameter("withBonus", withBonus != null ? withBonus == true ? "1" : "0" : null);

        return await MainClient.SendBybitRequest<BybitAssetBalances>(MainClient.GetUri(v5AssetTransferQueryAccountCoinsBalanceEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitAssetBalances>> GetAssetBalanceAsync(BybitAccount account, string asset, string userId = null, bool? withBonus = null, bool? withTransferSafeAmount = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() },
            { "coin", asset }
        };
        parameters.AddOptionalParameter("memberId", userId);
        parameters.AddOptionalParameter("withBonus", withBonus != null ? withBonus == true ? "1" : "0" : null);
        parameters.AddOptionalParameter("withTransferSafeAmount", withTransferSafeAmount != null ? withTransferSafeAmount == true ? "1" : "0" : null);

        return await MainClient.SendBybitRequest<BybitAssetBalances>(MainClient.GetUri(v5AssetTransferQueryAccountCoinBalanceEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<string>>> GetTransferableAssetsAsync(BybitAccount fromAccount, BybitAccount toAccount, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<string>>(MainClient.GetUri(v5AssetTransferQueryTransferCoinListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<string>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitTransferId>> CreateInternalTransferAsync(string asset, decimal quantity, BybitAccount fromAccount, BybitAccount toAccount, string transferId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
            { "amount", quantity.ToString(CI) },
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTransferId>(MainClient.GetUri(v5AssetTransferInterTransferEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitTransfer>>> GetInternalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("transferId", transferId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitTransfer>>(MainClient.GetUri(v5AssetTransferQueryInterTransferListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitSubUserIds>> GetSubUsersAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitSubUserIds>(MainClient.GetUri(v5AssetTransferQuerySubMemberListEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult> EnableUniversalTransferForSubUsersAsync(IEnumerable<string> subUserIds, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subMemberIds", new List<string> { string.Join(",", subUserIds) } },
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5AssetTransferSaveTransferSubMemberEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitTransferId>> CreateUniversalTransferAsync(string asset, decimal quantity, string fromUserId, string toUserId, BybitAccount fromAccount, BybitAccount toAccount, string transferId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
            { "amount", quantity.ToString(CI) },
            { "fromMemberId", fromUserId },
            { "toMemberId", toUserId },
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTransferId>(MainClient.GetUri(v5AssetTransferUniversalTransferEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitTransfer>>> GetUniversalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? transferStatus = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("transferId", transferId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("status", transferStatus?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitTransfer>>(MainClient.GetUri(v5AssetTransferQueryUniversalTransferListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitDepositAllowedAsset>>> GetDepositAllowedAssetsAsync(string asset = null, string network = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("chain", network);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitDepositAllowedAsset>>(MainClient.GetUri(v5AssetDepositQueryAllowedListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<bool?>> SetDepositAccountAsync(BybitAccount account, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccount.Unified, BybitAccount.Spot, BybitAccount.Option, BybitAccount.Contract, BybitAccount.Fund))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() }
        };

        var result = await MainClient.SendBybitRequest<BybitProcess>(MainClient.GetUri(v5AssetDepositDepositToAccountEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOnchainDeposit>>> GetMainUserDepositsAsync( string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOnchainDeposit>>(MainClient.GetUri(v5AssetDepositQueryRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitOnchainDeposit>>> GetSubUserDepositsAsync(string subUserId, string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subMemberId", subUserId },
        };
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitOnchainDeposit>>(MainClient.GetUri(v5AssetDepositQuerySubMemberRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitInternalDeposit>>> GetInternalDepositsAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitInternalDeposit>>(MainClient.GetUri(v5AssetDepositQueryInternalRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitDepositAddress>> GetMainUserDepositAddressAsync(string asset, string network = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset }
        };
        parameters.AddOptionalParameter("chainType", network);

        return await MainClient.SendBybitRequest<BybitDepositAddress>(MainClient.GetUri(v5AssetDepositQueryAddressEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitDepositAddressSingle>> GetSubUserDepositAddressAsync(string subUserId, string asset, string network = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset },
            { "chainType", network },
            { "subMemberId", subUserId },
        };
        return await MainClient.SendBybitRequest<BybitDepositAddressSingle>(MainClient.GetUri(v5AssetDepositQuerySubMemberAddressEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitAssetInformation>>> GetAssetInformationAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitAssetInformation>>(MainClient.GetUri(v5AssetCoinQueryInfoEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitWithdrawal>>> GetWithdrawalsAsync(string withdrawId = null, string asset = null, BybitWithdrawalType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("withdrawID", withdrawId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("withdrawType", type?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitWithdrawal>>(MainClient.GetUri(v5AssetWithdrawQueryRecordEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(string asset, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset }
        };

        return await MainClient.SendBybitRequest<BybitDelayedWithdrawal>(MainClient.GetUri(v5AssetWithdrawWithdrawableAmountEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<string>> WithdrawAsync(string asset, string network, decimal quantity, string address, string tag = null, bool? forceNetwork = null, BybitAccount? account = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset },
            { "chain", network },
            { "address", address },
            { "amount", quantity.ToString(CI) },
            { "timestamp", DateTime.UtcNow.ConvertToMilliseconds() }
        };

        parameters.AddOptionalParameter("tag", tag);
        parameters.AddOptionalParameter("accountType", account?.GetLabel());
        parameters.AddOptionalParameter("forceChain", forceNetwork == null ? null : forceNetwork.Value ? 1 : 0);

        var result = await MainClient.SendBybitRequest<BybitId>(MainClient.GetUri(v5AssetWithdrawCreateEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<string>(null);
        return result.As(result.Data.Id);
    }

    public async Task<RestCallResult<bool?>> CancelWithdrawalAsync(string id, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "id", id },
        };

        var result = await MainClient.SendBybitRequest<BybitProcess>(MainClient.GetUri(v5AssetWithdrawCancelEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }
    #endregion

}