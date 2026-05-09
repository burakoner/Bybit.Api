namespace Bybit.Api.User;

/// <summary>
/// Paged sub account list request.
/// </summary>
public record BybitUserSubAccountListRequest
{
    /// <summary>
    /// Data size per page.
    /// </summary>
    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    [JsonProperty("nextCursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
