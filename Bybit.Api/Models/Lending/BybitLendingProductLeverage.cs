namespace Bybit.Api.Models.Lending;

/// <summary>
/// Bybit Lending Product Leverage
/// </summary>
public class BybitLendingProductLeverage
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Maximum leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }
}