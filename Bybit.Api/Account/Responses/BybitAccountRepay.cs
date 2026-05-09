namespace Bybit.Api.Account;

/// <summary>
/// Bybit account manual repay result.
/// </summary>
public record BybitAccountRepay
{
    /// <summary>
    /// Repay result status.
    /// </summary>
    public BybitAccountRepaymentStatus ResultStatus { get; set; }
}
