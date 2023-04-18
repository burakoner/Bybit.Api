using Bybit.Api.Models.Server;

namespace Bybit.Api.Clients.RestApi;

public class BybitServerRestApiClient
{
    // Endpoints
    protected string v3PublicTimeEndpoint = "v3/public/time";

    // Internal
    internal BybitRestApiClient RootClient { get; }
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return RootClient.CI; } }

    internal BybitServerRestApiClient(BybitRestApiClient root)
    {
        this.RootClient = root;
        this.MainClient = root.MainClient;
    }

    public virtual async Task<RestCallResult<BybitServerTime>> GetServerTimeAsync(CancellationToken ct = default)
    {
        return await MainClient.SendBybitRequest<BybitServerTime>(MainClient.GetUri(v3PublicTimeEndpoint), HttpMethod.Get, ct).ConfigureAwait(false);
    }
}