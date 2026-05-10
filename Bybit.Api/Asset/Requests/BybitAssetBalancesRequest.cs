namespace Bybit.Api.Asset;

/// <summary>
/// All coins balance request.
/// </summary>
public record BybitAssetBalancesRequest
{
    /// <summary>
    /// Initializes a new all-coins balance request.
    /// </summary>
    /// <param name="account">Account type to query.</param>
    public BybitAssetBalancesRequest(BybitAccountType account)
    {
        Account = account;
    }

    /// <summary>
    /// Account type.
    /// </summary>
    [JsonProperty("accountType")]
    public BybitAccountType Account { get; set; }

    /// <summary>
    /// Sub UID.
    /// </summary>
    [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? MemberId { get; set; }

    /// <summary>
    /// Coin name, or comma separated coin names where supported.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    /// <summary>
    /// Whether to include bonus.
    /// </summary>
    [JsonIgnore]
    public bool? WithBonus { get; set; }
}
