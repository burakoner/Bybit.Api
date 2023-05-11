using Bybit.Api.Models.Lending;

namespace Bybit.Api.Clients.RestApi;

public class BybitInstitutionalLendingRestApiClient
{
    // Institutional Lending Endpoints
    protected const string v5InsLoanProductInfosEndpoint = "v5/ins-loan/product-infos";
    protected const string v5InsLoanEnsureTokensEndpoint = "v5/ins-loan/ensure-tokens";
    protected const string v5InsLoanLoanOrderEndpoint = "v5/ins-loan/loan-order";
    protected const string v5InsLoanRepaidHistoryEndpoint = "v5/ins-loan/repaid-history";
    protected const string v5InsLoanLtvEndpoint = "v5/ins-loan/ltv";

    // Internal
    internal BaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitInstitutionalLendingRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    public async Task<RestCallResult<IEnumerable<BybitLendingProduct>>> GetLendingProductsAsync(string productId = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("productId", productId);

        var result = await MainClient.SendBybitRequest<BybitLendingProductContainer>(MainClient.GetUri(v5InsLoanProductInfosEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLendingProduct>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitLendingToken>>> GetLendingTokensAsync(string token = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("ltCoin", token);

        var result = await MainClient.SendBybitRequest<BybitLendingTokenContainer>(MainClient.GetUri(v5InsLoanEnsureTokensEndpoint), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLendingToken>>(null);
        return result.As(result.Data.Payload);
    }

    // TODO: Get Margin Coin Info With Conversion Rate

    public async Task<RestCallResult<IEnumerable<BybitLendingLoanOrder>>> GetLoanOrdersAsync(string orderId=null, long? startTime=null, long? endTime= null, int? limit=null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("orderId", orderId);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitLendingLoanOrderContainer>(MainClient.GetUri(v5InsLoanLoanOrderEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLendingLoanOrder>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult<IEnumerable<BybitLendingRepayOrder>>> GetRepayOrdersAsync(long? startTime = null, long? endTime = null, int? limit = null, CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 100);

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);

        var result = await MainClient.SendBybitRequest<BybitLendingRepayOrderContainer>(MainClient.GetUri(v5InsLoanRepaidHistoryEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLendingRepayOrder>>(null);
        return result.As(result.Data.Payload);
    }

    // LTV: Customer Lifetime Value
    public async Task<RestCallResult<IEnumerable<BybitLendingLifetimeValue>>> GetCustomerLifetimeValueAsync(CancellationToken ct = default)
    {
        var result = await MainClient.SendBybitRequest<BybitLendingLifetimeValueContainer>(MainClient.GetUri(v5InsLoanLtvEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitLendingLifetimeValue>>(null);
        return result.As(result.Data.Payload);
    }

    // TODO: Get LTV with Ladder Conversion Rate
}