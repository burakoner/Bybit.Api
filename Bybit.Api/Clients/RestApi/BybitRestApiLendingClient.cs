using Bybit.Api.Models.Lending;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Lending Client
/// </summary>
public class BybitRestApiLendingClient
{
    // Institutional Lending Endpoints
    private const string _v5InsLoanProductInfos = "v5/ins-loan/product-infos";
    private const string _v5InsLoanEnsureTokens = "v5/ins-loan/ensure-tokens"; // TODO: Remove
    private const string _v5InsLoanEnsureTokensConvert = "v5/ins-loan/ensure-tokens-convert"; // TODO
    private const string _v5InsLoanLoanOrder = "v5/ins-loan/loan-order";
    private const string _v5InsLoanRepaidHistory = "v5/ins-loan/repaid-history";
    private const string _v5InsLoanLtvConvert = "v5/ins-loan/ltv-convert"; // TODO
    private const string _v5InsLoanAssociationUid = "v5/ins-loan/association-uid"; // TODO

    #region Internal
    internal BybitRestApiBaseClient MainClient { get; }
    internal BybitRestApiLendingClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get Product Info
    /// 
    /// TIP
    /// This endpoint can be queried without api key and secret, then it returns public product data
    /// If your uid is bound with OTC loan product, then you can get your private product data by calling the endpoint with api key and secret
    /// If your uid is not bound with OTC loan product but api key and secret are also passed, it will return public data only
    /// </summary>
    /// <param name="productId">Product Id. If not passed, then return all products info</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLendingProduct>>> GetLendingProductsAsync(string productId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("productId", productId);

        var result = await MainClient.SendBybitRequest<BybitLendingProductContainer>(MainClient.BuildUri(_v5InsLoanProductInfos), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLendingProduct>>(null);
        return result.As(result.Data.Payload);
    }

    // TODO: Remove
    private async Task<BybitRestCallResult<List<BybitLendingToken>>> GetLendingTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitLendingTokenContainer>(MainClient.BuildUri(_v5InsLoanEnsureTokens), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLendingToken>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get loan orders information
    /// </summary>
    /// <param name="orderId">Loan order id. If not passed, then return all orders, sort by loanTime in descend</param>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size. [1, 100], Default: 10</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLendingLoanOrder>>> GetLoanOrdersAsync(string orderId = null, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitLendingLoanOrderContainer>(MainClient.BuildUri(_v5InsLoanLoanOrder), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLendingLoanOrder>>(null);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get a list of your loan repayment orders (orders which repaid the loan).
    /// </summary>
    /// <param name="startTime">The start timestamp (ms)</param>
    /// <param name="endTime">The end timestamp (ms)</param>
    /// <param name="limit">Limit for data size. [1, 100]. Default: 100</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitLendingRepayOrder>>> GetRepayOrdersAsync(long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitLendingRepayOrderContainer>(MainClient.BuildUri(_v5InsLoanRepaidHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLendingRepayOrder>>(null);
        return result.As(result.Data.Payload);
    }

    // LTV: Customer Lifetime Value

}