namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card point record.
/// </summary>
public record BybitCardPointRecord
{
    /// <summary>
    /// External order ID.
    /// </summary>
    public string OutOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Point amount.
    /// </summary>
    public long Point { get; set; }

    /// <summary>
    /// Point direction.
    /// </summary>
    public BybitCardPointSide Side { get; set; }

    /// <summary>
    /// Type.
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Sub-type.
    /// </summary>
    public string SubType { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Creation time.
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Update timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updateTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Point order ID.
    /// </summary>
    [JsonProperty("bizId")]
    public string BusinessId { get; set; } = string.Empty;

    /// <summary>
    /// Consume ID lifecycle.
    /// </summary>
    [JsonProperty("bizTxnId")]
    public string BusinessTransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Transaction date and time.
    /// </summary>
    public string TransactionDate { get; set; } = string.Empty;

    /// <summary>
    /// Transaction ID.
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Transaction amount.
    /// </summary>
    public decimal? TransactionAmount { get; set; }

    /// <summary>
    /// Transaction currency.
    /// </summary>
    public string BasicCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Merchant category.
    /// </summary>
    public string MerchCategoryDesc { get; set; } = string.Empty;

    /// <summary>
    /// Merchant name.
    /// </summary>
    public string MerchName { get; set; } = string.Empty;

    /// <summary>
    /// Merchant country.
    /// </summary>
    public string MerchCountry { get; set; } = string.Empty;

    /// <summary>
    /// Merchant city.
    /// </summary>
    public string MerchCity { get; set; } = string.Empty;

    /// <summary>
    /// Card's last 4 digits.
    /// </summary>
    public string Pan4 { get; set; } = string.Empty;

    /// <summary>
    /// Pay with fiat.
    /// </summary>
    public decimal? PayFiatAmount { get; set; }

    /// <summary>
    /// Pay with crypto.
    /// </summary>
    public decimal? TransactionCurrencyAmount { get; set; }
}
