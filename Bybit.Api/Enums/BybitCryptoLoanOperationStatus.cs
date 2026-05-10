namespace Bybit.Api.Enums;

/// <summary>
/// Crypto loan operation status.
/// </summary>
public enum BybitCryptoLoanOperationStatus
{
    /// <summary>
    /// Success.
    /// </summary>
    [Map("1")]
    Success = 1,

    /// <summary>
    /// Processing.
    /// </summary>
    [Map("2")]
    Processing = 2,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("3")]
    Failed = 3,
}
