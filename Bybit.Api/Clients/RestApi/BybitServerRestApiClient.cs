using Bybit.Api.Models.Server;

namespace Bybit.Api.Clients.RestApi;

public class BybitServerRestApiClient
{
    // Endpoints
    protected const string v3PublicTimeEndpoint = "v3/public/time";

    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitServerRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    public virtual async Task<RestCallResult<BybitServerTime>> GetServerTimeAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitServerTime>(MainClient.GetUri(v3PublicTimeEndpoint), HttpMethod.Get, ct).ConfigureAwait(false);
    }
}