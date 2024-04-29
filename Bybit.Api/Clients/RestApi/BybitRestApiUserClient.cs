using Bybit.Api.Models.User;

namespace Bybit.Api.Clients.RestApi;

public class BybitRestApiUserClient
{
    // User Endpoints
    protected const string v5UserCreateSubMemberEndpoint = "v5/user/create-sub-member";
    protected const string v5UserCreateSubApiEndpoint = "v5/user/create-sub-api";
    protected const string v5UserQuerySubMembersEndpoint = "v5/user/query-sub-members";
    protected const string v5UserSubMembersEndpoint = "v5/user/submembers"; // TODO
    protected const string v5UserFrozenSubMemberEndpoint = "v5/user/frozen-sub-member";
    protected const string v5UserQueryApiEndpoint = "v5/user/query-api";
    protected const string v5UserSubApikeysEndpoint = "v5/user/sub-apikeys"; // TODO
    protected const string v5UserGetMemberTypeEndpoint = "v5/user/get-member-type"; // TODO
    protected const string v5UserUpdateApiEndpoint = "v5/user/update-api";
    protected const string v5UserUpdateSubApiEndpoint = "v5/user/update-sub-api";
    protected const string v5UserDelSubMemberEndpoint = "v5/user/del-submember"; // TODO
    protected const string v5UserDeleteApiEndpoint = "v5/user/delete-api";
    protected const string v5UserDeleteSubApiEndpoint = "v5/user/delete-sub-api";
    protected const string v5UserAffCustomerInfoEndpoint = "v5/user/aff-customer-info"; // TODO

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

        return await MainClient.SendBybitRequest<BybitSubAccount>(MainClient.BuildUri(v5UserCreateSubMemberEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
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

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(v5UserCreateSubApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<List<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await MainClient.SendBybitRequest<BybitUnifiedResponse<BybitSubAccount>>(MainClient.BuildUri(v5UserQuerySubMembersEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
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
        return await MainClient.SendBybitRequest(MainClient.BuildUri(v5UserFrozenSubMemberEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKeyInformation>> GetApiKeyInformationAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitApiKeyInformation>(MainClient.BuildUri(v5UserQueryApiEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKey>> ModifyMainAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(v5UserUpdateApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult<BybitApiKey>> ModifySubAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.BuildUri(v5UserUpdateSubApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult> DeleteMainAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.BuildUri(v5UserDeleteApiEndpoint), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult> DeleteSubAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.BuildUri(v5UserDeleteSubApiEndpoint), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

}