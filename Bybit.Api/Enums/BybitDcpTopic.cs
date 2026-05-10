namespace Bybit.Api.Enums;

/// <summary>
/// Bybit DCP WebSocket topic scope.
/// </summary>
public enum BybitDcpTopic
{
    /// <summary>
    /// Futures and perpetual orders.
    /// </summary>
    [Map("future")]
    Future = 1,

    /// <summary>
    /// Spot orders.
    /// </summary>
    [Map("spot")]
    Spot = 2,

    /// <summary>
    /// Option orders.
    /// </summary>
    [Map("option")]
    Option = 3,
}
