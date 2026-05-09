namespace Bybit.Api.Account;

/// <summary>
/// Bybit classic account transaction log request.
/// </summary>
public record BybitAccountClassicTransactionsRequest
{
    /// <summary>
    /// Currency.
    /// </summary>
    public string? Asset { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Types of transaction logs.
    /// </summary>
    public BybitTransactionType? Type { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
