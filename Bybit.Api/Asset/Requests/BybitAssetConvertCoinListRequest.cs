namespace Bybit.Api.Asset;

/// <summary>
/// Convert coin list request.
/// </summary>
public record BybitAssetConvertCoinListRequest
{
    public BybitAssetConvertCoinListRequest(string accountType)
    {
        AccountType = accountType;
    }

    [JsonProperty("accountType")]
    public string AccountType { get; set; }

    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
    public int? Side { get; set; }
}
