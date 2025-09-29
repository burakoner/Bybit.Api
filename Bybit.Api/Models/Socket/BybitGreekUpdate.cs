namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit Greek stream
/// </summary>
public class BybitGreekUpdate
{
    /// <summary>
    /// Base coin
    /// </summary>
    public string BaseCoin { get; set; } = string.Empty;

    /// <summary>
    /// Delta value
    /// </summary>
    public decimal TotalDelta { get; set; }

    /// <summary>
    /// Gamma value
    /// </summary>
    public decimal TotalGamma { get; set; }

    /// <summary>
    /// Vega value
    /// </summary>
    public decimal TotalVega { get; set; }

    /// <summary>
    /// Theta value
    /// </summary>
    public decimal TotalTheta { get; set; }
}