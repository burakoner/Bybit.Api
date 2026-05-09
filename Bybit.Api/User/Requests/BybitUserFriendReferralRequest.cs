namespace Bybit.Api.User;

/// <summary>
/// Friend referral list request.
/// </summary>
public record BybitUserFriendReferralRequest
{
    /// <summary>
    /// Invitation relationship status.
    /// </summary>
    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public int? Status { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public int? Size { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
