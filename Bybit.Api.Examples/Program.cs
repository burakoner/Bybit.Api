using Bybit.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Api.Examples;


internal class Program
{
    static async Task Main(string[] args)
    {
        #region Rest Api Client Examples

        var api = new BybitRestApiClient(new BybitRestApiClientOptions
        {
            RawResponse = true,
        });
        // api.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX");
        // var public_01 = await api.Server.GetServerTimeAsync();


        //var market_01 = await api.Market.GetKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour);
        //var market_02 = await api.Market.GetMarkKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour);
        //var market_03 = await api.Market.GetIndexKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour);
        //var market_04 = await api.Market.GetPremiumIndexKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour);
        //var market_05 = await api.Market.GetSpotInstrumentsAsync();
        //var market_06 = await api.Market.GetSpotInstrumentsAsync("BTCUSDT");
        //var market_07 = await api.Market.GetLinearInstrumentsAsync();
        //var market_08 = await api.Market.GetInverseInstrumentsAsync();
        //var market_09 = await api.Market.GetOptionInstrumentsAsync();
        //var market_10 = await api.Market.GetOrderbookAsync(BybitCategory.Spot, "BTCUSDT", 50);
        //var market_11 = await api.Market.GetPublicTradingHistoryAsync(BybitCategory.Spot, "BTCUSDT");
        //var market_12 = await api.Market.GetOpenInterestAsync(...);
        //var market_13 = await api.Market.GetHistoricalVolatilityAsync(BybitCategory.Option);
        //var market_14 = await api.Market.GetInsuranceAsync();
        //var market_15 = await api.Market.GetRiskLimitAsync(BybitCategory.Linear);
        //var market_16 = await api.Market.GetDeliveryPriceAsync(BybitCategory.Linear);

        //var order = await api.Trading.PlaceOrderAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy, BybitOrderType.Market, 100.0m,,,,,);


        var ws = new BybitStreamClient(new BybitStreamClientOptions
        {
            RawResponse = true,
        });

        // Sample Pairs
        var pairs = new List<string> { "BTCUSDT", "LTCUSDT", "ETHUSDT", "XRPUSDT", "BCHUSDT", "EOSUSDT", "ETCUSDT", "TRXUSDT", "QTUMUSDT", "XLMUSDT", "ADAUSDT" };

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToTradesAsync(BybitCategory.Spot, pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ TRADE ] " +
                        $" {data.Data.Symbol} " +
                        $" Id:{data.Data.Id} " +
                        $" Timestamp:{data.Data.Timestamp} " +
                        $" Time:{data.Data.Time} " +
                        $" Symbol:{data.Data.Symbol} " +
                        $" Side:{data.Data.Side} " +
                        $" Price:{data.Data.Price} " +
                        $" Quantity:{data.Data.Quantity} " +
                        $" Direction:{data.Data.Direction} " +
                        $" BlockTrade:{data.Data.BlockTrade} ");
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToOrderBookAsync(BybitCategory.Spot, pair, 1, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    var ask = data.Data.Asks.FirstOrDefault();
                    var bid = data.Data.Bids.FirstOrDefault();
                    Console.WriteLine($"[ ORDERBOOK ] " +
                        $" {data.Data.StreamType} " +
                        $" {data.Data.Symbol} " +
                        $" BAP:{(ask != null ? ask.Price.ToString() : "")} " +
                        $" BAS:{(ask != null ? ask.Size.ToString() : "")} " +
                        $" BBP:{(bid != null ? bid.Price.ToString() : "")} " +
                        $" BBS:{(bid != null ? bid.Size.ToString() : "")} " +
                        $" U:{data.Data.UpdateId} " +
                        $" S:{data.Data.CrossSequence} ");
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToSpotTickersAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ TICKER ] " +
                        $" S:{data.Data.Symbol} " +
                        $" O:{data.Data.OpenPrice24H} " +
                        $" H:{data.Data.HighPrice24H} " +
                        $" L:{data.Data.LowPrice24H} " +
                        $" C:{data.Data.LastPrice} " +
                        $" V:{data.Data.Volume24H}");
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToKlinesAsync( BybitCategory.Spot, pair, BybitKlineInterval.OneHour, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ KLINE ] " +
                        $" TS:{data.Data.Timestamp} " +
                        $" T:{data.Data.Time} " +
                        $" OTS:{data.Data.OpenTimestamp} " +
                        $" OT:{data.Data.OpenTime} " +
                        $" CTS:{data.Data.CloseTimestamp} " +
                        $" CT:{data.Data.CloseTime} " +
                        $" I:{data.Data.Interval} " +
                        $" O:{data.Data.Open} " +
                        $" H:{data.Data.High} " +
                        $" L:{data.Data.Low} " +
                        $" C:{data.Data.Close} " +
                        $" V:{data.Data.Volume} " +
                        $" T:{data.Data.Turnover} " +
                        $" C:{data.Data.Confirm} ");
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToLiquidationsAsync(BybitCategory.Inverse, pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ LIQ ] " +
                        $" {data.Data.UpdateTimestamp} " +
                        $" {data.Data.UpdateTime} " +
                        $" {data.Data.Symbol} " +
                        $" {data.Data.Side} " +
                        $" {data.Data.Size} " +
                        $" {data.Data.Price} ");
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToLeveragedTokenKlinesAsync(pair, BybitKlineInterval.OneHour, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToLeveragedTokenTickersAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToLeveragedTokenNetAssetValuesAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }
        Console.WriteLine("Subscribed!..");
        Console.ReadLine();

        #endregion

    }
}