namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Transfer Status
/// </summary>
public enum BybitTransferStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("UNKNOWN", "STATUS_UNKNOWN")]
    Unknown = 0,

    /// <summary>
    /// Success
    /// </summary>
    [Map("SUCCESS")]
    Success = 1,

    /// <summary>
    /// Pending
    /// </summary>
    [Map("PENDING")]
    Pending = 2,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("FAILED")]
    Failed = 3,
}