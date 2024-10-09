namespace Bybit.Api.Models.Lending;

/// <summary>
/// BybitLendingTokenContainer
/// </summary>
internal class BybitLendingTokenContainer
{
    /// <summary>
    /// Payload
    /// </summary>
    [JsonProperty("marginToken")]
    public List<BybitLendingToken> Payload { get; set; } = [];
}

/// <summary>
/// Bybit lending token
/// </summary>
public class BybitLendingToken
{
    /// <summary>
    /// Product id
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// Spot Tokens
    /// </summary>
    [JsonProperty("spotToken")]
    public List<BybitLendingTokenData> SpotTokens { get; set; } = [];

    /// <summary>
    /// Contract Tokens
    /// </summary>
    [JsonProperty("contractToken")]
    public List<BybitLendingTokenData> ContractTokens { get; set; } = [];
}

/// <summary>
/// Bybit lending token data
/// </summary>
public class BybitLendingTokenData
{
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Convert ratio
    /// </summary>
    public decimal ConvertRatio { get; set; }
}