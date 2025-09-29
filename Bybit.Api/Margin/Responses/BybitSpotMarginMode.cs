namespace Bybit.Api.Margin;

/// <summary>
/// Bybit Spot Margin Mode
/// </summary>
public record BybitSpotMarginMode
{
    /// <summary>
    /// Spot Margin Mode
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool SpotMarginMode { get; set; }
}