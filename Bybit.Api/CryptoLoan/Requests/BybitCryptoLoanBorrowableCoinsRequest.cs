namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get crypto loan borrowable coins request.
/// </summary>
public record BybitCryptoLoanBorrowableCoinsRequest
{
    /// <summary>
    /// VIP level.
    /// </summary>
    [JsonProperty("vipLevel", NullValueHandling = NullValueHandling.Ignore)]
    public string? VipLevel { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
    public string? Currency { get; set; }
}
