﻿using Bybit.Api.Account;
using Bybit.Api.Asset;
using Bybit.Api.Loan;
using Bybit.Api.Margin;
using Bybit.Api.Market;
using Bybit.Api.Tokens;
using Bybit.Api.Trading;
using Bybit.Api.User;

namespace Bybit.Api;

/// <summary>
/// Bybit Rest API Client
/// </summary>
public class BybitRestApiClient
{
    // Internal
    internal ILogger Logger { get; }
    internal BybitBaseRestApiClient BaseClient { get; }
    internal BybitRestApiClientOptions ClientOptions { get; }

    /// <summary>
    /// Market Client
    /// </summary>
    public BybitMarketRestApiClient Market { get; } // OK-1009

    /// <summary>
    /// Trade Client
    /// </summary>
    public BybitTradeRestApiClient Trade { get; } // OK-1009

    /// <summary>
    /// Position Client
    /// </summary>
    public BybitPositionRestApiClient Position { get; } // OK-1009

    /// <summary>
    /// Account Client
    /// </summary>
    public BybitAccountRestApiClient Account { get; } // OK-1010

    /// <summary>
    /// Asset Client
    /// </summary>
    public BybitAssetRestApiClient Asset { get; } // OK-1011

    /// <summary>
    /// User Client
    /// </summary>
    public BybitUserRestApiClient User { get; } // OK-1011

    /// <summary>
    /// Leverage Tokens Client
    /// </summary>
    public BybitLeverageTokenRestApiClient LeverageToken { get; } // OK-1011

    /// <summary>
    /// Margin Client
    /// </summary>
    public BybitMarginRestApiClient Margin { get; } // OK-1011

    /// <summary>
    /// Lending Client
    /// </summary>
    public BybitLoanRestApiClient Loan { get; } // OK-1011

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
        this.BaseClient = new BybitBaseRestApiClient(this);

        this.Market = new BybitMarketRestApiClient(this);
        this.Trade = new BybitTradeRestApiClient(this);
        this.Position = new BybitPositionRestApiClient(this);
        this.Account = new BybitAccountRestApiClient(this);
        this.Asset = new BybitAssetRestApiClient(this);
        this.User = new BybitUserRestApiClient(this);
        this.LeverageToken = new BybitLeverageTokenRestApiClient(this);
        this.Margin = new BybitMarginRestApiClient(this);
        this.Loan = new BybitLoanRestApiClient(this);
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
