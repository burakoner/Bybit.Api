namespace Bybit.Api.Market;

/// <summary>
/// Bybit Spot Instrument
/// </summary>
public record BybitMarketSpotInstrument
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Base asset
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Quote asset
    /// </summary>
    [JsonProperty("quoteCoin")]
    public string QuoteAsset { get; set; } = string.Empty;

    /// <summary>
    /// Whether or not this is an innovation zone token. 0: false, 1: true
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool Innovation { get; set; }

    /// <summary>
    /// the region to which the trading pair belongs
    /// </summary>
    [JsonProperty("symbolType")]
    public BybitInstrumentType? Type { get; set; }

    /// <summary>
    /// Instrument status
    /// </summary>
    public BybitInstrumentStatus Status { get; set; }

    /// <summary>
    /// Margin trade symbol or not
    /// </summary>
    public BybitMarginTradingStatus MarginTrading { get; set; }

    /// <summary>
    /// Whether or not it has an special treatment label. 0: false, 1: true
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool SpecialTreatment { get; set; }

    /// <summary>
    /// Size attributes
    /// </summary>
    [JsonProperty("lotSizeFilter")]
    public BybitMarketSpotInstrumentLotSizeFilter LotSizeFilter { get; set; } = default!;

    /// <summary>
    /// Price attributes
    /// </summary>
    [JsonProperty("priceFilter")]
    public BybitMarketSpotInstrumentPriceFilter PriceFilter { get; set; } = default!;

    /// <summary>
    /// Risk parameters for limit order price. Note that the formula changed in Jan 2025
    /// </summary>
    [JsonProperty("riskParameters")]
    public BybitMarketSpotInstrumentRiskParameters RiskParameters { get; set; } = default!;
}

/// <summary>
/// Spot Instrument Lot Size Filters
/// </summary>
public record BybitMarketSpotInstrumentLotSizeFilter
{
    /// <summary>
    /// The precision of base coin
    /// </summary>
    public decimal BasePrecision { get; set; }

    /// <summary>
    /// The precision of quote coin
    /// </summary>
    public decimal QuotePrecision { get; set; }

    /// <summary>
    /// Minimum order quantity
    /// </summary>
    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    /// <summary>
    /// Maximum order quantity
    /// </summary>
    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }

    /// <summary>
    /// Minimum order amount
    /// </summary>
    [JsonProperty("minOrderAmt")]
    public decimal MinimumOrderAmount { get; set; }

    /// <summary>
    /// Maximum order amount
    /// </summary>
    [JsonProperty("maxOrderAmt")]
    public decimal MaximumOrderAmount { get; set; }
}

/// <summary>
/// Spot Instrument Price Filters
/// </summary>
public record BybitMarketSpotInstrumentPriceFilter
{
    /// <summary>
    /// The step to increase/reduce order price
    /// </summary>
    public decimal TickSize { get; set; }
}

/// <summary>
/// Spot Instrument Risk Parameters
/// </summary>
public record BybitMarketSpotInstrumentRiskParameters
{
    /// <summary>
    /// PriceLimitRatioX
    /// </summary>
    [JsonProperty("priceLimitRatioX")]
    public decimal? PriceLimitRatioX { get; set; }

    /// <summary>
    /// PriceLimitRatioY
    /// </summary>
    [JsonProperty("priceLimitRatioY")]
    public decimal? PriceLimitRatioY { get; set; }
}

/// <summary>
/// Bybit Linear/Inverse Instrument
/// </summary>
public record BybitMarketFuturesInstrument
{
    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Contract type
    /// </summary>
    public BybitContractType ContractType { get; set; }

    /// <summary>
    /// Instrument status
    /// </summary>
    public BybitInstrumentStatus Status { get; set; }

    /// <summary>
    /// Base asset
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Quote asset
    /// </summary>
    [JsonProperty("quoteCoin")]
    public string QuoteAsset { get; set; } = string.Empty;

    /// <summary>
    /// the region to which the trading pair belongs
    /// </summary>
    [JsonProperty("symbolType")]
    public BybitInstrumentType? Type { get; set; }

    /// <summary>
    /// Launch time
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LaunchTime { get; set; }

    /// <summary>
    /// Delivery time
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DeliveryTime { get; set; }

    /// <summary>
    /// Delivery fee rate
    /// </summary>
    public decimal? DeliveryFeeRate { get; set; }

    /// <summary>
    /// Price scale
    /// </summary>
    public decimal PriceScale { get; set; }

    /// <summary>
    /// Leverage attributes
    /// </summary>
    [JsonProperty("leverageFilter")]
    public BybitMarketFuturesInstrumentLeverageFilter LeverageFilter { get; set; } = default!;

