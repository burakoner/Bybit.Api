namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade transaction log request.
/// </summary>
public record BybitPreUpgradeTransactionLogRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeTransactionLogRequest"/> record.
    /// </summary>
    public BybitPreUpgradeTransactionLogRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Transaction log type.
    /// </summary>
    public BybitTransactionType? Type { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
