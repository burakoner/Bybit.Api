namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Deposit
/// </summary>
public class BybitAssetDeposit
{
    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Chain
    /// </summary>
    [JsonProperty("chain")]
    public string Chain { get; set; } = string.Empty;

    /// <summary>
    /// Amount
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Transaction ID
    /// </summary>
    [JsonProperty("txID")]
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Deposit status
    /// </summary>
    public BybitDepositStatus Status { get; set; }

    /// <summary>
    /// Deposit target address
    /// </summary>
    public string ToAddress { get; set; } = string.Empty;

    /// <summary>
    /// Tag of deposit target address
    /// </summary>
    public string Tag { get; set; } = string.Empty;

    /// <summary>
    /// Deposit fee
    /// </summary>
    public decimal? DepositFee { get; set; }

    /// <summary>
    /// Last updated time
    /// </summary>
    [JsonProperty("successAt")]
    public long? SuccessTimestamp { get; set; }

    /// <summary>
    /// Last updated time
    /// </summary>
    public DateTime? SuccessTime { get => SuccessTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Number of confirmation blocks
    /// </summary>
    public int Confirmations { get; set; }

    /// <summary>
    /// Transaction sequence number
    /// </summary>
    [JsonProperty("txIndex")]
    public string TransactionIndex { get; set; } = string.Empty;

    /// <summary>
    /// Hash number on the chain
    /// </summary>
    public string BlockHash { get; set; } = string.Empty;

    /// <summary>
    /// The deposit limit for this coin in this chain. "-1" means no limit
    /// </summary>
    public string BatchReleaseLimit { get; set; } = string.Empty;

    /// <summary>
    /// The deposit type. 0: normal deposit, 10: the deposit reaches daily deposit limit, 20: abnormal deposit
    /// </summary>
    public string DepositType { get; set; } = string.Empty;
}
