namespace Bybit.Api.Asset;

/// <summary>
/// Asset overview request.
/// </summary>
public record BybitAssetOverviewRequest
{
    [JsonProperty("memberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? MemberId { get; set; }

    [JsonProperty("valuationCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? ValuationCurrency { get; set; }

    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public string? AccountType { get; set; }
}
