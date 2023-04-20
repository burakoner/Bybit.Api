﻿using Bybit.Api.Stream.Spot;

namespace Bybit.Api;

public class BybitStreamClient : StreamApiClient
{
    internal bool IsAuthendicated { get; private set; }

    public BybitStreamClient() : this(new BybitStreamClientOptions())
    {
    }

    public BybitStreamClient(BybitStreamClientOptions options) : base("Bybit Stream", options)
    {
        ContinueOnQueryResponse = true;
        UnhandledMessageExpected = true;
        KeepAliveInterval = TimeSpan.Zero;

        SendPeriodic("Ping", options.PingInterval, (connection) =>
        {
            return new BybitSpotPing() { Ping = DateTime.UtcNow.ConvertToMilliseconds() };
        });
        AddGenericHandler("Heartbeat", (evnt) => { });
    }

    #region Overrided Methods
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BybitAuthenticationProvider(credentials);

    protected override async Task<CallResult<bool>> AuthenticateAsync(StreamConnection connection)
    {
        if (connection.ApiClient.ClientOptions.AuthenticationProvider == null)
            return new CallResult<bool>(new NoApiCredentialsError());

        var expireTime = DateTime.UtcNow.AddSeconds(30).ConvertToMilliseconds();
        var key = connection.ApiClient.ClientOptions.AuthenticationProvider.Credentials.Key!.GetString();
        var signature = connection.ApiClient.ClientOptions.AuthenticationProvider.Sign($"GET/realtime{expireTime}");

        var authRequest = new BybitStreamRequest()
        {
            Operation = "auth",
            Parameters = new object[] { key, expireTime, signature }
        };

        var result = false;
        var error = "unspecified error";
        await connection.SendAndWaitAsync(authRequest, ClientOptions.ResponseTimeout, data =>
        {
            if (data.Type != JTokenType.Object)
                return false;

            return CheckAuth(data, ref result);
        }).ConfigureAwait(false);
        return result ? new CallResult<bool>(result) : new CallResult<bool>(new ServerError(error));
    }

    protected override bool HandleQueryResponse<T>(StreamConnection connection, object request, JToken data, out CallResult<T> callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleSubscriptionResponse(StreamConnection connection, StreamSubscription subscription, object request, JToken data, out CallResult<object> callResult)
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

    protected override bool MessageMatchesHandler(StreamConnection connection, JToken message, object request)
    {
        if (message.Type != JTokenType.Object)
            return false;

        var topic = message["topic"]?.ToString();
        if (topic == null)
            return false;

        return (request as BybitStreamRequest)?.MatchReponse(message) ?? false;
    }

    protected override bool MessageMatchesHandler(StreamConnection connection, JToken message, string identifier)
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

    protected override async Task<bool> UnsubscribeAsync(StreamConnection connection, StreamSubscription subscription)
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
    /// <summary>
    /// Check auth data for valid
    /// </summary>
    /// <param name="data"> Response data </param>
    /// <param name="isSuccess"> Flag if auth is succeeded </param>
    /// <returns> Flag if response is valid </returns>
    public bool CheckAuth(JToken data, ref bool isSuccess)
    {
        var isAuthOperation = data["op"]?.ToString() == "auth";

        var auth = data["success"]?.ToString();
        isSuccess = isAuthOperation && auth == "True";
        return auth != null;
    }
    #endregion

    #region Spot Streams

    public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(
        BybitCategory category, string symbol, int depth,
        Action<StreamDataEvent<BybitOrderBookUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot) depth.ValidateIntValues(nameof(category), 1, 50);
        if (category == BybitCategory.Inverse) depth.ValidateIntValues(nameof(category), 1, 50,200,500);
        if (category == BybitCategory.Linear) depth.ValidateIntValues(nameof(category), 1, 50,200,500);
        if (category == BybitCategory.Option) depth.ValidateIntValues(nameof(category), 25, 100);

        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"];  if (type == null)  return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitOrderBookUpdate>(internalData);
            if (!desResult)
            {
                log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookUpdate)} object: " + desResult.Error);
                return;
            }

            desResult.Data.Category = category;
            desResult.Data.StreamType = type.ToString().GetEnumByLabel<BybitStreamType>();
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketSpotAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                $"orderbook.{depth}.{symbol}"
            }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BybitCategory category, string symbol, Action<StreamDataEvent<BybitTradeUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var type = data.Data["type"]; if (type == null) return;
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<IEnumerable<BybitTradeUpdate>>(internalData);
            if (!desResult)
            {
                log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitTradeUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                item.Category = category;
                item.StreamType = type.ToString().GetEnumByLabel<BybitStreamType>();
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketSpotAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                $"publicTrade.{symbol}"
            }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BybitKlineInterval interval, Action<StreamDataEvent<BybitSpotKlineUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var desResult = Deserialize<BybitSpotKlineUpdate>(internalData);
            if (!desResult)
            {
                log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotKlineUpdate)} object: " + desResult.Error);
                return;
            }

            var topic = data.Data["topic"]!.ToString();
            handler(data.As(desResult.Data, topic.Substring(topic.IndexOf('.') + 1)));
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketSpotAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                $"kline.{interval.GetLabel()}.{symbol}"
            }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    /*
    public async Task<CallResult<UpdateSubscription>> SubscribeToBookPriceUpdatesAsync(string symbol, Action<StreamDataEvent<BybitSpotBookPriceV3>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var desResult = Deserialize<BybitSpotBookPriceV3>(internalData);
            if (!desResult)
            {
                log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotBookPriceV3)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketSpotAddress, new BybitSpotRequestMessageV3
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                $"bookticker.{symbol}"
            }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }
    */

    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<StreamDataEvent<BybitSpotTickerUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var desResult = Deserialize<BybitSpotTickerUpdate>(internalData);
            if (!desResult)
            {
                log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotTickerUpdate)} object: " + desResult.Error);
                return;
            }

            handler(data.As(desResult.Data, data.Data["params"]?["symbol"]?.ToString()));
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketSpotAddress, new BybitStreamRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                $"tickers.{symbol}"
            }
        }, null, false, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<StreamDataEvent<BybitSpotAccountUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitSpotAccountUpdate>(item);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotAccountUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketPrivateAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                "outboundAccountInfo"
            }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToUserOrdersUpdatesAsync(Action<StreamDataEvent<BybitSpotOrderUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitSpotOrderUpdate>(item);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketPrivateAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                "order"
            }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToUserStopOrdersUpdatesAsync(Action<StreamDataEvent<BybitSpotStopOrderUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitSpotStopOrderUpdate>(item);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotStopOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketPrivateAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                "stopOrder"
            }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradesUpdatesAsync(Action<StreamDataEvent<BybitSpotUserTradeUpdate>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<StreamDataEvent<JToken>>(data =>
        {
            var internalData = data.Data["data"];
            if (internalData == null)
                return;

            var jArray = (JArray)internalData;
            foreach (var item in jArray)
            {
                var desResult = Deserialize<BybitSpotUserTradeUpdate>(item);
                if (!desResult)
                {
                    log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpotUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            }
        });

        return await SubscribeAsync(((BybitStreamClientOptions)ClientOptions).WebSocketPrivateAddress, new BybitStreamRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = new[]
            {
                    "ticketInfo"
            }
        }, null, true, internalHandler, ct).ConfigureAwait(false);
    }
    #endregion
}
