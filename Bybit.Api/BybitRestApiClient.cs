namespace Bybit.Api;

public sealed class BybitRestApiClient
{
    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }
    internal CultureInfo CI { get; } = CultureInfo.InvariantCulture;

    // Section Clients
    internal BybitServerRestApiClient Server { get; }
    public BybitUserRestApiClient User { get; }
    public BybitWalletRestApiClient Wallet { get; }
    public BybitMarketRestApiClient Market { get; }
    public BybitTradingRestApiClient Trading { get; }
    public BybitLeveragedTokensRestApiClient LeveragedTokens { get; }
    public BybitUnifiedMarginRestApiClient UnifiedMargin { get; }
    public BybitNormalMarginRestApiClient NormalMargin { get; }
    public BybitLendingRestApiClient Lending { get; }

    public BybitRestApiClient() : this(new BybitRestApiClientOptions())
    {
    }

    public BybitRestApiClient(BybitRestApiClientOptions options)
    {
        this.ClientOptions = options;
        this.MainClient = new BybitBaseRestApiClient(this);

        this.Server = new BybitServerRestApiClient(this);
        this.User = new BybitUserRestApiClient(this);
        this.Wallet = new BybitWalletRestApiClient(this);
        this.Market = new BybitMarketRestApiClient(this);
        this.Trading = new BybitTradingRestApiClient(this);
        this.LeveragedTokens = new BybitLeveragedTokensRestApiClient(this);
        this.UnifiedMargin = new BybitUnifiedMarginRestApiClient(this);
        this.NormalMargin = new BybitNormalMarginRestApiClient(this);
        this.Lending = new BybitLendingRestApiClient(this);
    }

    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="credentials">API Credentials Object</param>
    public void SetApiCredentials(ApiCredentials credentials)
    {
        this.MainClient.SetApiCredentials(credentials);
    }

    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="apiKey">The api key</param>
    /// <param name="apiSecret">The api secret</param>
    public void SetApiCredentials(string apiKey, string apiSecret)
    {
        this.SetApiCredentials(new ApiCredentials(apiKey, apiSecret));
    }
}
