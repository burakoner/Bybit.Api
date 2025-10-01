using Bybit.Api.Account;
using Bybit.Api.Common.Requests;
using Bybit.Api.Market;
using Bybit.Api.Models.Socket;
using Bybit.Api.Trading;

namespace Bybit.Api;

/// <summary>
/// Bybit WebSocket Client
/// </summary>
public class BybitWebSocketClient : WebSocketApiClient
{
    internal bool IsAuthendicated { get; private set; }

    /// <summary>
    /// Creates a new instance of BybitWebSocketClient
    /// </summary>
    public BybitWebSocketClient() : this(null, new BybitWebSocketClientOptions())
    {
    }

    /// <summary>
    /// Creates a new instance of BybitWebSocketClient
    /// </summary>
    /// <param name="options"></param>
    public BybitWebSocketClient(BybitWebSocketClientOptions options) : this(null, options)
    {
    }

    /// <summary>
    /// Creates a new instance of BybitWebSocketClient
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="options"></param>
    public BybitWebSocketClient(ILogger? logger, BybitWebSocketClientOptions options) : base(logger, options)
    {
        ContinueOnQueryResponse = true;
        UnhandledMessageExpected = true;
        KeepAliveInterval = TimeSpan.Zero;

        if (options.ApiCredentials != null) options.AuthenticationProvider = CreateAuthenticationProvider(options.ApiCredentials);
        SendPeriodic("Ping", options.PingInterval, (connection) => new BybitSocketRequest
        {
            Operation = "ping",
            RequestId = Guid.NewGuid().ToString()
        });
        AddGenericHandler("Heartbeat", (evnt) => { });
    }

    #region Overrided Methods
    /// <inheritdoc/>
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BybitAuthenticationProvider(credentials);

    /// <inheritdoc/>
    protected override async Task<CallResult<bool>> AuthenticateAsync(WebSocketConnection connection)
    {
        if (connection.ApiClient.ClientOptions.AuthenticationProvider == null)
            return new CallResult<bool>(new NoApiCredentialsError());

        var expireTime = DateTime.UtcNow.AddSeconds(30).ConvertToMilliseconds();
        var key = connection.ApiClient.ClientOptions.AuthenticationProvider.Credentials.Key!.GetString();
        var signature = ((BybitAuthenticationProvider)connection.ApiClient.ClientOptions.AuthenticationProvider).StreamApiSignature($"GET/realtime{expireTime}");

        var authRequest = new BybitSocketRequest()
        {
            Operation = "auth",
            Parameters = [key, expireTime, signature]
        };

        var json = JsonConvert.SerializeObject(authRequest);

        var result = false;
        await connection.SendAndWaitAsync(authRequest, ClientOptions.ResponseTimeout, data =>
        {
            if (data.Type != JTokenType.Object)
                return false;

            var isAuthOperation = data["op"]?.ToString() == "auth";
            var auth = data["success"]?.ToString();
            result = isAuthOperation && auth == "True";
            return auth != null;
        }).ConfigureAwait(false);

        return result
            ? new CallResult<bool>(result)
            : new CallResult<bool>(new ServerError("Unspecified Error"));
    }

