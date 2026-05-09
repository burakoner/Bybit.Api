namespace Bybit.Api.Asset;

/// <summary>
/// Allowed deposit coin request.
/// </summary>
public record BybitAssetDepositAllowedRequest
{
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public string? Network { get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
