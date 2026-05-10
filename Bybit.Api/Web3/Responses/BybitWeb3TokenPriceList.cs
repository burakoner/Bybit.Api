namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token price list result.
/// </summary>
public record BybitWeb3TokenPriceList
{
    /// <summary>
    /// Token price info list.
    /// </summary>
    public List<BybitWeb3TokenPrice> TokenPriceInfoList { get; set; } = [];
}
