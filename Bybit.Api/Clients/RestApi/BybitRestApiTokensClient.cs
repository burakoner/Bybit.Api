using Bybit.Api.Models.LToken;

namespace Bybit.Api.Clients.RestApi;

public class BybitRestApiTokensClient
{
    // Spot Leverage Token Endpoints
    private const string _v5SpotLeverTokenInfo = "v5/spot-lever-token/info";
    private const string _v5SpotLeverTokenReference = "v5/spot-lever-token/reference";
    private const string _v5SpotLeverTokenPurchase = "v5/spot-lever-token/purchase";
    private const string _v5SpotLeverTokenRedeem = "v5/spot-lever-token/redeem";
    private const string _v5SpotLeverTokenOrderRecord = "v5/spot-lever-token/order-record";

    #region Internal
    internal BybitRestApiBaseClient MainClient { get; }
    internal BybitRestApiTokensClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }
    #endregion

    public async Task<BybitRestCallResult<List<BybitLeveragedTokenInformation>>> GetLeveragedTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeveragedTokenInformation>>(MainClient.BuildUri(_v5SpotLeverTokenInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeveragedTokenInformation>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<BybitRestCallResult<List<BybitLeveragedTokenMarket>>> GetLeveragedTokenMarketsAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeveragedTokenMarket>>(MainClient.BuildUri(_v5SpotLeverTokenReference), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeveragedTokenMarket>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<BybitRestCallResult<BybitLeveragedTokenPurchase>> PurchaseAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeveragedTokenPurchase>(MainClient.BuildUri(_v5SpotLeverTokenPurchase), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitLeveragedTokenRedeem>> RedeemAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeveragedTokenRedeem>(MainClient.BuildUri(_v5SpotLeverTokenRedeem), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<BybitLeveragedTokenOrder>>> GetOrdersAsync(string symbol=null, string orderId=null, string clientOrderId=null, BybitLtOrderType? type=null, long? startTime=null, long? endTime = null, int? limit=null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", symbol);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("serialNo", clientOrderId);
        parameters.AddOptionalParameter("ltOrderType", type?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeveragedTokenOrder>>(MainClient.BuildUri(_v5SpotLeverTokenOrderRecord), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeveragedTokenOrder>>(null);
        return result.As(result.Data.Payload);
    }

}