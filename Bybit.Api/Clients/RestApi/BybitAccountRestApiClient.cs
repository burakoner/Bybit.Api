using Bybit.Api.Models.Wallet;

namespace Bybit.Api.Clients.RestApi;

public class BybitAccountRestApiClient
{
    // Account Endpoints
    protected const string v5AccountWalletBalanceEndpoint = "v5/account/wallet-balance";
    protected const string v5AccountUpgradeToUtaEndpoint = "v5/account/upgrade-to-uta";
    protected const string v5AccountBorrowHistoryEndpoint = "v5/account/borrow-history";
    protected const string v5AccountCollateralInfoEndpoint = "v5/account/collateral-info";
    protected const string v5AssetCoinGreeksEndpoint = "v5/asset/coin-greeks";
    protected const string v5AccountFeeRateEndpoint = "v5/account/fee-rate";
    protected const string v5AccountInfoEndpoint = "v5/account/info";
    protected const string v5AccountTransactionLogEndpoint = "v5/account/transaction-log";
    protected const string v5AccountSetMarginModeEndpoint = "v5/account/set-margin-mode";
    protected const string v5AccountMmpModifyEndpoint = "v5/account/mmp-modify";
    protected const string v5AccountMmpResetEndpoint = "v5/account/mmp-reset";
    protected const string v5AccountMmpStateEndpoint = "v5/account/mmp-state";

    // Internal
    internal BaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitAccountRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    #region Account Methods
    public async Task<RestCallResult<IEnumerable<BybitBalance>>> GetBalancesAsync(BybitAccount account, string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "accountType", account.GetLabel() }
        };
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitBalance>>(MainClient.GetUri(v5AccountWalletBalanceEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitBalance>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitUnifiedUpgrade>> UpgradeToUnifiedAccountAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitUnifiedUpgrade>(MainClient.GetUri(v5AccountUpgradeToUtaEndpoint), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("currency", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitBorrowHistory>>(MainClient.GetUri(v5AccountBorrowHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitCollateralInfo>>> GetCollateralInfoAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("currency", asset);

        var result =  await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitCollateralInfo>>(MainClient.GetUri(v5AccountCollateralInfoEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitCollateralInfo>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitGreeks>>> GetAssetGreeksAsync(string baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("baseCoin", baseAsset);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitGreeks>>(MainClient.GetUri(v5AssetCoinGreeksEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitGreeks>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitFeeRate>>> GetFeeRateAsync(BybitCategory category, string symbol = null, string baseAsset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitFeeRate>>(MainClient.GetUri(v5AccountFeeRateEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitFeeRate>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitAccountInfo>(MainClient.GetUri(v5AccountInfoEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitTransaction>>> GetTransactionHistoryAsync(BybitAccount? account = null, BybitCategory? category = null, string asset = null, string baseAsset = null, BybitTransactionType? type = null, long? startTime = null, long? endTime = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        limit?.ValidateIntValues(nameof(limit), 1, 50);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("accountType", account?.GetLabel());
        parameters.AddOptionalParameter("category", category?.GetLabel());
        parameters.AddOptionalParameter("currency", asset);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("type", type?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitTransaction>>(MainClient.GetUri(v5AccountTransactionLogEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitReason>>> SetMarginModeAsync(BybitMarginMode marginMode, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "setMarginMode", marginMode.GetLabel() }
        };

        return await MainClient.SendBybitRequest<IEnumerable<BybitReason>>(MainClient.GetUri(v5AccountSetMarginModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetMarketMakerProtectionAsync(string baseAsset, int window, int frozenPeriod, decimal quantityLimit, decimal deltaLimit, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "baseCoin", baseAsset },
            { "window", window },
            { "frozenPeriod", frozenPeriod },
            { "qtyLimit", quantityLimit },
            { "deltaLimit", deltaLimit },
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5AccountMmpModifyEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> ResetMarketMakerProtectionAsync(string baseAsset, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "baseCoin", baseAsset },
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5AccountMmpResetEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitMmpState>>> GetMarketMakerProtectionAsync(string baseAsset, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "baseCoin", baseAsset },
        };

        var result = await MainClient.SendBybitRequest<BybitRestApiResultResponse<BybitMmpState>>(MainClient.GetUri(v5AccountMmpStateEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitMmpState>>(null);
        return result.As(result.Data.Payload);
    }
    #endregion

}