namespace Bybit.Api.Account;

/// <summary>
/// Bybit Withdrawal
/// </summary>
public class BybitWithdrawal
{
    /// <summary>
    /// Withdrawal Id
    /// </summary>
    [JsonProperty("withdrawId")]
    public string WithdrawalId { get; set; }

    /// <summary>
    /// Transaction ID. It returns "" when withdrawal failed, withdrawal cancelled
    /// </summary>
    [JsonProperty("txID")]
    public string TransactionId { get; set; }

    /// <summary>
    /// Withdraw type. 0: on chain. 1: off chain
    /// </summary>
    [JsonProperty("withdrawType")]
    public BybitWithdrawalType Type { get; set; }

    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Chain
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Withdraw fee
    /// </summary>
    public decimal? WithdrawFee { get; set; }

    /// <summary>
    /// Withdraw status
    /// </summary>
    public BybitWithdrawalStatus Status { get; set; }

    /// <summary>
    /// To withdrawal address. Shows the Bybit UID for internal transfers
    /// </summary>
    [JsonProperty("toAddress")]
    public string Address { get; set; }

    /// <summary>
    /// Tag
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Withdraw created timestamp (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Withdraw created timestamp
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Withdraw updated timestamp (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }

    /// <summary>
    /// Withdraw updated timestamp
    /// </summary>
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

}