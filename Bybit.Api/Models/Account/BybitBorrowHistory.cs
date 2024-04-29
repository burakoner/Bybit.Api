namespace Bybit.Api.Models.Account;

/// <summary>
/// Borrow history info
/// </summary>
public class BybitBorrowHistory
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Asset { get; set; }

    /// <summary>
    /// Created time
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Created time
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Interest
    /// </summary>
    public decimal BorrowCost { get; set; }

    /// <summary>
    /// Houly borrow rate
    /// </summary>
    public decimal HourlyBorrowRate { get; set; }

    /// <summary>
    /// Interest Bearing Borrow Size
    /// </summary>
    public decimal InterestBearingBorrowSize { get; set; }

    /// <summary>
    /// Cost exemption
    /// </summary>
    public decimal CostExcemption { get; set; }

    /// <summary>
    /// Total borrow amount
    /// </summary>
    public decimal BorrowAmount { get; set; }

    /// <summary>
    /// Unrealised loss
    /// </summary>
    public decimal UnrealisedLoss { get; set; }

    /// <summary>
    /// The borrowed amount for interest free
    /// </summary>
    public decimal FreeBorrowedAmount { get; set; }
}
