namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal address list request.
/// </summary>
public record BybitAssetWithdrawalAddressRequest
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
    public string? Chain { get; set; }

    /// <summary>
    /// Withdrawal address type.
    /// </summary>
    [JsonProperty("addressType", NullValueHandling = NullValueHandling.Ignore)]
    public int? AddressType { get; set; }

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
