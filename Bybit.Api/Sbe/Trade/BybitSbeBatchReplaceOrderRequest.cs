namespace Bybit.Api.Sbe;

/// <summary>
/// SBE batch replace order request.
/// </summary>
public record BybitSbeBatchReplaceOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeBatchReplaceOrderRequest"/> record.
    /// </summary>
    public BybitSbeBatchReplaceOrderRequest(BybitSbeCategory category, IEnumerable<BybitSbeReplaceOrderRequest> orders)
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
    /// Orders to replace.
    /// </summary>
    public List<BybitSbeReplaceOrderRequest> Orders { get; set; }
}
