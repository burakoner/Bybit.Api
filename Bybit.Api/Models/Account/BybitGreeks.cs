namespace Bybit.Api.Models.Account;

/// <summary>
/// Greeks
/// </summary>
public class BybitGreeks
{
    /// <summary>
    /// Asset
    /// </summary>
    public string BaseAsset { get; set; }
    /// <summary>
    /// Delta
    /// </summary>
    public decimal TotalDelta { get; set; }
    /// <summary>
    /// Gamma
    /// </summary>
    public decimal TotalGamma { get; set; }
    /// <summary>
    /// Vega
    /// </summary>
    public decimal TotalVega { get; set; }
    /// <summary>
    /// Theta
    /// </summary>
    public decimal TotalTheta { get; set; }
}
