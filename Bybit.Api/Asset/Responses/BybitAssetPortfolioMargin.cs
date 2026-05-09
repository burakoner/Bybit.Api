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
    public decimal Equity { get; set; }
    public decimal CashBalance { get; set; }
    public decimal MarginBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal AccountIM { get; set; }
    public decimal AccountMM { get; set; }
    public decimal AccountMMRate { get; set; }
    public decimal AccountIMRate { get; set; }
}

/// <summary>
/// Bybit portfolio margin asset PnL range.
/// </summary>
public record BybitAssetPortfolioMarginAssetPnlRange
{
    public string BaseCoin { get; set; } = string.Empty;
    public BybitAssetPortfolioMarginTotalPnlRanges TotalPnlRanges { get; set; } = default!;
    public List<BybitAssetPortfolioMarginPositionPnlRange> PerpPositionPnlRanges { get; set; } = [];
    public List<BybitAssetPortfolioMarginOptionExpiryPnlRange> OptionExpiryDatePnlRanges { get; set; } = [];
    public BybitAssetPortfolioMarginContingency? Contingency { get; set; }
    public BybitAssetPortfolioMarginAsset? Asset { get; set; }
    public decimal? MaxLossPriceMove { get; set; }
    public decimal? MaxLossIvShock { get; set; }
    public decimal? TotalClosePzFee { get; set; }
    public BybitAssetPortfolioMarginSpotHedgeInfo? SpotHedgeInfo { get; set; }
    public List<decimal> MaxLossIvShockList { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin aggregated PnL ranges.
/// </summary>
public record BybitAssetPortfolioMarginTotalPnlRanges
{
    [JsonProperty("ALL")]
    public BybitAssetPortfolioMarginPnlRangeContainer? All { get; set; }

    [JsonProperty("PERPETUAL")]
    public BybitAssetPortfolioMarginPnlRangeContainer? Perpetual { get; set; }

    [JsonProperty("OPTION")]
    public BybitAssetPortfolioMarginPnlRangeContainer? Option { get; set; }
}

/// <summary>
/// Bybit portfolio margin PnL range container.
/// </summary>
public record BybitAssetPortfolioMarginPnlRangeContainer
{
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin PnL data point.
/// </summary>
public record BybitAssetPortfolioMarginPnlRange
{
    public decimal PriceScale { get; set; }
    public List<decimal> Pnls { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin position PnL range.
/// </summary>
public record BybitAssetPortfolioMarginPositionPnlRange
{
    public string SymbolName { get; set; } = string.Empty;
    public decimal? Position { get; set; }
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
    public decimal? SessionAvgPrice { get; set; }
    public decimal? MarkPrice { get; set; }
    public decimal? OrderSize { get; set; }
    public int? ContractType { get; set; }
    public string SettleCoin { get; set; } = string.Empty;
    public string SymbolAlias { get; set; } = string.Empty;
}

/// <summary>
/// Bybit portfolio margin option expiry PnL range.
/// </summary>
public record BybitAssetPortfolioMarginOptionExpiryPnlRange
{
    public string ExpiryDateRepresentation { get; set; } = string.Empty;
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
    public List<BybitAssetPortfolioMarginPositionPnlRange> OptionPositionPnlRanges { get; set; } = [];
}

/// <summary>
/// Bybit portfolio margin contingency information.
/// </summary>
public record BybitAssetPortfolioMarginContingency
{
    public decimal? OptionContingency { get; set; }
    public decimal? FutureDeltaContingency { get; set; }
    public decimal? OptionVegaContingency { get; set; }
    public decimal? ContingencyComponents { get; set; }
    public decimal? UsdtUsdcContingency { get; set; }
    public decimal? FutureContingency { get; set; }
}

/// <summary>
/// Bybit portfolio margin asset margin information.
/// </summary>
public record BybitAssetPortfolioMarginAsset
{
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    public decimal? AssetIM { get; set; }
    public decimal? AssetMM { get; set; }
}

/// <summary>
/// Bybit portfolio margin spot hedge information.
/// </summary>
public record BybitAssetPortfolioMarginSpotHedgeInfo
{
    public decimal? HedgeSpotSize { get; set; }
    public decimal? WalletBalance { get; set; }
    public decimal? UsdIndexPrice { get; set; }
    public List<BybitAssetPortfolioMarginPnlRange> PnlRanges { get; set; } = [];
}
