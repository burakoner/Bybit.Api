namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card asset record status code filter.
/// </summary>
public enum BybitCardAssetRecordStatusCode
{
    /// <summary>
    /// Pending.
    /// </summary>
    [Map("0")]
    Pending = 0,

    /// <summary>
    /// Cleared.
    /// </summary>
    [Map("1")]
    Cleared = 1,

    /// <summary>
    /// Declined.
    /// </summary>
    [Map("2")]
    Declined = 2,
}
