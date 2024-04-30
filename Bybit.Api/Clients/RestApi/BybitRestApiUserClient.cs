using Bybit.Api.Models.User;
using System.Diagnostics.Metrics;
using System.Net;
using System;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Rest API User Client
/// </summary>
public class BybitRestApiUserClient
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
    internal BybitRestApiBaseClient MainClient { get; }
    internal BybitRestApiUserClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
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
    /// <param name="isUta">true: create UTA account
    /// false(default): create classic account</param>
    /// <param name="label">Set a remark</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSubAccount>> CreateSubAccountAsync(BybitSubAccountType type, string username, string password = null,
        bool? quickLogin = null, bool? isUta = null, string label = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "memberType", type.GetLabel() },
            { "username", username },
        };
        parameters.AddOptionalParameter("password", password);
        parameters.AddOptionalParameter("switch", quickLogin.HasValue && quickLogin.Value ? "1" : "0");
        parameters.AddOptionalParameter("isUta", isUta);
        parameters.AddOptionalParameter("note", label);

        return await MainClient.SendBybitRequest<BybitSubAccount>(MainClient.BuildUri(_v5UserCreateSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult<BybitApiKey>> CreateSubAccountApiKeyAsync(long subuid,
        bool readOnly,
        BybitApiKeyPermissions permissions,
        IEnumerable<string> ips = null,
        string label = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subuid", subuid },
            { "readOnly", readOnly ? 1 : 0 },
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("note", label);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(_v5UserCreateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get Sub UID List (Limited)
    /// Get at most 10k sub UID of master account. Use master user's api key only.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitSubAccount>>(MainClient.BuildUri(_v5UserQuerySubMembers), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSubAccount>>(null);
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
    public async Task<BybitRestCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(int pageSize, string cursor = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("pageSize", pageSize);
        parameters.AddOptionalParameter("nextCursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitSubAccount>>(MainClient.BuildUri(_v5UserSubMembers), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSubAccount>>(null);
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
        var parameters = new Dictionary<string, object>
        {
            { "subuid", subuid },
            { "frozen", frozen ? 1 : 0 },
        };
        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserFrozenSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get the information of the api key. Use the api key pending to be checked to call the endpoint. Both master and sub user's api key are applicable.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitApiKeyInformation>> GetApiKeyInformationAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitApiKeyInformation>(MainClient.BuildUri(_v5UserQueryApi), HttpMethod.Get, ct, true).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult<BybitApiKey>> ModifyMasterAccountApiKeyAsync(
        BybitApiKeyPermissions permissions,
        bool? readOnly = null,
        IEnumerable<string> ips = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(_v5UserUpdateApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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
    public async Task<BybitRestCallResult<BybitApiKey>> ModifySubAccountApiKeyAsync(
        BybitApiKeyPermissions permissions,
        bool? readOnly = null,
        IEnumerable<string> ips = null,
        string apikey = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly.HasValue && readOnly.Value ? 1 : 0);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(_v5UserUpdateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the api key of master account. Use the api key pending to be delete to call the endpoint. Use master user's api key only.
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> DeleteMasterAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserDeleteApi), HttpMethod.Post, ct, true).ConfigureAwait(false);
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
        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("apikey", apikey);

        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserDeleteSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}