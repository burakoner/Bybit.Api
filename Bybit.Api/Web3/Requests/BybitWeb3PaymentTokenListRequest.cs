namespace Bybit.Api.Web3;

/// <summary>
/// Web3 payment token list request.
/// </summary>
public record BybitWeb3PaymentTokenListRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3PaymentTokenListRequest"/> record.
    /// </summary>
    public BybitWeb3PaymentTokenListRequest(string chainCode, string tokenAddress)
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
