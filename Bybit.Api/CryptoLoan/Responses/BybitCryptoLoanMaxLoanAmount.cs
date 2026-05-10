namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan maximum loan amount.
/// </summary>
public record BybitCryptoLoanMaxLoanAmount
{
    /// <summary>
    /// Coin to borrow.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Maximum loan amount.
    /// </summary>
    public decimal MaxLoan { get; set; }

    /// <summary>
    /// Notional USD value.
    /// </summary>
    [JsonProperty("notionalUsd")]
    public decimal NotionalUsd { get; set; }

    /// <summary>
    /// Remaining individual platform borrowing limit.
    /// </summary>
    public decimal RemainingQuota { get; set; }
}
