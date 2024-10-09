namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Internal Deposit Status
/// </summary>
public enum BybitInternalDepositStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("0")]
    Unknown = 0,

    /// <summary>
    /// Processing
    /// </summary>
    [Map("1")]
    Processing = 1,

    /// <summary>
    /// Success
    /// </summary>
    [Map("2")]
    Success = 2,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("3")]
    Failed = 3,
}