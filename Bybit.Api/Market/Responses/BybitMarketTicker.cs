namespace Bybit.Api.Market;

/// <summary>
/// Bybit Spot Ticker
/// </summary>
public class BybitMarketSpotTicker
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid quantity
    /// </summary>
    [JsonProperty("bid1Size")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask quantity
    /// </summary>
    [JsonProperty("ask1Size")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Last trade price
    /// </summary>
    public decimal LastPrice { get; set; }

    /// <summary>
    /// Price 24h ago
    /// </summary>
    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }

    /// <summary>
    /// Price change percentage since 24h ago
    /// </summary>
    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage24H { get; set; }

    /// <summary>
    /// Price change since 24h ago
    /// </summary>
    public decimal PriceChange24H { get => LastPrice - OpenPrice24H; }

    /// <summary>
    /// High price last 24h
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// Low price last 24h
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// QuoteVolume last 24h
    /// </summary>
    [JsonProperty("turnover24h")]
    public decimal QuoteVolume24H { get; set; }

    /// <summary>
    /// Volume last 24h
    /// </summary>
    [JsonProperty("volume24h")]
    public decimal Volume24H { get; set; }

    /// <summary>
    /// Usd index price
    /// </summary>
    [JsonProperty("usdIndexPrice")]
    public decimal UsdIndexPrice { get; set; }
}

/// <summary>
/// Bybit Linear Inverse Ticker
/// </summary>
public class BybitMarketFuturesTicker
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Last trade price
    /// </summary>
    public decimal LastPrice { get; set; }
    
    /// <summary>
    /// Index price
    /// </summary>
    public decimal IndexPrice { get; set; }
    
    /// <summary>
    /// Mark price
    /// </summary>
    public decimal MarkPrice { get; set; }
    
    /// <summary>
    /// Price 24h ago
    /// </summary>
    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }
    
    /// <summary>
    /// Price change percentage since 24h ago
    /// </summary>
    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage24H { get; set; }
    
    /// <summary>
    /// High price last 24h
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// Low price last 24h
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// Price change since 24h ago
    /// </summary>
    public decimal PriceChange24H { get => LastPrice - OpenPrice24H; }
    
    /// <summary>
    /// Price 1h ago
    /// </summary>
    [JsonProperty("prevPrice1h")]
    public decimal OpenPrice1H { get; set; }

    /// <summary>
    /// Price change since 1h ago
    /// </summary>
    public decimal PriceChange1H { get => LastPrice - OpenPrice1H; }
    
    /// <summary>
    /// Open interest
    /// </summary>
    public decimal? OpenInterest { get; set; }

    /// <summary>
    /// Open interest value
    /// </summary>
    public decimal? OpenInterestValue { get; set; }
    
    /// <summary>
    /// QuoteVolume last 24h
    /// </summary>
    [JsonProperty("turnover24h")]
    public decimal QuoteVolume24H { get; set; }

    /// <summary>
    /// Volume last 24h
    /// </summary>
    [JsonProperty("volume24h")]
    public decimal Volume24H { get; set; }
    
    /// <summary>
    /// Funding rate
    /// </summary>
    public decimal? FundingRate { get; set; }

    /// <summary>
    /// Next funding time
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? NextFundingTime { get; set; }

    /// <summary>
    /// Predicted delivery price
    /// </summary>
    public decimal? PredictedDeliveryPrice { get; set; }

    /// <summary>
    /// Basis rate
    /// </summary>
    public decimal? BasisRate { get; set; }

    /// <summary>
    /// Basis
    /// </summary>
    public decimal? Basis { get; set; }

    /// <summary>
    /// Delivery fee rate
    /// </summary>
    public decimal? DeliveryFeeRate { get; set; }

    /// <summary>
    /// Delivery time
    /// </summary>
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DeliveryTime { get; set; }

    /// <summary>
    /// Best ask quantity
    /// </summary>
    [JsonProperty("ask1Size")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best bid quantity
    /// </summary>
    [JsonProperty("bid1Size")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Estimated pre-market contract open price
    /// The value is meaningless when entering continuous trading phase
    /// </summary>
    [JsonProperty("preOpenPrice")]
    public decimal? EstimatedOpenPrice { get; set; }

    /// <summary>
    /// Estimated pre-market contract open qty
    /// The value is meaningless when entering continuous trading phase
    /// </summary>
    [JsonProperty("preQty")]
    public decimal? EstimatedOpenQuantity { get; set; }

    /// <summary>
    /// The current pre-market contract phase
    /// </summary>
    [JsonProperty("curPreListingPhase")]
    public BybitPreListingPhase PreListingPhase { get; set; }
}

/// <summary>
/// Bybit Option Ticker
/// </summary>
public class BybitMarketOptionTicker
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid quantity
    /// </summary>
    [JsonProperty("bid1Size")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best bid IV
    /// </summary>
    [JsonProperty("bid1lv")]
    public decimal BestBidIv { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask quantity
    /// </summary>
    [JsonProperty("ask1Size")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Best ask IV
    /// </summary>
    [JsonProperty("ask1lv")]
    public decimal BestAskIv { get; set; }

    /// <summary>
    /// Last trade price
    /// </summary>
    public decimal LastPrice { get; set; }

    /// <summary>
    /// High price last 24h
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// Low price last 24h
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// Mark price
    /// </summary>
    public decimal MarkPrice { get; set; }

    /// <summary>
    /// Index price
    /// </summary>
    public decimal IndexPrice { get; set; }

    /// <summary>
    /// Mark iv
    /// </summary>
    public decimal MarkIv { get; set; }

    /// <summary>
    /// Underlying asset price
    /// </summary>
    public decimal UnderlyingPrice { get; set; }

    /// <summary>
    /// Open interest
    /// </summary>
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// QuoteVolume last 24h
    /// </summary>
    [JsonProperty("turnover24h")]
    public decimal QuoteVolume24H { get; set; }

    /// <summary>
    /// Volume last 24h
    /// </summary>
    [JsonProperty("volume24h")]
    public decimal Volume24H { get; set; }

    /// <summary>
    /// Total volume
    /// </summary>
    public decimal TotalVolume { get; set; }

    /// <summary>
    /// Total turnover
    /// </summary>
    public decimal TotalTurnover { get; set; }

    /// <summary>
    /// Delta
    /// </summary>
    public decimal Delta { get; set; }

    /// <summary>
    /// Gamma
    /// </summary>
    public decimal Gamma { get; set; }

    /// <summary>
    /// Vega
    /// </summary>
    public decimal Vega { get; set; }

    /// <summary>
    /// Theta
    /// </summary>
    public decimal Theta { get; set; }

    /// <summary>
    /// Predicted delivery price
    /// </summary>
    public decimal PredictedDeliveryPrice { get; set; }

    /// <summary>
    /// Change since 24h ago
    /// </summary>
    [JsonProperty("change24h")]
    public decimal Change24H { get; set; }
}
