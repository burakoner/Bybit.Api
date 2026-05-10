namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker voucher specification.
/// </summary>
public record BybitBrokerVoucherSpec
{
    /// <summary>
    /// Voucher ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Coin.
    /// </summary>
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Amount unit.
    /// </summary>
    public BybitBrokerVoucherAmountUnit AmountUnit { get; set; }

    /// <summary>
    /// Product line.
    /// </summary>
    public string ProductLine { get; set; } = string.Empty;

    /// <summary>
    /// Sub product line.
    /// </summary>
    public string SubProductLine { get; set; } = string.Empty;

    /// <summary>
    /// Total amount of voucher.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Used amount of voucher.
    /// </summary>
    public decimal? UsedAmount { get; set; }
}
