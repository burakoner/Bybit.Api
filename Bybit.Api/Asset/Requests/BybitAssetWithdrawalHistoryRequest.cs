namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal history request.
/// </summary>
public record BybitAssetWithdrawalHistoryRequest
{
    /// <summary>
    /// Withdrawal ID.
    /// </summary>
    [JsonProperty("withdrawID", NullValueHandling = NullValueHandling.Ignore)]
    public string? WithdrawId { get; set; }

    /// <summary>
    /// Transaction hash ID.
    /// </summary>
    [JsonProperty("txID", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Coin name, uppercase only.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    /// <summary>
    /// Withdrawal type.
    /// </summary>
    [JsonProperty("withdrawType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitWithdrawalType? Type { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? EndTime { get; set; }

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
