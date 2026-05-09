namespace Bybit.Api.Asset;

/// <summary>
/// Single coin balance request.
/// </summary>
public record BybitAssetBalanceRequest
{
    public BybitAssetBalanceRequest(string asset, BybitAccountType account)
    {
        Asset = asset;
        Account = account;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Account type.
    /// </summary>
    [JsonProperty("accountType")]
    public BybitAccountType Account { get; set; }

    /// <summary>
    /// To account type.
    /// </summary>
    [JsonProperty("toAccountType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitAccountType? ToAccount { get; set; }

    /// <summary>
    /// UID.
    /// </summary>
    [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? MemberId { get; set; }

    /// <summary>
    /// To UID.
    /// </summary>
    [JsonProperty("toMemberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ToMemberId { get; set; }

    /// <summary>
    /// Whether to include bonus.
    /// </summary>
    [JsonIgnore]
    public bool? WithBonus { get; set; }

    /// <summary>
    /// Whether to query delay withdraw/transfer safe amount.
    /// </summary>
    [JsonIgnore]
    public bool? WithTransferSafeAmount { get; set; }

    /// <summary>
    /// Whether to query LTV transfer safe amount.
    /// </summary>
    [JsonIgnore]
    public bool? WithLtvTransferSafeAmount { get; set; }
}
