namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token price list request.
/// </summary>
public record BybitWeb3TokenPriceListRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3TokenPriceListRequest"/> record.
    /// </summary>
    public BybitWeb3TokenPriceListRequest(IEnumerable<BybitWeb3TokenAddressInfo> tokenAddressInfo)
    {
        TokenAddressInfo = [.. tokenAddressInfo];
    }

    /// <summary>
    /// Token identifiers to query.
    /// </summary>
    [JsonProperty("tokenAddressInfo")]
    public List<BybitWeb3TokenAddressInfo> TokenAddressInfo { get; set; }
}
