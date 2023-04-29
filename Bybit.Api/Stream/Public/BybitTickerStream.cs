namespace Bybit.Api.Helpers.Public;

public class BybitSpotTickerStream
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }
    [JsonProperty("volume24h")]
    public decimal Volume24H { get; set; }
    [JsonProperty("turnover24h")]
    public decimal Turnover24H { get; set; }
    [JsonProperty("usdIndexPrice")]
    public decimal? UsdIndex { get; set; }

    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }
    public decimal PriceChange { get => LastPrice - OpenPrice24H; }
}

public class BybitFuturesTickerStream
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }
    [JsonProperty("indexPrice")]
    public decimal IndexPrice { get; set; }
    [JsonProperty("markPrice")]
    public decimal MarkPrice { get; set; }

    [JsonProperty("price24hPcnt")]
    public decimal PriceChange24HPercentage { get; set; }
    public decimal PriceChange24h { get => LastPrice - OpenPrice24H; }
    public decimal PriceChange1h { get => LastPrice - OpenPrice1h; }

    [JsonProperty("prevPrice1h")]
    public decimal OpenPrice1h { get; set; }
    public decimal OpenInterest { get; set; }
    public decimal OpenInterestValue { get; set; }
    public decimal Turnover24H { get; set; }
    public decimal Volume24H { get; set; }
    public decimal FundingRate { get; set; }

    [JsonProperty("nextFundingTime")]
    public long NextFundingTimestamp { get; set; }
    public DateTime NextFundingTime { get => NextFundingTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }

    public decimal? PredictedDeliveryPrice { get; set; }
    public decimal BasisRate { get; set; }
    public decimal Basis { get; set; }
    public decimal DeliveryFeeRate { get; set; }

    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    [JsonProperty("bid1Size")]
    public decimal BestBidSize { get; set; }

    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    [JsonProperty("ask1Size")]
    public decimal BestAskSize { get; set; }
}

public class BybitOptionTickerStream
{
    public string Symbol { get; set; }

    [JsonProperty("bidPrice")]
    public decimal BestBidPrice { get; set; }

    [JsonProperty("bidSize")]
    public decimal BestBidSize { get; set; }

    [JsonProperty("bidIv")]
    public decimal BestBidIv { get; set; }

    [JsonProperty("askPrice")]
    public decimal BestAskPrice { get; set; }

    [JsonProperty("askSize")]
    public decimal BestAskSize { get; set; }

    [JsonProperty("askIv")]
    public decimal BestAskIv { get; set; }

    public decimal LastPrice { get; set; }
    public decimal HighPrice24H { get; set; }
    public decimal LowPrice24H { get; set; }
    public decimal MarkPrice { get; set; }
    public decimal IndexPrice { get; set; }

    [JsonProperty("markIv")]
    public decimal MarkPriceIv { get; set; }

    public decimal UnderlyingPrice { get; set; }
    public decimal OpenInterest { get; set; }
    public decimal Turnover24H { get; set; }
    public decimal Volume24H { get; set; }
    public decimal TotalVolume { get; set; }
    public decimal TotalTurnover { get; set; }
    public decimal Delta { get; set; }
    public decimal Gamma { get; set; }
    public decimal Vega { get; set; }
    public decimal Theta { get; set; }
    public decimal? PredictedDeliveryPrice { get; set; }
    public decimal Change24H { get; set; }
}

public class BybitLeveragedTokenTickerStream
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24H { get; set; }
    [JsonProperty("highPrice24h")]
    public decimal HighPrice24H { get; set; }
    [JsonProperty("lowPrice24h")]
    public decimal LowPrice24H { get; set; }
    [JsonProperty("lastPrice")]
    public decimal LastPrice { get; set; }
    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }
    public decimal PriceChange { get => LastPrice - OpenPrice24H; }
}

