namespace Bybit.Api.Web3;

/// <summary>
/// Web3 token details.
/// </summary>
public record BybitWeb3TokenDetails
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
    /// Minimum order quantity.
    /// </summary>
    public decimal? MinOrderQuantity { get; set; }

    /// <summary>
    /// Maximum order quantity.
    /// </summary>
    public decimal? MaxOrderQuantity { get; set; }

    /// <summary>
    /// Maximum position quantity per user.
    /// </summary>
    public decimal? MaxPositionQuantity { get; set; }

    /// <summary>
    /// Token project description.
    /// </summary>
    public string TokenDesc { get; set; } = string.Empty;

    /// <summary>
    /// X profile URL.
    /// </summary>
    public string XUrl { get; set; } = string.Empty;

    /// <summary>
    /// Official website URL.
    /// </summary>
    public string OfficialUrl { get; set; } = string.Empty;

    /// <summary>
    /// Whitepaper URL.
    /// </summary>
    public string WhitePaperUrl { get; set; } = string.Empty;

    /// <summary>
    /// Token tag.
    /// </summary>
    public BybitWeb3TokenTag TokenTag { get; set; }

    /// <summary>
    /// Risk flag.
    /// </summary>
    public BybitWeb3RiskFlag RiskFlag { get; set; }

    /// <summary>
    /// Token creation timestamp on chain in seconds.
    /// </summary>
    public long? CreateTimeOnchain { get; set; }

    /// <summary>
    /// Token creation time on chain.
    /// </summary>
    public DateTime? CreateTimeOnchainDateTime { get => CreateTimeOnchain.HasValue ? CreateTimeOnchain.Value.ConvertFromSeconds() : null; }

    /// <summary>
    /// Token status.
    /// </summary>
    public BybitWeb3TokenStatus Status { get; set; }

    /// <summary>
    /// Token tag IDs.
    /// </summary>
    public List<int> TokenTags { get; set; } = [];

    /// <summary>
    /// Whether to display a notification.
    /// </summary>
    public BybitWeb3MessageDisplay ShowMessage { get; set; }

    /// <summary>
    /// Notification message content.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Notification link display name.
    /// </summary>
    public string LinkName { get; set; } = string.Empty;

    /// <summary>
    /// Notification link URL.
    /// </summary>
    public string LinkAddress { get; set; } = string.Empty;
}
