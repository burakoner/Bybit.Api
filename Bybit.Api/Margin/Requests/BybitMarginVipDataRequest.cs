namespace Bybit.Api.Margin;

/// <summary>
/// Get VIP margin data request.
/// </summary>
public record BybitMarginVipDataRequest
{
    /// <summary>
    /// VIP level.
    /// </summary>
    public string? VipLevel { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string? Currency { get; set; }
}
