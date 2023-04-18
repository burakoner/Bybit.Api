namespace Bybit.Api.Clients.RestApi;

public class BybitAccountRestApiClient
{
    // Internal
    internal BybitRestApiClient RootClient { get; }
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return RootClient.CI; } }

    internal BybitAccountRestApiClient(BybitRestApiClient root)
    {
        this.RootClient = root;
        this.MainClient = root.MainClient;
    }
}