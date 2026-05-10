namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get crypto loan collateral coins request.
/// </summary>
public record BybitCryptoLoanCollateralCoinsRequest
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
    public string? Currency { get; set; }
}
