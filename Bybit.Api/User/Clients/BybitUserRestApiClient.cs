namespace Bybit.Api.User;

/// <summary>
/// Bybit Rest API User Client
/// </summary>
public class BybitUserRestApiClient
{
    // User Endpoints
    private const string _v5UserCreateSubMember = "v5/user/create-sub-member";
    private const string _v5UserCreateSubApi = "v5/user/create-sub-api";
    private const string _v5UserQuerySubMembers = "v5/user/query-sub-members";
    private const string _v5UserSubMembers = "v5/user/submembers"; // TODO
    private const string _v5UserFrozenSubMember = "v5/user/frozen-sub-member";
    private const string _v5UserQueryApi = "v5/user/query-api";
    private const string _v5UserSubApikeys = "v5/user/sub-apikeys"; // TODO
    private const string _v5UserGetMemberType = "v5/user/get-member-type"; // TODO
    private const string _v5UserUpdateApi = "v5/user/update-api";
    private const string _v5UserUpdateSubApi = "v5/user/update-sub-api";
    private const string _v5UserDelSubMember = "v5/user/del-submember"; // TODO
    private const string _v5UserDeleteApi = "v5/user/delete-api";
    private const string _v5UserDeleteSubApi = "v5/user/delete-sub-api";
    private const string _v5UserAffCustomerInfo = "v5/user/aff-customer-info"; // TODO

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitUserRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

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
    /// 1: turn on quick login.</param>
    /// false(default): create classic account</param>
    /// <param name="label">Set a remark</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitUserSubAccount>> CreateSubAccountAsync(
        BybitSubAccountType type, 
        string username, 
        string password = null,
        bool? quickLogin = null, 
        string label = null, 
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("memberType", type);
        parameters.Add("username", username);
        parameters.AddOptional("password", password);
        parameters.AddOptional("switch", quickLogin.HasValue && quickLogin.Value ? "1" : "0");
        parameters.AddOptional("note", label);

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
        IEnumerable<string> ips = null,
        string label = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subuid", subuid },
            { "readOnly", readOnly ? 1 : 0 },
            { "permissions", permissions },
        };
        parameters.AddOptional("note", label);
        parameters.AddOptional("ips", ips);

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
        if (!result) return result.As<List<BybitUserSubAccount>>(null);
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
    public async Task<BybitRestCallResult<List<BybitUserSubAccount>>> GetSubAccountsAsync(int pageSize, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("pageSize", pageSize);
        parameters.AddOptional("nextCursor", cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitUserSubAccount>>(_.BuildUri(_v5UserSubMembers), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitUserSubAccount>>(null);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
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
        IEnumerable<string> ips = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "permissions", permissions },
        };
        parameters.AddOptional("readOnly", readOnly);
        parameters.AddOptional("ips", ips);

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
        IEnumerable<string> ips = null,
        string apikey = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "permissions", permissions },
        };
        parameters.AddOptional("readOnly", readOnly.HasValue && readOnly.Value ? 1 : 0);
        parameters.AddOptional("ips", ips);

        return await _.SendBybitRequest<BybitUserApiKey>(_.BuildUri(_v5UserUpdateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult> DeleteSubAccountApiKeyAsync(string apikey = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("apikey", apikey);

        return await _.SendBybitRequest(_.BuildUri(_v5UserDeleteSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}