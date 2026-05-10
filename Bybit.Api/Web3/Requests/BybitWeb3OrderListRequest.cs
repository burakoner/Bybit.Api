namespace Bybit.Api.Web3;

/// <summary>
/// Web3 order list request.
/// </summary>
public record BybitWeb3OrderListRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3OrderListRequest"/> record.
    /// </summary>
    public BybitWeb3OrderListRequest(int limit, int pageIndex)
    {
        Limit = limit;
        PageIndex = pageIndex;
    }

    /// <summary>
    /// Trade type filter.
    /// </summary>
    [JsonProperty("tradeType", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerEnumConverter))]
    public BybitWeb3TradeType? TradeType { get; set; }

    /// <summary>
    /// Token code filter.
    /// </summary>
    [JsonProperty("tokenCode", NullValueHandling = NullValueHandling.Ignore)]
    public string? TokenCode { get; set; }

    /// <summary>
    /// Order status filter.
    /// </summary>
    [JsonProperty("orderStatus", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(IntegerEnumConverter))]
    public List<BybitWeb3OrderStatus>? OrderStatus { get; set; }

    /// <summary>
    /// Query last N days.
    /// </summary>
    [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
    public int? Days { get; set; }

    /// <summary>
    /// Results per page.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; }

    /// <summary>
    /// Page number.
    /// </summary>
    [JsonProperty("pageIndex")]
    public int PageIndex { get; set; }

    /// <summary>
    /// Pagination direction.
    /// </summary>
    [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
    public BybitWeb3PaginationDirection? Direction { get; set; }
}
