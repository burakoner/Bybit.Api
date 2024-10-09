#if NETSTANDARD2_1_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Bybit.Api.Models;

/// <summary>
/// Bybit Rest Call Result
/// </summary>
/// <param name="request"></param>
/// <param name="response"></param>
/// <param name="error"></param>
public class BybitRestCallResult(RestCallRequest request, RestCallResponse response, Error error) : RestCallResult(request, response, error)
{
    /// <summary>
    /// Next Page Cursor
    /// </summary>
    public string Cursor { get; set; }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="responseCode"></param>
    /// <param name="responseHeaders"></param>
    /// <param name="responseTime"></param>
    /// <param name="requestUrl"></param>
    /// <param name="requestBody"></param>
    /// <param name="requestMethod"></param>
    /// <param name="requestHeaders"></param>
    /// <param name="error"></param>
    public BybitRestCallResult(
        HttpStatusCode? responseCode,
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders,
        TimeSpan? responseTime,
        string requestUrl,
        string requestBody,
        HttpMethod requestMethod,
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> requestHeaders,
        Error error) : this(
            new RestCallRequest(requestUrl, requestMethod, requestBody, requestHeaders),
            new RestCallResponse(responseTime, responseCode, responseHeaders),
            error)
    { }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="error"></param>
    public BybitRestCallResult(Error error) : this(null, null, error) { }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public new BybitRestCallResult AsError(Error error)
    {
        return new BybitRestCallResult(Request, Response, error);
    }
}

/// <summary>
/// Bybit Rest Call Result
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="request"></param>
/// <param name="response"></param>
/// <param name="data"></param>
/// <param name="raw"></param>
/// <param name="error"></param>
public class BybitRestCallResult<T>(RestCallRequest request, RestCallResponse response, T data, string raw, Error error) : RestCallResult<T>(request, response, data, raw, error)
{
    /// <summary>
    /// Next Page Cursor
    /// </summary>
    public string Cursor { get; set; }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="responseCode"></param>
    /// <param name="responseHeaders"></param>
    /// <param name="responseTime"></param>
    /// <param name="responseRaw"></param>
    /// <param name="requestUrl"></param>
    /// <param name="requestBody"></param>
    /// <param name="requestMethod"></param>
    /// <param name="requestHeaders"></param>
    /// <param name="data"></param>
    /// <param name="error"></param>
    public BybitRestCallResult(
        HttpStatusCode? responseCode,
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders,
        TimeSpan? responseTime,
        string responseRaw,
        string requestUrl,
        string requestBody,
        HttpMethod requestMethod,
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> requestHeaders,
        T data,
        Error error) : this(
            new RestCallRequest(requestUrl, requestMethod, requestBody, requestHeaders),
            new RestCallResponse(responseTime, responseCode, responseHeaders),
            data, responseRaw, error)
    { }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="error"></param>
    public BybitRestCallResult(Error error) : this(null, null, default, null, error) { }

    /// <summary>
    /// Bybit Rest Call Result
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="response">Response</param>
    /// <param name="raw">Raw Data</param>
    /// <param name="error">Error</param>
    public BybitRestCallResult(RestCallRequest request, RestCallResponse response, string raw, Error error) : this(request, response, default, raw, error) { }

    /// <summary>
    /// Copy the RestCallResult to a new data type
    /// </summary>
    /// <typeparam name="K">The new type</typeparam>
    /// <param name="data">The data of the new type</param>
    /// <returns></returns>
    public new BybitRestCallResult<K> As<K>(
#if NETSTANDARD2_1_OR_GREATER
        [AllowNull] 
        #endif
        K data)
    {
        return new BybitRestCallResult<K>(Request, Response, data, Raw, Error);
    }

    internal BybitRestCallResult<K> As<K>(
#if NETSTANDARD2_1_OR_GREATER
    [AllowNull] 
        #endif
        K data, string cursor)
    {
        return new BybitRestCallResult<K>(Request, Response, data, Raw, Error)
        {
            Cursor = cursor
        };
    }

    /// <summary>
    /// Copy the WebCallResult to a new data type
    /// </summary>
    /// <typeparam name="K">The new type</typeparam>
    /// <param name="error">The error returned</param>
    /// <returns></returns>
    public new RestCallResult<K> AsError<K>(Error error)
    {
        return new RestCallResult<K>(Request, Response, default, Raw, error);
    }
}
