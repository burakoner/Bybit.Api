namespace Bybit.Api.Margin;

internal record BybitMarginVipDataContainer
{
    /// <summary>
    /// VIP margin data groups.
    /// </summary>
    public List<BybitMarginVipData> VipCoinList { get; set; } = [];
}

/// <summary>
/// VIP margin data for one VIP level.
/// </summary>
public record BybitMarginVipData
{
    /// <summary>
    /// VIP level.
    /// </summary>
    public string VipLevel { get; set; } = string.Empty;

    /// <summary>
    /// Coin margin data.
    /// </summary>
    public List<BybitMarginVipCoin> List { get; set; } = [];
}

/// <summary>
/// VIP margin data for one coin.
/// </summary>
public record BybitMarginVipCoin
{
    /// <summary>
    /// Whether it is allowed to be borrowed.
    /// </summary>
    public bool Borrowable { get; set; }

    /// <summary>
    /// Collateral ratio.
    /// </summary>
    public decimal? CollateralRatio { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Borrow interest rate per hour.
    /// </summary>
    public decimal? HourlyBorrowRate { get; set; }

    /// <summary>
    /// Liquidation order.
    /// </summary>
    public int? LiquidationOrder { get; set; }

    /// <summary>
    /// Whether it can be used as a margin collateral currency.
    /// </summary>
    public bool MarginCollateral { get; set; }

    /// <summary>
    /// Max borrow amount.
    /// </summary>
    public decimal? MaxBorrowingAmount { get; set; }
}
