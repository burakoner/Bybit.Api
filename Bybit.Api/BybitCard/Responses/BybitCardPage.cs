namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card paginated response.
/// </summary>
public record BybitCardPage<T>
{
    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Current page number.
    /// </summary>
    public int PageNo { get; set; }

    /// <summary>
    /// Total number of records.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Page data.
    /// </summary>
    public List<T> Data { get; set; } = [];
}
