using Bybit.Api.Enums;
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

        var order = await api.Trade.PlaceOrderAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy, BybitOrderType.Market, 100.0m);


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