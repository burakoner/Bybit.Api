using Bybit.Api.Models.User;

namespace Bybit.Api.Clients.RestApi;

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

    public async Task<BybitRestCallResult<BybitSubAccount>> CreateSubAccountAsync(BybitSubAccountType type, string username, string password = null, bool? quickLogin = null, string label = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "memberType", type.GetLabel() },
            { "username", username },
        };
        parameters.AddOptionalParameter("password", password);
        parameters.AddOptionalParameter("switch", quickLogin);
        parameters.AddOptionalParameter("note", label);

        return await MainClient.SendBybitRequest<BybitSubAccount>(MainClient.BuildUri(_v5UserCreateSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKey>> CreateSubAccountApiKeyAsync(long subuid, bool readOnly, BybitApiKeyPermissions permissions, string label = null, IEnumerable<string> ips = null, CancellationToken ct = default)
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

    public async Task<BybitRestCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitSubAccount>>(MainClient.BuildUri(_v5UserQuerySubMembers), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSubAccount>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<BybitRestCallResult> FreezeSubAccountAsync(long subuid, bool frozen, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subuid", subuid },
            { "frozen", frozen ? 1 : 0 },
        };
        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserFrozenSubMember), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKeyInformation>> GetApiKeyInformationAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitApiKeyInformation>(MainClient.BuildUri(_v5UserQueryApi), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKey>> ModifyMainAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(_v5UserUpdateApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKey>> ModifySubAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(_v5UserUpdateSubApi), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult> DeleteMainAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserDeleteApi), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult> DeleteSubAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5UserDeleteSubApi), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

}