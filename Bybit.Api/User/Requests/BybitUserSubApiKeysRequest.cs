namespace Bybit.Api.User;

/// <summary>
/// Sub account API key list request.
/// </summary>
public record BybitUserSubApiKeysRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="subMemberId">Sub UID.</param>
    public BybitUserSubApiKeysRequest(string subMemberId)
    {
        SubMemberId = subMemberId;
    }

    /// <summary>
    /// Sub UID.
    /// </summary>
    [JsonProperty("subMemberId")]
    public string SubMemberId { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
