using ApiSharp.Attributes;
using ApiSharp.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bybit.Api.Examples;

public enum BybitStreamOperation
{
    [Label("auth")]
    Auth,

    [Label("ping")]
    Ping,

    [Label("pong")]
    Pong,

    [Label("subscribe")]
    Subscribe,

    [Label("unsubscribe")]
    Unsubscribe,
}

public class BybitStreamOperationConverter : BaseConverter<BybitStreamOperation>
{
    public BybitStreamOperationConverter() : this(true) { }
    public BybitStreamOperationConverter(bool quotes) : base(quotes) { }

    protected override List<KeyValuePair<BybitStreamOperation, string>> Mapping => new List<KeyValuePair<BybitStreamOperation, string>>
        {
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Auth, "auth"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Ping, "ping"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Pong, "pong"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Subscribe, "subscribe"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Unsubscribe, "unsubscribe"),
        };
}




public class BybitStreamOperationConverterConst : BaseConverter<BybitStreamOperation>
{
    public static readonly List<KeyValuePair<BybitStreamOperation, string>> list = new List<KeyValuePair<BybitStreamOperation, string>>
        {
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Auth, "auth"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Ping, "ping"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Pong, "pong"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Subscribe, "subscribe"),
            new KeyValuePair<BybitStreamOperation, string>(BybitStreamOperation.Unsubscribe, "unsubscribe"),
        };

    public BybitStreamOperationConverterConst() : this(true) { }
    public BybitStreamOperationConverterConst(bool quotes) : base(quotes) { }

    protected override List<KeyValuePair<BybitStreamOperation, string>> Mapping => list;
}

public class Payload00
{
    [JsonConverter(typeof(BybitStreamOperationConverterConst))]
    public BybitStreamOperation StreamOperation { get; set; }
}

public class Payload01
{
    [JsonConverter(typeof(BybitStreamOperationConverter))]
    public BybitStreamOperation StreamOperation { get; set; }
}

public class Payload02
{
    [JsonConverter(typeof(LabelConverter<BybitStreamOperation>))]
    public BybitStreamOperation StreamOperation { get; set; }
}

internal class Program
{
    static async Task Main(string[] args)
    {
        var payload00 = new Payload00 { StreamOperation = BybitStreamOperation.Subscribe };
        var payload01 = new Payload01 { StreamOperation = BybitStreamOperation.Subscribe };
        var payload02 = new Payload02 { StreamOperation = BybitStreamOperation.Subscribe };
        var json00 = JsonConvert.SerializeObject(payload00);
        var json01 = JsonConvert.SerializeObject(payload01);
        var json02 = JsonConvert.SerializeObject(payload02);

        JsonConvert.SerializeObject(payload00);
        JsonConvert.DeserializeObject<Payload01>(json00);
        JsonConvert.SerializeObject(payload01);
        JsonConvert.DeserializeObject<Payload01>(json01);
        JsonConvert.SerializeObject(payload02);
        JsonConvert.DeserializeObject<Payload02>(json02);

        var sw01 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.SerializeObject(payload00);
        }
        sw01.Stop();

        var sw02 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.DeserializeObject<Payload00>(json00);
        }
        sw02.Stop();

        var sw11 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.SerializeObject(payload01);
        }
        sw11.Stop();

        var sw12 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.DeserializeObject<Payload01>(json01);
        }
        sw12.Stop();

        var sw21 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.SerializeObject(payload02);
        }
        sw21.Stop();

        var sw22 = Stopwatch.StartNew();
        for (var i = 0; i < 100000; i++)
        {
            JsonConvert.DeserializeObject<Payload02>(json02);
        }
        sw22.Stop();










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
        var pairs = new List<string> { "BTCUSDT", "LTCUSDT", "ETHUSDT", "XRPUSDT", "BCHUSDT", "EOSUSDT", "OKBUSDT", "ETCUSDT", "TRXUSDT", "BSVUSDT", "DASHUSDT", "NEOUSDT", "QTUMUSDT", "XLMUSDT", "ADAUSDT", "AEUSDT", "BLOCUSDT", "EGTUSDT", "IOTAUSDT", "SCUSDT", "WXTUSDT", "ZECUSDT", };

        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs)
        {
            await ws.SubscribeToTradeUpdatesAsync(Enums.BybitCategory.Spot, pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ TRADE ] " +
                        $" {data.Data.StreamType} " +
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
            await ws.SubscribeToOrderBookUpdatesAsync( Enums.BybitCategory.Spot, pair, 1, (data) =>
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

        /* Instruments (Public) */
        Console.WriteLine("Being subscribed...");
        foreach (var pair in pairs) {
            await ws.SubscribeToTickerUpdatesAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"[ TICKER ] {data.Data.Symbol} O:{data.Data.Open} H:{data.Data.High} L:{data.Data.Low} C:{data.Data.Last} V:{data.Data.Volume}");
                }
            });
        }
        Console.WriteLine("Subscribed!..");

        Console.ReadLine();



        var abc = 0;
        #endregion

