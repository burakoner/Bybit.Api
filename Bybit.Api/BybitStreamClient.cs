using Bybit.Api.Helpers.Private;
using Bybit.Api.Helpers.Public;
using System.Linq;

namespace Bybit.Api;

public class BybitStreamClient : WebSocketApiClient
{
    internal bool IsAuthendicated { get; private set; }

    public BybitStreamClient() : this(null, new BybitStreamClientOptions())
    {
    }

    public BybitStreamClient(BybitStreamClientOptions options) : this(null, options)
    {
    }

    public BybitStreamClient(ILogger logger, BybitStreamClientOptions options) : base(logger, options)
    {
        ContinueOnQueryResponse = true;
        UnhandledMessageExpected = true;
        KeepAliveInterval = TimeSpan.Zero;

        if (options.ApiCredentials != null) options.AuthenticationProvider = CreateAuthenticationProvider(options.ApiCredentials);
        SendPeriodic("Ping", options.PingInterval, (connection) => new BybitStreamRequest { 
            Operation = "ping", 
            RequestId = Guid.NewGuid().ToString() 
        });
        AddGenericHandler("Heartbeat", (evnt) => { });
    }

    #region Overrided Methods
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BybitAuthenticationProvider(credentials);

    protected override async Task<CallResult<bool>> AuthenticateAsync(WebSocketConnection connection)
    {
        if (connection.ApiClient.ClientOptions.AuthenticationProvider == null)
            return new CallResult<bool>(new NoApiCredentialsError());

        var expireTime = DateTime.UtcNow.AddSeconds(30).ConvertToMilliseconds();
        var key = connection.ApiClient.ClientOptions.AuthenticationProvider.Credentials.Key!.GetString();
        var signature = ((BybitAuthenticationProvider)connection.ApiClient.ClientOptions.AuthenticationProvider).StreamApiSignature($"GET/realtime{expireTime}");

        var authRequest = new BybitStreamRequest()
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

    protected override bool HandleQueryResponse<T>(WebSocketConnection connection, object request, JToken data, out CallResult<T> callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleSubscriptionResponse(WebSocketConnection connection, WebSocketSubscription subscription, object request, JToken data, out CallResult<object> callResult)
    {
        callResult = null;
        if (data.Type != JTokenType.Object)
            return false;

        var bRequest = (BybitStreamRequest)request;
        var forcedExit = false;

        var success = bRequest.ValidateResponse(data, ref forcedExit);
        if (forcedExit) return false;

        if (success) callResult = new CallResult<object>(true);
        else callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));

        return true;
    }

    protected override bool MessageMatchesHandler(WebSocketConnection connection, JToken message, object request)
    {
        if (message.Type != JTokenType.Object)
            return false;

        var topic = message["topic"]?.ToString();
        if (topic == null)
            return false;

        return (request as BybitStreamRequest)?.MatchReponse(message) ?? false;
    }

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

    protected override async Task<bool> UnsubscribeAsync(WebSocketConnection connection, WebSocketSubscription subscription)
    {
        var bRequest = ((BybitStreamRequest)subscription.Request!);
        var message = new BybitStreamRequest
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
        var options = (BybitStreamClientOptions)ClientOptions;
        
        if (auth) return options.WebSocketPrivateAddress;
        if (category == BybitCategory.Spot) return options.WebSocketSpotAddress;
        if (category == BybitCategory.Inverse) return options.WebSocketInverseAddress;
        if (category == BybitCategory.Linear) return options.WebSocketPerpetualAddress;
        if (category == BybitCategory.Option) return options.WebSocketOptionAddress;

        throw new NotImplementedException("Endpoint is not found");
    }
    #endregion

