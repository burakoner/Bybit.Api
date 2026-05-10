namespace Bybit.Api.Web3;

/// <summary>
/// Web3 order list result.
/// </summary>
public record BybitWeb3OrderResult
{
    /// <summary>
    /// Total order count.
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Current page number.
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// Orders.
    /// </summary>
    public List<BybitWeb3Order> Orders { get; set; } = [];
}
