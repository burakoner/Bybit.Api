namespace Bybit.Api.Sbe;

/// <summary>
/// SBE batch create order request.
/// </summary>
public record BybitSbeBatchCreateOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeBatchCreateOrderRequest"/> record.
    /// </summary>
    public BybitSbeBatchCreateOrderRequest(BybitSbeCategory category, IEnumerable<BybitSbeCreateOrderRequest> orders)
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
    /// Orders to create.
    /// </summary>
    public List<BybitSbeCreateOrderRequest> Orders { get; set; }
}
