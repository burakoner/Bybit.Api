namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade delivery record request.
/// </summary>
public record BybitPreUpgradeDeliveryRecordRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPreUpgradeDeliveryRecordRequest"/> record.
    /// </summary>
    public BybitPreUpgradeDeliveryRecordRequest(BybitCategory category)
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
    /// Expiry date, e.g. 25MAR22.
    /// </summary>
    public string? ExpiryDate { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
