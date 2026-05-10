namespace Bybit.Api.Affiliate;

/// <summary>
/// Affiliate user.
/// </summary>
public record BybitAffiliateUser
{
    /// <summary>
    /// User ID.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// User registration date.
    /// </summary>
    public string RegisterTime { get; set; } = string.Empty;

    /// <summary>
    /// User registration source.
    /// </summary>
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// User remark.
    /// </summary>
    public string Remarks { get; set; } = string.Empty;

    /// <summary>
    /// Whether KYC is completed.
    /// </summary>
    public bool IsKyc { get; set; }

    /// <summary>
    /// Taker volume in last 30 days, USDT.
    /// </summary>
    public decimal? TakerVol30Day { get; set; }

    /// <summary>
    /// Maker volume in last 30 days, USDT.
    /// </summary>
    public decimal? MakerVol30Day { get; set; }

    /// <summary>
    /// Total trading volume in last 30 days, USDT.
    /// </summary>
    public decimal? TradeVol30Day { get; set; }

    /// <summary>
    /// Deposit amount in last 30 days, USDT.
    /// </summary>
    public decimal? DepositAmount30Day { get; set; }

    /// <summary>
    /// Taker volume in the past year, USDT.
    /// </summary>
    public decimal? TakerVol365Day { get; set; }

    /// <summary>
    /// Maker volume in the past year, USDT.
    /// </summary>
    public decimal? MakerVol365Day { get; set; }

    /// <summary>
    /// Total trading volume in the past year, USDT.
    /// </summary>
    public decimal? TradeVol365Day { get; set; }

    /// <summary>
    /// Total deposit amount in the past year, USDT.
    /// </summary>
    public decimal? DepositAmount365Day { get; set; }

    /// <summary>
    /// Taker volume in the query period, USDT.
    /// </summary>
    public decimal? TakerVol { get; set; }

    /// <summary>
    /// Maker volume in the query period, USDT.
    /// </summary>
    public decimal? MakerVol { get; set; }

    /// <summary>
    /// Total trading volume in the query period, USDT.
    /// </summary>
    public decimal? TradeVol { get; set; }

    /// <summary>
    /// Query period start date.
    /// </summary>
    public string StartDate { get; set; } = string.Empty;

    /// <summary>
    /// Query period end date.
    /// </summary>
    public string EndDate { get; set; } = string.Empty;

    /// <summary>
    /// TradFi trade volume in the query period, USDT.
    /// </summary>
    public decimal? TradfiTradeVol { get; set; }

    /// <summary>
    /// TradFi trade volume in last 30 days, USDT.
    /// </summary>
    public decimal? TradfiTradeVol30Day { get; set; }

    /// <summary>
    /// TradFi trade volume in the past year, USDT.
    /// </summary>
    public decimal? TradfiTradeVol365Day { get; set; }

    /// <summary>
    /// Commission in the query period, keyed by asset.
    /// </summary>
    public Dictionary<string, decimal?> CommissionsVol { get; set; } = [];

    /// <summary>
    /// Commission in last 30 days, keyed by asset.
    /// </summary>
    public Dictionary<string, decimal?> Commissions30Day { get; set; } = [];

    /// <summary>
    /// Commission in the past year, keyed by asset.
    /// </summary>
    public Dictionary<string, decimal?> Commissions365Day { get; set; } = [];
}
