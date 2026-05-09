namespace Bybit.Api.Asset;

/// <summary>
/// Confirm convert quote request.
/// </summary>
public record BybitAssetConvertExecuteRequest
{
    public BybitAssetConvertExecuteRequest(string quoteTransactionId)
    {
        QuoteTransactionId = quoteTransactionId;
    }

    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; }
}
