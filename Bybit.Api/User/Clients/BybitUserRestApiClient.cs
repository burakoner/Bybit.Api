namespace Bybit.Api.User;

/// <summary>
/// Bybit Rest API User Client
/// </summary>
public class BybitUserRestApiClient
{
    // User Endpoints
    private const string _v5UserAgreement = "v5/user/agreement";
    private const string _v5UserCreateSubMember = "v5/user/create-sub-member";
    private const string _v5UserCreateSubApi = "v5/user/create-sub-api";
    private const string _v5UserQuerySubMembers = "v5/user/query-sub-members";
    private const string _v5UserSubMembers = "v5/user/submembers";
    private const string _v5UserEscrowSubMembers = "v5/user/escrow_sub_members";
    private const string _v5UserFrozenSubMember = "v5/user/frozen-sub-member";
    private const string _v5UserQueryApi = "v5/user/query-api";
    private const string _v5UserSubApikeys = "v5/user/sub-apikeys";
    private const string _v5UserGetMemberType = "v5/user/get-member-type";
    private const string _v5UserUpdateApi = "v5/user/update-api";
    private const string _v5UserUpdateSubApi = "v5/user/update-sub-api";
    private const string _v5UserDelSubMember = "v5/user/del-submember";
    private const string _v5UserDeleteApi = "v5/user/delete-api";
    private const string _v5UserDeleteSubApi = "v5/user/delete-sub-api";
    private const string _v5UserInvitationReferrals = "v5/user/invitation/referrals";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitUserRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    #region Helpers
    private static int? ToInt(bool? value)
    {
        return value.HasValue ? value.Value ? 1 : 0 : null;
    }

    private static string? ToIpString(IEnumerable<string>? ips)
    {
        if (ips == null)
            return null;

        return string.Join(",", ips);
    }

    private static ParameterCollection GetModifyApiKeyParameters(BybitUserModifyApiKeyRequest request, bool includeIpAddresses)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("permissions", request.Permissions);
        parameters.AddOptional("readOnly", ToInt(request.ReadOnly));
        if (includeIpAddresses)
            parameters.AddOptional("ips", request.IpAddresses);

