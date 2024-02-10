namespace Bybit.Api;

public sealed class BybitRestApiClient
{
    // Internal
    internal ILogger Logger { get; }
    internal BaseRestApiClient MainClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }
    internal CultureInfo CI { get; } = CultureInfo.InvariantCulture;

    // Section Clients
    internal BybitServerRestApiClient Server { get; }
    public BybitMarketRestApiClient Market { get; }
    public BybitTradeRestApiClient Trade { get; }
    public BybitPositionRestApiClient Position { get; }
    // TODO: Pre-Upgrade
    public BybitAccountRestApiClient Account { get; }
    public BybitAssetRestApiClient Asset { get; }
    public BybitUserRestApiClient User { get; }
    public BybitLeveragedTokensRestApiClient LeveragedTokens { get; }
    public BybitUnifiedMarginRestApiClient UnifiedMargin { get; }
    public BybitNormalMarginRestApiClient NormalMargin { get; }
    public BybitInstitutionalLendingRestApiClient InstitutionalLending { get; }
    // TODO: C2C Lending

    public BybitRestApiClient() : this(null, new BybitRestApiClientOptions())
    {
    }

    public BybitRestApiClient(BybitRestApiClientOptions options) : this(null, options)
    {
    }

    public BybitRestApiClient(ILogger logger, BybitRestApiClientOptions options)
    {
        this.ClientOptions = options;
        this.MainClient = new BaseRestApiClient(this);

        this.Server = new BybitServerRestApiClient(this);
        this.User = new BybitUserRestApiClient(this);
        this.Account = new BybitAccountRestApiClient(this);
        this.Asset = new BybitAssetRestApiClient(this);
        this.Market = new BybitMarketRestApiClient(this);
        this.Trade = new BybitTradeRestApiClient(this);
        this.Position = new BybitPositionRestApiClient(this);
        this.LeveragedTokens = new BybitLeveragedTokensRestApiClient(this);
        this.UnifiedMargin = new BybitUnifiedMarginRestApiClient(this);
        this.NormalMargin = new BybitNormalMarginRestApiClient(this);
        this.InstitutionalLending = new BybitInstitutionalLendingRestApiClient(this);
    }

    public void SetApiCredentials(ApiCredentials credentials)
        => this.MainClient.SetApiCredentials(credentials);

    public void SetApiCredentials(string apiKey, string apiSecret)
        => this.SetApiCredentials(new ApiCredentials(apiKey, apiSecret));
}
