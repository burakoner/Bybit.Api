namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Sub Account Type
/// </summary>
public enum BybitSubAccountType
{
    /// <summary>
    /// Normal Sub Account
    /// </summary>
    [Label("1")]
    NormalSubAccount,

    /// <summary>
    /// Custodial Sub Account
    /// </summary>
    [Label("6")]
    CustodialSubAccount,
}