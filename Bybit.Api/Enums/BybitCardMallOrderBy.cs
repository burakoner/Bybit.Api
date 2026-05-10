namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card reward mall sort type.
/// </summary>
public enum BybitCardMallOrderBy
{
    /// <summary>
    /// Priority.
    /// </summary>
    [Map("1")]
    Priority = 1,

    /// <summary>
    /// Listing time.
    /// </summary>
    [Map("2")]
    ListingTime = 2,

    /// <summary>
    /// Price.
    /// </summary>
    [Map("3")]
    Price = 3,
}
