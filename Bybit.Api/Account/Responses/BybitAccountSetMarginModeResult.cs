namespace Bybit.Api.Account;

/// <summary>
/// Bybit set account margin mode result.
/// </summary>
internal record BybitAccountSetMarginModeResult
{
    /// <summary>
    /// Failure reasons. Empty when margin mode was updated successfully.
    /// </summary>
    public List<BybitAccountReason> Reasons { get; set; } = [];
}
