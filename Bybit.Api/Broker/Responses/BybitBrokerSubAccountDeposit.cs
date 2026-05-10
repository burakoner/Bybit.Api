namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker subaccount deposit record.
/// </summary>
public record BybitBrokerSubAccountDeposit
{
    /// <summary>
    /// Unique ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Subaccount user ID.
    /// </summary>
    public long SubMemberId { get; set; }

    /// <summary>
    /// Coin.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Chain.
    /// </summary>
    public string Chain { get; set; } = string.Empty;

    /// <summary>
    /// Amount.
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Transaction ID.
    /// </summary>
    [JsonProperty("txID")]
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Deposit status.
    /// </summary>
    public BybitDepositStatus Status { get; set; }

    /// <summary>
    /// Deposit target address.
    /// </summary>
    public string ToAddress { get; set; } = string.Empty;

    /// <summary>
    /// Tag of deposit target address.
    /// </summary>
    public string Tag { get; set; } = string.Empty;

    /// <summary>
    /// Deposit fee.
    /// </summary>
    public decimal? DepositFee { get; set; }

    /// <summary>
    /// Deposit success timestamp.
    /// </summary>
    [JsonProperty("successAt")]
    public long? SuccessTimestamp { get; set; }

    /// <summary>
    /// Deposit success time.
    /// </summary>
    public DateTime? SuccessTime { get => SuccessTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Number of confirmation blocks.
    /// </summary>
    public int? Confirmations { get; set; }

    /// <summary>
    /// Transaction sequence number.
    /// </summary>
    [JsonProperty("txIndex")]
    public string TransactionIndex { get; set; } = string.Empty;

    /// <summary>
    /// Hash number on the chain.
    /// </summary>
    public string BlockHash { get; set; } = string.Empty;

    /// <summary>
    /// Deposit limit for this coin in this chain. -1 means no limit.
    /// </summary>
    public decimal? BatchReleaseLimit { get; set; }

    /// <summary>
    /// Deposit type. 0: normal deposit, 10: daily deposit limit reached, 20: abnormal deposit.
    /// </summary>
    public int? DepositType { get; set; }

    /// <summary>
    /// From address of deposit.
    /// </summary>
    public string FromAddress { get; set; } = string.Empty;

    /// <summary>
    /// Tax record ID for tax reporting, when applicable.
    /// </summary>
    public string TaxDepositRecordsId { get; set; } = string.Empty;

    /// <summary>
    /// Tax reporting status, when applicable.
    /// </summary>
    public int? TaxStatus { get; set; }
}
