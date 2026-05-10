namespace Bybit.Api.Enums;

/// <summary>
/// Web3 pagination direction.
/// </summary>
public enum BybitWeb3PaginationDirection
{
    /// <summary>
    /// Previous page.
    /// </summary>
    [Map("prev")]
    Previous,

    /// <summary>
    /// Next page.
    /// </summary>
    [Map("next")]
    Next,
}
