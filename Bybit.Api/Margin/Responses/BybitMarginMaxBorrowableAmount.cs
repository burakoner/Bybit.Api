namespace Bybit.Api.Margin;

/// <summary>
/// Max borrowable amount.
/// </summary>
public record BybitMarginMaxBorrowableAmount
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Max borrowable amount.
    /// </summary>
    [JsonProperty("maxLoan")]
    public decimal MaxBorrowableAmount { get; set; }
}
