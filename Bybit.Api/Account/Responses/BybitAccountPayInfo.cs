namespace Bybit.Api.Account;

/// <summary>
/// Bybit account pay information.
/// </summary>
public record BybitAccountPayInfo
{
    /// <summary>
    /// Collateral information.
    /// </summary>
    public BybitAccountPayCollateralInfo CollateralInfo { get; set; } = default!;

    /// <summary>
    /// Borrow information. Returned when a coin is specified.
    /// </summary>
    public BybitAccountPayBorrowInfo? BorrowInfo { get; set; }
}

/// <summary>
/// Bybit account pay collateral information.
/// </summary>
public record BybitAccountPayCollateralInfo
{
    /// <summary>
    /// Collateral list.
    /// </summary>
    public List<BybitAccountPayCollateral> CollateralList { get; set; } = [];
}

/// <summary>
/// Bybit account pay collateral item.
/// </summary>
public record BybitAccountPayCollateral
{
    /// <summary>
    /// Collateral coin.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Available size.
    /// </summary>
    public decimal AvailableSize { get; set; }

    /// <summary>
    /// Available value in USD.
    /// </summary>
    public decimal AvailableValue { get; set; }

    /// <summary>
    /// Coin precision.
    /// </summary>
    public int CoinScale { get; set; }

    /// <summary>
    /// Borrow size.
    /// </summary>
    public decimal BorrowSize { get; set; }

    /// <summary>
    /// Spot hedge amount.
    /// </summary>
    public decimal SpotHedgeAmount { get; set; }

    /// <summary>
    /// Frozen asset.
    /// </summary>
    public decimal AssetFrozen { get; set; }
}

/// <summary>
/// Bybit account pay borrow information.
/// </summary>
public record BybitAccountPayBorrowInfo
{
    /// <summary>
    /// Borrow coin.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Borrow size.
    /// </summary>
    public decimal BorrowSize { get; set; }

    /// <summary>
    /// Borrow value in USD.
    /// </summary>
    public decimal BorrowValue { get; set; }

    /// <summary>
    /// Frozen asset.
    /// </summary>
    public decimal AssetFrozen { get; set; }

    /// <summary>
    /// Available balance.
    /// </summary>
    public decimal AvailableBalance { get; set; }
}
