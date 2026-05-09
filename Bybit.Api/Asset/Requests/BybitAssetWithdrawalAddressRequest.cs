namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal address list request.
/// </summary>
public record BybitAssetWithdrawalAddressRequest
{
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
    public string? Chain { get; set; }

    [JsonProperty("addressType", NullValueHandling = NullValueHandling.Ignore)]
    public int? AddressType { get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
