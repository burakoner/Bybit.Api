namespace Bybit.Api.Asset;

/// <summary>
/// Bybit total members assets.
/// </summary>
public record BybitAssetTotalMembersAssets
{
    /// <summary>
    /// Total asset value in USD.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Total asset value in the quoted coin.
    /// </summary>
    public decimal QuoteTotal { get; set; }

    /// <summary>
    /// Downstream data status. 0 is normal.
    /// </summary>
    public int Stat { get; set; }

    /// <summary>
    /// Account asset list.
    /// </summary>
    public List<BybitAssetTotalMembersAsset> List { get; set; } = [];
}

/// <summary>
/// Bybit member asset summary.
/// </summary>
public record BybitAssetTotalMembersAsset
{
    /// <summary>
    /// User ID.
    /// </summary>
    [JsonProperty("uid")]
    public long UserId { get; set; }

    /// <summary>
    /// Whether this row is the master account.
    /// </summary>
    [JsonProperty("isM")]
    public bool? IsMaster { get; set; }

    /// <summary>
    /// Sub-account type.
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// Downstream data status. 0 is normal.
    /// </summary>
    public int Stat { get; set; }

    /// <summary>
    /// Original balance in USD.
    /// </summary>
    [JsonProperty("origb")]
    public decimal OriginalBalance { get; set; }

    /// <summary>
    /// Balance in the requested quote coin.
    /// </summary>
    [JsonProperty("quoteb")]
    public decimal? QuoteBalance { get; set; }

    /// <summary>
    /// Account type breakdown.
    /// </summary>
    public List<BybitAssetTotalMembersAssetItem> Items { get; set; } = [];
}

/// <summary>
/// Bybit member asset account type breakdown.
/// </summary>
public record BybitAssetTotalMembersAssetItem
{
    /// <summary>
    /// Account type label.
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Original balance in USD.
    /// </summary>
    [JsonProperty("origb")]
    public decimal OriginalBalance { get; set; }

    /// <summary>
    /// Balance in the requested quote coin.
    /// </summary>
    [JsonProperty("quoteb")]
    public decimal QuoteBalance { get; set; }

    /// <summary>
    /// Downstream data status. 0 is normal.
    /// </summary>
    public int Stat { get; set; }
}
