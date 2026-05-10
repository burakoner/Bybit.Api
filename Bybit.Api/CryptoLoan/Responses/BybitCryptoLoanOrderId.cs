namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan order ID response.
/// </summary>
public record BybitCryptoLoanOrderId
{
    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;
}
