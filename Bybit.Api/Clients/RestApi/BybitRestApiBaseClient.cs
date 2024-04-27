namespace Bybit.Api.Clients.RestApi;

internal class BybitRestApiBaseClient : RestApiClient
{
    // Internal
    internal ILogger Log { get => this._logger; }
    internal TimeSyncState TimeSyncState = new("Bybit RestApi");

    // Root Client
    internal BybitRestApiClient RootClient { get; }
    internal CultureInfo CI { get { return RootClient.CI; } }
    internal new BybitRestApiClientOptions ClientOptions { get { return RootClient.ClientOptions; } }

    internal BybitRestApiBaseClient(BybitRestApiClient root) : base(root.Logger, root.ClientOptions)
    {
        RootClient = root;

        RequestBodyFormat = RestRequestBodyFormat.Json;
        ArraySerialization = ArraySerialization.MultipleValues;

        Thread.CurrentThread.CurrentCulture = CI;
        Thread.CurrentThread.CurrentUICulture = CI;
    }

    #region Override Methods
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BybitAuthenticationProvider(credentials);

    protected override Error ParseErrorResponse(JToken error)
    {
        if (!error.HasValues)
            return new ServerError(error.ToString());

        if ((error["msg"] == null && error["code"] == null) || (string.IsNullOrWhiteSpace((string)error["msg"])))
            return new ServerError(error.ToString());

        if (error["msg"] != null && error["code"] == null || (!string.IsNullOrWhiteSpace((string)error["msg"])))
            return new ServerError((string)error["message"]!);

        return new ServerError((int)error["code"], (string)error["message"]);
    }

    protected override async Task<RestCallResult<DateTime>> GetServerTimestampAsync()
    {
        var serverTime = await RootClient.Market.GetServerTimeAsync();
        return serverTime.As(serverTime.Data.Time);
    }

    protected override TimeSyncInfo GetTimeSyncInfo()
        => new(this._logger, ClientOptions.AutoTimestamp, ClientOptions.TimestampRecalculationInterval, TimeSyncState);

    protected override TimeSpan GetTimeOffset()
        => TimeSyncState.TimeOffset;
    #endregion

    #region Internal Methods
    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="apiKey">The api key</param>
    /// <param name="apiSecret">The api secret</param>
    internal virtual void SetApiCredentials(string apiKey, string apiSecret)
    {
        SetApiCredentials(new ApiCredentials(apiKey, apiSecret));
    }

    internal async Task<RestCallResult> SendBybitRequest(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, Dictionary<string, object> queryParameters = null, Dictionary<string, object> bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = CI;
        Thread.CurrentThread.CurrentUICulture = CI;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new RestCallResult(result.Request, result.Response, result.Error);
        if (result.Data.ReturnCode > 0) return new RestCallResult(result.Request, result.Response, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new RestCallResult(result.Request, result.Response, result.Error);
    }

    internal async Task<RestCallResult<T>> SendBybitRequest<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, Dictionary<string, object> queryParameters = null, Dictionary<string, object> bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = CI;
        Thread.CurrentThread.CurrentUICulture = CI;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse<T>>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new RestCallResult<T>(result.Request, result.Response, result.Raw, result.Error);
        if (result.Data.ReturnCode > 0) return new RestCallResult<T>(result.Request, result.Response,  result.Raw, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new RestCallResult<T>(result.Request, result.Response, result.Data.Result, result.Raw, result.Error);
    }

    internal async Task<RestCallResult<BybitRestApiResponse<T1, T2>>> SendBybitRequest<T1, T2>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, Dictionary<string, object> queryParameters = null, Dictionary<string, object> bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = CI;
        Thread.CurrentThread.CurrentUICulture = CI;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse<T1, T2>>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new RestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response, result.Raw, result.Error);
        if (result.Data.ReturnCode > 0) return new RestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response,  result.Raw, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new RestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response, result.Data, result.Raw, result.Error);
    }

    internal async Task<RestCallResult<T>> SendRequest<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, Dictionary<string, object> queryParameters = null, Dictionary<string, object> bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1) where T : class
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = CI;
        Thread.CurrentThread.CurrentUICulture = CI;

        // Do Request
        var result = await SendRequestAsync<T>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        return result;
    }

    internal Uri GetUri(string endpoint, string[] parameters = null)
    {
        return new Uri($"{ClientOptions.BaseAddress.TrimEnd('/')}/{endpoint.TrimStart('/')}");
    }
    #endregion

}