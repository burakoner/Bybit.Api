namespace Bybit.Api.Account;

/// <summary>
/// Bybit unified account transaction log request.
/// </summary>
public record BybitAccountTransactionsRequest
{
    /// <summary>
    /// Account type.
    /// </summary>
    public BybitAccountType? Account { get; set; }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory? Category { get; set; }

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
    /// Transaction sub type.
    /// </summary>
    public string? TransactionSubType { get; set; }

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
