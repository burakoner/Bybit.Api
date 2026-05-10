namespace Bybit.Api.Enums;

/// <summary>
/// Web3 order status.
/// </summary>
public enum BybitWeb3OrderStatus
{
    /// <summary>
    /// Processing.
    /// </summary>
    [Map("1")]
    Processing = 1,

    /// <summary>
    /// Success.
    /// </summary>
    [Map("2")]
    Success = 2,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("3")]
    Failed = 3,
}
