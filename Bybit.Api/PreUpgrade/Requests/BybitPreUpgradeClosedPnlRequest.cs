namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade closed PnL request.
/// </summary>
public record BybitPreUpgradeClosedPnlRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeClosedPnlRequest"/> record.
    /// </summary>
    public BybitPreUpgradeClosedPnlRequest(BybitCategory category, string symbol)
    {
        Category = category;
        Symbol = symbol;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

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
