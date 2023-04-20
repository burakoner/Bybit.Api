namespace Bybit.Api.Models.Margin;

public class BybitSpotMarginAsset
{
    [JsonProperty("coin")]
    public string Asset { get; set; }
    public decimal ConversionRate { get; set; }
    public int LiquidationOrder { get; set; }
}