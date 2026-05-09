namespace Bybit.Api.Enums;

/// <summary>
/// Bybit RFQ trader type.
/// </summary>
public enum BybitRfqTraderType
{
    /// <summary>
    /// Quote side.
    /// </summary>
    [Map("quote")]
    Quote = 1,

    /// <summary>
    /// Request side.
    /// </summary>
    [Map("request")]
    Request = 2,
}
