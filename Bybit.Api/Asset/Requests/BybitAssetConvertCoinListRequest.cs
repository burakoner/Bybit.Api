namespace Bybit.Api.Asset;

/// <summary>
/// Convert coin list request.
/// </summary>
public record BybitAssetConvertCoinListRequest
{
    /// <summary>
    /// Initializes a new convert coin list request.
    /// </summary>
    /// <param name="accountType">Convert wallet type.</param>
    public BybitAssetConvertCoinListRequest(string accountType)
    {
        AccountType = accountType;
    }

    /// <summary>
    /// Convert wallet type.
    /// </summary>
    [JsonProperty("accountType")]
    public string AccountType { get; set; }

    /// <summary>
    /// Coin to sell or filter by, uppercase only.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    /// <summary>
    /// Convert direction. 0 returns from-coin list; 1 returns to-coin list.
    /// </summary>
    [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
    public int? Side { get; set; }
}
