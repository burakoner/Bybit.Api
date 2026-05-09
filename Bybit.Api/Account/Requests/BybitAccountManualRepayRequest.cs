namespace Bybit.Api.Account;

/// <summary>
/// Bybit account manual repay request.
/// </summary>
public record BybitAccountManualRepayRequest
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string? Asset { get; set; }

    /// <summary>
    /// Repay amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitAccountRepaymentType? RepaymentType { get; set; }
}
