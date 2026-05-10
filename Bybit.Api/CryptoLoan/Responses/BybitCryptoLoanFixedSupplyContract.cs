namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan supply contract.
/// </summary>
public record BybitCryptoLoanFixedSupplyContract
{
    /// <summary>
    /// Actual redemption timestamp.
    /// </summary>
    public long? ActualRedemptionTime { get; set; }

    /// <summary>
    /// Actual redemption time.
    /// </summary>
    public DateTime? ActualRedemptionDateTime { get => ActualRedemptionTime?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Annual rate for the supply.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Paid interest.
    /// </summary>
    public decimal InterestPaid { get; set; }

    [JsonProperty("interest", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    private decimal InterestAlias { set => InterestPaid = value; get => InterestPaid; }

    /// <summary>
    /// Supply order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Overdue interest.
    /// </summary>
    public decimal PenaltyInterest { get; set; }

    /// <summary>
    /// Planned redemption timestamp.
    /// </summary>
    public long RedemptionTime { get; set; }

    /// <summary>
    /// Planned redemption time.
    /// </summary>
    public DateTime RedemptionDateTime { get => RedemptionTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Supply contract status.
    /// </summary>
    public BybitCryptoLoanSupplyContractStatus Status { get; set; }

    /// <summary>
    /// Supply amount.
    /// </summary>
    public decimal SupplyAmount { get; set; }

    /// <summary>
    /// Supply coin.
    /// </summary>
    public string SupplyCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Supply contract ID.
    /// </summary>
    public string SupplyId { get; set; } = string.Empty;

    /// <summary>
    /// Supply timestamp.
    /// </summary>
    public long SupplyTime { get; set; }

    /// <summary>
    /// Supply time.
    /// </summary>
    public DateTime SupplyDateTime { get => SupplyTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }
}
