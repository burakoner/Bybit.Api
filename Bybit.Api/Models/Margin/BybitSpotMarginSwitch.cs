namespace Bybit.Api.Models.Margin;

public class BybitSpotMarginSwitch
{
    [JsonConverter(typeof(BooleanConverter))]
    public bool SpotMarginMode { get; set; }
}