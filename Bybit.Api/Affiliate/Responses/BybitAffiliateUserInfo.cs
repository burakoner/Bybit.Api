namespace Bybit.Api.Affiliate;

/// <summary>
/// Affiliate user information.
/// </summary>
public record BybitAffiliateUserInfo
{
    /// <summary>
    /// UID.
    /// </summary>
    public long Uid { get; set; }

    /// <summary>
    /// VIP level.
    /// </summary>
    public string VipLevel { get; set; } = string.Empty;

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
    /// Wallet balance range code.
    /// </summary>
    public int TotalWalletBalance { get; set; }

    /// <summary>
    /// Deposit data update time in UTC.
    /// </summary>
    public string DepositUpdateTime { get; set; } = string.Empty;

    /// <summary>
    /// Volume data update time in UTC.
    /// </summary>
    public string VolUpdateTime { get; set; } = string.Empty;

    /// <summary>
    /// KYC level.
    /// </summary>
    [JsonProperty("KycLevel")]
    public int KycLevel { get; set; }

    /// <summary>
    /// TradFi trade volume in last 30 days, USDT.
    /// </summary>
    public decimal? TradfiTradeVol30Day { get; set; }

    /// <summary>
    /// TradFi trade volume in the past year, USDT.
    /// </summary>
    public decimal? TradfiTradeVol365Day { get; set; }

    /// <summary>
    /// TradFi commissions in last 30 days, keyed by asset.
    /// </summary>
    public Dictionary<string, decimal?> Commissions30Day { get; set; } = [];

    /// <summary>
    /// TradFi commissions in the past year, keyed by asset.
    /// </summary>
    public Dictionary<string, decimal?> Commissions365Day { get; set; } = [];
}