    /// <inheritdoc/>
    protected override bool HandleQueryResponse<T>(WebSocketConnection connection, object request, JToken data, out CallResult<T> callResult)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    protected override bool HandleSubscriptionResponse(WebSocketConnection connection, WebSocketSubscription subscription, object request, JToken data, out CallResult<object>? callResult)
    {
        callResult = null;
        if (data.Type != JTokenType.Object)
            return false;

        var bRequest = (BybitSocketRequest)request;
        var forcedExit = false;

        var success = bRequest.ValidateResponse(data, ref forcedExit);
        if (forcedExit) return false;

        if (success) callResult = new CallResult<object>(true);
        else callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));

        return true;
    }

    /// <inheritdoc/>
    protected override bool MessageMatchesHandler(WebSocketConnection connection, JToken message, object request)
    {
        if (message.Type != JTokenType.Object)
            return false;

        var topic = message["topic"]?.ToString();
        if (topic == null)
            return false;

        return (request as BybitSocketRequest)?.MatchReponse(message) ?? false;
    }

    /// <inheritdoc/>
    protected override bool MessageMatchesHandler(WebSocketConnection connection, JToken message, string identifier)
    {
        if (identifier == "Heartbeat")
        {
            if (message.Type != JTokenType.Object)
                return false;

            var ret = message["ret_msg"];
            if (ret == null) return false;

            var isPing = ret.ToString() == "pong";
            if (!isPing) return false;

            return true;
        }

        if (identifier == "AccountInfo")
        {
            if (message.Type != JTokenType.Array)
                return false;

            var updateType = ((JArray)message)[0]["e"]?.ToString();
            if (updateType == null) return false;

            return updateType == "outboundAccountInfo" || updateType == "stop_executionReport" || updateType == "executionReport" || updateType == "order" || updateType == "ticketInfo";
        }

        return false;
    }

    /// <inheritdoc/>
    protected override async Task<bool> UnsubscribeAsync(WebSocketConnection connection, WebSocketSubscription subscription)
    {
        var bRequest = ((BybitSocketRequest)subscription.Request!);
        var message = new BybitSocketRequest
        {
            Operation = "unsubscribe",
            Parameters = bRequest.Parameters,
        };

        var result = false;
        await connection.SendAndWaitAsync(message, ClientOptions.ResponseTimeout, data =>
        {
            if (data.Type != JTokenType.Object)
                return false;

            result = data["success"]?.Value<bool>() == true;
            return true;
        }).ConfigureAwait(false);

        return result;
    }
    #endregion

    #region Private Methods
    private string GetStreamAddress(BybitCategory category, bool auth)
    {
        var options = (BybitWebSocketClientOptions)ClientOptions;

        if (auth) return options.WebSocketPrivateAddress;
        if (category == BybitCategory.Spot) return options.WebSocketSpotAddress;
        if (category == BybitCategory.Inverse) return options.WebSocketInverseAddress;
        if (category == BybitCategory.Linear) return options.WebSocketPerpetualAddress;
        if (category == BybitCategory.Option) return options.WebSocketOptionAddress;

        throw new NotImplementedException("Endpoint is not found");
    }
    #endregion

    #region Public Streams
    /// <summary>
    /// Subscribe to the orderbook stream. Supports different depths.
    /// 
    /// Depths
    /// Linear &amp; inverse:
    /// Level 1 data, push frequency: 10ms
    /// Level 50 data, push frequency: 20ms
    /// Level 200 data, push frequency: 100ms
    /// Level 500 data, push frequency: 100ms
    /// 
    /// Spot:
    /// Level 1 data, push frequency: 10ms
    /// Level 50 data, push frequency: 20ms
    /// Level 200 data, push frequency: 200ms
    /// 
    /// Option:
    /// Level 25 data, push frequency: 20ms
    /// Level 100 data, push frequency: 100ms
    /// 
    /// Topic:
    /// orderbook.{depth}.{symbol} e.g., orderbook.1.BTCUSDT
    /// 
    /// Process snapshot/delta
    /// To process snapshot and delta messages, please follow these rules:
    /// 
    /// Once you have subscribed successfully, you will receive a snapshot. The WebSocket will keep pushing delta messages every time the orderbook changes. If you receive a new snapshot message, you will have to reset your local orderbook. If there is a problem on Bybit's end, a snapshot will be re-sent, which is guaranteed to contain the latest data.
    /// 
    /// To apply delta updates:
    /// If you receive an amount that is 0, delete the entry
    /// If you receive an amount that does not exist, insert it
    /// If the entry exists, you simply update the value
    /// See working code examples of this logic in the FAQ.
    /// 
    /// INFO
    /// Linear &amp; inverse level 1 data: if 3 seconds have elapsed without a change in the orderbook, a snapshot message will be pushed again.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="depth">Depth</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderBookAsync(BybitCategory category, string symbol, int depth, Action<WebSocketDataEvent<BybitOrderBookUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) depth.ValidateIntValues(nameof(category), 1, 50, 200);
        if (category == BybitCategory.Inverse) depth.ValidateIntValues(nameof(category), 1, 50, 200, 500);
        if (category == BybitCategory.Linear) depth.ValidateIntValues(nameof(category), 1, 50, 200, 500);
        if (category == BybitCategory.Option) depth.ValidateIntValues(nameof(category), 25, 100);

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitOrderBookUpdate>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookUpdate)} object: " + desResult.Error);
                return;
            }

            //desResult.Data.Category = category;
            desResult.Data.StreamType = MapConverter.GetEnumByLabel<BybitStreamType>(type.ToString());
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [$"orderbook.{depth}.{symbol}"]
        }, string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    // TODO: RPI Orderbook

    /// <summary>
    /// Subscribe to the recent trades stream.
    /// After subscription, you will be pushed trade messages in real-time.
    /// Push frequency: real-time
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(BybitCategory category, string symbol, Action<WebSocketDataEvent<BybitTradeUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<BybitTradeUpdate>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [$"publicTrade.{symbol}"]
        }, string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpotTickersAsync(string symbol, Action<WebSocketDataEvent<BybitSpotTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Spot, [symbol], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLinearTickersAsync(string symbol, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Linear, [symbol], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInverseTickersAsync(string symbol, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Inverse, [symbol], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOptionTickersAsync(string symbol, Action<WebSocketDataEvent<BybitOptionTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Option, [symbol], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpotTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitSpotTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Spot, symbols, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLinearTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
    => await SubscribeToTickersAsync(BybitCategory.Linear, symbols, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInverseTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Inverse, symbols, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOptionTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitOptionTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Option, symbols, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the ticker stream.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    private async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTickersAsync<T>(BybitCategory category, IEnumerable<string> symbols, Action<WebSocketDataEvent<T>> handler, CancellationToken ct = default)
    {
        if (symbols.Count() > 10) throw new ArgumentException("Maximum 10 symbols per request");

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<T>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(T)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitSocketRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [.. symbols.Select(x => $"tickers.{x}")],
        }, string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the klines stream.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="interval">Interval</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(BybitCategory category, string symbol, BybitInterval interval, Action<WebSocketDataEvent<BybitKlineUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<BybitKlineUpdate>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitKlineUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [$"kline.{MapConverter.GetString(interval)}.{symbol}"]
        }, string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    // TODO: All Liquidation
    // TODO: Remove SubscribeToLiquidationsAsync

    /// <summary>
    /// Subscribe to the liquidation stream, at most one order is published per second per symbol
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLiquidationsAsync(BybitCategory category, string symbol, Action<WebSocketDataEvent<BybitLiquidationUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitLiquidationUpdate>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLiquidationUpdate)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [$"liquidation.{symbol}"]
        }, string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    // TODO: Order Price Limit
    #endregion

    #region Private Streams
    /// <summary>
    /// Subscribe to the position stream to see changes to your position data in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<WebSocketDataEvent<BybitPositionUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitPositionUpdate>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = ["position"]
        }, string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the execution stream to see your executions in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToExecutionUpdatesAsync(Action<WebSocketDataEvent<BybitExecutionUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            // var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitExecutionUpdate>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitExecutionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = ["execution"]
        }, string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }

    // TODO: Fast Execution

    /// <summary>
    /// Subscribe to the order stream to see changes to your orders in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<WebSocketDataEvent<BybitOrderUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            // var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitOrderUpdate>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = ["order"]
        }, string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the wallet stream to see changes to your wallet in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<WebSocketDataEvent<BybitAccountBalance>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitAccountBalance>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitAccountBalance)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = ["wallet"]
        }, string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the greeks stream to see changes to your greeks data in real-time. option only.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<WebSocketDataEvent<BybitGreekUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitGreekUpdate>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitGreekUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = ["greeks"]
        }, string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }

    // TODO: DCP
    #endregion

    // TODO: Websocket Trade

    // TODO: System Status
}
