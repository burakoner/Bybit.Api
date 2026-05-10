namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token address identifier.
/// </summary>
public record BybitWeb3TokenAddressInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3TokenAddressInfo"/> record.
    /// </summary>
    public BybitWeb3TokenAddressInfo(string chainCode, string tokenAddress)
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
