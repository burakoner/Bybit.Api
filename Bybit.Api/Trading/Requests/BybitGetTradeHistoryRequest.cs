namespace Bybit.Api.Trading;

/// <summary>
/// Get trade history request.
/// </summary>
public record BybitGetTradeHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitGetTradeHistoryRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitGetTradeHistoryRequest(BybitCategory category)
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
    /// Order ID.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// User customised order ID.
    /// </summary>
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Settle coin.
    /// </summary>
    public string? SettleAsset { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Execution type.
    /// </summary>
    public BybitExecutionType? ExecutionType { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
