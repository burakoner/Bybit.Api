namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker account information.
/// </summary>
public record BybitBrokerAccountInfo
{
    /// <summary>
    /// The quantity of subaccounts created.
    /// </summary>
    public int SubAcctQty { get; set; }

    /// <summary>
    /// The maximum quantity of subaccounts that can be created.
    /// </summary>
    public int MaxSubAcctQty { get; set; }

    /// <summary>
    /// Rebate percentage of the base fee.
    /// </summary>
    public BybitBrokerFeeRebateRate BaseFeeRebateRate { get; set; } = new();

    /// <summary>
    /// Rebate percentage of the markup fee.
    /// </summary>
    public BybitBrokerMarkupFeeRebateRate MarkupFeeRebateRate { get; set; } = new();

    /// <summary>
    /// System timestamp in milliseconds.
    /// </summary>
    [JsonProperty("ts")]
    public long Timestamp { get; set; }

    /// <summary>
    /// System time.
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}

/// <summary>
/// Exchange broker fee rebate rate.
/// </summary>
public record BybitBrokerFeeRebateRate
{
    /// <summary>
    /// Spot rebate percentage.
    /// </summary>
    public string Spot { get; set; } = string.Empty;

    /// <summary>
    /// Derivatives rebate percentage.
    /// </summary>
    public string Derivatives { get; set; } = string.Empty;
}

/// <summary>
/// Exchange broker markup fee rebate rate.
/// </summary>
public record BybitBrokerMarkupFeeRebateRate : BybitBrokerFeeRebateRate
{
    /// <summary>
    /// Convert rebate percentage.
    /// </summary>
    public string Convert { get; set; } = string.Empty;
}
