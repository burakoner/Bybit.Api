namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan collateral coin data.
/// </summary>
public record BybitCryptoLoanCollateralData
{
    /// <summary>
    /// Collateral ratio configuration list.
    /// </summary>
    public List<BybitCryptoLoanCollateralRatioConfig> CollateralRatioConfigList { get; set; } = [];

    /// <summary>
    /// Currency liquidation order list.
    /// </summary>
    public List<BybitCryptoLoanCurrencyLiquidation> CurrencyLiquidationList { get; set; } = [];
}

/// <summary>
/// Crypto loan collateral ratio configuration.
/// </summary>
public record BybitCryptoLoanCollateralRatioConfig
{
    /// <summary>
    /// Collateral ratio tiers.
    /// </summary>
    public List<BybitCryptoLoanCollateralRatio> CollateralRatioList { get; set; } = [];

    /// <summary>
    /// Currencies with the same collateral ratio.
    /// </summary>
    public string Currencies { get; set; } = string.Empty;
}

/// <summary>
/// Crypto loan collateral ratio tier.
/// </summary>
public record BybitCryptoLoanCollateralRatio
{
    /// <summary>
    /// Collateral ratio.
    /// </summary>
    public decimal CollateralRatio { get; set; }

    /// <summary>
    /// Maximum quantity.
    /// </summary>
    public decimal MaxValue { get; set; }

    /// <summary>
    /// Minimum quantity.
    /// </summary>
    public decimal MinValue { get; set; }
}

/// <summary>
/// Crypto loan currency liquidation order.
/// </summary>
public record BybitCryptoLoanCurrencyLiquidation
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Liquidation order.
    /// </summary>
    public int LiquidationOrder { get; set; }
}
