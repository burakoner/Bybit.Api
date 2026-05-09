namespace Bybit.Api.Account;

/// <summary>
/// Bybit account trade information for analysis.
/// </summary>
public record BybitAccountTradeAnalysis
{
    /// <summary>
    /// Base coin.
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Settle coin.
    /// </summary>
    [JsonProperty("settleCoin")]
    public string SettleAsset { get; set; } = string.Empty;

    /// <summary>
    /// Symbol realised PnL.
    /// </summary>
    [JsonProperty("symbolRnl")]
    public decimal SymbolRealizedPnl { get; set; }

    /// <summary>
    /// Net execution quantity.
    /// </summary>
    public decimal NetExecQty { get; set; }

    /// <summary>
    /// Total execution value.
    /// </summary>
    public decimal SumExecValue { get; set; }

    /// <summary>
    /// Total execution quantity.
    /// </summary>
    public decimal SumExecQty { get; set; }

    /// <summary>
    /// Average buy execution price.
    /// </summary>
    public decimal AvgBuyExecPrice { get; set; }

    /// <summary>
    /// Total buy execution value.
    /// </summary>
    public decimal SumBuyExecValue { get; set; }

    /// <summary>
    /// Total buy execution quantity.
    /// </summary>
    public decimal SumBuyExecQty { get; set; }

    /// <summary>
    /// Total buy execution fee.
    /// </summary>
    public decimal SumBuyExecFee { get; set; }

    /// <summary>
    /// Total buy order quantity.
    /// </summary>
    public decimal SumBuyOrderQty { get; set; }

    /// <summary>
    /// Average sell execution price.
    /// </summary>
    public decimal AvgSellExecPrice { get; set; }

    /// <summary>
    /// Total sell execution value.
    /// </summary>
    public decimal SumSellExecValue { get; set; }

    /// <summary>
    /// Total sell execution quantity.
    /// </summary>
    public decimal SumSellExecQty { get; set; }

    /// <summary>
    /// Total sell execution fee.
    /// </summary>
    public decimal SumSellExecFee { get; set; }

    /// <summary>
    /// Total sell order quantity.
    /// </summary>
    public decimal SumSellOrderQty { get; set; }

    /// <summary>
    /// Maximum margin version.
    /// </summary>
    public int MaxMarginVersion { get; set; }

    /// <summary>
    /// Entry and exit price pairs.
    /// </summary>
    public List<BybitAccountTradeAnalysisPricePair> SumPriceList { get; set; } = [];
}

/// <summary>
/// Bybit account trade analysis daily price summary.
/// </summary>
public record BybitAccountTradeAnalysisPricePair
{
    /// <summary>
    /// Date.
    /// </summary>
    public string Day { get; set; } = string.Empty;

    /// <summary>
    /// Daily total buy execution value.
    /// </summary>
    public decimal SumBuyExecValue { get; set; }

    /// <summary>
    /// Daily total sell execution value.
    /// </summary>
    public decimal SumSellExecValue { get; set; }

    /// <summary>
    /// Daily total execution value.
    /// </summary>
    public decimal SumExecValue { get; set; }
}
