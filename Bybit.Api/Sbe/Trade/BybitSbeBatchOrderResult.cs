namespace Bybit.Api.Sbe;

/// <summary>
/// SBE batch order result.
/// </summary>
public record BybitSbeBatchOrderResult
{
    /// <summary>
    /// Per-order result code.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Product category.
    /// </summary>
    public BybitSbeCategory Category { get; set; }

    /// <summary>
    /// Internal numeric symbol ID.
    /// </summary>
    public long SymbolId { get; set; }

    /// <summary>
    /// Exchange-assigned order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Client order ID.
    /// </summary>
    public string OrderLinkId { get; set; } = string.Empty;

    /// <summary>
    /// Per-order message.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp string.
    /// </summary>
    public string CreateAt { get; set; } = string.Empty;
}
