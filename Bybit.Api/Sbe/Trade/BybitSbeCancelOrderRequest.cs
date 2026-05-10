namespace Bybit.Api.Sbe;

/// <summary>
/// SBE cancel order request.
/// </summary>
public record BybitSbeCancelOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeCancelOrderRequest"/> record.
    /// </summary>
    public BybitSbeCancelOrderRequest(BybitSbeCategory category, long symbolId)
    {
        Category = category;
        SymbolId = symbolId;
    }

    /// <summary>
    /// API request header.
    /// </summary>
    public BybitSbeApiRequestHeader Header { get; set; } = new();

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
    public string? OrderId { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    public string? OrderLinkId { get; set; }
}
