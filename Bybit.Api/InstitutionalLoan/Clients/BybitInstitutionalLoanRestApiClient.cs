namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Bybit REST API Institutional Loan client.
/// </summary>
public class BybitInstitutionalLoanRestApiClient
{
    private const string _v5InsLoanProductInfos = "v5/ins-loan/product-infos";
    private const string _v5InsLoanEnsureTokensConvert = "v5/ins-loan/ensure-tokens-convert";
    private const string _v5InsLoanLoanOrder = "v5/ins-loan/loan-order";
    private const string _v5InsLoanRepaidHistory = "v5/ins-loan/repaid-history";
    private const string _v5InsLoanLtvConvert = "v5/ins-loan/ltv-convert";
    private const string _v5InsLoanAssociationUid = "v5/ins-loan/association-uid";
    private const string _v5InsLoanRepayLoan = "v5/ins-loan/repay-loan";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitInstitutionalLoanRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get product information. This endpoint does not require authentication for public product data.
    /// </summary>
    /// <param name="productId">Product ID. If not passed, returns all products.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<BybitRestCallResult<List<BybitLoanProduct>>> GetProductsAsync(string? productId = null, CancellationToken ct = default)
        => GetProductsAsync(new BybitLoanProductRequest { ProductId = productId }, ct);

    /// <summary>
    /// Get product information. This endpoint does not require authentication for public product data.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitLoanProduct>>> GetProductsAsync(BybitLoanProductRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection();
        parameters.AddOptional("productId", request.ProductId);

        var result = await _.SendBybitRequest<BybitLendingProductContainer>(_.BuildUri(_v5InsLoanProductInfos), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanProduct>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get margin coin information. This endpoint does not require authentication for public margin data.
    /// </summary>
    /// <param name="productId">Product ID. If not passed, returns all margin products.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<BybitRestCallResult<List<BybitLoanToken>>> GetMarginCoinsAsync(string? productId = null, CancellationToken ct = default)
        => GetMarginCoinsAsync(new BybitLoanMarginCoinRequest { ProductId = productId }, ct);

    /// <summary>
    /// Get margin coin information. This endpoint does not require authentication for public margin data.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitLoanToken>>> GetMarginCoinsAsync(BybitLoanMarginCoinRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection();
        parameters.AddOptional("productId", request.ProductId);

        var result = await _.SendBybitRequest<BybitLendingTokenContainer>(_.BuildUri(_v5InsLoanEnsureTokensConvert), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanToken>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get loan order information.
    /// </summary>
    /// <param name="orderId">Loan order ID. If not passed, returns all orders sorted by loan time in descending order.</param>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Limit for data size. [1, 100], default: 10.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<BybitRestCallResult<List<BybitLoanOrder>>> GetLoanOrdersAsync(string? orderId = null, long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
        => GetLoanOrdersAsync(new BybitLoanOrdersRequest { OrderId = orderId, StartTime = startTime, EndTime = endTime, Limit = limit }, ct);

    /// <summary>
    /// Get loan order information.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitLoanOrder>>> GetLoanOrdersAsync(BybitLoanOrdersRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);

        var result = await _.SendBybitRequest<BybitLendingLoanOrderContainer>(_.BuildUri(_v5InsLoanLoanOrder), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanOrder>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get a list of your loan repayment orders.
    /// </summary>
    /// <param name="startTime">Start timestamp in milliseconds.</param>
    /// <param name="endTime">End timestamp in milliseconds.</param>
    /// <param name="limit">Limit for data size. [1, 100], default: 100.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<BybitRestCallResult<List<BybitLoanRepayOrder>>> GetRepayOrdersAsync(long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
        => GetRepayOrdersAsync(new BybitLoanRepayOrdersRequest { StartTime = startTime, EndTime = endTime, Limit = limit }, ct);

    /// <summary>
    /// Get a list of your loan repayment orders.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitLoanRepayOrder>>> GetRepayOrdersAsync(BybitLoanRepayOrdersRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 100);

        var parameters = new ParameterCollection();
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);

        var result = await _.SendBybitRequest<BybitLoanRepayOrderContainer>(_.BuildUri(_v5InsLoanRepaidHistory), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitLoanRepayOrder>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get your institutional loan-to-value ratio.
    /// </summary>
    public async Task<BybitRestCallResult<BybitLoanLtv>> GetLtvAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitLoanLtv>(_.BuildUri(_v5InsLoanLtvConvert), HttpMethod.Get, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Get your institutional loan-to-value ratio.
    /// </summary>
    public Task<BybitRestCallResult<BybitLoanLtv>> GetLoanToValueAsync(CancellationToken ct = default)
        => GetLtvAsync(ct);

    /// <summary>
    /// Bind a new UID to the risk unit.
    /// </summary>
    public Task<BybitRestCallResult<BybitLoanUidAssociation>> BindUidAsync(string uid, CancellationToken ct = default)
        => BindOrUnbindUidAsync(uid, BybitLoanUidOperation.Bind, ct);

    /// <summary>
    /// Unbind a UID from the risk unit.
    /// </summary>
    public Task<BybitRestCallResult<BybitLoanUidAssociation>> UnbindUidAsync(string uid, CancellationToken ct = default)
        => BindOrUnbindUidAsync(uid, BybitLoanUidOperation.Unbind, ct);

    /// <summary>
    /// Bind or unbind a UID from the institutional loan risk unit.
    /// </summary>
    public Task<BybitRestCallResult<BybitLoanUidAssociation>> BindOrUnbindUidAsync(string uid, BybitLoanUidOperation operation, CancellationToken ct = default)
        => BindOrUnbindUidAsync(new BybitLoanBindUidRequest(uid, operation), ct);

    /// <summary>
    /// Bind or unbind a UID from the institutional loan risk unit.
    /// </summary>
    public async Task<BybitRestCallResult<BybitLoanUidAssociation>> BindOrUnbindUidAsync(BybitLoanBindUidRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection
        {
            { "uid", request.Uid },
        };
        parameters.AddEnum("operate", request.Operation);

        return await _.SendBybitRequest<BybitLoanUidAssociation>(_.BuildUri(_v5InsLoanAssociationUid), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Repay an institutional loan.
    /// </summary>
    public Task<BybitRestCallResult<BybitLoanRepayResult>> RepayAsync(string token, decimal quantity, CancellationToken ct = default)
        => RepayAsync(new BybitLoanRepayRequest(token, quantity), ct);

    /// <summary>
    /// Repay an institutional loan.
    /// </summary>
    public async Task<BybitRestCallResult<BybitLoanRepayResult>> RepayAsync(BybitLoanRepayRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection
        {
            { "token", request.Token },
        };
        parameters.AddString("quantity", request.Quantity);

        return await _.SendBybitRequest<BybitLoanRepayResult>(_.BuildUri(_v5InsLoanRepayLoan), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}
