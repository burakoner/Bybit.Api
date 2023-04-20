namespace Bybit.Api.Models.Margin;

public class BybitSpotMarginMode
{
    [JsonConverter(typeof(BooleanConverter))]
    public bool SpotMarginMode { get; set; }
}