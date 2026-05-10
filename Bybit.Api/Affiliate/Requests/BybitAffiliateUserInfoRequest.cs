namespace Bybit.Api.Affiliate;

/// <summary>
/// Affiliate user info request.
/// </summary>
public record BybitAffiliateUserInfoRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="uid">Affiliate client master account UID.</param>
    public BybitAffiliateUserInfoRequest(long uid)
    {
        Uid = uid;
    }

    /// <summary>
    /// Affiliate client master account UID.
    /// </summary>
    [JsonProperty("uid")]
    public long Uid { get; set; }
}
