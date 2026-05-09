namespace Bybit.Api.Asset;

/// <summary>
/// Convert status request.
/// </summary>
public record BybitAssetConvertStatusRequest
{
    public BybitAssetConvertStatusRequest(string quoteTransactionId, string accountType)
    {
        QuoteTransactionId = quoteTransactionId;
        AccountType = accountType;
    }

    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; }

    [JsonProperty("accountType")]
    public string AccountType { get; set; }
}
