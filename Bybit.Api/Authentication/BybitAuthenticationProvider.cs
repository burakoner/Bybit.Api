﻿namespace Bybit.Api.Authentication;

internal class BybitAuthenticationProvider(ApiCredentials credentials) : AuthenticationProvider(credentials ?? new ApiCredentials("", ""))
{
    public override void AuthenticateRestApi(RestApiClient apiClient, Uri uri, HttpMethod method, bool signed, ArraySerialization serialization, SortedDictionary<string, object> query, SortedDictionary<string, object> body, string bodyContent, SortedDictionary<string, string> headers)
    {
        // Options
        var options = (BybitRestApiClientOptions)apiClient.ClientOptions;

        // Check Point
        if (!signed && !options.SignPublicRequests)
            return;

        // Check Point
        if (Credentials == null || Credentials.Key == null || Credentials.Secret == null || string.IsNullOrEmpty(Credentials.Key.GetString()))
            throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

        // Set Uri
        uri = uri.SetParameters(query, serialization);

        // Time
        var timeOffset = ((BybitBaseRestApiClient)apiClient).TimeSyncState.TimeOffset;
        var serverTime = DateTime.UtcNow.Add(timeOffset);

        // Signature
        var apikey = Credentials.Key.GetString();
        var receiveWindow = options.ReceiveWindow.TotalMilliseconds.ToString();
        var timestamp = serverTime.ConvertToMilliseconds().ToString();
        var signtext = timestamp + Credentials.Key.GetString() + receiveWindow + uri.Query?.Trim('?') + bodyContent;
        var signature = SignHMACSHA256(signtext).ToLower();

        // Headers
        headers.Add("Referer", options.BrokerId);
        headers.Add("X-BAPI-SIGN", signature);
        headers.Add("X-BAPI-API-KEY", apikey);
        headers.Add("X-BAPI-TIMESTAMP", timestamp);
        headers.Add("X-BAPI-RECV-WINDOW", receiveWindow);
    }

    public string StreamApiSignature(string payload)
    {
        return SignHMACSHA256(payload).ToLower();
    }

    public static string Base64Encode(byte[] plainBytes) => Convert.ToBase64String(plainBytes);
    public static string Base64Encode(string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    public static string Base64Decode(string base64EncodedData) => Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
}
