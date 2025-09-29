namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Bybit Lending Product Leverage
/// </summary>
public record BybitLoanLeverage
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Maximum leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }
}