namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token price.
/// </summary>
public record BybitWeb3TokenPrice
{
    /// <summary>
    /// Blockchain code.
    /// </summary>
    public string ChainCode { get; set; } = string.Empty;

    /// <summary>
    /// Token contract address.
    /// </summary>
    public string TokenAddress { get; set; } = string.Empty;

    /// <summary>
    /// Current price in USD.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Twenty-four hour price change.
    /// </summary>
    public decimal? Change24h { get; set; }

    /// <summary>
    /// Twenty-four hour volume in USD.
    /// </summary>
    public decimal? Vol24h { get; set; }

    /// <summary>
    /// Market capitalization in USD.
    /// </summary>
    public decimal? MarketCap { get; set; }

    /// <summary>
    /// Total liquidity in USD.
    /// </summary>
    public decimal? Liquidity { get; set; }

    /// <summary>
    /// Number of holders.
    /// </summary>
    public long? Holders { get; set; }
}
