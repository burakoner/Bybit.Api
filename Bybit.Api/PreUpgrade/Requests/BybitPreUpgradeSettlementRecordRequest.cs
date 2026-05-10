namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade USDC session settlement request.
/// </summary>
public record BybitPreUpgradeSettlementRecordRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeSettlementRecordRequest"/> record.
    /// </summary>
    public BybitPreUpgradeSettlementRecordRequest(BybitCategory category)
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
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
