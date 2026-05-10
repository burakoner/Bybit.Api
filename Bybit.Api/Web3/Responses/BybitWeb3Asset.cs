namespace Bybit.Api.Web3;

/// <summary>
/// Web3 asset.
/// </summary>
public record BybitWeb3Asset
{
    /// <summary>
    /// Blockchain code.
    /// </summary>
    public string ChainCode { get; set; } = string.Empty;

    /// <summary>
    /// Chain icon URL.
    /// </summary>
    public string ChainIconUrl { get; set; } = string.Empty;

    /// <summary>
    /// Token contract address.
    /// </summary>
    public string TokenAddress { get; set; } = string.Empty;

    /// <summary>
    /// Token code.
    /// </summary>
    public string TokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Token symbol.
    /// </summary>
    public string TokenSymbol { get; set; } = string.Empty;

    /// <summary>
    /// Token decimal precision.
    /// </summary>
    public int TokenDecimals { get; set; }

    /// <summary>
    /// Token icon URL for light mode.
    /// </summary>
    public string TokenIconUrlDay { get; set; } = string.Empty;

    /// <summary>
    /// Token icon URL for dark mode.
    /// </summary>
    public string TokenIconUrlNight { get; set; } = string.Empty;

    /// <summary>
    /// Holding quantity.
    /// </summary>
    public decimal? TokenAmount { get; set; }

    /// <summary>
    /// Holding value in USD.
    /// </summary>
    public decimal? TokenAmountUsd { get; set; }

    /// <summary>
    /// Whether tradable.
    /// </summary>
    public BybitWeb3TradeFlag TradeFlag { get; set; }

    /// <summary>
    /// Unrealized profit/loss in USD.
    /// </summary>
    public decimal? Pnl { get; set; }

    /// <summary>
    /// Profit/loss ratio.
    /// </summary>
    public decimal? PnlRatio { get; set; }

    /// <summary>
    /// Average cost price.
    /// </summary>
    public decimal? CostPrice { get; set; }

    /// <summary>
    /// Current market price.
    /// </summary>
    public decimal? LastPrice { get; set; }

    /// <summary>
    /// Total cost basis in USD.
    /// </summary>
    public decimal? CostTotalValue { get; set; }

    /// <summary>
    /// Token lifecycle status.
    /// </summary>
    public BybitWeb3AssetStatus AssetStatus { get; set; }

    /// <summary>
    /// Delisting announcement URL.
    /// </summary>
    public string AnnouncementUrl { get; set; } = string.Empty;

    /// <summary>
    /// Estimated delisting timestamp in milliseconds.
    /// </summary>
    public long? EstimatedOfflineTime { get; set; }

    /// <summary>
    /// Estimated delisting time.
    /// </summary>
    public DateTime? EstimatedOfflineDateTime { get => EstimatedOfflineTime.HasValue ? EstimatedOfflineTime.Value.ConvertFromMilliseconds() : null; }

    /// <summary>
    /// Actual delisting timestamp in milliseconds.
    /// </summary>
    public long? DelistingTime { get; set; }

    /// <summary>
    /// Actual delisting time.
    /// </summary>
    public DateTime? DelistingDateTime { get => DelistingTime.HasValue ? DelistingTime.Value.ConvertFromMilliseconds() : null; }
}
