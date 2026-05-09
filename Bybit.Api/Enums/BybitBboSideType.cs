namespace Bybit.Api.Enums;

/// <summary>
/// Bybit best bid/offer side type.
/// </summary>
public enum BybitBboSideType
{
    /// <summary>
    /// Use the order price on the orderbook in the same direction as the side.
    /// </summary>
    [Map("Queue")]
    Queue = 1,

    /// <summary>
    /// Use the order price on the orderbook in the opposite direction as the side.
    /// </summary>
    [Map("Counterparty")]
    Counterparty = 2,
}
