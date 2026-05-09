namespace Bybit.Api.Account;

/// <summary>
/// Bybit account manual borrow result.
/// </summary>
public record BybitAccountManualBorrow
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Borrow amount.
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }
}
