using Bybit.Api.Models.Account;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Rest API Asset Client
/// </summary>
public class BybitRestApiAssetClient
{
    // Asset Endpoints
    private const string _v5AssetExchangeOrderRecord = "v5/asset/exchange/order-record";
    private const string _v5AssetDeliveryRecord = "v5/asset/delivery-record";
    private const string _v5AssetSettlementRecord = "v5/asset/settlement-record";
    private const string _v5AssetTransferQueryAssetInfo = "v5/asset/transfer/query-asset-info";
    private const string _v5AssetTransferQueryAccountCoinsBalance = "v5/asset/transfer/query-account-coins-balance";
    private const string _v5AssetTransferQueryAccountCoinBalance = "v5/asset/transfer/query-account-coin-balance";
    private const string _v5AssetTransferQueryTransferCoinList = "v5/asset/transfer/query-transfer-coin-list";
    private const string _v5AssetTransferInterTransfer = "v5/asset/transfer/inter-transfer";
    private const string _v5AssetTransferQueryInterTransferList = "v5/asset/transfer/query-inter-transfer-list";
    private const string _v5AssetTransferQuerySubMemberList = "v5/asset/transfer/query-sub-member-list";
    private const string _v5AssetTransferUniversalTransfer = "v5/asset/transfer/universal-transfer";
    private const string _v5AssetTransferQueryUniversalTransferList = "v5/asset/transfer/query-universal-transfer-list";
    private const string _v5AssetDepositQueryAllowedList = "v5/asset/deposit/query-allowed-list";
    private const string _v5AssetDepositDepositToAccount = "v5/asset/deposit/deposit-to-account";
    private const string _v5AssetDepositQueryRecord = "v5/asset/deposit/query-record";
    private const string _v5AssetDepositQuerySubMemberRecord = "v5/asset/deposit/query-sub-member-record";
    private const string _v5AssetDepositQueryInternalRecord = "v5/asset/deposit/query-internal-record";
    private const string _v5AssetDepositQueryAddress = "v5/asset/deposit/query-address";
    private const string _v5AssetDepositQuerySubMemberAddress = "v5/asset/deposit/query-sub-member-address";
    private const string _v5AssetCoinQueryInfo = "v5/asset/coin/query-info";
    private const string _v5AssetWithdrawQueryRecord = "v5/asset/withdraw/query-record";
    private const string _v5AssetWithdrawWithdrawableAmount = "v5/asset/withdraw/withdrawable-amount";
    private const string _v5AssetWithdrawCreate = "v5/asset/withdraw/create";
    private const string _v5AssetWithdrawCancel = "v5/asset/withdraw/cancel";

