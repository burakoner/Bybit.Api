namespace Bybit.Api.Asset;

/// <summary>
/// Convert status request.
/// </summary>
public record BybitAssetConvertStatusRequest
{
    /// <summary>
    /// Initializes a new convert status request.
    /// </summary>
    /// <param name="quoteTransactionId">Quote transaction ID.</param>
    /// <param name="accountType">Convert wallet type.</param>
    public BybitAssetConvertStatusRequest(string quoteTransactionId, string accountType)
    {
        QuoteTransactionId = quoteTransactionId;
        AccountType = accountType;
    }

    /// <summary>
    /// Quote transaction ID.
    /// </summary>
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; }

    /// <summary>
    /// Convert wallet type.
    /// </summary>
    [JsonProperty("accountType")]
    public string AccountType { get; set; }
}
