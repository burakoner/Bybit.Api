namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leveraged Token Order Type
/// </summary>
public enum BybitLeverageTokenOrderType
{
    /// <summary>
    /// Purchase
    /// </summary>
    [Label("1")]
    Purchase,

    /// <summary>
    /// Redemption
    /// </summary>
    [Label("2")]
    Redemption,
}