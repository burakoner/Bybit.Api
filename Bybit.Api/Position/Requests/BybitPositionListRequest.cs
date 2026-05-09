namespace Bybit.Api.Position;

/// <summary>
/// Get position info request.
/// </summary>
public record BybitPositionListRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionListRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitPositionListRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Base coin. Option only.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Settle coin.
    /// </summary>
    public string? SettleAsset { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
