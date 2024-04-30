using Bybit.Api.Models.Tokens;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Leverage Tokens Client
/// </summary>
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

    /// <summary>
    /// Query leverage token information
    /// </summary>
    /// <param name="token">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLeverageTokenInformation>>> GetLeverageTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeverageTokenInformation>>(MainClient.BuildUri(_v5SpotLeverTokenInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeverageTokenInformation>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get leverage token market information
    /// </summary>
    /// <param name="token">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLeverageTokenMarket>>> GetLeverageTokenMarketsAsync(string token, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeverageTokenMarket>>(MainClient.BuildUri(_v5SpotLeverTokenReference), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeverageTokenMarket>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Purchase levearge token
    /// </summary>
    /// <param name="symbol">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="quantity">Purchase amount</param>
    /// <param name="clientOrderId">Serial number</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitLeverageTokenPurchase>> PurchaseAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeverageTokenPurchase>(MainClient.BuildUri(_v5SpotLeverTokenPurchase), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Redeem leverage token
    /// </summary>
    /// <param name="symbol">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="quantity">Redeem quantity of LT</param>
    /// <param name="clientOrderId">Serial number</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitLeverageTokenRedeem>> RedeemAsync(string symbol, decimal quantity, string clientOrderId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "ltCoin", symbol },
            { "ltAmount", quantity.ToString(BybitConstants.BybitCultureInfo) },
        };
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        return await MainClient.SendBybitRequest<BybitLeverageTokenRedeem>(MainClient.BuildUri(_v5SpotLeverTokenRedeem), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get purchase or redeem history
    /// </summary>
    /// <param name="symbol">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size per page. [1, 500]. Default: 100</param>
    /// <param name="type">LT order type. 1: purchase, 2: redemption</param>
    /// <param name="clientOrderId">Serial number</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLeverageTokenOrder>>> GetHistoryAsync(
        string symbol = null,
        string orderId = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        BybitLeverageTokenOrderType? type = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 500);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", symbol);
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("ltOrderType", type?.GetLabel());
        parameters.AddOptionalParameter("serialNo", clientOrderId);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitLeverageTokenOrder>>(MainClient.BuildUri(_v5SpotLeverTokenOrderRecord), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeverageTokenOrder>>(null);
        return result.As(result.Data.Payload);
    }

}