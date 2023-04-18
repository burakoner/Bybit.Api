namespace Bybit.Api.Enums;

/// <summary>
/// • Unified account & Normal account: 0(default) - query open orders only
/// • Unified account - spot / linear / option: 1
///   Unified account - inverse & Normal account - linear / inverse: 2
///   return cancelled, rejected or totally filled orders by last 10 minutes, A maximum of 500 records are kept under each account.If the Bybit service is restarted due to an update, this part of the data will be cleared and accumulated again, but the order records will still be queried in order history
/// • Normal spot: not supported, return open orders only
/// </summary>
public enum BybitQueryOpenOnly
{
    [Label("0")]
    QueryOpenOrdersOnly,

    [Label("1")]
    QueryRecentOrders_for_SpotLinearOption,

    [Label("2")]
    QueryRecentOrders_for_UnifiedInverse_NormalLinearInverse,
}