namespace Bybit.Api.Stream.Spot;

public class BybitSpotAccountUpdate : BybitSocketEvent
{
    [JsonProperty("T")]
    public bool AllowTrade { get; set; }
    
    [JsonProperty("W")]
    public bool AllowWithdraw { get; set; }
    
    [JsonProperty("D")]
    public bool AllowDeposit { get; set; }
    
    [JsonProperty("B")]
    public IEnumerable<BybitSpotAccountBalance> Balances { get; set; } = Array.Empty<BybitSpotAccountBalance>();
}

public class BybitSpotAccountBalance
{
    [JsonProperty("a")]
    public string Asset { get; set; }

    [JsonProperty("f")]
    public decimal Available { get; set; }

    [JsonProperty("l")]
    public decimal Locked { get; set; }
}