#if FALSE
        #region WebSocket Api Client Examples
        /* OKX Socket Client */
        var ws = new BybitStreamClient();
        ws.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-API-PASSPHRASE-XXXXXXXX");

        /* Sample Pairs */
        var sample_pairs = new List<string> { "BTC-USDT", "LTC-USDT", "ETH-USDT", "XRP-USDT", "BCH-USDT", "EOS-USDT", "OKB-USDT", "ETC-USDT", "TRX-USDT", "BSV-USDT", "DASH-USDT", "NEO-USDT", "QTUM-USDT", "XLM-USDT", "ADA-USDT", "AE-USDT", "BLOC-USDT", "EGT-USDT", "IOTA-USDT", "SC-USDT", "WXT-USDT", "ZEC-USDT", };

        /* WS Subscriptions */
        var subs = new List<UpdateSubscription>();

        /* Instruments (Public) */
        await ws.SubscribeToInstrumentsAsync(OkxInstrumentType.Spot, (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
                Console.WriteLine($"Instrument {data.Instrument} BaseCurrency:{data.BaseCurrency} Category:{data.Category}");
            }
        });

        /* Tickers (Public) */
        foreach (var pair in sample_pairs)
        {
            var subscription = await ws.SubscribeToTickersAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                    Console.WriteLine($"Ticker {data.Instrument} Ask:{data.AskPrice} Bid:{data.BidPrice}");
                }
            });
            subs.Add(subscription.Data);
        }

        /* Unsubscribe */
        foreach (var sub in subs)
        {
            _ = ws.UnsubscribeAsync(sub);
        }

        /* Interests (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToInterestsAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Candlesticks (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToCandlesticksAsync(pair, OkxPeriod.FiveMinutes, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Trades (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToTradesAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Estimated Price (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToTradesAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Mark Price (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToMarkPriceAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Mark Price Candlesticks (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToMarkPriceCandlesticksAsync(pair, OkxPeriod.FiveMinutes, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Limit Price (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToPriceLimitAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Order Book (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToOrderBookAsync(pair, OkxOrderBookType.OrderBook, (data) =>
            {
                if (data != null && data.Asks != null && data.Asks.Count() > 0 && data.Bids != null && data.Bids.Count() > 0)
                {
                    // ... Your logic here
                }
            });
        }

        /* Option Summary (Public) */
        await ws.SubscribeToOptionSummaryAsync("USD", (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Funding Rates (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToFundingRatesAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Index Candlesticks (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToIndexCandlesticksAsync(pair, OkxPeriod.FiveMinutes, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* Index Tickers (Public) */
        foreach (var pair in sample_pairs)
        {
            await ws.SubscribeToIndexTickersAsync(pair, (data) =>
            {
                if (data != null)
                {
                    // ... Your logic here
                }
            });
        }

        /* System Status (Public) */
        await ws.SubscribeToSystemStatusAsync((data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Account Updates (Private) */
        await ws.SubscribeToAccountUpdatesAsync((data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Position Updates (Private) */
        await ws.SubscribeToPositionUpdatesAsync(OkxInstrumentType.Futures, "INSTRUMENT", "UNDERLYING", (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Balance And Position Updates (Private) */
        await ws.SubscribeToBalanceAndPositionUpdatesAsync((data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Order Updates (Private) */
        await ws.SubscribeToOrderUpdatesAsync(OkxInstrumentType.Futures, "INSTRUMENT", "UNDERLYING", (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Algo Order Updates (Private) */
        await ws.SubscribeToAlgoOrderUpdatesAsync(OkxInstrumentType.Futures, "INSTRUMENT", "UNDERLYING", (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });

        /* Advance Algo Order Updates (Private) */
        await ws.SubscribeToAdvanceAlgoOrderUpdatesAsync(OkxInstrumentType.Futures, "INSTRUMENT", "UNDERLYING", (data) =>
        {
            if (data != null)
            {
                // ... Your logic here
            }
        });
        #endregion
#endif

    }
}