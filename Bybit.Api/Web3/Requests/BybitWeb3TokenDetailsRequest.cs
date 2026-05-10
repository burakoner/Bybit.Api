namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token details request.
/// </summary>
public record BybitWeb3TokenDetailsRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3TokenDetailsRequest"/> record.
    /// </summary>
    public BybitWeb3TokenDetailsRequest(string chainCode, string tokenAddress)
    {
        ChainCode = chainCode;
        TokenAddress = tokenAddress;
    }

    /// <summary>
    /// Blockchain code.
    /// </summary>
    [JsonProperty("chainCode")]
    public string ChainCode { get; set; }

    /// <summary>
    /// Token contract address.
    /// </summary>
    [JsonProperty("tokenAddress")]
    public string TokenAddress { get; set; }
}
