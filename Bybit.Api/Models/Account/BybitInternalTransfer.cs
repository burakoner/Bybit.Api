namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Internal Transfer
/// </summary>
public class BybitInternalTransfer
{
    /// <summary>
    /// Transfer Id
    /// </summary>
    public string TransferId { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// From Account
    /// </summary>
    [JsonProperty("fromAccountType")]
    public BybitAccountType FromAccount { get; set; }

    /// <summary>
    /// To Account
    /// </summary>
    [JsonProperty("toAccountType")]
    public BybitAccountType ToAccount { get; set; }

    /// <summary>
    /// Timestamp
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("status")]
    public BybitTransferStatus Status { get; set; }
}
