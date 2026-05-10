namespace Bybit.Api.Web3;

/// <summary>
/// Web3 asset list result.
/// </summary>
public record BybitWeb3AssetList
{
    /// <summary>
    /// Total portfolio value in USD.
    /// </summary>
    public decimal? TotalAssetUsd { get; set; }

    /// <summary>
    /// Token holdings.
    /// </summary>
    public List<BybitWeb3Asset> AssetList { get; set; } = [];
}
