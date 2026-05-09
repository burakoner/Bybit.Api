namespace Bybit.Api.Enums;

/// <summary>
/// Bybit withdrawal account source.
/// </summary>
public enum BybitAssetWithdrawAccountType
{
    /// <summary>
    /// Funding wallet.
    /// </summary>
    [Map("FUND")]
    Fund = 1,

    /// <summary>
    /// Unified Trading Account wallet. Bybit uses UTA for this withdraw endpoint.
    /// </summary>
    [Map("UTA")]
    UnifiedTradingAccount = 2,

    /// <summary>
    /// Earn account.
    /// </summary>
    [Map("EARN")]
    Earn = 3,

    /// <summary>
    /// Combo withdrawal. Funding wallet is deducted first, then UTA and Earn.
    /// </summary>
    [Map("FUND,UTA,EARN")]
    FundUnifiedEarn = 4,
}
