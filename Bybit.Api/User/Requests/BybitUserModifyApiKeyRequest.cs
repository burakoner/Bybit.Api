namespace Bybit.Api.User;

/// <summary>
/// Modify API key request.
/// </summary>
public record BybitUserModifyApiKeyRequest
{
    /// <summary>
    /// API key permissions.
    /// </summary>
    [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
    public BybitUserApiKeyPermissions? Permissions { get; set; }

    /// <summary>
    /// Whether the API key is read-only.
    /// </summary>
    [JsonIgnore]
    public bool? ReadOnly { get; set; }

    /// <summary>
    /// IP binding string. Only sent by sub API key update requests.
    /// </summary>
    [JsonProperty("ips", NullValueHandling = NullValueHandling.Ignore)]
    public string? IpAddresses { get; set; }
}
