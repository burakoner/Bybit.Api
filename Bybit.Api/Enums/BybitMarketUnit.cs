namespace Bybit.Api.Enums;

/// <summary>
/// Bybit market unit
/// </summary>
public enum BybitMarketUnit
{
    /// <summary>
    /// Base asset
    /// </summary>
    [Label("baseCoin")]
    BaseAsset,

    /// <summary>
    /// Quote asset
    /// </summary>
    [Label("quoteCoin")]
    QuoteAsset,
}