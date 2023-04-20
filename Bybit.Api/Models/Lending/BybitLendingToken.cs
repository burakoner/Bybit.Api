namespace Bybit.Api.Models.Lending;

internal class BybitLendingTokenContainer
{
    [JsonProperty("marginToken")]
    public IEnumerable<BybitLendingToken> Payload { get; set; }
}

public class BybitLendingToken
{
    public string ProductId { get; set; }

    [JsonProperty("spotToken")]
    public IEnumerable<BybitLendingTokenData> SpotTokens { get; set; }

    [JsonProperty("contractToken")]
    public IEnumerable<BybitLendingTokenData> ContractTokens { get; set; }
}


public class BybitLendingTokenData
{
    public string Token { get; set; }
    public decimal ConvertRatio { get; set; }
}