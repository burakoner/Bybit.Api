namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card reward mall currency type.
/// </summary>
public enum BybitCardMallCurrencyType
{
    /// <summary>
    /// Fiat.
    /// </summary>
    [Map("1")]
    Fiat = 1,

    /// <summary>
    /// Crypto.
    /// </summary>
    [Map("2")]
    Crypto = 2,

    /// <summary>
    /// Points.
    /// </summary>
    [Map("3")]
    Point = 3,
}
