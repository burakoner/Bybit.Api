namespace Bybit.Api.Market;

/// <summary>
/// Request for fee group structure.
/// </summary>
public record BybitMarketFeeGroupInfoRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketFeeGroupInfoRequest"/> record.
    /// </summary>
    /// <param name="productType">Product type</param>
    public BybitMarketFeeGroupInfoRequest(string productType)
    {
        ProductType = productType;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public string ProductType { get; set; }

    /// <summary>
    /// Group ID.
    /// </summary>
    public string? GroupId { get; set; }
}
