namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card reward tier information.
/// </summary>
public record BybitCardTierInfo
{
    /// <summary>
    /// Used spending limit.
    /// </summary>
    public decimal UsedLimit { get; set; }

    /// <summary>
    /// Total spending limit.
    /// </summary>
    public decimal Limit { get; set; }

    /// <summary>
    /// Limit unit.
    /// </summary>
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// User tier level.
    /// </summary>
    public string Tier { get; set; } = string.Empty;

    /// <summary>
    /// Whether auto cashback is enabled.
    /// </summary>
    public bool AutoCashback { get; set; }
}
