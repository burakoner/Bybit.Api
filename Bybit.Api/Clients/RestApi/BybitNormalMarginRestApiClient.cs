using Bybit.Api.Models.Margin;

namespace Bybit.Api.Clients.RestApi;

public class BybitNormalMarginRestApiClient
{
    // Spot Margin Trade (Normal) Endpoints
    protected const string v5SpotCrossMarginTradePledgeTokenEndpoint = "v5/spot-cross-margin-trade/pledge-token";
    protected const string v5SpotCrossMarginTradeBorrowTokenEndpoint = "v5/spot-cross-margin-trade/borrow-token";
    protected const string v5SpotCrossMarginTradeLoanInfoEndpoint = "v5/spot-cross-margin-trade/loan-info";
    protected const string v5SpotCrossMarginTradeAccountEndpoint = "v5/spot-cross-margin-trade/account";
    protected const string v5SpotCrossMarginTradeLoanEndpoint = "v5/spot-cross-margin-trade/loan";
    protected const string v5SpotCrossMarginTradeRepayEndpoint = "v5/spot-cross-margin-trade/repay";
    protected const string v5SpotCrossMarginTradeOrdersEndpoint = "v5/spot-cross-margin-trade/orders";
    protected const string v5SpotCrossMarginTradeRepayHistoryEndpoint = "v5/spot-cross-margin-trade/repay-history";
    protected const string v5SpotCrossMarginTradeSwitchEndpoint = "v5/spot-cross-margin-trade/switch";

    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitNormalMarginRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    public async Task<RestCallResult<IEnumerable<BybitSpotMarginAsset>>> GetMarginAssetsAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitSpotMarginAsset>>(MainClient.GetUri(v5SpotCrossMarginTradePledgeTokenEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotMarginAsset>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitSpotBorrowableAsset>>> GetBorrowableAssetsAsync(string asset = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitSpotBorrowableAsset>>(MainClient.GetUri(v5SpotCrossMarginTradeBorrowTokenEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotBorrowableAsset>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitSpotInterestAndQuota>> GetInterestAndQuotaAsync(string asset, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "coin", asset },
        };

        return await MainClient.SendBybitRequest<BybitSpotInterestAndQuota>(MainClient.GetUri(v5SpotCrossMarginTradeBorrowTokenEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitMarginAccountInformation>> GetLoanAccountInformationAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitMarginAccountInformation>(MainClient.GetUri(v5SpotCrossMarginTradeAccountEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitSpotBorrowReponse>> BorrowAsync(string asset, decimal quantity, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "coin", asset },
            { "qty", quantity.ToString(CI) },
        };
        return await MainClient.SendBybitRequest<BybitSpotBorrowReponse>(MainClient.GetUri(v5SpotCrossMarginTradeLoanEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitSpotRepaymentReponse>> RepayAsync(string asset, decimal? quantity = null, bool? completeRepayment = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "coin", asset },
        };
        parameters.AddOptionalParameter("qty", quantity);
        parameters.AddOptionalParameter("completeRepayment", completeRepayment != null ? completeRepayment == true ? 1 : 0 : null);

        return await MainClient.SendBybitRequest<BybitSpotRepaymentReponse>(MainClient.GetUri(v5SpotCrossMarginTradeRepayEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitSpotBorrowOrder>>> GetBorrowsAsync(string asset = null, BybitSpotBorrowOrderStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 500);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("status", status?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitSpotBorrowOrder>>(MainClient.GetUri(v5SpotCrossMarginTradeOrdersEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotBorrowOrder>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitSpotRepaymentOrder>>> GetRepaymentsAsync(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 500);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("coin", asset);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitSpotRepaymentOrder>>(MainClient.GetUri(v5SpotCrossMarginTradeRepayHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSpotRepaymentOrder>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitSpotMarginSwitch>> SwitchMarginTradeAsync(bool spotMarginTrade, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "switch", spotMarginTrade ? 1 : 0 },
        };

        return await MainClient.SendBybitRequest<BybitSpotMarginSwitch>(MainClient.GetUri(v5SpotCrossMarginTradeSwitchEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}