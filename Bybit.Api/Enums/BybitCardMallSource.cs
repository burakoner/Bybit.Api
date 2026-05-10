namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card reward mall query source.
/// </summary>
public enum BybitCardMallSource
{
    /// <summary>
    /// Default item list.
    /// </summary>
    [Map("0")]
    Default = 0,

    /// <summary>
    /// VIP item list.
    /// </summary>
    [Map("1")]
    Vip = 1,
}