    #region Public Streams
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderBookAsync(
        BybitCategory category, string symbol, int depth,
        Action<WebSocketDataEvent<BybitOrderBookUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) depth.ValidateIntValues(nameof(category), 1, 50);
        if (category == BybitCategory.Inverse) depth.ValidateIntValues(nameof(category), 1, 50,200,500);
        if (category == BybitCategory.Linear) depth.ValidateIntValues(nameof(category), 1, 50,200,500);
        if (category == BybitCategory.Option) depth.ValidateIntValues(nameof(category), 25, 100);

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"];  if (type == null)  return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitOrderBookUpdate>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookUpdate)} object: " + desResult.Error);
                return;
            }

            //desResult.Data.Category = category;
            desResult.Data.StreamType = type.ToString().GetEnumByLabel<BybitStreamType>();
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"orderbook.{depth}.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(
        BybitCategory category, string symbol, 
        Action<WebSocketDataEvent<BybitTradeStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<IEnumerable<BybitTradeStream>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeStream)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                //item.Category = category;
                //item.StreamType = type.ToString().GetEnumByLabel<BybitStreamType>();
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"publicTrade.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpotTickersAsync(string symbol, Action<WebSocketDataEvent<BybitSpotTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Spot, [symbol], handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLinearTickersAsync(string symbol, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Linear, [symbol], handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInverseTickersAsync(string symbol, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Inverse, [symbol], handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOptionTickersAsync(string symbol, Action<WebSocketDataEvent<BybitOptionTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Option, [symbol], handler, ct).ConfigureAwait(false);

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpotTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitSpotTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Spot, symbols, handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLinearTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
    => await SubscribeToTickersAsync(BybitCategory.Linear, symbols, handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInverseTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitFuturesTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Inverse, symbols, handler, ct).ConfigureAwait(false);
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOptionTickersAsync(IEnumerable<string> symbols, Action<WebSocketDataEvent<BybitOptionTickerStream>> handler, CancellationToken ct = default)
        => await SubscribeToTickersAsync(BybitCategory.Option, symbols, handler, ct).ConfigureAwait(false);

    private async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTickersAsync<T>(
        BybitCategory category, IEnumerable<string> symbols,
        Action<WebSocketDataEvent<T>> handler, CancellationToken ct = default)
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

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitStreamRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = symbols.Select(x=> $"tickers.{x}").ToArray(),
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(
        BybitCategory category, string symbol, BybitKlineInterval interval,
        Action<WebSocketDataEvent<BybitKlineStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<IEnumerable<BybitKlineStream>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitKlineStream)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"kline.{interval.GetLabel()}.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLiquidationsAsync(
        BybitCategory category, string symbol,
        Action<WebSocketDataEvent<BybitLiquidationStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitLiquidationStream>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitKlineStream)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"liquidation.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLeveragedTokenKlinesAsync(
        string symbol, BybitKlineInterval interval,
        Action<WebSocketDataEvent<BybitLeveragedTokenKlineStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<IEnumerable<BybitLeveragedTokenKlineStream>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLeveragedTokenKlineStream)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(BybitCategory.Spot, false), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"kline_lt.{interval.GetLabel()}.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLeveragedTokenTickersAsync(
        string symbol,
        Action<WebSocketDataEvent<BybitLeveragedTokenTickerStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitLeveragedTokenTickerStream>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitLeveragedTokenTickerStream)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress( BybitCategory.Spot, false), new BybitStreamRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"tickers_lt.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToLeveragedTokenNetAssetValuesAsync(
        string symbol,
        Action<WebSocketDataEvent<BybitNavStream>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitNavStream>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitNavStream)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress( BybitCategory.Spot, false), new BybitStreamRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { $"lt.{symbol}" }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    #endregion

    #region Private Updates
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<WebSocketDataEvent<BybitWalletUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            // var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitWalletUpdate>(item);
                if (!desResult)
                {
                    this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitWalletUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { "wallet" }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }
    
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<WebSocketDataEvent<BybitPositionUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            // var type = data.Data["type"]; if (type == null) return;
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

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { "position" }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

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

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { "execution" }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

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

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { "order" }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<WebSocketDataEvent<BybitGreekUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            // var type = data.Data["type"]; if (type == null) return;
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

        return await SubscribeAsync(GetStreamAddress(default, true), new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[] { "order" }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }
    #endregion

}
