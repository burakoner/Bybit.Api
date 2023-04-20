using Bybit.Api.Models.User;

namespace Bybit.Api.Clients.RestApi;

public class BybitUserRestApiClient
{
    // User Endpoints
    protected const string v5UserCreateSubMemberEndpoint = "v5/user/create-sub-member";
    protected const string v5UserCreateSubApiEndpoint = "v5/user/create-sub-api";
    protected const string v5UserQuerySubMembersEndpoint = "v5/user/query-sub-members";
    protected const string v5UserFrozenSubMemberEndpoint = "v5/user/frozen-sub-member";
    protected const string v5UserQueryApiEndpoint = "v5/user/query-api";
    protected const string v5UserUpdateApiEndpoint = "v5/user/update-api";
    protected const string v5UserUpdateSubApiEndpoint = "v5/user/update-sub-api";
    protected const string v5UserDeleteApiEndpoint = "v5/user/delete-api";
    protected const string v5UserDeleteSubApiEndpoint = "v5/user/delete-sub-api";

    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitUserRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    public async Task<RestCallResult<BybitSubAccount>> CreateSubAccountAsync(BybitSubAccountType type, string username, string password = null, bool? quickLogin = null, string label = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "memberType", type.GetLabel() },
            { "username", username },
        };
        parameters.AddOptionalParameter("password", password);
        parameters.AddOptionalParameter("switch", quickLogin);
        parameters.AddOptionalParameter("note", label);

        return await MainClient.SendBybitRequest<BybitSubAccount>(MainClient.GetUri(v5UserCreateSubMemberEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitApiKey>> CreateSubAccountApiKeyAsync(long subuid, bool readOnly, BybitApiKeyPermissions permissions, string label = null, IEnumerable<string> ips=null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subuid", subuid },
            { "readOnly", readOnly ? 1 : 0 },
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("note", label);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.GetUri(v5UserCreateSubApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<IEnumerable<BybitSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitSubAccount>>(MainClient.GetUri(v5UserQuerySubMembersEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitSubAccount>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult> FreezeSubAccountAsync(long subuid, bool frozen, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "subuid", subuid },
            { "frozen", frozen ? 1 : 0 },
        };
        return await MainClient.SendBybitRequest(MainClient.GetUri(v5UserFrozenSubMemberEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitApiKeyInformation>> GetApiKeyInformationAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitApiKeyInformation>(MainClient.GetUri(v5UserQueryApiEndpoint), HttpMethod.Get, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitApiKey>> ModifyMainAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.GetUri(v5UserUpdateApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitApiKey>> ModifySubAccountApiKeyAsync(BybitApiKeyPermissions permissions, bool? readOnly = null, IEnumerable<string> ips = null, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "permissions", permissions },
        };
        parameters.AddOptionalParameter("readOnly", readOnly);
        parameters.AddOptionalParameter("ips", ips);

        return await MainClient.SendBybitRequest<BybitApiKey>(MainClient.GetUri(v5UserUpdateSubApiEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> DeleteMainAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.GetUri(v5UserDeleteApiEndpoint), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

    public async Task<RestCallResult> DeleteSubAccountApiKeyAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest(MainClient.GetUri(v5UserDeleteSubApiEndpoint), HttpMethod.Post, ct, true).ConfigureAwait(false);
    }

}