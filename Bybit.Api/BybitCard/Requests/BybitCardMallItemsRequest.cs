namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card reward mall item list request.
/// </summary>
public record BybitCardMallItemsRequest
{
    /// <summary>
    /// Page number.
    /// </summary>
    [JsonProperty("pageNo", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageNo { get; set; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; }

    /// <summary>
    /// Item type.
    /// </summary>
    [JsonProperty("itemType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardMallItemType? ItemType { get; set; }

    /// <summary>
    /// Item sub-type.
    /// </summary>
    [JsonProperty("itemBizType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardMallItemBizType? ItemBusinessType { get; set; }

    /// <summary>
    /// Sort type.
    /// </summary>
    [JsonProperty("orderBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardMallOrderBy? OrderBy { get; set; }

    /// <summary>
    /// Whether to sort in ascending order.
    /// </summary>
    [JsonProperty("asc", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Ascending { get; set; }

    /// <summary>
    /// Query source.
    /// </summary>
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardMallSource? Source { get; set; }
}
