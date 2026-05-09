namespace Bybit.Api.Market;

/// <summary>
/// Bybit index price components.
/// </summary>
public record BybitMarketIndexPriceComponents
{
    /// <summary>
    /// Name of the index.
    /// </summary>
    public string IndexName { get; set; } = string.Empty;

    /// <summary>
    /// Last price of the index.
    /// </summary>
    public decimal LastPrice { get; set; }

    /// <summary>
    /// Timestamp of the last update in milliseconds.
    /// </summary>
    public long UpdateTime { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime Time { get => UpdateTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// List of components contributing to the index price.
    /// </summary>
    public List<BybitMarketIndexPriceComponent> Components { get; set; } = [];
}

/// <summary>
/// Bybit index price component.
/// </summary>
public record BybitMarketIndexPriceComponent
{
    /// <summary>
    /// Name of the exchange.
    /// </summary>
    public string Exchange { get; set; } = string.Empty;

    /// <summary>
    /// Spot trading pair on the exchange.
    /// </summary>
    public string SpotPair { get; set; } = string.Empty;

    /// <summary>
    /// Equivalent price.
    /// </summary>
    public decimal EquivalentPrice { get; set; }

    /// <summary>
    /// Multiplier used for the component price.
    /// </summary>
    public decimal Multiplier { get; set; }

    /// <summary>
    /// Actual price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Weight in the index calculation.
    /// </summary>
    public decimal Weight { get; set; }
}
