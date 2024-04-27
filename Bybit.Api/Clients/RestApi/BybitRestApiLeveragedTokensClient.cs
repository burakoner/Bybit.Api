using Bybit.Api.Models.LToken;

namespace Bybit.Api.Clients.RestApi;

public class BybitRestApiLeveragedTokensClient
{
    // Spot Leverage Token Endpoints
    protected const string v5SpotLeverTokenInfoEndpoint = "v5/spot-lever-token/info";
    protected const string v5SpotLeverTokenReferenceEndpoint = "v5/spot-lever-token/reference";
    protected const string v5SpotLeverTokenPurchaseEndpoint = "v5/spot-lever-token/purchase";
    protected const string v5SpotLeverTokenRedeemEndpoint = "v5/spot-lever-token/redeem";
    protected const string v5SpotLeverTokenOrderRecordEndpoint = "v5/spot-lever-token/order-record";

    // Internal
    internal BybitRestApiBaseClient MainClient { get; }

    internal BybitRestApiLeveragedTokensClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }

    public async Task<RestCallResult<IEnumerable<BybitLeveragedTokenInformation>>> GetLeveragedTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitLeveragedTokenInformation>>(MainClient.GetUri(v5SpotLeverTokenInfoEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLeveragedTokenInformation>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitLeveragedTokenMarket>>> GetLeveragedTokenMarketsAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitLeveragedTokenMarket>>(MainClient.GetUri(v5SpotLeverTokenReferenceEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLeveragedTokenMarket>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<BybitLeveragedTokenPurchase>> PurchaseAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeveragedTokenPurchase>(MainClient.GetUri(v5SpotLeverTokenPurchaseEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitLeveragedTokenRedeem>> RedeemAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeveragedTokenRedeem>(MainClient.GetUri(v5SpotLeverTokenRedeemEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitLeveragedTokenOrder>>> GetOrdersAsync(string symbol=null, string orderId=null, string clientOrderId=null, BybitLtOrderType? type=null, long? startTime=null, long? endTime = null, int? limit=null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", symbol);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("serialNo", clientOrderId);
        parameters.AddOptionalParameter("ltOrderType", type?.GetLabel());
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitListResponse<BybitLeveragedTokenOrder>>(MainClient.GetUri(v5SpotLeverTokenOrderRecordEndpoint), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLeveragedTokenOrder>>(null);
        return result.As(result.Data.Payload);
    }

}