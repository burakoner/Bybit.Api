namespace Bybit.Api.Asset;

/// <summary>
/// Confirm convert quote request.
/// </summary>
public record BybitAssetConvertExecuteRequest
{
    /// <summary>
    /// Initializes a new convert quote confirmation request.
    /// </summary>
    /// <param name="quoteTransactionId">Quote transaction ID returned by the quote endpoint.</param>
    public BybitAssetConvertExecuteRequest(string quoteTransactionId)
    {
        QuoteTransactionId = quoteTransactionId;
    }

    /// <summary>
    /// Quote transaction ID returned by the quote endpoint.
    /// </summary>
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; }
}
