namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Cancel fixed crypto loan supply order request.
/// </summary>
public record BybitCryptoLoanFixedCancelSupplyRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFixedCancelSupplyRequest"/> record.
    /// </summary>
    /// <param name="orderId">Supply order ID.</param>
    public BybitCryptoLoanFixedCancelSupplyRequest(string orderId)
    {
        OrderId = orderId;
    }

    /// <summary>
    /// Supply order ID.
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// Refund account.
    /// </summary>
    [JsonProperty("refundedAccount", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCryptoLoanRefundedAccount? RefundedAccount { get; set; }
}
