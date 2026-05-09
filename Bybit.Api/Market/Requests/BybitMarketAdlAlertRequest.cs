namespace Bybit.Api.Market;

/// <summary>
/// Request for ADL alert.
/// </summary>
public record BybitMarketAdlAlertRequest
{
    /// <summary>
    /// Contract name.
    /// </summary>
    public string? Symbol { get; set; }
}