        return parameters;
    }
    #endregion

    /// <summary>
    /// Sign commodity trading agreement.
    /// </summary>
    /// <param name="category">Deprecated agreement category</param>
    /// <param name="categoryV2">Agreement category</param>
    /// <param name="agree">Agreement flag. Must be true</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult> SignAgreementAsync(int? category = null, int? categoryV2 = null, bool agree = true, CancellationToken ct = default)
    {
        return SignAgreementAsync(new BybitUserSignAgreementRequest(agree)
        {
            Category = category,
            CategoryV2 = categoryV2,
        }, ct);
    }

    /// <summary>
    /// Sign commodity trading agreement.
    /// </summary>
    /// <param name="request">Agreement request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SignAgreementAsync(BybitUserSignAgreementRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection()
        {
            { "agree", request.Agree },
        };
        parameters.AddOptional("category", request.Category);
        parameters.AddOptional("categoryV2", request.CategoryV2);

        return await _.SendBybitRequest(_.BuildUri(_v5UserAgreement), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Create a new sub user id. Use master account's api key.
    /// </summary>
    /// <param name="type">1: normal sub account, 6: custodial sub account</param>
    /// <param name="username">Give a username of the new sub user id.
    /// 6-16 characters, must include both numbers and letters.
    /// cannot be the same as the exist or deleted one.</param>
    /// <param name="password">Give a username of the new sub user id.
    /// 6-16 characters, must include both numbers and letters.
    /// cannot be the same as the exist or deleted one.</param>
    /// <param name="quickLogin">
    /// 0: turn off quick login (default)
    /// 1: turn on quick login.
    /// false(default): create classic account</param>
    /// <param name="label">Set a remark</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserSubAccount>> CreateSubAccountAsync(
        BybitSubAccountType type, 
        string username, 
        string? password = null,
        bool? quickLogin = null, 
        string? label = null, 
        CancellationToken ct = default)
    {
        return await CreateSubAccountAsync(new BybitUserCreateSubAccountRequest(type, username)
        {
            Password = password,
            QuickLogin = quickLogin,
            Label = label,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Create a new sub user id. Use master account's api key.
    /// </summary>
    /// <param name="request">Create sub account request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserSubAccount>> CreateSubAccountAsync(BybitUserCreateSubAccountRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("memberType", request.Type);
        parameters.Add("username", request.Username);
        parameters.AddOptional("password", request.Password);
        parameters.AddOptional("switch", ToInt(request.QuickLogin));
        parameters.AddOptional("note", request.Label);

        return await _.SendBybitRequest<BybitUserSubAccount>(_.BuildUri(_v5UserCreateSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// To create new API key for those newly created sub UID. Use master user's api key only.
    /// </summary>
    /// <param name="subuid">Sub user Id</param>
    /// <param name="readOnly">0：Read and Write. 1：Read only</param>
    /// <param name="permissions">Tick the types of permission.
    /// one of below types must be passed, otherwise the error is thrown</param>
    /// <param name="ips">Set the IP bind. example: "192.168.0.1,192.168.0.2"note:
    /// don't pass ips or pass with "*" means no bind
    /// No ip bound api key will be invalid after 90 days
    /// api key without IP bound will be invalid after 7 days once the account password is changed</param>
    /// <param name="label">Set a remark</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> CreateSubAccountApiKeyAsync(
        long subuid,
        bool readOnly,
        BybitUserApiKeyPermissions permissions,
        IEnumerable<string>? ips = null,
        string? label = null,
        CancellationToken ct = default)
    {
        return await CreateSubAccountApiKeyAsync(new BybitUserCreateSubApiKeyRequest(subuid, readOnly, permissions)
        {
            IpAddresses = ToIpString(ips),
            Label = label,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// To create new API key for those newly created sub UID. Use master user's api key only.
    /// </summary>
    /// <param name="request">Create sub account API key request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> CreateSubAccountApiKeyAsync(BybitUserCreateSubApiKeyRequest request, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subuid", request.SubUserId },
            { "readOnly", request.ReadOnly ? 1 : 0 },
            { "permissions", request.Permissions },
        };
        parameters.AddOptional("note", request.Label);
        parameters.AddOptional("ips", request.IpAddresses);

        return await _.SendBybitRequest<BybitUserApiKey>(_.BuildUri(_v5UserCreateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Sub UID List (Limited)
    /// Get at most 10k sub UID of master account. Use master user's api key only.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await _.SendBybitRequest<BybitListResponse<BybitUserSubAccount>>(_.BuildUri(_v5UserQuerySubMembers), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserSubAccount>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get Sub UID List (Unlimited)
    /// This API is applicable to the client who has over 10k sub accounts. Use master user's api key only.
    /// </summary>
    /// <param name="pageSize">Data size per page. Return up to 100 records per request</param>
    /// <param name="cursor">Cursor. Use the nextCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetSubAccountsAsync(int pageSize, string? cursor = null, CancellationToken ct = default)
    {
        return await GetSubAccountsAsync(new BybitUserSubAccountListRequest
        {
            PageSize = pageSize,
            Cursor = cursor,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Sub UID List (Unlimited)
    /// </summary>
    /// <param name="request">Paged sub account list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetSubAccountsAsync(BybitUserSubAccountListRequest request, CancellationToken ct = default)
    {
        request.PageSize?.ValidateIntBetween(nameof(request.PageSize), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("pageSize", request.PageSize);
        parameters.AddOptional("nextCursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserSubAccount>>(_.BuildUri(_v5UserSubMembers), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserSubAccount>>(default!);
        return result.As(result.Data.Payload, result.Data.NextCursor);
    }

    /// <summary>
    /// Get fund custodial sub accounts.
    /// </summary>
    /// <param name="pageSize">Data size per page. Return up to 100 records per request</param>
    /// <param name="cursor">Cursor. Use the nextCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetFundCustodialSubAccountsAsync(int? pageSize = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFundCustodialSubAccountsAsync(new BybitUserSubAccountListRequest
        {
            PageSize = pageSize,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get fund custodial sub accounts.
    /// </summary>
    /// <param name="request">Paged sub account list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetFundCustodialSubAccountsAsync(BybitUserSubAccountListRequest request, CancellationToken ct = default)
    {
        request.PageSize?.ValidateIntBetween(nameof(request.PageSize), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("pageSize", request.PageSize);
        parameters.AddOptional("nextCursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserSubAccount>>(_.BuildUri(_v5UserEscrowSubMembers), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserSubAccount>>(default!);
        return result.As(result.Data.Payload, result.Data.NextCursor);
    }

    /// <summary>
    /// Freeze Sub UID. Use master user's api key only.
    /// </summary>
    /// <param name="subuid">Sub user Id</param>
    /// <param name="frozen">0：unfreeze, 1：freeze</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> FreezeSubAccountAsync(long subuid, bool frozen, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subuid", subuid },
            { "frozen", frozen ? 1 : 0 },
        };
        return await _.SendBybitRequest(_.BuildUri(_v5UserFrozenSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get the information of the api key. Use the api key pending to be checked to call the endpoint. Both master and sub user's api key are applicable.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKeyInformation>> GetApiKeyInformationAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest<BybitUserApiKeyInformation>(_.BuildUri(_v5UserQueryApi), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Query all api keys information of a sub UID.
    /// </summary>
    /// <param name="subMemberId">Sub UID</param>
    /// <param name="limit">Limit for data size per page. [1, 20]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitUserApiKey>>> GetSubAccountApiKeysAsync(string subMemberId, int? limit = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetSubAccountApiKeysAsync(new BybitUserSubApiKeysRequest(subMemberId)
        {
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Query all api keys information of a sub UID.
    /// </summary>
    /// <param name="request">Sub account API key list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserApiKey>>> GetSubAccountApiKeysAsync(BybitUserSubApiKeysRequest request, CancellationToken ct = default)
    {
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 20);
        var parameters = new ParameterCollection
        {
            { "subMemberId", request.SubMemberId },
        };
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserApiKey>>(_.BuildUri(_v5UserSubApikeys), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserApiKey>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Get available wallet types for the master account or sub account.
    /// </summary>
    /// <param name="memberIds">UIDs separated by comma</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserWalletType>>> GetWalletTypesAsync(string? memberIds = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("memberIds", memberIds);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserWalletType>>(_.BuildUri(_v5UserGetMemberType), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserWalletType>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Modify the settings of master api key. Use the api key pending to be modified to call the endpoint. Use master user's api key only.
    /// </summary>
    /// <param name="permissions">Tick the types of permission. Don't send this param if you don't want to change the permission</param>
    /// <param name="readOnly">0 (default)：Read and Write. 1：Read only</param>
    /// <param name="ips">Set the IP bind. example: "192.168.0.1,192.168.0.2"note:
    /// don't pass ips or pass with "*" means no bind
    /// No ip bound api key will be invalid after 90 days
    /// api key will be invalid after 7 days once the account password is changed</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> ModifyMasterAccountApiKeyAsync(
        BybitUserApiKeyPermissions permissions,
        bool? readOnly = null,
        IEnumerable<string>? ips = null,
        CancellationToken ct = default)
    {
        return await ModifyMasterAccountApiKeyAsync(new BybitUserModifyApiKeyRequest
        {
            Permissions = permissions,
            ReadOnly = readOnly,
            IpAddresses = ToIpString(ips),
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Modify the settings of master api key.
    /// </summary>
    /// <param name="request">Modify API key request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> ModifyMasterAccountApiKeyAsync(BybitUserModifyApiKeyRequest request, CancellationToken ct = default)
    {
        var parameters = GetModifyApiKeyParameters(request, false);

        return await _.SendBybitRequest<BybitUserApiKey>(_.BuildUri(_v5UserUpdateApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Modify the settings of sub api key. Use the sub account api key pending to be modified to call the endpoint or use master account api key to manage its sub account api key.
    /// </summary>
    /// <param name="permissions">Tick the types of permission. Don't send this param if you don't want to change the permission</param>
    /// <param name="readOnly">0 (default)：Read and Write. 1：Read only</param>
    /// <param name="ips">Set the IP bind. example: "192.168.0.1,192.168.0.2"note:
    /// don't pass ips or pass with "*" means no bind
    /// No ip bound api key will be invalid after 90 days
    /// api key will be invalid after 7 days once the account password is changed</param>
    /// <param name="apikey">Sub account api key
    /// You must pass this param when you use master account manage sub account api key settings
    /// If you use corresponding sub uid api key call this endpoint, apikey param cannot be passed, otherwise throwing an error</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> ModifySubAccountApiKeyAsync(
        BybitUserApiKeyPermissions permissions,
        bool? readOnly = null,
        IEnumerable<string>? ips = null,
        string? apikey = null,
        CancellationToken ct = default)
    {
        return await ModifySubAccountApiKeyAsync(new BybitUserModifySubApiKeyRequest
        {
            Permissions = permissions,
            ReadOnly = readOnly,
            IpAddresses = ToIpString(ips),
            ApiKey = apikey,
        }, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Modify the settings of sub api key.
    /// </summary>
    /// <param name="request">Modify sub account API key request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserApiKey>> ModifySubAccountApiKeyAsync(BybitUserModifySubApiKeyRequest request, CancellationToken ct = default)
    {
        var parameters = GetModifyApiKeyParameters(request, true);
        parameters.AddOptional("apikey", request.ApiKey);

        return await _.SendBybitRequest<BybitUserApiKey>(_.BuildUri(_v5UserUpdateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a sub UID.
    /// </summary>
    /// <param name="subMemberId">Sub UID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> DeleteSubAccountAsync(string subMemberId, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subMemberId", subMemberId },
        };

        return await _.SendBybitRequest(_.BuildUri(_v5UserDelSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the api key of master account. Use the api key pending to be delete to call the endpoint. Use master user's api key only.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> DeleteMasterAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await _.SendBybitRequest(_.BuildUri(_v5UserDeleteApi), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the api key of sub account. Use the sub api key pending to be delete to call the endpoint or use the master api key to delete corresponding sub account api key
    /// </summary>
    /// <param name="apikey">Sub account api key
    /// You must pass this param when you use master account manage sub account api key settings
    /// If you use corresponding sub uid api key call this endpoint, apikey param cannot be passed, otherwise throwing an error</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> DeleteSubAccountApiKeyAsync(string? apikey = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("apikey", apikey);

        return await _.SendBybitRequest(_.BuildUri(_v5UserDeleteSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get friend referrals.
    /// </summary>
    /// <param name="status">Invitation relationship status. 0: alive, 1: invalid</param>
    /// <param name="size">Data size per page. [1, 100]. Default: 20</param>
    /// <param name="cursor">Cursor. Use the nextCursor token from the response to retrieve the next page of the result set</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<BybitRestCallResult<List<BybitUserFriendReferral>>> GetFriendReferralsAsync(int? status = null, int? size = null, string? cursor = null, CancellationToken ct = default)
    {
        return GetFriendReferralsAsync(new BybitUserFriendReferralRequest
        {
            Status = status,
            Size = size,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get friend referrals.
    /// </summary>
    /// <param name="request">Friend referral list request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitUserFriendReferral>>> GetFriendReferralsAsync(BybitUserFriendReferralRequest request, CancellationToken ct = default)
    {
        request.Size?.ValidateIntBetween(nameof(request.Size), 1, 100);
        var parameters = new ParameterCollection();
        parameters.AddOptional("status", request.Status);
        parameters.AddOptional("size", request.Size);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserFriendReferral>>(_.BuildUri(_v5UserInvitationReferrals), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserFriendReferral>>(default!);
        return result.As(result.Data.Payload, result.Data.NextCursor);
    }

}
