namespace Bybit.Api.Market;

/// <summary>
/// Bybit Spot Ticker Update
/// </summary>
public record BybitSpotTickerStream
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Last price
    /// </summary>
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }

    /// <summary>
    /// The highest price in the last 24 hours
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }
    
    /// <summary>
    /// The lowest price in the last 24 hours
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// Percentage change of market price relative to 24h
    /// </summary>
    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }

    /// <summary>
    /// Volume for 24h
    /// </summary>
    [JsonProperty("volume24h")]
    public decimal Volume24H { get; set; }

    /// <summary>
    /// Turnover for 24h
    /// </summary>
    [JsonProperty("turnover24h")]
    public decimal QuoteVolume24H { get; set; }

    /// <summary>
    /// Percentage change of market price relative to 24h
    /// </summary>
    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }

    /// <summary>
    /// Price change in 24 hours
    /// </summary>
    public decimal PriceChange { get => LastPrice - OpenPrice24H; }

    /// <summary>
    /// USD index price
    /// used to calculate USD value of the assets in Unified account
    /// non-collateral margin coin returns ""
    /// </summary>
    [JsonProperty("usdIndexPrice")]
    public decimal? UsdIndex { get; set; }
}

/// <summary>
/// Bybit Futures Ticker Update
/// </summary>
public record BybitFuturesTickerStream
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Tick direction
    /// </summary>
    [JsonProperty("tickDirection")]
    public BybitTickDirection TickDirection { get; set; }
    
    /// <summary>
    /// Percentage change of market price in the last 24 hours
    /// </summary>
    [JsonProperty("price24hPcnt")]
    public decimal PriceChange24HPercentage { get; set; }

    /// <summary>
    /// Percentage change of market price in the last 24 hours
    /// </summary>
    public decimal PriceChange24h { get => LastPrice - OpenPrice24H; }

    /// <summary>
    /// Last price
    /// </summary>
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }

    /// <summary>
    /// Market price 24 hours ago
    /// </summary>
    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }

    /// <summary>
    /// The highest price in the last 24 hours
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// The lowest price in the last 24 hours
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// Market price an hour ago
    /// </summary>
    [JsonProperty("prevPrice1h")]
    public decimal OpenPrice1h { get; set; }

    /// <summary>
    /// Percentage change of market price in the last 1 hour
    /// </summary>
    public decimal PriceChange1h { get => LastPrice - OpenPrice1h; }

    /// <summary>
    /// Mark price
    /// </summary>
    [JsonProperty("markPrice")]
    public decimal MarkPrice { get; set; }

    /// <summary>
    /// Index price
    /// </summary>
    [JsonProperty("indexPrice")]
    public decimal IndexPrice { get; set; }

    /// <summary>
    /// Open interest size
    /// </summary>
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// Open interest value
    /// </summary>
    public decimal OpenInterestValue { get; set; }

    /// <summary>
    /// Turnover for 24h
    /// </summary>
    [JsonProperty("turnover24H")]
    public decimal QuoteVolume24H { get; set; }

    /// <summary>
    /// Volume for 24h
    /// </summary>
    public decimal Volume24H { get; set; }

    /// <summary>
    /// Next funding timestamp (ms)
    /// </summary>
    [JsonProperty("nextFundingTime")]
    public long NextFundingTimestamp { get; set; }

    /// <summary>
    /// Next funding timestamp (ms)
    /// </summary>
    public DateTime NextFundingTime { get => NextFundingTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Funding rate
    /// </summary>
    public decimal FundingRate { get; set; }
    
    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid size
    /// </summary>
    [JsonProperty("bid1Size")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask size
    /// </summary>
    [JsonProperty("ask1Size")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Delivery date time (UTC+0). Unique field for inverse futures &amp; USDC futures
    /// </summary>
    [JsonProperty("deliveryTime")]
    public DateTime? DeliveryTime { get; set; }

    /// <summary>
    /// Basis rate. Unique field for inverse futures &amp; USDC futures
    /// </summary>
    public decimal? BasisRate { get; set; }

    /// <summary>
    /// Delivery fee rate. Unique field for inverse futures &amp; USDC futures
    /// </summary>
    public decimal? DeliveryFeeRate { get; set; }

    /// <summary>
    /// Predicated delivery price. Unique field for inverse futures &amp; USDC futures
    /// </summary>
    public decimal? PredictedDeliveryPrice { get; set; }
}

/// <summary>
/// Bybit Option Ticker Update
/// </summary>
public record BybitOptionTickerStream
{
    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bidPrice")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid size
    /// </summary>
    [JsonProperty("bidSize")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best bid iv
    /// </summary>
    [JsonProperty("bidIv")]
    public decimal BestBidIv { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("askPrice")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask size
    /// </summary>
    [JsonProperty("askSize")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Best ask iv
    /// </summary>
    [JsonProperty("askIv")]
    public decimal BestAskIv { get; set; }

    /// <summary>
    /// Last price
    /// </summary>
    public decimal LastPrice { get; set; }

    /// <summary>
    /// The highest price in the last 24 hours
    /// </summary>
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// The lowest price in the last 24 hours
    /// </summary>
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
    /// Mark price iv
    /// </summary>
    [JsonProperty("markIv")]
    public decimal MarkPriceIv { get; set; }

    /// <summary>
    /// Underlying price
    /// </summary>
    public decimal UnderlyingPrice { get; set; }

    /// <summary>
    /// Open interest size
    /// </summary>
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// Turnover for 24h
    /// </summary>
    [JsonProperty("turnover24H")]
    public decimal QuoteVolume24H { get; set; }
    
    /// <summary>
    /// Volume for 24h
    /// </summary>
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
    /// Predicated delivery price. It has value when 30 min before delivery
    /// </summary>
    public decimal? PredictedDeliveryPrice { get; set; }

    /// <summary>
    /// The change in the last 24 hous
    /// </summary>
    public decimal Change24H { get; set; }
}

/// <summary>
/// Bybit Leverage Token Ticker Update
/// </summary>
public record BybitLeverageTokenTickerStream
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Market price 24 hours ago
    /// </summary>
    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }

    /// <summary>
    /// Highest price in the past 24 hours
    /// </summary>
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }

    /// <summary>
    /// Lowest price in the past 24 hours
    /// </summary>
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }

    /// <summary>
    /// The last price
    /// </summary>
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }

    /// <summary>
    /// Market price change percentage in the past 24 hours
    /// </summary>
    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }

    /// <summary>
    /// Market price change percentage in the past 24 hours
    /// </summary>
    public decimal PriceChange { get => LastPrice - OpenPrice24H; }
}
