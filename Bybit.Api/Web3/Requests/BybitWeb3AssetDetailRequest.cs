namespace Bybit.Api.Web3;

/// <summary>
/// Web3 asset detail request.
/// </summary>
public record BybitWeb3AssetDetailRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3AssetDetailRequest"/> record.
    /// </summary>
    public BybitWeb3AssetDetailRequest(string chainCode, string tokenAddress)
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
