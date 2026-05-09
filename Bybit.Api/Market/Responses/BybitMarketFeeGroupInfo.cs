namespace Bybit.Api.Market;

/// <summary>
/// Bybit fee group structure.
/// </summary>
public record BybitMarketFeeGroupInfo
{
    /// <summary>
    /// List of fee group objects.
    /// </summary>
    public List<BybitMarketFeeGroup> List { get; set; } = [];
}

/// <summary>
/// Bybit fee group.
/// </summary>
public record BybitMarketFeeGroup
{
    /// <summary>
    /// Fee group name.
    /// </summary>
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// Group weighting factor.
    /// </summary>
    public int WeightingFactor { get; set; }

    /// <summary>
    /// Symbols number.
    /// </summary>
    public int SymbolsNumbers { get; set; }

    /// <summary>
    /// Symbols in this fee group.
    /// </summary>
    public List<string> Symbols { get; set; } = [];

    /// <summary>
    /// Fee rate details.
    /// </summary>
    public BybitMarketFeeRates FeeRates { get; set; } = default!;

    /// <summary>
    /// Latest data update timestamp in milliseconds.
    /// </summary>
    public long UpdateTime { get; set; }

    /// <summary>
    /// Latest data update time.
    /// </summary>
    public DateTime Time { get => UpdateTime.ConvertFromMilliseconds(); }
}

/// <summary>
/// Bybit fee rate groups.
/// </summary>
public record BybitMarketFeeRates
{
    /// <summary>
    /// Pro-level fee structures.
    /// </summary>
    public List<BybitMarketFeeRate> Pro { get; set; } = [];

    /// <summary>
    /// Market Maker-level fee structures.
    /// </summary>
    public List<BybitMarketFeeRate> MarketMaker { get; set; } = [];
}

/// <summary>
/// Bybit fee rate.
/// </summary>
public record BybitMarketFeeRate
{
    /// <summary>
    /// Fee level name.
    /// </summary>
    public string Level { get; set; } = string.Empty;

    /// <summary>
    /// Taker fee rate.
    /// </summary>
    public decimal? TakerFeeRate { get; set; }

    /// <summary>
    /// Maker fee rate.
    /// </summary>
    public decimal? MakerFeeRate { get; set; }

    /// <summary>
    /// Maker rebate fee rate.
    /// </summary>
    public decimal? MakerRebate { get; set; }
}
