namespace Bybit.Api.Models.Market;

public class BybitInsurance
{
    public string Coin { get; set; }
    public decimal Balance { get; set; }
    [JsonProperty("value")]
    public decimal UsdValue { get; set; }
}