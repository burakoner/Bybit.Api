namespace Bybit.Api.Models.Lending;

internal class BybitLendingTokenContainer
{
    [JsonProperty("marginToken")]
    public List<BybitLendingToken> Payload { get; set; } = [];
}

public class BybitLendingToken
{
    public string ProductId { get; set; }

    [JsonProperty("spotToken")]
    public List<BybitLendingTokenData> SpotTokens { get; set; } = [];

    [JsonProperty("contractToken")]
    public List<BybitLendingTokenData> ContractTokens { get; set; } = [];
}


public class BybitLendingTokenData
{
    public string Token { get; set; }
    public decimal ConvertRatio { get; set; }
}