namespace Bybit.Api.Affiliate;

/// <summary>
/// Affiliate user list request.
/// </summary>
public record BybitAffiliateUserListRequest
{
    /// <summary>
    /// Data size per page. [0, 1000].
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public int? Size { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }

    /// <summary>
    /// Whether to return deposit info.
    /// </summary>
    [JsonProperty("needDeposit", NullValueHandling = NullValueHandling.Ignore)]
    public bool? NeedDeposit { get; set; }

    /// <summary>
    /// Whether to return 30 day trading info.
    /// </summary>
    [JsonProperty("need30", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Need30Day { get; set; }

    /// <summary>
    /// Whether to return 365 day trading info.
    /// </summary>
    [JsonProperty("need365", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Need365Day { get; set; }

    /// <summary>
    /// Start date of the query period. Format: YYYY-MM-DD.
    /// </summary>
    [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
    public string? StartDate { get; set; }

    /// <summary>
    /// End date of the query period. Format: YYYY-MM-DD.
    /// </summary>
    [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
    public string? EndDate { get; set; }
}
