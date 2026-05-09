namespace Bybit.Api.User;

/// <summary>
/// Create sub account request.
/// </summary>
public record BybitUserCreateSubAccountRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="type">Sub account type.</param>
    /// <param name="username">Sub account username.</param>
    public BybitUserCreateSubAccountRequest(BybitSubAccountType type, string username)
    {
        Type = type;
        Username = username;
    }

    /// <summary>
    /// Sub account type.
    /// </summary>
    [JsonProperty("memberType")]
    public BybitSubAccountType Type { get; set; }

    /// <summary>
    /// Sub account username.
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; set; }

    /// <summary>
    /// Sub account password.
    /// </summary>
    [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
    public string? Password { get; set; }

    /// <summary>
    /// Whether quick login should be enabled.
    /// </summary>
    [JsonIgnore]
    public bool? QuickLogin { get; set; }

    /// <summary>
    /// Remark.
    /// </summary>
    [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
    public string? Label { get; set; }
}
