namespace Bybit.Api.Web3;

/// <summary>
/// Web3 payment token.
/// </summary>
public record BybitWeb3PaymentToken
{
    /// <summary>
    /// Payment token code.
    /// </summary>
    public string TokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Token symbol.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Token decimal precision.
    /// </summary>
    public int TokenDecimals { get; set; }

    /// <summary>
    /// Token icon URL for light mode.
    /// </summary>
    public string TokenIconUrlDay { get; set; } = string.Empty;

    /// <summary>
    /// Token icon URL for dark mode.
    /// </summary>
    public string TokenIconUrlNight { get; set; } = string.Empty;

    /// <summary>
    /// Maximum trading amount.
    /// </summary>
    public decimal? Limit { get; set; }

    /// <summary>
    /// Supported blockchain codes.
    /// </summary>
    public List<string> SupportChains { get; set; } = [];
}
