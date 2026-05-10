namespace Bybit.Api.Web3;

/// <summary>
/// Web3 asset detail result.
/// </summary>
public record BybitWeb3AssetDetail
{
    /// <summary>
    /// Asset details.
    /// </summary>
    public List<BybitWeb3Asset> AssetList { get; set; } = [];
}
