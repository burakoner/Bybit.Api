namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card reward mall item type.
/// </summary>
public enum BybitCardMallItemType
{
    /// <summary>
    /// Virtual item.
    /// </summary>
    [Map("1")]
    Virtual = 1,

    /// <summary>
    /// Physical item.
    /// </summary>
    [Map("2")]
    Physical = 2,
}
