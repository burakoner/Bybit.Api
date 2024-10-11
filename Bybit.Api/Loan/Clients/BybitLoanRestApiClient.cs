namespace Bybit.Api.Loan;

/// <summary>
/// Bybit Lending Client
/// </summary>
public class BybitLoanRestApiClient
{
    // Institutional Lending Endpoints
    private const string _v5InsLoanProductInfos = "v5/ins-loan/product-infos";
    private const string _v5InsLoanEnsureTokensConvert = "v5/ins-loan/ensure-tokens-convert"; // TODO
    private const string _v5InsLoanLoanOrder = "v5/ins-loan/loan-order";
    private const string _v5InsLoanRepaidHistory = "v5/ins-loan/repaid-history";
    private const string _v5InsLoanLtvConvert = "v5/ins-loan/ltv-convert"; // TODO
    private const string _v5InsLoanAssociationUid = "v5/ins-loan/association-uid"; // TODO

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitLoanRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
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
    public async Task<BybitRestCallResult<List<BybitLoanProduct>>> GetProductsAsync(string productId = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("productId", productId);

        var result = await _.SendBybitRequest<BybitLendingProductContainer>(_.BuildUri(_v5InsLoanProductInfos), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanProduct>>(null);
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
    public async Task<BybitRestCallResult<List<BybitLoanOrder>>> GetLoanOrdersAsync(string orderId = null, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitLendingLoanOrderContainer>(_.BuildUri(_v5InsLoanLoanOrder), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanOrder>>(null);
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
    public async Task<BybitRestCallResult<List<BybitLoanRepayOrder>>> GetRepayOrdersAsync(long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);

        var result = await _.SendBybitRequest<BybitLoanRepayOrderContainer>(_.BuildUri(_v5InsLoanRepaidHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanRepayOrder>>(null);
        return result.As(result.Data.Payload);
    }

    // LTV: Customer Lifetime Value

}