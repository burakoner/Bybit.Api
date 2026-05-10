namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker earnings.
/// </summary>
public record BybitBrokerEarnings
{
    /// <summary>
    /// Category statistics for total earning data.
    /// </summary>
    public BybitBrokerEarningCategories TotalEarningCat { get; set; } = new();

    /// <summary>
    /// Detailed trading information for each sub UID and each category.
    /// </summary>
    public List<BybitBrokerEarningDetail> Details { get; set; } = [];

    /// <summary>
    /// Cursor for the next page.
    /// </summary>
    public string NextPageCursor { get; set; } = string.Empty;
}

/// <summary>
/// Exchange broker earning categories.
/// </summary>
public record BybitBrokerEarningCategories
{
    /// <summary>
    /// Spot trading earnings.
    /// </summary>
    public List<BybitBrokerEarningAmount> Spot { get; set; } = [];

    /// <summary>
    /// Derivatives trading earnings.
    /// </summary>
    public List<BybitBrokerEarningAmount> Derivatives { get; set; } = [];

    /// <summary>
    /// Options trading earnings.
    /// </summary>
    public List<BybitBrokerEarningAmount> Options { get; set; } = [];

    /// <summary>
    /// Convert trading earnings.
    /// </summary>
    public List<BybitBrokerEarningAmount> Convert { get; set; } = [];

    /// <summary>
    /// Total earnings across categories.
    /// </summary>
    public List<BybitBrokerEarningAmount> Total { get; set; } = [];
}

/// <summary>
/// Exchange broker earning amount.
/// </summary>
public record BybitBrokerEarningAmount
{
    /// <summary>
    /// Rebate coin name.
    /// </summary>
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Rebate amount.
    /// </summary>
    public decimal Earning { get; set; }
}

/// <summary>
/// Exchange broker earning detail.
/// </summary>
public record BybitBrokerEarningDetail
{
    /// <summary>
    /// Sub UID.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Business type.
    /// </summary>
    [JsonProperty("bizType")]
    public BybitBrokerBusinessType BusinessType { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Rebate coin name.
    /// </summary>
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Rebate amount.
    /// </summary>
    public decimal Earning { get; set; }

    /// <summary>
    /// Earning generated from markup fee rate.
    /// </summary>
    public decimal MarkupEarning { get; set; }

    /// <summary>
    /// Earning generated from base fee rate.
    /// </summary>
    public decimal BaseFeeEarning { get; set; }

    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Trade ID.
    /// </summary>
    public string ExecId { get; set; } = string.Empty;

    /// <summary>
    /// Order execution timestamp in milliseconds.
    /// </summary>
    [JsonProperty("execTime")]
    public long ExecTimestamp { get; set; }

    /// <summary>
    /// Order execution time.
    /// </summary>
    public DateTime ExecTime { get => ExecTimestamp.ConvertFromMilliseconds(); }
}
