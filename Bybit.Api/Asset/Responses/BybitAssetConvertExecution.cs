namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert execution response.
/// </summary>
public record BybitAssetConvertExecution
{
    /// <summary>
    /// Quote transaction ID.
    /// </summary>
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Convert execution status.
    /// </summary>
    public BybitConvertStatus ExchangeStatus { get; set; }
}
