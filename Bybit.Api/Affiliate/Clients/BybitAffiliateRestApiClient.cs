namespace Bybit.Api.Affiliate;

/// <summary>
/// Bybit REST API Affiliate client.
/// </summary>
public class BybitAffiliateRestApiClient
{
    private const string _v5AffiliateUserList = "v5/affiliate/aff-user-list";
    private const string _v5AffiliateUserInfo = "v5/user/aff-customer-info";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitAffiliateRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Query affiliate user list.
    /// </summary>
    /// <param name="size">Data size per page. [0, 1000].</param>
    /// <param name="cursor">Pagination cursor.</param>
    /// <param name="needDeposit">Whether to return deposit info.</param>
    /// <param name="need30Day">Whether to return 30 day trading info.</param>
    /// <param name="need365Day">Whether to return 365 day trading info.</param>
    /// <param name="startDate">Start date of the query period. Format: YYYY-MM-DD.</param>
    /// <param name="endDate">End date of the query period. Format: YYYY-MM-DD.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitAffiliateUser>>> GetUsersAsync(int? size = null, string? cursor = null, bool? needDeposit = null, bool? need30Day = null, bool? need365Day = null, string? startDate = null, string? endDate = null, CancellationToken ct = default)
    {
        return GetUsersAsync(new BybitAffiliateUserListRequest
        {
            Size = size,
            Cursor = cursor,
            NeedDeposit = needDeposit,
            Need30Day = need30Day,
            Need365Day = need365Day,
            StartDate = startDate,
            EndDate = endDate,
        }, ct);
    }

    /// <summary>
    /// Query affiliate user list.
    /// </summary>
    /// <param name="request">Affiliate user list request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitAffiliateUser>>> GetUsersAsync(BybitAffiliateUserListRequest request, CancellationToken ct = default)
    {
        request.Size?.ValidateIntBetween(nameof(request.Size), 0, 1000);

        var parameters = new ParameterCollection();
        parameters.AddOptional("size", request.Size);
        parameters.AddOptional("cursor", request.Cursor);
        parameters.AddOptional("needDeposit", request.NeedDeposit);
        parameters.AddOptional("need30", request.Need30Day);
        parameters.AddOptional("need365", request.Need365Day);
        parameters.AddOptional("startDate", request.StartDate);
        parameters.AddOptional("endDate", request.EndDate);

        var result = await _.SendBybitRequest<BybitListResponse<BybitAffiliateUser>>(_.BuildUri(_v5AffiliateUserList), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitAffiliateUser>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query affiliate user information.
    /// </summary>
    /// <param name="uid">Affiliate client master account UID.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<BybitAffiliateUserInfo>> GetUserInfoAsync(long uid, CancellationToken ct = default)
        => GetUserInfoAsync(new BybitAffiliateUserInfoRequest(uid), ct);

    /// <summary>
    /// Query affiliate user information.
    /// </summary>
    /// <param name="request">Affiliate user info request.</param>
    /// <param name="ct">Cancellation Token.</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitAffiliateUserInfo>> GetUserInfoAsync(BybitAffiliateUserInfoRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "uid", request.Uid },
        };

        return await _.SendBybitRequest<BybitAffiliateUserInfo>(_.BuildUri(_v5AffiliateUserInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
}
