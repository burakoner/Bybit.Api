using Bybit.Api.Account;
using Bybit.Api.Common.Requests;
using Bybit.Api.Market;
using Bybit.Api.Models.Socket;
using Bybit.Api.Rfq;
using Bybit.Api.Spread;
using Bybit.Api.Trading;
using BybitSystemStatus = Bybit.Api.System.BybitSystemStatus;

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

        var result = false;
        await connection.SendAndWaitAsync(authRequest, ClientOptions.ResponseTimeout, data =>
        {
            if (data.Type != JTokenType.Object)
                return false;

            var isAuthOperation = data["op"]?.ToString() == "auth";
            var streamSuccess = data["success"]?.Value<bool?>();
            var tradeRetCode = data["retCode"]?.Value<int?>();
            result = isAuthOperation && (streamSuccess == true || tradeRetCode == 0);
            return isAuthOperation && (streamSuccess != null || tradeRetCode != null);
        }).ConfigureAwait(false);

        return result
            ? new CallResult<bool>(result)
            : new CallResult<bool>(new ServerError("Unspecified Error"));
    }

    /// <inheritdoc/>
    protected override bool HandleQueryResponse<T>(WebSocketConnection connection, object request, JToken data, out CallResult<T> callResult)
    {
        callResult = null!;
        if (data.Type != JTokenType.Object)
            return false;

        if (request is not BybitWebSocketTradeRequest tradeRequest)
            return false;

        var operation = data["op"]?.ToString();
        if (operation != tradeRequest.Operation)
            return false;

        var requestId = data["reqId"]?.ToString();
        if (tradeRequest.RequestId != null && requestId != tradeRequest.RequestId)
            return false;

        var returnCode = data["retCode"]?.Value<int?>();
        if (returnCode == null)
            return false;

        if (returnCode != 0)
        {
            callResult = new CallResult<T>(new ServerError(data["retMsg"]?.ToString() ?? "Unspecified Error"));
            return true;
        }

        var desResult = Deserialize<T>(data);
        if (!desResult)
        {
            callResult = new CallResult<T>(desResult.Error!);
            return true;
        }

        callResult = new CallResult<T>(desResult.Data);
        return true;
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

    private string GetSpreadStreamAddress()
        => ((BybitWebSocketClientOptions)ClientOptions).WebSocketSpreadAddress;

    private string GetRfqStreamAddress()
        => ((BybitWebSocketClientOptions)ClientOptions).WebSocketRfqAddress;

    private string GetSystemStatusStreamAddress()
        => ((BybitWebSocketClientOptions)ClientOptions).WebSocketSystemStatusAddress;

    private string GetTradeStreamAddress()
        => ((BybitWebSocketClientOptions)ClientOptions).WebSocketTradeAddress;

    private static BybitSocketRequest CreateSubscribeRequest(IEnumerable<string> topics)
    {
        return new BybitSocketRequest()
        {
            RequestId = Guid.NewGuid().ToString(),
            Operation = "subscribe",
            Parameters = [.. topics]
        };
    }

    private static long GetLong(JToken data, string field)
        => data[field]?.Value<long?>() ?? 0;

    private static long? GetNullableLong(JToken data, string field)
        => data[field]?.Value<long?>();

    private static BybitStreamType GetStreamType(JToken data)
        => MapConverter.GetEnumByLabel<BybitStreamType>(data["type"]?.ToString() ?? string.Empty);

    private static void ApplyTickerMetadata<T>(T ticker, JToken data)
    {
        var streamType = GetStreamType(data);
        var timestamp = GetLong(data, "ts");
        var crossSequence = GetNullableLong(data, "cs");
        var messageId = data["id"]?.ToString() ?? string.Empty;

        switch (ticker)
        {
            case BybitSpotTickerStream spot:
                spot.StreamType = streamType;
                spot.Timestamp = timestamp;
                spot.CrossSequence = crossSequence;
                break;
            case BybitFuturesTickerStream futures:
                futures.StreamType = streamType;
                futures.Timestamp = timestamp;
                futures.CrossSequence = crossSequence;
                break;
            case BybitOptionTickerStream option:
                option.StreamType = streamType;
                option.Timestamp = timestamp;
                option.MessageId = messageId;
                break;
        }
    }

    private static void ValidateInsurancePools(BybitCategory category, IEnumerable<BybitInsurancePool> pools)
    {
        var poolList = pools.ToList();
        if (poolList.Count == 0)
            throw new ArgumentException("At least one insurance pool is required", nameof(pools));

        if (category == BybitCategory.Inverse)
        {
            if (poolList.Any(x => x != BybitInsurancePool.Inverse))
                throw new ArgumentException("Inverse WebSocket address only supports the inverse insurance pool", nameof(pools));
            return;
        }

        if (category == BybitCategory.Linear)
        {
            if (poolList.Any(x => x == BybitInsurancePool.Inverse))
                throw new ArgumentException("Linear WebSocket address supports USDT and USDC insurance pools only", nameof(pools));
            return;
        }

        throw new ArgumentException("Insurance pool streams support linear and inverse categories only", nameof(category));
    }

    private async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToArrayTopicAsync<T>(string url, string topicName, bool authenticated, Action<WebSocketDataEvent<T>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<T>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(T)} array: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(url, CreateSubscribeRequest([topicName]), string.Empty, authenticated, internalHandler, ct).ConfigureAwait(false);
    }

    private async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToObjectTopicAsync<T>(string url, string topicName, bool authenticated, Action<WebSocketDataEvent<T>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
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

        return await SubscribeAsync(url, CreateSubscribeRequest([topicName]), string.Empty, authenticated, internalHandler, ct).ConfigureAwait(false);
    }

    private Task<CallResult<T>> QueryTradeAsync<T>(string operation, object args, string? requestId = null, long receiveWindow = 5000, string? referer = null)
    {
        var timestamp = DateTime.UtcNow.ConvertToMilliseconds();
        var request = new BybitWebSocketTradeRequest
        {
            RequestId = requestId,
            Operation = operation,
            Header = new BybitWebSocketTradeRequestHeader
            {
                Timestamp = timestamp,
                ReceiveWindow = receiveWindow,
                Referer = referer,
            },
            Parameters = [args],
        };

        return QueryAsync<T>(GetTradeStreamAddress(), request, true);
    }

    private static ParameterCollection CreateWebSocketPlaceOrderParameters(BybitPlaceOrderRequest request)
    {
        request.BboLevel?.ValidateIntBetween(nameof(request.BboLevel), 1, 5);

        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.Add("symbol", request.Symbol);
        parameters.AddEnum("side", request.Side);
        parameters.AddEnum("orderType", request.Type);
        parameters.AddString("qty", request.Quantity);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);
        parameters.AddOptionalEnum("marketUnit", request.MarketUnit);
        parameters.AddOptional("isLeverage", request.IsLeverageField);
        parameters.AddOptionalEnum("slippageToleranceType", request.SlippageToleranceType);
        if (request.SlippageToleranceType != null && request.SlippageTolerance != null)
        {
            if (request.SlippageToleranceType == BybitSlippageToleranceType.TickSize)
                parameters.AddOptionalString("slippageTolerance", Convert.ToInt32(request.SlippageTolerance));
            else if (request.SlippageToleranceType == BybitSlippageToleranceType.Percent)
                parameters.AddOptionalString("slippageTolerance", request.SlippageTolerance);
        }

        parameters.AddOptionalString("price", request.Price);
        parameters.AddOptionalEnum("triggerDirection", request.TriggerDirection);
        parameters.AddOptionalEnum("orderFilter", request.OrderFilter);
        parameters.AddOptionalString("triggerPrice", request.TriggerPrice);
        parameters.AddOptionalEnum("triggerBy", request.TriggerBy);
        parameters.AddOptionalString("orderIv", request.OrderIv);
        parameters.AddOptionalEnum("timeInForce", request.TimeInForce);
        parameters.AddOptionalEnum("positionIdx", request.PositionIndex);
        parameters.AddOptional("reduceOnly", request.ReduceOnly);
        parameters.AddOptional("closeOnTrigger", request.CloseOnTrigger);
        parameters.AddOptional("mmp", request.Mmp);
        parameters.AddOptionalEnum("smpType", request.SelfMatchPrevention);
        parameters.AddOptionalEnum("tpslMode", request.TakeProfitStopLossMode);
        parameters.AddOptionalEnum("tpOrderType", request.TakeProfitOrderType);
        parameters.AddOptionalEnum("tpTriggerBy", request.TakeProfitTriggerBy);
        parameters.AddOptionalString("takeProfit", request.TakeProfitPrice);
        parameters.AddOptionalString("tpLimitPrice", request.TakeProfitLimitPrice);
        parameters.AddOptionalEnum("slOrderType", request.StopLossOrderType);
        parameters.AddOptionalEnum("slTriggerBy", request.StopLossTriggerBy);
        parameters.AddOptionalString("stopLoss", request.StopLossPrice);
        parameters.AddOptionalString("slLimitPrice", request.StopLossLimitPrice);
        parameters.AddOptionalEnum("bboSideType", request.BboSideType);
        parameters.AddOptionalString("bboLevel", request.BboLevel);

        return parameters;
    }

    private static ParameterCollection CreateWebSocketAmendOrderParameters(BybitAmendOrderRequest request)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.Add("symbol", request.Symbol);
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);
        parameters.AddOptionalString("orderIv", request.OrderIv);
        parameters.AddOptionalString("qty", request.Quantity);
        parameters.AddOptionalString("price", request.Price);
        parameters.AddOptionalString("triggerPrice", request.TriggerPrice);
        parameters.AddOptionalEnum("triggerBy", request.TriggerBy);
        parameters.AddOptionalEnum("tpslMode", request.TakeProfitStopLossMode);
        parameters.AddOptionalEnum("tpTriggerBy", request.TakeProfitTriggerBy);
        parameters.AddOptionalString("takeProfit", request.TakeProfitPrice);
        parameters.AddOptionalString("tpLimitPrice", request.TakeProfitLimitPrice);
        parameters.AddOptionalEnum("slTriggerBy", request.StopLossTriggerBy);
        parameters.AddOptionalString("stopLoss", request.StopLossPrice);
        parameters.AddOptionalString("slLimitPrice", request.StopLossLimitPrice);

        return parameters;
    }

    private static ParameterCollection CreateWebSocketCancelOrderParameters(BybitCancelOrderRequest request)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", request.Category);
        parameters.Add("symbol", request.Symbol);
        parameters.AddOptional("orderId", request.OrderId);
        parameters.AddOptional("orderLinkId", request.ClientOrderId);
        parameters.AddOptionalEnum("orderFilter", request.OrderFilter);

        return parameters;
    }

    private static ParameterCollection CreateWebSocketBatchOrderParameters<TRequest>(BybitCategory category, IEnumerable<TRequest> requests)
    {
        var parameters = new ParameterCollection();
        parameters.AddEnum("category", category);
        parameters.Add("request", requests.ToList());
        return parameters;
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
    /// Level 1000 data, push frequency: 200ms
    /// 
    /// Spot:
    /// Level 1 data, push frequency: 10ms
    /// Level 50 data, push frequency: 20ms
    /// Level 200 data, push frequency: 100ms
    /// Level 1000 data, push frequency: 200ms
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
        if (category == BybitCategory.Spot) depth.ValidateIntValues(nameof(depth), 1, 50, 200, 1000);
        if (category == BybitCategory.Inverse) depth.ValidateIntValues(nameof(depth), 1, 50, 200, 1000);
        if (category == BybitCategory.Linear) depth.ValidateIntValues(nameof(depth), 1, 50, 200, 1000);
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
            desResult.Data.Timestamp = GetLong(data.Data, "ts");
            desResult.Data.CreateTimestamp = GetNullableLong(data.Data, "cts");
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"orderbook.{depth}.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the RPI orderbook stream.
    /// </summary>
    /// <param name="category">Category. Spot, Linear and Inverse are supported.</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToRpiOrderBookAsync(BybitCategory category, string symbol, Action<WebSocketDataEvent<BybitOrderBookUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Option)
            throw new ArgumentException("RPI orderbook stream is not supported for options", nameof(category));

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

            desResult.Data.StreamType = MapConverter.GetEnumByLabel<BybitStreamType>(type.ToString());
            desResult.Data.Timestamp = GetLong(data.Data, "ts");
            desResult.Data.CreateTimestamp = GetNullableLong(data.Data, "cts");
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"orderbook.rpi.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

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
                item.StreamType = GetStreamType(data.Data);
                item.StreamTimestamp = GetLong(data.Data, "ts");
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"publicTrade.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
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

            ApplyTickerMetadata(desResult.Data, data.Data);
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest(symbols.Select(x => $"tickers.{x}")), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
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
                item.StreamType = GetStreamType(data.Data);
                item.StreamTimestamp = GetLong(data.Data, "ts");
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"kline.{MapConverter.GetString(interval)}.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the legacy liquidation stream, at most one order is published per second per symbol.
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

            desResult.Data.StreamType = GetStreamType(data.Data);
            desResult.Data.StreamTimestamp = GetLong(data.Data, "ts");
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"liquidation.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the all-liquidation stream. Pushes all liquidations that occur on Bybit for derivatives contracts.
    /// </summary>
    /// <param name="category">Category. Linear and Inverse are supported.</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToAllLiquidationsAsync(BybitCategory category, string symbol, Action<WebSocketDataEvent<BybitAllLiquidationUpdate>> handler, CancellationToken ct = default)
    {
        if (category != BybitCategory.Linear && category != BybitCategory.Inverse)
            throw new ArgumentException("All liquidation stream supports linear and inverse categories only", nameof(category));

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<BybitAllLiquidationUpdate>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitAllLiquidationUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                item.StreamType = GetStreamType(data.Data);
                item.StreamTimestamp = GetLong(data.Data, "ts");
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"allLiquidation.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to order price limit updates.
    /// </summary>
    /// <param name="category">Category. Spot, Linear and Inverse are supported.</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderPriceLimitAsync(BybitCategory category, string symbol, Action<WebSocketDataEvent<BybitOrderPriceLimitUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Option)
            throw new ArgumentException("Order price limit stream is not supported for options", nameof(category));

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitOrderPriceLimitUpdate>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderPriceLimitUpdate)} object: " + desResult.Error);
                return;
            }

            desResult.Data.Timestamp = GetLong(data.Data, "ts");
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest([$"priceLimit.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to insurance pool updates.
    /// </summary>
    /// <param name="category">Linear for USDT/USDC pools, Inverse for the inverse pool.</param>
    /// <param name="pool">Insurance pool</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInsurancePoolAsync(BybitCategory category, BybitInsurancePool pool, Action<WebSocketDataEvent<BybitInsurancePoolUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToInsurancePoolAsync(category, [pool], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to insurance pool updates.
    /// </summary>
    /// <param name="category">Linear for USDT/USDC pools, Inverse for the inverse pool.</param>
    /// <param name="pools">Insurance pools</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToInsurancePoolAsync(BybitCategory category, IEnumerable<BybitInsurancePool> pools, Action<WebSocketDataEvent<BybitInsurancePoolUpdate>> handler, CancellationToken ct = default)
    {
        var poolList = pools.ToList();
        ValidateInsurancePools(category, poolList);

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<BybitInsurancePoolUpdate>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitInsurancePoolUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                item.StreamType = GetStreamType(data.Data);
                item.StreamTimestamp = GetLong(data.Data, "ts");
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest(poolList.Select(x => $"insurance.{MapConverter.GetString(x)}")), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to ADL alert updates.
    /// </summary>
    /// <param name="category">Linear for USDT/USDC alerts, Inverse for inverse alerts.</param>
    /// <param name="pool">Insurance pool filter</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToAdlAlertsAsync(BybitCategory category, BybitInsurancePool pool, Action<WebSocketDataEvent<BybitAdlAlertUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToAdlAlertsAsync(category, [pool], handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to ADL alert updates.
    /// </summary>
    /// <param name="category">Linear for USDT/USDC alerts, Inverse for inverse alerts.</param>
    /// <param name="pools">Insurance pool filters</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToAdlAlertsAsync(BybitCategory category, IEnumerable<BybitInsurancePool> pools, Action<WebSocketDataEvent<BybitAdlAlertUpdate>> handler, CancellationToken ct = default)
    {
        var poolList = pools.ToList();
        ValidateInsurancePools(category, poolList);

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<List<BybitAdlAlertUpdate>>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitAdlAlertUpdate)} object: " + desResult.Error);
                return;
            }

            foreach (var item in desResult.Data)
            {
                item.StreamType = GetStreamType(data.Data);
                item.StreamTimestamp = GetLong(data.Data, "ts");
                handler(data.As(item, topic.ToString()));
            }
        });

        return await SubscribeAsync(GetStreamAddress(category, false), CreateSubscribeRequest(poolList.Select(x => $"adlAlert.{MapConverter.GetString(x)}")), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }
    #endregion

    #region Private Streams
    /// <summary>
    /// Subscribe to the position stream to see changes to your position data in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<WebSocketDataEvent<BybitPositionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "position", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the categorised position stream.
    /// </summary>
    /// <param name="category">Category. Linear, Inverse and Option are supported.</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToPositionUpdatesAsync(BybitCategory category, Action<WebSocketDataEvent<BybitPositionUpdate>> handler, CancellationToken ct = default)
    {
        if (category == BybitCategory.Spot)
            throw new ArgumentException("Position stream is not supported for spot", nameof(category));

        return await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), $"position.{MapConverter.GetString(category)}", true, handler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to the execution stream to see your executions in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToExecutionUpdatesAsync(Action<WebSocketDataEvent<BybitExecutionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "execution", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the categorised execution stream.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToExecutionUpdatesAsync(BybitCategory category, Action<WebSocketDataEvent<BybitExecutionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), $"execution.{MapConverter.GetString(category)}", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the fast execution stream.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToFastExecutionUpdatesAsync(Action<WebSocketDataEvent<BybitFastExecutionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "execution.fast", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the categorised fast execution stream.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToFastExecutionUpdatesAsync(BybitCategory category, Action<WebSocketDataEvent<BybitFastExecutionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), $"execution.fast.{MapConverter.GetString(category)}", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the order stream to see changes to your orders in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<WebSocketDataEvent<BybitOrderUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "order", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the categorised order stream.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrderUpdatesAsync(BybitCategory category, Action<WebSocketDataEvent<BybitOrderUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), $"order.{MapConverter.GetString(category)}", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the wallet stream to see changes to your wallet in real-time.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToWalletUpdatesAsync(Action<WebSocketDataEvent<BybitAccountBalance>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "wallet", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the greeks stream to see changes to your greeks data in real-time. option only.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToGreekUpdatesAsync(Action<WebSocketDataEvent<BybitGreekUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "greeks", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to a DCP heartbeat topic. All private connections subscribing to the selected DCP topic must disconnect for DCP to trigger.
    /// </summary>
    /// <param name="dcpTopic">DCP topic scope</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDcpAsync(BybitDcpTopic dcpTopic, Action<WebSocketDataEvent<JToken>> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var responseTopic = data.Data["topic"]; if (responseTopic == null) return;
            handler(data.As(data.Data, responseTopic.ToString()));
        });

        return await SubscribeAsync(GetStreamAddress(default, true), CreateSubscribeRequest([$"dcp.{MapConverter.GetString(dcpTopic)}"]), string.Empty, true, internalHandler, ct).ConfigureAwait(false);
    }
    #endregion

    #region System Streams
    /// <summary>
    /// Subscribe to system status updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSystemStatusUpdatesAsync(Action<WebSocketDataEvent<BybitSystemStatus>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetSystemStatusStreamAddress(), "system.status", false, handler, ct).ConfigureAwait(false);
    #endregion

    #region Spread Streams
    /// <summary>
    /// Subscribe to the spread orderbook stream.
    /// </summary>
    /// <param name="symbol">Spread symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadOrderBookAsync(string symbol, Action<WebSocketDataEvent<BybitSpreadOrderbook>> handler, CancellationToken ct = default)
        => await SubscribeToSpreadOrderBookAsync(symbol, 25, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to the spread orderbook stream.
    /// </summary>
    /// <param name="symbol">Spread symbol</param>
    /// <param name="depth">Depth. Currently 25.</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadOrderBookAsync(string symbol, int depth, Action<WebSocketDataEvent<BybitSpreadOrderbook>> handler, CancellationToken ct = default)
    {
        depth.ValidateIntValues(nameof(depth), 25);

        var internalHandler = new Action<WebSocketDataEvent<JToken>>(data =>
        {
            var topic = data.Data["topic"]; if (topic == null) return;
            var internalData = data.Data["data"]; if (internalData == null) return;

            var desResult = Deserialize<BybitSpreadOrderbook>(internalData);
            if (!desResult)
            {
                this._logger.Log(LogLevel.Warning, $"Failed to deserialize {nameof(BybitSpreadOrderbook)} object: " + desResult.Error);
                return;
            }

            desResult.Data.Timestamp = GetLong(data.Data, "ts");
            desResult.Data.CreateTimestamp = GetLong(data.Data, "cts");
            handler(data.As(desResult.Data, topic.ToString()));
        });

        return await SubscribeAsync(GetSpreadStreamAddress(), CreateSubscribeRequest([$"orderbook.{depth}.{symbol}"]), string.Empty, false, internalHandler, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Subscribe to spread public trade updates.
    /// </summary>
    /// <param name="symbol">Spread symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadTradesAsync(string symbol, Action<WebSocketDataEvent<BybitSpreadPublicTrade>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetSpreadStreamAddress(), $"publicTrade.{symbol}", false, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to spread ticker updates.
    /// </summary>
    /// <param name="symbol">Spread symbol</param>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadTickersAsync(string symbol, Action<WebSocketDataEvent<BybitSpreadTicker>> handler, CancellationToken ct = default)
        => await SubscribeToObjectTopicAsync(GetSpreadStreamAddress(), $"tickers.{symbol}", false, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to spread order updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadOrderUpdatesAsync(Action<WebSocketDataEvent<BybitSpreadOrderUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "spread.order", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to spread execution updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToSpreadExecutionUpdatesAsync(Action<WebSocketDataEvent<BybitSpreadExecutionUpdate>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "spread.execution", true, handler, ct).ConfigureAwait(false);
    #endregion

    #region RFQ Streams
    /// <summary>
    /// Subscribe to RFQ public trade updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToRfqPublicTradesAsync(Action<WebSocketDataEvent<BybitRfqPublicTrade>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetRfqStreamAddress(), "rfq.open.public.trades", false, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to RFQ quote updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToRfqQuoteUpdatesAsync(Action<WebSocketDataEvent<BybitRfqQuote>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "rfq.open.quotes", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to RFQ execution updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToRfqExecutionUpdatesAsync(Action<WebSocketDataEvent<BybitRfqTrade>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "rfq.open.trades", true, handler, ct).ConfigureAwait(false);

    /// <summary>
    /// Subscribe to RFQ inquiry updates.
    /// </summary>
    /// <param name="handler">Update Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<CallResult<WebSocketUpdateSubscription>> SubscribeToRfqUpdatesAsync(Action<WebSocketDataEvent<BybitRfqInfo>> handler, CancellationToken ct = default)
        => await SubscribeToArrayTopicAsync(GetStreamAddress(default, true), "rfq.open.rfqs", true, handler, ct).ConfigureAwait(false);
    #endregion

    #region WebSocket Trade
    /// <summary>
    /// Create an order through WebSocket order entry.
    /// </summary>
    /// <param name="request">Place order request.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitTradingOrderId>>> PlaceOrderAsync(BybitPlaceOrderRequest request, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitTradingOrderId>>("order.create", CreateWebSocketPlaceOrderParameters(request), requestId, receiveWindow, referer).ConfigureAwait(false);

    /// <summary>
    /// Amend an order through WebSocket order entry.
    /// </summary>
    /// <param name="request">Amend order request.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitTradingOrderId>>> AmendOrderAsync(BybitAmendOrderRequest request, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitTradingOrderId>>("order.amend", CreateWebSocketAmendOrderParameters(request), requestId, receiveWindow, referer).ConfigureAwait(false);

    /// <summary>
    /// Cancel an order through WebSocket order entry.
    /// </summary>
    /// <param name="request">Cancel order request.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitTradingOrderId>>> CancelOrderAsync(BybitCancelOrderRequest request, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitTradingOrderId>>("order.cancel", CreateWebSocketCancelOrderParameters(request), requestId, receiveWindow, referer).ConfigureAwait(false);

    /// <summary>
    /// Create batch orders through WebSocket order entry.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="requests">Batch place order requests.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchPlaceOrder>>>> PlaceOrdersAsync(BybitCategory category, IEnumerable<BybitBatchPlaceOrderRequest> requests, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchPlaceOrder>>>("order.create-batch", CreateWebSocketBatchOrderParameters(category, requests), requestId, receiveWindow, referer).ConfigureAwait(false);

    /// <summary>
    /// Amend batch orders through WebSocket order entry.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="requests">Batch amend order requests.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchAmendOrder>>>> AmendOrdersAsync(BybitCategory category, IEnumerable<BybitBatchAmendOrderRequest> requests, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchAmendOrder>>>("order.amend-batch", CreateWebSocketBatchOrderParameters(category, requests), requestId, receiveWindow, referer).ConfigureAwait(false);

    /// <summary>
    /// Cancel batch orders through WebSocket order entry.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="requests">Batch cancel order requests.</param>
    /// <param name="requestId">Optional request ID.</param>
    /// <param name="receiveWindow">Receive window in milliseconds.</param>
    /// <param name="referer">Optional referer header.</param>
    /// <returns></returns>
    public async Task<CallResult<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchCancelOrder>>>> CancelOrdersAsync(BybitCategory category, IEnumerable<BybitBatchCancelOrderRequest> requests, string? requestId = null, long receiveWindow = 5000, string? referer = null)
        => await QueryTradeAsync<BybitWebSocketTradeResponse<BybitWebSocketTradeList<BybitTradingBatchCancelOrder>>>("order.cancel-batch", CreateWebSocketBatchOrderParameters(category, requests), requestId, receiveWindow, referer).ConfigureAwait(false);
    #endregion
}
