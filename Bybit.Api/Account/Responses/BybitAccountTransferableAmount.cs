namespace Bybit.Api.Account;

/// <summary>
/// Bybit unified account transferable amount.
/// </summary>
public record BybitAccountTransferableAmount
{
    /// <summary>
    /// Available withdrawal amount after collateral conversion, with current LTV considered.
    /// </summary>
    public decimal AvailableWithdrawal { get; set; }

    /// <summary>
    /// Available withdrawal amount without collateral conversion, keyed by coin.
    /// </summary>
    public Dictionary<string, decimal> AvailableWithdrawalMap { get; set; } = [];
}
