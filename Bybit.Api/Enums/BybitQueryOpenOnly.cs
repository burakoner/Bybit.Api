namespace Bybit.Api.Enums;

/// <summary>
/// • Unified account &amp; Normal account: 0(default) - query open orders only
/// • Unified account - spot / linear / option: 1
///   Unified account - inverse &amp; Normal account - linear / inverse: 2
///   return cancelled, rejected or totally filled orders by last 10 minutes, A maximum of 500 records are kept under each account.If the Bybit service is restarted due to an update, this part of the data will be cleared and accumulated again, but the order records will still be queried in order history
/// • Normal spot: not supported, return open orders only
/// </summary>
public enum BybitQueryOpenOnly
{
    /// <summary>
    /// Query open orders only
    /// </summary>
    [Map("0")]
    QueryOpenOrdersOnly = 0,

    /// <summary>
    /// Query recent orders for spot/linear/option
    /// </summary>
    [Map("1")]
    QueryRecentOrders_for_SpotLinearOption = 1,

    /// <summary>
    /// Query recent orders for unified inverse &amp; normal linear/inverse
    /// </summary>
    [Map("2")]
    QueryRecentOrders_for_UnifiedInverse_NormalLinearInverse = 2,
}