    /// <summary>
    /// Price attributes
    /// </summary>
    [JsonProperty("priceFilter")]
    public BybitMarketFuturesInstrumentPriceFilter PriceFilter { get; set; } = default!;

    /// <summary>
    /// Size attributes
    /// </summary>
    [JsonProperty("lotSizeFilter")]
    public BybitMarketFuturesInstrumentLotSizeFilter LotSizeFilter { get; set; } = default!;

    /// <summary>
    /// Whether to support unified margin trade
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool UnifiedMarginTrade { get; set; }

    /// <summary>
    /// Funding interval (minute)
    /// </summary>
    public int FundingInterval { get; set; }

    /// <summary>
    /// Settle asset
    /// </summary>
    [JsonProperty("settleCoin")]
    public string SettleAsset { get; set; } = string.Empty;

    /// <summary>
    /// Copy trading support
    /// </summary>
    public BybitCopyTradingSupport CopyTrading { get; set; }

    /// <summary>
    /// Upper limit of funding date
    /// </summary>
    [JsonProperty("upperFundingRate")]
    public decimal UpperFundingRate { get; set; }

    /// <summary>
    /// Lower limit of funding data
    /// </summary>
    [JsonProperty("lowerFundingRate")]
    public decimal LowerFundingRate { get; set; }

    /// <summary>
    /// The USDC futures &amp; perpetual name displayed in the Web or App
    /// </summary>
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = "";

    /// <summary>
    /// Risk parameters for limit order price. Note that the formula changed in Jan 2025
    /// </summary>
    [JsonProperty("riskParameters")]
    public BybitMarketFuturesInstrumentRiskParameters RiskParameters { get; set; } = default!;

    /// <summary>
    /// Whether the contract is a pre-market contract
    /// When the pre-market contract is converted to official contract, it will be false
    /// </summary>
    public bool IsPreListing { get; set; }

    /// <summary>
    /// If isPreListing=false, preListingInfo=null
    /// If isPreListing=true, preListingInfo is an object
    /// </summary>
    [JsonProperty("preListingInfo")]
    public BybitMarketFuturesInstrumentPreListingInformation PreListingInformation{ get; set; } = default!;
}

/// <summary>
/// Bybit Linear/Inverse Instrument Leverage Filter
/// </summary>
public record BybitMarketFuturesInstrumentLeverageFilter
{
    /// <summary>
    /// Minimum leverage
    /// </summary>
    [JsonProperty("minLeverage")]
    public decimal MinimumLeverage { get; set; }

    /// <summary>
    /// Maximum leverage
    /// </summary>
    [JsonProperty("maxLeverage")]
    public decimal MaximumLeverage { get; set; }

    /// <summary>
    /// The step to increase/reduce leverage
    /// </summary>
    public decimal LeverageStep { get; set; }
}

/// <summary>
/// Bybit Linear/Inverse Instrument Price Filter
/// </summary>
public record BybitMarketFuturesInstrumentPriceFilter
{
    /// <summary>
    /// Minimum price
    /// </summary>
    [JsonProperty("minPrice")]
    public decimal MinimumPrice { get; set; }

    /// <summary>
    /// Maximum price
    /// </summary>
    [JsonProperty("maxPrice")]
    public decimal MaximumPrice { get; set; }

    /// <summary>
    /// The step to increase/reduce order price
    /// </summary>
    public decimal TickSize { get; set; }
}

/// <summary>
/// Bybit Linear/Inverse Instrument Lot Size Filter
/// </summary>
public record BybitMarketFuturesInstrumentLotSizeFilter
{
    /// <summary>
    /// Minimum notional value
    /// </summary>
    [JsonProperty("minNotionalValue")]
    public decimal MinimumNotionalValue { get; set; }

    /// <summary>
    /// Maximum quantity for Limit and PostOnly order
    /// </summary>
    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }

    /// <summary>
    /// Maximum quantity for Market order
    /// </summary>
    [JsonProperty("maxMktOrderQty")]
    public decimal MaximumMarketOrderQuantity { get; set; }

    /// <summary>
    /// Minimum order quantity
    /// </summary>
    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    /// <summary>
    /// The step to increase/reduce order quantity
    /// </summary>
    [JsonProperty("qtyStep")]
    public decimal QuantityStep { get; set; }
}

/// <summary>
/// Bybit Linear/Inverse Instrument Risk Parameters
/// </summary>
public record BybitMarketFuturesInstrumentRiskParameters
{
    /// <summary>
    /// PriceLimitRatioX
    /// </summary>
    [JsonProperty("priceLimitRatioX")]
    public decimal? PriceLimitRatioX { get; set; }

    /// <summary>
    /// PriceLimitRatioY
    /// </summary>
    [JsonProperty("priceLimitRatioY")]
    public decimal? PriceLimitRatioY { get; set; }
}

