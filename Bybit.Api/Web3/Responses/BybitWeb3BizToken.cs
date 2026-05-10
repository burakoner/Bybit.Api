namespace Bybit.Api.Web3;

/// <summary>
/// Web3 business token.
/// </summary>
public record BybitWeb3BizToken
{
    /// <summary>
    /// Token code.
    /// </summary>
    public string TokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Blockchain code.
    /// </summary>
    public string ChainCode { get; set; } = string.Empty;

    /// <summary>
    /// Chain icon URL.
    /// </summary>
    public string ChainIconUrl { get; set; } = string.Empty;

    /// <summary>
    /// Token contract address.
    /// </summary>
    public string TokenAddress { get; set; } = string.Empty;

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
    /// Token listing timestamp in seconds.
    /// </summary>
    public long CreateTime { get; set; }

    /// <summary>
    /// Token listing time.
    /// </summary>
    public DateTime CreateDateTime { get => CreateTime.ConvertFromSeconds(); }

    /// <summary>
    /// Token creation timestamp on chain in seconds.
    /// </summary>
    public long? CreateTimeOnchain { get; set; }

    /// <summary>
    /// Token creation time on chain.
    /// </summary>
    public DateTime? CreateTimeOnchainDateTime { get => CreateTimeOnchain.HasValue ? CreateTimeOnchain.Value.ConvertFromSeconds() : null; }

    /// <summary>
    /// Risk flag.
    /// </summary>
    public BybitWeb3RiskFlag RiskFlag { get; set; }

    /// <summary>
    /// Minimum order quantity.
    /// </summary>
    public decimal? MinOrderQuantity { get; set; }

    /// <summary>
    /// Maximum order quantity.
    /// </summary>
    public decimal? MaxOrderQuantity { get; set; }

    /// <summary>
    /// Token tag IDs.
    /// </summary>
    public List<int> TokenTags { get; set; } = [];

    /// <summary>
    /// Supported payment token codes.
    /// </summary>
    public List<string> PayTokenCodes { get; set; } = [];
}
