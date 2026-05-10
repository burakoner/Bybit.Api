namespace Bybit.Api.Enums;

/// <summary>
/// Bybit insurance pool WebSocket topic scope.
/// </summary>
public enum BybitInsurancePool
{
    /// <summary>
    /// USDT contracts.
    /// </summary>
    [Map("USDT")]
    USDT = 1,

    /// <summary>
    /// USDC contracts.
    /// </summary>
    [Map("USDC")]
    USDC = 2,

    /// <summary>
    /// Inverse contracts.
    /// </summary>
    [Map("inverse")]
    Inverse = 3,
}
