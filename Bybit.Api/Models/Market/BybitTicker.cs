namespace Bybit.Api.Models.Market;

public class BybitSpotTicker
{
    public string Symbol { get; set; }

    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    [JsonProperty("bid1Size")]
    public decimal BestBidSize { get; set; }

    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    [JsonProperty("ask1Size")]
    public decimal BestAskSize { get; set; }

    public decimal LastPrice { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24h { get; set; }
    public decimal HighPrice24h { get; set; }
    public decimal LowPrice24h { get; set; }
    public decimal Turnover24h { get; set; }
    public decimal Volume24h { get; set; }
    public decimal? UsdIndexPrice { get; set; }

    [JsonProperty("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }
    public decimal PriceChange { get => LastPrice - OpenPrice24h; }
}

public class BybitLinearInverseTicker
{
    public string Symbol { get; set; }
    public decimal LastPrice { get; set; }
    public decimal IndexPrice { get; set; }
    public decimal MarkPrice { get; set; }

    [JsonProperty("prevPrice24h")]
    public decimal OpenPrice24h { get; set; }

    [JsonProperty("price24hPcnt")]
    public decimal PriceChange24hPercentage { get; set; }
    public decimal PriceChange24h { get => LastPrice - OpenPrice24h; }
    public decimal PriceChange1h { get => LastPrice - OpenPrice1h; }

    public decimal HighPrice24h { get; set; }
    public decimal LowPrice24h { get; set; }
    public decimal OpenPrice1h { get; set; }
    public decimal OpenInterest { get; set; }
    public decimal OpenInterestValue { get; set; }
    public decimal Turnover24h { get; set; }
    public decimal Volume24h { get; set; }
    public decimal FundingRate { get; set; }

    [JsonProperty("nextFundingTime")]
    public long NextFundingTimestamp { get; set; }
    public DateTime NextFundingTime { get => NextFundingTimestamp.ConvertFromMilliseconds(); }
    
    [JsonProperty("deliveryTime")]
    public long DeliveryTimestamp { get; set; }
    public DateTime DeliveryTime { get => DeliveryTimestamp.ConvertFromMilliseconds(); }

    public decimal PredictedDeliveryPrice { get; set; }
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

public class BybitOptionTicker
{
    public string Symbol { get; set; }

    [JsonProperty("bid1Price")]
    public decimal BestBidPrice { get; set; }

    [JsonProperty("bid1Size")]
    public decimal BestBidSize { get; set; }
    
    [JsonProperty("bid1Iv")]
    public decimal BestBidIv { get; set; }

    [JsonProperty("ask1Price")]
    public decimal BestAskPrice { get; set; }

    [JsonProperty("ask1Size")]
    public decimal BestAskSize { get; set; }

    [JsonProperty("ask1Iv")]
    public decimal BestAskIv { get; set; }

    public decimal LastPrice { get; set; }
    public decimal HighPrice24h { get; set; }
    public decimal LowPrice24h { get; set; }
    public decimal MarkPrice { get; set; }
    public decimal IndexPrice { get; set; }

    [JsonProperty("markIv")]
    public decimal MarkPriceIv { get; set; }

    public decimal UnderlyingPrice { get; set; }
    public decimal OpenInterest { get; set; }
    public decimal Turnover24h { get; set; }
    public decimal Volume24h { get; set; }
    public decimal TotalVolume { get; set; }
    public decimal TotalTurnover { get; set; }
    public decimal Delta { get; set; }
    public decimal Gamma { get; set; }
    public decimal Vega { get; set; }
    public decimal Theta { get; set; }
    public decimal PredictedDeliveryPrice { get; set; }
    public decimal Change24h { get; set; }
}
