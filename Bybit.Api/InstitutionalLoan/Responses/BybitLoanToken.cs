namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// BybitLendingTokenContainer
/// </summary>
internal record BybitLendingTokenContainer
{
    /// <summary>
    /// Payload
    /// </summary>
    [JsonProperty("marginToken")]
    public List<BybitLoanToken> Payload { get; set; } = [];
}

/// <summary>
/// Bybit lending token.
/// </summary>
public record BybitLoanToken
{
    /// <summary>
    /// Product id
    /// </summary>
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Margin coin information.
    /// </summary>
    [JsonProperty("tokenInfo")]
    public List<BybitLoanTokenInfo> TokenInfo { get; set; } = [];

    /// <summary>
    /// Spot tokens. Kept for compatibility with the old documentation shape.
    /// </summary>
    [JsonProperty("spotToken")]
    public List<BybitLendingTokenData> SpotTokens { get; set; } = [];

    /// <summary>
    /// Contract tokens. Kept for compatibility with the old documentation shape.
    /// </summary>
    [JsonProperty("contractToken")]
    public List<BybitLendingTokenData> ContractTokens { get; set; } = [];
}

/// <summary>
/// Bybit lending token information.
/// </summary>
public record BybitLoanTokenInfo
{
    /// <summary>
    /// Margin coin.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Margin coin convert ratio list.
    /// </summary>
    public List<BybitLoanConvertRatio> ConvertRatioList { get; set; } = [];
}

/// <summary>
/// Bybit lending token conversion ratio tier.
/// </summary>
public record BybitLoanConvertRatio
{
    /// <summary>
    /// Ladder.
    /// </summary>
    public string Ladder { get; set; } = string.Empty;

    /// <summary>
    /// Convert ratio.
    /// </summary>
    public decimal ConvertRatio { get; set; }
}

/// <summary>
/// Bybit lending token data
/// </summary>
public record BybitLendingTokenData
{
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Convert ratio
    /// </summary>
    public decimal ConvertRatio { get; set; }
}
