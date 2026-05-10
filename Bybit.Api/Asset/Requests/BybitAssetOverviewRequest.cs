namespace Bybit.Api.Asset;

/// <summary>
/// Asset overview request.
/// </summary>
public record BybitAssetOverviewRequest
{
    /// <summary>
    /// Sub UID to query.
    /// </summary>
    [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? MemberId { get; set; }

    /// <summary>
    /// Currency used to value assets.
    /// </summary>
    [JsonProperty("valuationCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? ValuationCurrency { get; set; }

    /// <summary>
    /// Account type to include in the overview.
    /// </summary>
    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public string? AccountType { get; set; }
}
