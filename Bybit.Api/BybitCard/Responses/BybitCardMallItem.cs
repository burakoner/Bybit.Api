namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card reward mall item.
/// </summary>
public record BybitCardMallItem
{
    /// <summary>
    /// Item ID.
    /// </summary>
    public string ItemId { get; set; } = string.Empty;

    /// <summary>
    /// Item name.
    /// </summary>
    public string ItemName { get; set; } = string.Empty;

    /// <summary>
    /// Priority.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Listing timestamp in milliseconds.
    /// </summary>
    [JsonProperty("onTime")]
    public long OnTimestamp { get; set; }

    /// <summary>
    /// Listing time.
    /// </summary>
    public DateTime OnTime { get => OnTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Delisting timestamp in milliseconds.
    /// </summary>
    [JsonProperty("offTime")]
    public long OffTimestamp { get; set; }

    /// <summary>
    /// Delisting time.
    /// </summary>
    public DateTime OffTime { get => OffTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Discounted price.
    /// </summary>
    public decimal DiscountPrice { get; set; }

    /// <summary>
    /// Total quantity.
    /// </summary>
    public int TotalNum { get; set; }

    /// <summary>
    /// Redeemed quantity.
    /// </summary>
    public int RedeemNum { get; set; }

    /// <summary>
    /// Image path.
    /// </summary>
    public string PicPath { get; set; } = string.Empty;

    /// <summary>
    /// Currency.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Currency type.
    /// </summary>
    public BybitCardMallCurrencyType CurrencyType { get; set; }

    /// <summary>
    /// Item type.
    /// </summary>
    public BybitCardMallItemType ItemType { get; set; }

    /// <summary>
    /// Item sub-type.
    /// </summary>
    public BybitCardMallItemBizType ItemBizType { get; set; }
}
