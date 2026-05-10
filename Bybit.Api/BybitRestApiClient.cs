using Bybit.Api.Account;
using Bybit.Api.Asset;
using Bybit.Api.Affiliate;
using Bybit.Api.Broker;
using Bybit.Api.CryptoLoan;
using Bybit.Api.InstitutionalLoan;
using Bybit.Api.Margin;
using Bybit.Api.Market;
using Bybit.Api.Trading;
using Bybit.Api.User;
using Bybit.Api.System;
using Bybit.Api.Position;
using Bybit.Api.Spread;
using Bybit.Api.Rfq;

namespace Bybit.Api;

/// <summary>
/// Bybit Rest API Client
/// </summary>
public class BybitRestApiClient
{
    // Internal
    internal ILogger? Logger { get; }
    internal BybitBaseRestApiClient BaseClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }

    /// <summary>
    /// System Client
    /// </summary>
    public BybitSystemRestApiClient System { get; }

    /// <summary>
    /// Market Client
    /// </summary>
    public BybitMarketRestApiClient Market { get; }

    /// <summary>
    /// Trade Client
    /// </summary>
    public BybitTradeRestApiClient Trade { get; }

    /// <summary>
    /// Position Client
    /// </summary>
    public BybitPositionRestApiClient Position { get; }

    // TODO: Pre-upgrade

    /// <summary>
    /// Account Client
    /// </summary>
    public BybitAccountRestApiClient Account { get; }

    /// <summary>
    /// Asset Client
    /// </summary>
    public BybitAssetRestApiClient Asset { get; } // OK-1011

    /// <summary>
    /// User Client
    /// </summary>
    public BybitUserRestApiClient User { get; } // OK-1011

    /// <summary>
    /// Spread Trading Client
    /// </summary>
    public BybitSpreadRestApiClient Spread { get; }

    /// <summary>
    /// RFQ Trading Client
    /// </summary>
    public BybitRfqRestApiClient Rfq { get; }

    /// <summary>
    /// Affiliate Client
    /// </summary>
    public BybitAffiliateRestApiClient Affiliate { get; }

    /// <summary>
    /// Margin Client
    /// </summary>
    public BybitMarginRestApiClient Margin { get; } // OK-1011

    /// <summary>
    /// Crypto Loan Client
    /// </summary>
    public BybitCryptoLoanRestApiClient CryptoLoan { get; }

    // NOT TO DO: Crypto Loan (legacy)

    /// <summary>
    /// Institutional Loan Client
    /// </summary>
    public BybitInstitutionalLoanRestApiClient InstitutionalLoan { get; } // OK-1011

    /// <summary>
    /// Broker Client
    /// </summary>
    public BybitBrokerRestApiClient Broker { get; }

    // TODO: Earn

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
    public BybitRestApiClient(ILogger? logger, BybitRestApiClientOptions options)
    {
        this.Logger = logger;
        this.ClientOptions = options;
        this.BaseClient = new BybitBaseRestApiClient(this);

        this.System = new BybitSystemRestApiClient(this);
        this.Market = new BybitMarketRestApiClient(this);
        this.Trade = new BybitTradeRestApiClient(this);
        this.Position = new BybitPositionRestApiClient(this);
        this.Account = new BybitAccountRestApiClient(this);
        this.Asset = new BybitAssetRestApiClient(this);
        this.User = new BybitUserRestApiClient(this);
        this.Spread = new BybitSpreadRestApiClient(this);
        this.Rfq = new BybitRfqRestApiClient(this);
        this.Affiliate = new BybitAffiliateRestApiClient(this);
        this.Broker = new BybitBrokerRestApiClient(this);
        this.Margin = new BybitMarginRestApiClient(this);
        this.CryptoLoan = new BybitCryptoLoanRestApiClient(this);
        this.InstitutionalLoan = new BybitInstitutionalLoanRestApiClient(this);
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
