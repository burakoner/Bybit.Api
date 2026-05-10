namespace Bybit.Api.Asset;

/// <summary>
/// Bybit portfolio margin information.
/// </summary>
public record BybitAssetPortfolioMargin
{
    /// <summary>
    /// Wallet information.
    /// </summary>
    public BybitAssetPortfolioMarginWallet Wallet { get; set; } = default!;

    /// <summary>
    /// Asset PnL range list.
    /// </summary>
    public List<BybitAssetPortfolioMarginAssetPnlRange> AssetPnlRange { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin wallet information.
/// </summary>
public record BybitAssetPortfolioMarginWallet
{
    /// <summary>
    /// Portfolio margin account equity.
    /// </summary>
    public decimal Equity { get; set; }

    /// <summary>
    /// Portfolio margin account cash balance.
    /// </summary>
    public decimal CashBalance { get; set; }

    /// <summary>
    /// Portfolio margin account margin balance.
    /// </summary>
    public decimal MarginBalance { get; set; }

    /// <summary>
    /// Available balance.
    /// </summary>
    public decimal AvailableBalance { get; set; }

    /// <summary>
    /// Account initial margin.
    /// </summary>
    public decimal AccountIM { get; set; }

    /// <summary>
    /// Account maintenance margin.
    /// </summary>
    public decimal AccountMM { get; set; }

    /// <summary>
    /// Account maintenance margin rate.
    /// </summary>
    public decimal AccountMMRate { get; set; }

    /// <summary>
    /// Account initial margin rate.
    /// </summary>
    public decimal AccountIMRate { get; set; }
}

/// <summary>
/// Bybit portfolio margin asset PnL range.
/// </summary>
public record BybitAssetPortfolioMarginAssetPnlRange
{
    /// <summary>
    /// Base coin.
    /// </summary>
    public string BaseCoin { get; set; } = string.Empty;

    /// <summary>
    /// Aggregated PnL ranges by product group.
    /// </summary>
    public BybitAssetPortfolioMarginTotalPnlRanges TotalPnlRanges { get; set; } = default!;

    /// <summary>
    /// Perpetual position PnL ranges.
    /// </summary>
    public List<BybitAssetPortfolioMarginPositionPnlRange> PerpPositionPnlRanges { get; set; } = [];

    /// <summary>
    /// Option expiry-date PnL ranges.
    /// </summary>
    public List<BybitAssetPortfolioMarginOptionExpiryPnlRange> OptionExpiryDatePnlRanges { get; set; } = [];

    /// <summary>
    /// Contingency margin information.
    /// </summary>
    public BybitAssetPortfolioMarginContingency? Contingency { get; set; }

    /// <summary>
    /// Asset margin information.
    /// </summary>
    public BybitAssetPortfolioMarginAsset? Asset { get; set; }

    /// <summary>
    /// Maximum loss price move.
    /// </summary>
    public decimal? MaxLossPriceMove { get; set; }

    /// <summary>
    /// Maximum loss implied-volatility shock.
    /// </summary>
    public decimal? MaxLossIvShock { get; set; }

    /// <summary>
    /// Total close position fee.
    /// </summary>
    public decimal? TotalClosePzFee { get; set; }

    /// <summary>
    /// Spot hedge information.
    /// </summary>
    public BybitAssetPortfolioMarginSpotHedgeInfo? SpotHedgeInfo { get; set; }

    /// <summary>
    /// Maximum loss implied-volatility shock list.
    /// </summary>
    public List<decimal> MaxLossIvShockList { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin aggregated PnL ranges.
/// </summary>
public record BybitAssetPortfolioMarginTotalPnlRanges
{
    /// <summary>
    /// Combined PnL range.
    /// </summary>
    [JsonProperty("ALL")]
    public BybitAssetPortfolioMarginPnlRangeContainer? All { get; set; }

    /// <summary>
    /// Perpetual PnL range.
    /// </summary>
    [JsonProperty("PERPETUAL")]
    public BybitAssetPortfolioMarginPnlRangeContainer? Perpetual { get; set; }

    /// <summary>
    /// Option PnL range.
    /// </summary>
    [JsonProperty("OPTION")]
    public BybitAssetPortfolioMarginPnlRangeContainer? Option { get; set; }
}

/// <summary>
/// Bybit portfolio margin PnL range container.
/// </summary>
public record BybitAssetPortfolioMarginPnlRangeContainer
{
    /// <summary>
    /// PnL range data points.
    /// </summary>
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin PnL data point.
/// </summary>
public record BybitAssetPortfolioMarginPnlRange
{
    /// <summary>
    /// Price scale for this PnL point.
    /// </summary>
    public decimal PriceScale { get; set; }

    /// <summary>
    /// PnL values for this price scale.
    /// </summary>
    public List<decimal> Pnls { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin position PnL range.
/// </summary>
public record BybitAssetPortfolioMarginPositionPnlRange
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string SymbolName { get; set; } = string.Empty;

    /// <summary>
    /// Position size.
    /// </summary>
    public decimal? Position { get; set; }

    /// <summary>
    /// PnL range data points.
    /// </summary>
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];

    /// <summary>
    /// Session average price.
    /// </summary>
    public decimal? SessionAvgPrice { get; set; }

    /// <summary>
    /// Mark price.
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Open order size.
    /// </summary>
    public decimal? OrderSize { get; set; }

    /// <summary>
    /// Contract type.
    /// </summary>
    public int? ContractType { get; set; }

    /// <summary>
    /// Settlement coin.
    /// </summary>
    public string SettleCoin { get; set; } = string.Empty;

    /// <summary>
    /// Symbol alias.
    /// </summary>
    public string SymbolAlias { get; set; } = string.Empty;
}

/// <summary>
/// Bybit portfolio margin option expiry PnL range.
/// </summary>
public record BybitAssetPortfolioMarginOptionExpiryPnlRange
{
    /// <summary>
    /// Option expiry date representation.
    /// </summary>
    public string ExpiryDateRepresentation { get; set; } = string.Empty;

    /// <summary>
    /// PnL range data points for the expiry date.
    /// </summary>
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];

    /// <summary>
    /// Option position PnL ranges.
    /// </summary>
    public List<BybitAssetPortfolioMarginPositionPnlRange> OptionPositionPnlRanges { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin contingency information.
/// </summary>
public record BybitAssetPortfolioMarginContingency
{
    /// <summary>
    /// Option contingency amount.
    /// </summary>
    public decimal? OptionContingency { get; set; }

    /// <summary>
    /// Futures delta contingency amount.
    /// </summary>
    public decimal? FutureDeltaContingency { get; set; }

    /// <summary>
    /// Option vega contingency amount.
    /// </summary>
    public decimal? OptionVegaContingency { get; set; }

    /// <summary>
    /// Contingency component amount.
    /// </summary>
    public decimal? ContingencyComponents { get; set; }

    /// <summary>
    /// USDT/USDC contingency amount.
    /// </summary>
    public decimal? UsdtUsdcContingency { get; set; }

    /// <summary>
    /// Futures contingency amount.
    /// </summary>
    public decimal? FutureContingency { get; set; }
}

/// <summary>
/// Bybit portfolio margin asset margin information.
/// </summary>
public record BybitAssetPortfolioMarginAsset
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Asset initial margin.
    /// </summary>
    public decimal? AssetIM { get; set; }

    /// <summary>
    /// Asset maintenance margin.
    /// </summary>
    public decimal? AssetMM { get; set; }
}

/// <summary>
/// Bybit portfolio margin spot hedge information.
/// </summary>
public record BybitAssetPortfolioMarginSpotHedgeInfo
{
    /// <summary>
    /// Spot asset quantity used for hedging in portfolio margin.
    /// </summary>
    public decimal? HedgeSpotSize { get; set; }

    /// <summary>
    /// Spot wallet balance.
    /// </summary>
    public decimal? WalletBalance { get; set; }

    /// <summary>
    /// USD index price.
    /// </summary>
    public decimal? UsdIndexPrice { get; set; }

    /// <summary>
    /// PnL range data points for the spot hedge.
    /// </summary>
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
}
