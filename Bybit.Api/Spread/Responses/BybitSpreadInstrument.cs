namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread instrument.
/// </summary>
public record BybitSpreadInstrument
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Spread contract type.
    /// </summary>
    public BybitSpreadContractType ContractType { get; set; }

    /// <summary>
    /// Spread status.
    /// </summary>
    public BybitSpreadStatus Status { get; set; }

    /// <summary>
    /// Base asset.
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Quote asset.
    /// </summary>
    [JsonProperty("quoteCoin")]
    public string QuoteAsset { get; set; } = string.Empty;

    /// <summary>
    /// Settle asset.
    /// </summary>
    [JsonProperty("settleCoin")]
    public string SettleAsset { get; set; } = string.Empty;

    /// <summary>
    /// Price tick size.
    /// </summary>
    public decimal TickSize { get; set; }

    /// <summary>
    /// Minimum order price.
    /// </summary>
    [JsonProperty("minPrice")]
    public decimal MinimumPrice { get; set; }

    /// <summary>
    /// Maximum order price.
    /// </summary>
    [JsonProperty("maxPrice")]
    public decimal MaximumPrice { get; set; }

    /// <summary>
    /// Order quantity precision.
    /// </summary>
    public decimal LotSize { get; set; }

    /// <summary>
    /// Minimum order quantity.
    /// </summary>
    [JsonProperty("minSize")]
    public decimal MinimumQuantity { get; set; }

    /// <summary>
    /// Maximum order quantity.
    /// </summary>
    [JsonProperty("maxSize")]
    public decimal MaximumQuantity { get; set; }

    /// <summary>
    /// Launch timestamp in milliseconds.
    /// </summary>
    [JsonProperty("launchTime")]
    public long LaunchTimestamp { get; set; }

    /// <summary>
    /// Launch time.
    /// </summary>
    [JsonIgnore]
    public DateTime LaunchTime { get => LaunchTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Delivery timestamp in milliseconds.
    /// </summary>
    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }

    /// <summary>
    /// Delivery time. Null when Bybit returns 0 for non-delivery combinations.
    /// </summary>
    [JsonIgnore]
    public DateTime? DeliveryTime { get => DeliveryTimestamp > 0 ? DeliveryTimestamp.ConvertFromMilliseconds() : null; }

    /// <summary>
    /// Spread leg information.
    /// </summary>
    public List<BybitSpreadInstrumentLeg> Legs { get; set; } = [];
}

/// <summary>
/// Bybit spread instrument leg.
/// </summary>
public record BybitSpreadInstrumentLeg
{
    /// <summary>
    /// Leg symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Leg contract type.
    /// </summary>
    public BybitSpreadLegContractType ContractType { get; set; }
}
