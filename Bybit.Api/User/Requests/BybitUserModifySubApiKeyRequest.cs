namespace Bybit.Api.User;

/// <summary>
/// Modify sub account API key request.
/// </summary>
public record BybitUserModifySubApiKeyRequest : BybitUserModifyApiKeyRequest
{
    /// <summary>
    /// Sub account API key.
    /// </summary>
    [JsonProperty("apikey", NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiKey { get; set; }
}
