namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Transfer Status
/// </summary>
public enum BybitTransferStatus
{
    /// <summary>
    /// Success
    /// </summary>
    [Label("SUCCESS")]
    Success,

    /// <summary>
    /// Pending
    /// </summary>
    [Label("PENDING")]
    Pending,

    /// <summary>
    /// Failed
    /// </summary>
    [Label("FAILED")]
    Failed,
}