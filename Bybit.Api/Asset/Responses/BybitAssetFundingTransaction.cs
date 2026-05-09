namespace Bybit.Api.Asset;

/// <summary>
/// Bybit funding account transaction.
/// </summary>
public record BybitAssetFundingTransaction
{
    /// <summary>
    /// Member ID.
    /// </summary>
    public string MemberId { get; set; } = string.Empty;

    /// <summary>
    /// Coin symbol.
    /// </summary>
    [JsonProperty("currency")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Direction. I: In, O: Out.
    /// </summary>
    public string IoDirection { get; set; } = string.Empty;

    /// <summary>
    /// Transaction amount.
    /// </summary>
    [JsonProperty("txnAmt")]
    public decimal TransactionAmount { get; set; }

    /// <summary>
    /// Balance after transaction.
    /// </summary>
    [JsonProperty("afterAmt")]
    public decimal BalanceAfterTransaction { get; set; }

    /// <summary>
    /// Create timestamp in seconds.
    /// </summary>
    public long CreateTime { get; set; }

    /// <summary>
    /// Create time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreateTime).UtcDateTime;

    /// <summary>
    /// Business type localized key.
    /// </summary>
    public string ShowBusiType { get; set; } = string.Empty;

    /// <summary>
    /// Business type in English.
    /// </summary>
    public string ShowBusiTypeEn { get; set; } = string.Empty;

    /// <summary>
    /// Description localized key.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Description in English.
    /// </summary>
    public string DescriptionEn { get; set; } = string.Empty;
}
