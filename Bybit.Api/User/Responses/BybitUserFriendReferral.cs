namespace Bybit.Api.User;

/// <summary>
/// Bybit friend referral record.
/// </summary>
public record BybitUserFriendReferral
{
    /// <summary>
    /// Referral relationship ID.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Invitee user ID.
    /// </summary>
    public long InviteeUid { get; set; }

    /// <summary>
    /// Invitation relationship status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Created timestamp in seconds.
    /// </summary>
    public long CreatedAt { get; set; }

    /// <summary>
    /// Updated timestamp in seconds.
    /// </summary>
    public long UpdatedAt { get; set; }

    /// <summary>
    /// Created time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime { get => DateTimeOffset.FromUnixTimeSeconds(CreatedAt).UtcDateTime; }

    /// <summary>
    /// Updated time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdatedTime { get => DateTimeOffset.FromUnixTimeSeconds(UpdatedAt).UtcDateTime; }
}
