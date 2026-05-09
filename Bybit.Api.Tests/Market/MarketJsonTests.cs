using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Market;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Market;

public class MarketJsonTests
{
    [Fact]
    public void FuturesTicker_WithEmptyOptionalNumericFields_DeserializesAsNull()
    {
        var result = DeserializeResult<MarketListResult<BybitMarketFuturesTicker>>("futures-ticker-empty-fields.json");
        var ticker = Assert.Single(result.List);

        Assert.Null(ticker.PredictedDeliveryPrice);
        Assert.Null(ticker.BasisRate);
        Assert.Null(ticker.Basis);
        Assert.Null(ticker.DeliveryFeeRate);
        Assert.Null(ticker.EstimatedOpenPrice);
        Assert.Null(ticker.EstimatedOpenQuantity);
        Assert.Null(ticker.PreListingPhase);
        Assert.Null(ticker.BasisRateYear);
        Assert.Equal(8, ticker.FundingIntervalHour);
        Assert.Equal(0.005m, ticker.FundingCap);
    }

    [Fact]
    public void OptionTicker_MapsBidAndAskIvFields()
    {
        var result = DeserializeResult<MarketListResult<BybitMarketOptionTicker>>("option-ticker.json");
        var ticker = Assert.Single(result.List);

        Assert.Equal(0m, ticker.BestBidIv);
        Assert.Equal(5m, ticker.BestAskIv);
        Assert.Null(ticker.PredictedDeliveryPrice);
    }

    [Fact]
    public void SpotInstrument_MapsCurrentFields()
    {
        var result = DeserializeResult<MarketListResult<BybitMarketSpotInstrument>>("spot-instrument.json");
        var instrument = Assert.Single(result.List);

        Assert.Equal(9L, instrument.SymbolId);
        Assert.Equal("BTCUSDT", instrument.Name);
        Assert.True(instrument.SpecialTreatment);
        Assert.Equal(BybitInstrumentType.XStocks, instrument.Type);
        Assert.Equal(83m, instrument.LotSizeFilter.MaximumLimitOrderQuantity);
        Assert.Equal(41.5m, instrument.LotSizeFilter.MaximumMarketOrderQuantity);
        Assert.Equal(60000m, instrument.LotSizeFilter.PostOnlyMaximumLimitOrderSize);
    }

    [Fact]
    public void RecentPublicTrade_UsesStringExecutionId()
    {
        var result = DeserializeResult<MarketListResult<BybitMarketTrade>>("recent-public-trade.json");
        var trade = Assert.Single(result.List);

        Assert.Equal("2100000000007764263", trade.TradeId);
        Assert.True(trade.IsRpiTrade);
        Assert.Equal("454803359210", trade.Sequence);
    }

    [Fact]
    public void IndexPriceComponents_MapsDocumentShape()
    {
        var result = DeserializeResult<BybitMarketIndexPriceComponents>("index-price-components.json");
        var component = Assert.Single(result.Components);

        Assert.Equal("1000BTTUSDT", result.IndexName);
        Assert.Equal(0.0006496m, result.LastPrice);
        Assert.Equal("GateIO", component.Exchange);
        Assert.Equal(1000m, component.Multiplier);
    }

    [Fact]
    public void OrderPriceLimit_MapsDocumentShape()
    {
        var result = DeserializeResult<BybitMarketOrderPriceLimit>("order-price-limit.json");

        Assert.Equal("BTCUSDT", result.Symbol);
        Assert.Equal(105878.10m, result.BuyLimit);
        Assert.Equal(103781.60m, result.SellLimit);
        Assert.Equal(1750302284491, result.Timestamp);
    }

    [Fact]
    public void AdlAlert_MapsEmptyMaxBalanceAsNull()
    {
        var result = DeserializeResult<BybitMarketAdlAlert>("adl-alert.json");
        var item = Assert.Single(result.List);

        Assert.NotNull(result.UpdateTime);
        Assert.Equal("BTCUSDT", item.Symbol);
        Assert.Null(item.MaxBalance);
        Assert.Equal(-0.3m, item.InsurancePnlRatio);
    }

    [Fact]
    public void FeeGroupInfo_MapsEmptyFeeRatesAsNull()
    {
        var result = DeserializeResult<BybitMarketFeeGroupInfo>("fee-group-info.json");
        var group = Assert.Single(result.List);
        var pro = Assert.Single(group.FeeRates.Pro);
        var marketMaker = Assert.Single(group.FeeRates.MarketMaker);

        Assert.Equal("G1(Major Coins)", group.GroupName);
        Assert.Equal(0.00028m, pro.TakerFeeRate);
        Assert.Null(pro.MakerRebate);
        Assert.Null(marketMaker.TakerFeeRate);
        Assert.Equal(-0.0000075m, marketMaker.MakerRebate);
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Market", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record MarketListResult<T>
    {
        public List<T> List { get; set; } = [];
    }
}
