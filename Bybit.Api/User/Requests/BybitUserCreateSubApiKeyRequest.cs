namespace Bybit.Api.User;

/// <summary>
/// Create sub account API key request.
/// </summary>
public record BybitUserCreateSubApiKeyRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="subUserId">Sub user ID.</param>
    /// <param name="readOnly">Whether the API key is read-only.</param>
    /// <param name="permissions">API key permissions.</param>
    public BybitUserCreateSubApiKeyRequest(long subUserId, bool readOnly, BybitUserApiKeyPermissions permissions)
    {
        SubUserId = subUserId;
        ReadOnly = readOnly;
        Permissions = permissions;
    }

    /// <summary>
    /// Sub user ID.
    /// </summary>
    [JsonProperty("subuid")]
    public long SubUserId { get; set; }

    /// <summary>
    /// Whether the API key is read-only.
    /// </summary>
    [JsonIgnore]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// API key permissions.
    /// </summary>
    [JsonProperty("permissions")]
    public BybitUserApiKeyPermissions Permissions { get; set; }

    /// <summary>
    /// IP binding string.
    /// </summary>
    [JsonProperty("ips", NullValueHandling = NullValueHandling.Ignore)]
    public string? IpAddresses { get; set; }

    /// <summary>
    /// Remark.
    /// </summary>
    [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
    public string? Label { get; set; }
}
