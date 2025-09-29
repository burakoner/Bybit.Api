namespace Bybit.Api.System;

/// <summary>
/// Bybit System Service Type
/// </summary>
public enum BybitSystemServiceType
{
    /// <summary>
    /// Trading service
    /// </summary>
    [Map("1")]
    TradingService = 1,

    /// <summary>
    /// Trading Service Via Http Request
    /// </summary>
    [Map("2")]
    TradingServiceViaHttpRequest = 2,

    /// <summary>
    /// Trading Service Via Websocket
    /// </summary>
    [Map("3")]
    TradingServiceViaWebsocket = 3,

    /// <summary>
    /// Private Websocket Stream
    /// </summary>
    [Map("4")]
    PrivateWebsocketStream = 4,

    /// <summary>
    /// Market Data Service
    /// </summary>
    [Map("5")]
    MarketDataService = 5,
}