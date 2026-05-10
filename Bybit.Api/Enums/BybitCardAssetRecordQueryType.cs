namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card asset record query type.
/// </summary>
public enum BybitCardAssetRecordQueryType
{
    /// <summary>
    /// Authorization.
    /// </summary>
    [Map("SIDE_QUERY_AUTH")]
    Authorization,

    /// <summary>
    /// Clearing.
    /// </summary>
    [Map("SIDE_QUERY_FINANCIAL")]
    Financial,

    /// <summary>
    /// Refund.
    /// </summary>
    [Map("SIDE_QUERY_REFUND")]
    Refund,
}