    #region Internal
    internal BybitRestApiBaseClient MainClient { get; }
    internal BybitRestApiAssetClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }
    #endregion

    #region Asset Methods
    public async Task<BybitRestCallResult<List<BybitAssetExchange>>> GetAssetExchangeHistoryAsync(string fromAsset = null, string toAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("fromCoin", fromAsset);
        parameters.AddOptionalParameter("toCoin", toAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitAssetExchange>>(MainClient.BuildUri(_v5AssetExchangeOrderRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetExchange>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitDelivery>>> GetDeliveryHistoryAsync(BybitCategory category, string symbol = null, long? expiryDate = null, int? limit = null, string cursor = null, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitDelivery>>(MainClient.BuildUri(_v5AssetDeliveryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitDelivery>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitSettlement>>> GetSettlementHistoryAsync(BybitCategory category, string symbol = null, int? limit = null, string cursor = null, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitSettlement>>(MainClient.BuildUri(_v5AssetSettlementRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSettlement>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<BybitCategoryAssetBalance>> GetSpotAssetBalancesAsync(BybitAccount account, string asset = null, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccount.Spot))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() }
        };
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitCategoryAssetBalances>(MainClient.BuildUri(_v5AssetTransferQueryAssetInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<BybitCategoryAssetBalance>(null);
        return result.As(result.Data.Spot);
    }

    public async Task<BybitRestCallResult<BybitAssetBalances>> GetAssetBalancesAsync(BybitAccount account, string userId = null, string asset = null, bool? withBonus = null, CancellationToken ct = default)
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

        return await MainClient.SendBybitRequest<BybitAssetBalances>(MainClient.BuildUri(_v5AssetTransferQueryAccountCoinsBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitAssetBalances>> GetAssetBalanceAsync(BybitAccount account, string asset, string userId = null, bool? withBonus = null, bool? withTransferSafeAmount = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() },
            { "coin", asset }
        };
        parameters.AddOptionalParameter("memberId", userId);
        parameters.AddOptionalParameter("withBonus", withBonus != null ? withBonus == true ? "1" : "0" : null);
        parameters.AddOptionalParameter("withTransferSafeAmount", withTransferSafeAmount != null ? withTransferSafeAmount == true ? "1" : "0" : null);

        return await MainClient.SendBybitRequest<BybitAssetBalances>(MainClient.BuildUri(_v5AssetTransferQueryAccountCoinBalance), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<string>>> GetTransferableAssetsAsync(BybitAccount fromAccount, BybitAccount toAccount, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<string>>(MainClient.BuildUri(_v5AssetTransferQueryTransferCoinList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<string>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<BybitRestCallResult<BybitTransferId>> CreateInternalTransferAsync(string asset, decimal quantity, BybitAccount fromAccount, BybitAccount toAccount, string transferId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
            { "amount", quantity.ToString(BybitConstants.BybitCultureInfo) },
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTransferId>(MainClient.BuildUri(_v5AssetTransferInterTransfer), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<BybitTransfer>>> GetInternalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("transferId", transferId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitTransfer>>(MainClient.BuildUri(_v5AssetTransferQueryInterTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTransfer>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<BybitSubUserIds>> GetSubUsersAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitSubUserIds>(MainClient.BuildUri(_v5AssetTransferQuerySubMemberList), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitTransferId>> CreateUniversalTransferAsync(string asset, decimal quantity, string fromUserId, string toUserId, BybitAccount fromAccount, BybitAccount toAccount, string transferId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "transferId", transferId ?? Guid.NewGuid().ToString() },
            { "coin", asset },
            { "amount", quantity.ToString(BybitConstants.BybitCultureInfo) },
            { "fromMemberId", fromUserId },
            { "toMemberId", toUserId },
            { "fromAccountType", fromAccount.GetLabel() },
            { "toAccountType", toAccount.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTransferId>(MainClient.BuildUri(_v5AssetTransferUniversalTransfer), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<BybitTransfer>>> GetUniversalTransfersAsync(string transferId = null, string asset = null, BybitTransferStatus? transferStatus = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("transferId", transferId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("status", transferStatus?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitTransfer>>(MainClient.BuildUri(_v5AssetTransferQueryUniversalTransferList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitTransfer>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitDepositAllowedAsset>>> GetDepositAllowedAssetsAsync(string asset = null, string network = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("chain", network);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitDepositAllowedAsset>>(MainClient.BuildUri(_v5AssetDepositQueryAllowedList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitDepositAllowedAsset>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<bool?>> SetDepositAccountAsync(BybitAccount account, CancellationToken ct = default)
    {
        if (account.IsNotIn(BybitAccount.Unified, BybitAccount.Spot, BybitAccount.Option, BybitAccount.Contract, BybitAccount.Fund))
            throw new NotSupportedException($"{account} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>()
        {
            { "accountType", account.GetLabel() }
        };

        var result = await MainClient.SendBybitRequest<BybitProcess>(MainClient.BuildUri(_v5AssetDepositDepositToAccount), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }

    public async Task<BybitRestCallResult<List<BybitOnchainDeposit>>> GetMainUserDepositsAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitOnchainDeposit>>(MainClient.BuildUri(_v5AssetDepositQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitOnchainDeposit>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitOnchainDeposit>>> GetSubUserDepositsAsync(string subUserId, string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
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

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitOnchainDeposit>>(MainClient.BuildUri(_v5AssetDepositQuerySubMemberRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitOnchainDeposit>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitInternalDeposit>>> GetInternalDepositsAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitInternalDeposit>>(MainClient.BuildUri(_v5AssetDepositQueryInternalRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitInternalDeposit>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<BybitDepositAddress>> GetMainUserDepositAddressAsync(string asset, string network = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset }
        };
        parameters.AddOptionalParameter("chainType", network);

        return await MainClient.SendBybitRequest<BybitDepositAddress>(MainClient.BuildUri(_v5AssetDepositQueryAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitDepositAddressSingle>> GetSubUserDepositAddressAsync(string subUserId, string asset, string network = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset },
            { "chainType", network },
            { "subMemberId", subUserId },
        };
        return await MainClient.SendBybitRequest<BybitDepositAddressSingle>(MainClient.BuildUri(_v5AssetDepositQuerySubMemberAddress), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<BybitAssetInformation>>> GetAssetInformationAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitAssetInformation>>(MainClient.BuildUri(_v5AssetCoinQueryInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAssetInformation>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<List<BybitWithdrawal>>> GetWithdrawalsAsync(string withdrawId = null, string asset = null, BybitWithdrawalType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("withdrawID", withdrawId);
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("withdrawType", type?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result =  await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitWithdrawal>>(MainClient.BuildUri(_v5AssetWithdrawQueryRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitWithdrawal>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    public async Task<BybitRestCallResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(string asset, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset }
        };

        return await MainClient.SendBybitRequest<BybitDelayedWithdrawal>(MainClient.BuildUri(_v5AssetWithdrawWithdrawableAmount), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<string>> WithdrawAsync(string asset, string network, decimal quantity, string address, string tag = null, bool? forceNetwork = null, BybitAccount? account = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "coin", asset },
            { "chain", network },
            { "address", address },
            { "amount", quantity.ToString(BybitConstants.BybitCultureInfo) },
            { "timestamp", DateTime.UtcNow.ConvertToMilliseconds() }
        };

        parameters.AddOptionalParameter("tag", tag);
        parameters.AddOptionalParameter("accountType", account?.GetLabel());
        parameters.AddOptionalParameter("forceChain", forceNetwork == null ? null : forceNetwork.Value ? 1 : 0);

        var result = await MainClient.SendBybitRequest<BybitId>(MainClient.BuildUri(_v5AssetWithdrawCreate), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<string>(null);
        return result.As(result.Data.Id);
    }

    public async Task<BybitRestCallResult<bool?>> CancelWithdrawalAsync(string id, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "id", id },
        };

        var result = await MainClient.SendBybitRequest<BybitProcess>(MainClient.BuildUri(_v5AssetWithdrawCancel), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<bool?>(null);
        return result.As((bool?)result.Data.Success);
    }
    #endregion

}