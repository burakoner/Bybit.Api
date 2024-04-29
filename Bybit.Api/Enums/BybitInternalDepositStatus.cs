namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Internal Deposit Status
/// </summary>
public enum BybitInternalDepositStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Label("0")]
    Unknown,

    /// <summary>
    /// Processing
    /// </summary>
    [Label("1")]
    Processing,

    /// <summary>
    /// Success
    /// </summary>
    [Label("2")]
    Success,

    /// <summary>
    /// Failed
    /// </summary>
    [Label("3")]
    Failed,
}