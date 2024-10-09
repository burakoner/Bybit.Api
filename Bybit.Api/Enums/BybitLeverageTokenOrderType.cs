namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leverage Token Order Type
/// </summary>
public enum BybitLeverageTokenOrderType
{
    /// <summary>
    /// Purchase
    /// </summary>
    [Map("1")]
    Purchase = 1,

    /// <summary>
    /// Redemption
    /// </summary>
    [Map("2")]
    Redemption = 2,
}