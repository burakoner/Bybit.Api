namespace Bybit.Api;

public sealed class BybitRestApiClient
{
    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }
    internal CultureInfo CI { get; } = CultureInfo.InvariantCulture;

    // Section Clients
    public BybitMarketRestApiClient Market { get; }
    public BybitTradeRestApiClient Trade { get; }
    public BybitPositionRestApiClient Position { get; }
    public BybitAccountRestApiClient Account { get; }
    public BybitAssetRestApiClient Asset { get; }
    public BybitUserRestApiClient User { get; }
    internal BybitServerRestApiClient Server { get; }

    public BybitRestApiClient() : this(new BybitRestApiClientOptions())
    {
    }

    public BybitRestApiClient(BybitRestApiClientOptions options)
    {
        this.ClientOptions = options;
        this.MainClient = new BybitBaseRestApiClient(this);

        Market = new BybitMarketRestApiClient(this);
        Trade = new BybitTradeRestApiClient(this);
        Position = new BybitPositionRestApiClient(this);
        Account = new BybitAccountRestApiClient(this);
        Asset = new BybitAssetRestApiClient(this);
        User = new BybitUserRestApiClient(this);
        Server = new  BybitServerRestApiClient(this);
    }

    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="credentials">API Credentials Object</param>
    public void SetApiCredentials(ApiCredentials credentials)
    {
        MainClient.SetApiCredentials(credentials);
    }

    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="apiKey">The api key</param>
    /// <param name="apiSecret">The api secret</param>
    public void SetApiCredentials(string apiKey, string apiSecret)
    {
        SetApiCredentials(new ApiCredentials(apiKey, apiSecret));
    }
}
