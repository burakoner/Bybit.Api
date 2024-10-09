namespace Bybit.Api.Clients.RestApi;

internal class BybitRestApiBaseClient : RestApiClient
{
    // Internal
    internal ILogger Log { get => this._logger; }
    internal TimeSyncState TimeSyncState = new("Bybit RestApi");

    // Root Client
    internal BybitRestApiClient _ { get; }
    internal new BybitRestApiClientOptions ClientOptions { get { return _.ClientOptions; } }
    internal CultureInfo BybitCultureInfo = CultureInfo.InvariantCulture;


    internal BybitRestApiBaseClient(BybitRestApiClient root) : base(root.Logger, root.ClientOptions)
    {
        _ = root;

        RequestBodyFormat = RestRequestBodyFormat.Json;
        ArraySerialization = ArraySerialization.MultipleValues;
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
        var serverTime = await _.Market.GetServerTimeAsync();
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

    internal async Task<BybitRestCallResult> SendBybitRequest(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, ParameterCollection queryParameters = null, ParameterCollection bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = BybitCultureInfo;
        Thread.CurrentThread.CurrentUICulture = BybitCultureInfo;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new BybitRestCallResult(result.Request, result.Response, result.Error);
        if (result.Data.ReturnCode > 0) return new BybitRestCallResult(result.Request, result.Response, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new BybitRestCallResult(result.Request, result.Response, result.Error);
    }
    
    internal async Task<BybitRestCallResult<T>> SendBybitRequest<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, ParameterCollection queryParameters = null, ParameterCollection bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = BybitCultureInfo;
        Thread.CurrentThread.CurrentUICulture = BybitCultureInfo;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse<T>>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new BybitRestCallResult<T>(result.Request, result.Response, result.Raw, result.Error);
        if (result.Data.ReturnCode > 0) return new BybitRestCallResult<T>(result.Request, result.Response,  result.Raw, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new BybitRestCallResult<T>(result.Request, result.Response, result.Data.Result, result.Raw, result.Error);
    }

    internal async Task<BybitRestCallResult<BybitRestApiResponse<T1, T2>>> SendBybitRequest<T1, T2>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, ParameterCollection queryParameters = null, ParameterCollection bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = BybitCultureInfo;
        Thread.CurrentThread.CurrentUICulture = BybitCultureInfo;

        // Do Request
        var result = await SendRequestAsync<BybitRestApiResponse<T1, T2>>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new BybitRestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response, result.Raw, result.Error);
        if (result.Data.ReturnCode > 0) return new BybitRestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response,  result.Raw, new ServerError(result.Data.ReturnCode, result.Data.ReturnMessage));
        return new BybitRestCallResult<BybitRestApiResponse<T1, T2>>(result.Request, result.Response, result.Data, result.Raw, result.Error);
    }

    internal async Task<RestCallResult<T>> SendRequest<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, ParameterCollection queryParameters = null, ParameterCollection bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1) where T : class
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = BybitCultureInfo;
        Thread.CurrentThread.CurrentUICulture = BybitCultureInfo;

        // Do Request
        var result = await SendRequestAsync<T>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        return result;
    }

    internal Uri BuildUri(string endpoint, string[] parameters = null)
    {
        return new Uri($"{ClientOptions.BaseAddress.TrimEnd('/')}/{endpoint.TrimStart('/')}");
    }
    #endregion

}