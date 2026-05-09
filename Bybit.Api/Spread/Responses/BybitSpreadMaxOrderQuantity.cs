namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread maximum order quantity.
/// </summary>
public record BybitSpreadMaxOrderQuantity
{
    /// <summary>
    /// Maximum order quantity.
    /// </summary>
    [JsonProperty("ab")]
    public decimal MaximumOrderQuantity { get; set; }
}
