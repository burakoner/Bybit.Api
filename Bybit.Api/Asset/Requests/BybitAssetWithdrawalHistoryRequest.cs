namespace Bybit.Api.Asset;

/// <summary>
/// Withdrawal history request.
/// </summary>
public record BybitAssetWithdrawalHistoryRequest
{
    [JsonProperty("withdrawID", NullValueHandling = NullValueHandling.Ignore)]
    public string? WithdrawId { get; set; }

    [JsonProperty("txID", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionId { get; set; }

    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    [JsonProperty("withdrawType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitWithdrawalType? Type { get; set; }

    [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? StartTime { get; set; }

    [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? EndTime { get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