/// <summary>
/// BybitFuturesInstrumentPreListingDetails
/// </summary>
public record BybitMarketFuturesInstrumentPreListingInformation
{
    /// <summary>
    /// The current auction phase
    /// </summary>
    [JsonProperty("curAuctionPhase")]
    public BybitPreListingPhase CurrentAuctionPhase { get; set; }

    /// <summary>
    /// Each phase time info
    /// </summary>
    [JsonProperty("phases")]
    public List<BybitMarketFuturesInstrumentPreListingPhase> Phases { get; set; } = [];

    /// <summary>
    /// Action fee info
    /// </summary>
    [JsonProperty("auctionFeeInfo")]
    public BybitMarketFuturesInstrumentPreListingAuctionFee AuctionFees { get; set; } = default!;
}

/// <summary>
/// BybitFuturesInstrumentPreListingPhase
/// </summary>
public record BybitMarketFuturesInstrumentPreListingPhase
{
    /// <summary>
    /// pre-market trading phase
    /// </summary>
    [JsonProperty("phase")]
    public BybitPreListingPhase Phase { get; set; }

    /// <summary>
    /// The start time of the phase, timestamp(ms)
    /// </summary>
    [JsonProperty("startTime")]
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// The end time of the phase, timestamp(ms)
    /// </summary>
    [JsonProperty("endTime")]
    public DateTime? EndTime { get; set; }
}

/// <summary>
/// BybitFuturesInstrumentPreListingAuctionFee
/// </summary>
public record BybitMarketFuturesInstrumentPreListingAuctionFee
{
    /// <summary>
    /// The trading fee rate during auction phase
    /// There is no trading fee until entering continues trading phase
    /// </summary>
    [JsonProperty("auctionFeeRate")]
    public decimal AuctionFeeRate { get; set; }

    /// <summary>
    /// The taker fee rate during continues trading phase
    /// </summary>
    [JsonProperty("takerFeeRate")]
    public decimal TakerFeeRate { get; set; }

    /// <summary>
    /// The maker fee rate during continues trading phase
    /// </summary>
    [JsonProperty("makerFeeRate")]
    public decimal MakerFeeRate { get; set; }
}

/// <summary>
/// Bybit Option Instrument
/// </summary>
public record BybitMarketOptionInstrument
{
    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Option type. Call, Put
    /// </summary>
    public BybitOptionType OptionsType { get; set; }

    /// <summary>
    /// Instrument status
    /// </summary>
    public BybitInstrumentStatus Status { get; set; }

    /// <summary>
    /// Base asset
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Quote asset
    /// </summary>
    [JsonProperty("quoteCoin")]
    public string QuoteAsset { get; set; } = string.Empty;

    /// <summary>
    /// Settle asset
    /// </summary>
    [JsonProperty("settleCoin")]
    public string SettleAsset { get; set; } = string.Empty;

    /// <summary>
    /// Launch timestamp (ms)
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LaunchTime { get; set; }

    /// <summary>
    /// Delivery timestamp (ms)
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DeliveryTime { get; set; }

    /// <summary>
    /// Delivery fee rate
    /// </summary>
    public decimal DeliveryFeeRate { get; set; }

    /// <summary>
    /// Price attributes
    /// </summary>
    public BybitMarketOptionsInstrumentPriceFilter PriceFilter { get; set; } = default!;

    /// <summary>
    /// Size attributes
    /// </summary>
    public BybitMarketOptionsInstrumentLotSizeFilter LotSizeFilter { get; set; } = default!;

    /// <summary>
    /// The option name displayed in the Web or App
    /// </summary>
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = "";
}

/// <summary>
/// Bybit Options Instrument Price Filter
/// </summary>
public record BybitMarketOptionsInstrumentPriceFilter
{
    /// <summary>
    /// Minimum order price
    /// </summary>
    [JsonProperty("minPrice")]
    public decimal MinimumPrice { get; set; }

    /// <summary>
    /// Maximum order price
    /// </summary>
    [JsonProperty("maxPrice")]
    public decimal MaximumPrice { get; set; }

    /// <summary>
    /// The step to increase/reduce order price
    /// </summary>
    [JsonProperty("tickSize")]
    public decimal TickSize { get; set; }
}

/// <summary>
/// Bybit Options Instrument Lot Size Filter
/// </summary>
public record BybitMarketOptionsInstrumentLotSizeFilter
{
    /// <summary>
    /// Maximum order quantity
    /// </summary>
    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }

    /// <summary>
    /// Minimum order quantity
    /// </summary>
    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    /// <summary>
    /// The step to increase/reduce order quantity
    /// </summary>
    [JsonProperty("qtyStep")]
    public decimal QuantityStep { get; set; }
}
