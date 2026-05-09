namespace Bybit.Api.Account;

/// <summary>
/// Bybit account wallet balance request.
/// </summary>
public record BybitAccountWalletBalanceRequest
{
    /// <summary>
    /// Account type.
    /// </summary>
    public BybitAccountType AccountType { get; set; } = BybitAccountType.Unified;

    /// <summary>
    /// Coin name, uppercase only. Multiple coins can be separated by comma.
    /// </summary>
    public string? Asset { get; set; }
}
