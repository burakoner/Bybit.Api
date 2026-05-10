namespace Bybit.Api.Asset;

/// <summary>
/// Allowed deposit coin request.
/// </summary>
public record BybitAssetDepositAllowedRequest
{
    /// <summary>
    /// Coin name, uppercase only.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    /// <summary>
    /// Chain name.
    /// </summary>
    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public string? Network { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Page cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
