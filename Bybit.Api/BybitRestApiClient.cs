namespace Bybit.Api;

/// <summary>
/// Bybit Rest API Client
/// </summary>
public class BybitRestApiClient
{
    // Internal
    internal ILogger Logger { get; }
    internal BybitRestApiBaseClient BaseClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }

    /// <summary>
    /// Market Client
    /// </summary>
    public BybitRestApiMarketClient Market { get; }

    /// <summary>
    /// Trade Client
    /// </summary>
    public BybitRestApiTradeClient Trade { get; }

    /// <summary>
    /// Position Client
    /// </summary>
    public BybitRestApiPositionClient Position { get; }

    // TODO: Pre-Upgrade

    /// <summary>
    /// Account Client
    /// </summary>
    public BybitRestApiAccountClient Account { get; }

    /// <summary>
    /// Asset Client
    /// </summary>
    public BybitRestApiAssetClient Asset { get; }

    /// <summary>
    /// User Client
    /// </summary>
    public BybitRestApiUserClient User { get; }

    /// <summary>
    /// Leveraged Tokens Client
    /// </summary>
    public BybitRestApiLeveragedTokensClient LeveragedTokens { get; }

    /// <summary>
    /// Margin Client
    /// </summary>
    public BybitRestApiMarginClient Margin { get; }

    /// <summary>
    /// Lending Client
    /// </summary>
    public BybitRestApiLendingClient Lending { get; }

    // TODO: Broker

    /// <summary>
    /// Create a new instance of the Bybit Rest API Client
    /// </summary>
    public BybitRestApiClient() : this(null, new BybitRestApiClientOptions())
    {
    }

    /// <summary>
    /// Create a new instance of the Bybit Rest API Client
    /// </summary>
    /// <param name="options"></param>
    public BybitRestApiClient(BybitRestApiClientOptions options) : this(null, options)
    {
    }

    /// <summary>
    /// Create a new instance of the Bybit Rest API Client
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="options"></param>
    public BybitRestApiClient(ILogger logger, BybitRestApiClientOptions options)
    {
        this.Logger = logger;
        this.ClientOptions = options;
        this.BaseClient = new BybitRestApiBaseClient(this);

        this.Market = new BybitRestApiMarketClient(this);
        this.Trade = new BybitRestApiTradeClient(this);
        this.Position = new BybitRestApiPositionClient(this);
        this.Account = new BybitRestApiAccountClient(this);
        this.Asset = new BybitRestApiAssetClient(this);
        this.User = new BybitRestApiUserClient(this);
        this.LeveragedTokens = new BybitRestApiLeveragedTokensClient(this);
        this.Margin = new BybitRestApiMarginClient(this);
        this.Lending = new BybitRestApiLendingClient(this);
    }

    /// <summary>
    /// Set the API Credentials
    /// </summary>
    /// <param name="credentials"></param>
    public void SetApiCredentials(ApiCredentials credentials)
        => this.BaseClient.SetApiCredentials(credentials);

    /// <summary>
    /// Set the API Credentials
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="apiSecret"></param>
    public void SetApiCredentials(string apiKey, string apiSecret)
        => this.SetApiCredentials(new ApiCredentials(apiKey, apiSecret));
}
