namespace Bybit.Api.Sbe;

/// <summary>
/// SBE batch cancel order request.
/// </summary>
public record BybitSbeBatchCancelOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeBatchCancelOrderRequest"/> record.
    /// </summary>
    public BybitSbeBatchCancelOrderRequest(BybitSbeCategory category, IEnumerable<BybitSbeCancelOrderRequest> orders)
    {
        Category = category;
        Orders = [.. orders];
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
    /// Orders to cancel.
    /// </summary>
    public List<BybitSbeCancelOrderRequest> Orders { get; set; }
}
