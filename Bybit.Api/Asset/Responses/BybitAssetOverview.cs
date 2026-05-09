namespace Bybit.Api.Asset;

/// <summary>
/// Bybit asset overview.
/// </summary>
public record BybitAssetOverview
{
    /// <summary>
    /// Total equity across all accounts.
    /// </summary>
    public decimal TotalEquity { get; set; }

    /// <summary>
    /// Account holdings.
    /// </summary>
    public List<BybitAssetOverviewAccount> List { get; set; } = [];
}

/// <summary>
/// Bybit asset overview account.
/// </summary>
public record BybitAssetOverviewAccount
{
    /// <summary>
    /// Account type label returned by Bybit.
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// Account total equity.
    /// </summary>
    public decimal TotalEquity { get; set; }

    /// <summary>
    /// Valuation currency.
    /// </summary>
    public string ValuationCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Snapshot timestamp in milliseconds.
    /// </summary>
    public long SnapshotTime { get; set; }

    /// <summary>
    /// Coin-level holdings.
    /// </summary>
    public List<BybitAssetOverviewCoin> CoinDetail { get; set; } = [];

    /// <summary>
    /// Product category breakdown.
    /// </summary>
    public List<BybitAssetOverviewCategory> Categories { get; set; } = [];
}

/// <summary>
/// Bybit asset overview category.
/// </summary>
public record BybitAssetOverviewCategory
{
    /// <summary>
    /// Category name.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Category equity.
    /// </summary>
    public decimal Equity { get; set; }

    /// <summary>
    /// Coin-level holdings in this category.
    /// </summary>
    public List<BybitAssetOverviewCoin> CoinDetail { get; set; } = [];
}

/// <summary>
/// Bybit asset overview coin.
/// </summary>
public record BybitAssetOverviewCoin
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Coin equity amount.
    /// </summary>
    public decimal Equity { get; set; }

    /// <summary>
    /// Extended Alpha fields.
    /// </summary>
    public BybitAssetOverviewExtendedMap? ExtMap { get; set; }
}

/// <summary>
/// Bybit asset overview extended fields.
/// </summary>
public record BybitAssetOverviewExtendedMap
{
    /// <summary>
    /// Upper price of the liquidity position range.
    /// </summary>
    public decimal? PriceUpper { get; set; }

    /// <summary>
    /// Lower price of the liquidity position range.
    /// </summary>
    public decimal? PriceLower { get; set; }

    /// <summary>
    /// Unit of the equity value.
    /// </summary>
    public string EquityUnit { get; set; } = string.Empty;
}
