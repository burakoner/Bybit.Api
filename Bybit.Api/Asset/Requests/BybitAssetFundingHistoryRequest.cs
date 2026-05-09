namespace Bybit.Api.Asset;

/// <summary>
/// Funding account transaction history request.
/// </summary>
public record BybitAssetFundingHistoryRequest
{
    /// <summary>
    /// Start timestamp in seconds.
    /// </summary>
    [JsonProperty("createTimeFrom", NullValueHandling = NullValueHandling.Ignore)]
    public long? CreateTimeFrom { get; set; }

    /// <summary>
    /// End timestamp in seconds.
    /// </summary>
    [JsonProperty("createTimeTo", NullValueHandling = NullValueHandling.Ignore)]
    public long? CreateTimeTo { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerToStringConverter))]
    public int? Limit { get; set; }

    /// <summary>
    /// Page cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
