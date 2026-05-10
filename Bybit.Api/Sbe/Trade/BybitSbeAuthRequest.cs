namespace Bybit.Api.Sbe;

/// <summary>
/// SBE authentication request.
/// </summary>
public record BybitSbeAuthRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeAuthRequest"/> record.
    /// </summary>
    public BybitSbeAuthRequest(string requestId, string apiKey, long expires, string signature)
    {
        RequestId = requestId;
        ApiKey = apiKey;
        Expires = expires;
        Signature = signature;
    }

    /// <summary>
    /// Client request ID.
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// API key.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Expiry timestamp in milliseconds.
    /// </summary>
    public long Expires { get; set; }

    /// <summary>
    /// HMAC-SHA256 signature string.
    /// </summary>
    public string Signature { get; set; }
}
