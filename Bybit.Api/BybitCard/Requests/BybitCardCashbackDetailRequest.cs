namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card cashback detail request.
/// </summary>
public record BybitCardCashbackDetailRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCardCashbackDetailRequest"/> record.
    /// </summary>
    /// <param name="businessTransactionId">Order ID.</param>
    public BybitCardCashbackDetailRequest(string businessTransactionId)
    {
        BusinessTransactionId = businessTransactionId;
    }

    /// <summary>
    /// Order ID.
    /// </summary>
    [JsonProperty("bizTxnId")]
    public string BusinessTransactionId { get; set; }
}
