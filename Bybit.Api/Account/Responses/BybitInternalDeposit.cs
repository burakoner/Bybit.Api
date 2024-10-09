namespace Bybit.Api.Account;

/// <summary>
/// Bybit Internal Deposit
/// </summary>
public class BybitInternalDeposit
{
    /// <summary>
    /// Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// 1: Internal deposit
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; }

    /// <summary>
    /// Deposit coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Deposit amount
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// 1=Processing
    /// 2=Success
    /// 3=deposit failed
    /// </summary>
    public BybitInternalDepositStatus Status { get; set; }

    /// <summary>
    /// Email address or phone number
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Deposit created timestamp
    /// </summary>
    [JsonProperty("createdTime")]
    public long? CreatedTimestamp { get; set; }

    /// <summary>
    /// Deposit created time
    /// </summary>
    public DateTime? CreatedTime { get => CreatedTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Internal transfer transaction ID
    /// </summary>
    [JsonProperty("txID")]
    public string TransactionId { get; set; }
}
