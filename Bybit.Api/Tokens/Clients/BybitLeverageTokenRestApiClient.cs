namespace Bybit.Api.Tokens;

/// <summary>
/// Bybit Leverage Tokens Client
/// </summary>
public class BybitLeverageTokenRestApiClient
{
    // Spot Leverage Token Endpoints
    private const string _v5SpotLeverTokenInfo = "v5/spot-lever-token/info";
    private const string _v5SpotLeverTokenReference = "v5/spot-lever-token/reference";
    private const string _v5SpotLeverTokenPurchase = "v5/spot-lever-token/purchase";
    private const string _v5SpotLeverTokenRedeem = "v5/spot-lever-token/redeem";
    private const string _v5SpotLeverTokenOrderRecord = "v5/spot-lever-token/order-record";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitLeverageTokenRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Query leverage token information
    /// </summary>
    /// <param name="token">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLeverageToken>>> GetTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("ltCoin", token);

        var result = await _.SendBybitRequest<BybitListResponse<BybitLeverageToken>>(_.BuildUri(_v5SpotLeverTokenInfo), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeverageToken>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get leverage token market information
    /// </summary>
    /// <param name="token">Abbreviation of the LT, such as BTC3L</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLeverageTokenMarket>>> GetMarketsAsync(string token, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("ltCoin", token);

        var result = await _.SendBybitRequest<BybitListResponse<BybitLeverageTokenMarket>>(_.BuildUri(_v5SpotLeverTokenReference), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
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
        var parameters = new ParameterCollection
        {
            { "ltCoin", symbol },
        };
        parameters.AddString("ltAmount", quantity);
        parameters.AddOptional("serialNo", clientOrderId);

        return await _.SendBybitRequest<BybitLeverageTokenPurchase>(_.BuildUri(_v5SpotLeverTokenPurchase), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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
        var parameters = new ParameterCollection
        {
            { "ltCoin", symbol },
        };
        parameters.AddString("ltAmount", quantity);
        parameters.AddOptional("serialNo", clientOrderId);

        return await _.SendBybitRequest<BybitLeverageTokenRedeem>(_.BuildUri(_v5SpotLeverTokenRedeem), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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

        var parameters = new ParameterCollection();
        parameters.AddOptional("ltCoin", symbol);
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptionalEnum("ltOrderType", type);
        parameters.AddOptional("serialNo", clientOrderId);

        var result = await _.SendBybitRequest<BybitListResponse<BybitLeverageTokenOrder>>(_.BuildUri(_v5SpotLeverTokenOrderRecord), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLeverageTokenOrder>>(null);
        return result.As(result.Data.Payload);
    }

}