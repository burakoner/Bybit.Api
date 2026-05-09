namespace Bybit.Api.Examples;

internal class Program
{
    static async Task Main()
    {
        #region Rest API Examples
        var api = new BybitRestApiClient();
        api.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX");

        // Market API Methods (Public)
        var market_01 = await api.Market.GetServerTimeAsync(/* ...optional parameters... */);
        var market_02 = await api.Market.GetKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitInterval.OneHour /* ...optional parameters... */);
        var market_03 = await api.Market.GetMarkKlinesAsync(BybitCategory.Linear, "BTCUSDT", BybitInterval.OneHour /* ...optional parameters... */);
        var market_04 = await api.Market.GetIndexKlinesAsync(BybitCategory.Inverse, "BTCUSDT", BybitInterval.OneHour /* ...optional parameters... */);
        var market_05 = await api.Market.GetPremiumIndexKlinesAsync(BybitCategory.Linear, "BTCUSDT", BybitInterval.OneHour /* ...optional parameters... */);
        var market_06 = await api.Market.GetSpotInstrumentsAsync(/* ...optional parameters... */);
        var market_07 = await api.Market.GetLinearInstrumentsAsync(/* ...optional parameters... */);
        var market_08 = await api.Market.GetInverseInstrumentsAsync(/* ...optional parameters... */);
        var market_09 = await api.Market.GetOptionInstrumentsAsync(/* ...optional parameters... */);
        var market_10 = await api.Market.GetOrderbookAsync(BybitCategory.Spot, "BTCUSDT" /* ...optional parameters... */);
        var market_11 = await api.Market.GetSpotTickersAsync(/* ...optional parameters... */);
        var market_12 = await api.Market.GetLinearTickersAsync(/* ...optional parameters... */);
        var market_13 = await api.Market.GetInverseTickersAsync(/* ...optional parameters... */);
        var market_14 = await api.Market.GetOptionTickersAsync(/* ...optional parameters... */);
        var market_15 = await api.Market.GetFundingHistoryAsync(BybitCategory.Inverse, "BTCUSDT" /* ...optional parameters... */);
        var market_16 = await api.Market.GetTradingHistoryAsync(BybitCategory.Spot, "BTCUSDT" /* ...optional parameters... */);
        var market_17 = await api.Market.GetOpenInterestAsync(BybitCategory.Linear, "BTCUSDT", BybitRecordPeriod.OneDay /* ...optional parameters... */);
        var market_18 = await api.Market.GetVolatilityAsync(BybitCategory.Option /* ...optional parameters... */);
        var market_19 = await api.Market.GetInsuranceAsync(/* ...optional parameters... */);
        var market_20 = await api.Market.GetRiskLimitAsync(BybitCategory.Linear /* ...optional parameters... */);
        var market_21 = await api.Market.GetDeliveryPriceAsync(BybitCategory.Linear /* ...optional parameters... */);
        var market_22 = await api.Market.GetNewDeliveryPriceAsync(BybitCategory.Option, "BTC" /* ...optional parameters... */);
        var market_23 = await api.Market.GetLongShortRatioAsync(BybitCategory.Linear, "BTCUSDT", BybitRecordPeriod.OneDay /* ...optional parameters... */);
        var market_24 = await api.Market.GetIndexPriceComponentsAsync("BTCUSDT" /* ...optional parameters... */);
        var market_25 = await api.Market.GetOrderPriceLimitAsync(BybitCategory.Linear, "BTCUSDT" /* ...optional parameters... */);
        var market_26 = await api.Market.GetAdlAlertAsync("BTCUSDT" /* ...optional parameters... */);
        var market_27 = await api.Market.GetFeeGroupInfoAsync("contract" /* ...optional parameters... */);
        var market_28 = await api.Market.GetOpenInterestAsync(new BybitMarketOpenInterestRequest(BybitCategory.Linear, "BTCUSDT", BybitRecordPeriod.OneDay) { Limit = 10 });

        // Trade API Methods (Private)
        var trade_01 = await api.Trade.PlaceOrderAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy, BybitOrderType.Market, 100.0m /* ...optional parameters... */);
        var trade_02 = await api.Trade.AmendOrderAsync(BybitCategory.Spot, "XRPUSDT" /* ...optional parameters... */);
        var trade_03 = await api.Trade.AmendOrderAsync(BybitCategory.Spot, "XRPUSDT", "-----ORDER-ID-----" /* ...optional parameters... */);
        var trade_04 = await api.Trade.GetOrdersAsync(BybitCategory.Spot /* ...optional parameters... */);
        var trade_05 = await api.Trade.CancelOrdersAsync(BybitCategory.Spot /* ...optional parameters... */);
        var trade_06 = await api.Trade.GetOrderHistoryAsync(BybitCategory.Spot /* ...optional parameters... */);
        var trade_07 = await api.Trade.GetTradeHistoryAsync(BybitCategory.Spot /* ...optional parameters... */);
        var trade_08 = await api.Trade.PlaceOrdersAsync(BybitCategory.Spot, [] /* ...optional parameters... */);
        var trade_09 = await api.Trade.AmendOrdersAsync(BybitCategory.Spot, [] /* ...optional parameters... */);
        var trade_10 = await api.Trade.CancelOrdersAsync(BybitCategory.Spot, []/* ...optional parameters... */);
        var trade_11 = await api.Trade.GetBorrowQuotaAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy /* ...optional parameters... */);
        var trade_12 = await api.Trade.SetDisconnectProtectionAsync(10 /* ...optional parameters... */);
        var trade_13 = await api.Trade.PlaceOrderAsync(new BybitPlaceOrderRequest(BybitCategory.Linear, "BTCUSDT", BybitOrderSide.Buy, BybitOrderType.Limit, 1.0m)
        {
            Price = 25000.0m,
            TimeInForce = BybitTimeInForce.GoodTillCancel,
            BboSideType = BybitBboSideType.Queue,
            BboLevel = 1,
        });
        var trade_14 = await api.Trade.PreCheckOrderAsync(new BybitPreCheckOrderRequest(BybitCategory.Linear, "BTCUSDT", BybitOrderSide.Buy, BybitOrderType.Limit, 1.0m)
        {
            Price = 25000.0m,
            TimeInForce = BybitTimeInForce.GoodTillCancel,
        });

        // Position API Methods (Private)
        var position_01 = await api.Position.GetPositionsAsync(BybitCategory.Linear /* ...optional parameters... */);
        var position_02 = await api.Position.SetLeverageAsync(BybitCategory.Linear, "BTCUSDT", 10.0m, 10.0m /* ...optional parameters... */);
        var position_03 = await api.Position.SwitchMarginModeAsync(BybitCategory.Linear, "BTCUSDT", BybitTradeMode.CrossMargin, 10.0m, 10.0m /* ...optional parameters... */);
        var position_04 = await api.Position.GetPositionsAsync(new BybitPositionListRequest(BybitCategory.Option)
        {
            BaseAsset = "BTC",
            Limit = 20,
        });
        var position_05 = await api.Position.SwitchPositionModeAsync(BybitCategory.Linear, BybitPositionMode.BothSides /* ...optional parameters... */);
        var position_06 = await api.Position.SetTradingStopAsync(BybitCategory.Linear, "BTCUSDT", BybitPositionIndex.OneWayModePosition /* ...optional parameters... */);
        var position_07 = await api.Position.SetTradingStopAsync(new BybitPositionSetTradingStopRequest(BybitCategory.Linear, "BTCUSDT", BybitPositionIndex.OneWayModePosition)
        {
            TakeProfitStopLossMode = BybitTakeProfitStopLossMode.Partial,
            TakeProfitPrice = 65000.0m,
            StopLossPrice = 59000.0m,
            TakeProfitTrigger = BybitTriggerPrice.MarkPrice,
            StopLossTrigger = BybitTriggerPrice.IndexPrice,
        });
        var position_08 = await api.Position.SetAutoAddMarginAsync(BybitCategory.Linear, "BTCUSDT", true /* ...optional parameters... */);
        var position_09 = await api.Position.AddOrReduceMarginAsync(BybitCategory.Linear, "BTCUSDT", 10.0m /* ...optional parameters... */);
        var position_10 = await api.Position.GetClosedPnlAsync(BybitCategory.Linear /* ...optional parameters... */);
        var position_11 = await api.Position.GetClosedOptionsPositionsAsync(/* ...optional parameters... */);
        var position_12 = await api.Position.MovePositionsAsync("-----FROM-UID-----", "-----TO-UID-----", [] /* ...optional parameters... */);
        var position_13 = await api.Position.MovePositionsAsync(new BybitPositionMovePositionsRequest("-----FROM-UID-----", "-----TO-UID-----", [
            new BybitPositionMoveRequest
            {
                Category = BybitCategory.Spot,
                Symbol = "BTCUSDT",
                Side = BybitOrderSide.Sell,
                Price = 100.0m,
                Quantity = 0.01m,
            }
        ]));
        var position_14 = await api.Position.GetMoveHistoryAsync(new BybitPositionMoveHistoryRequest
        {
            Status = BybitMoveStatus.Filled,
            Limit = 20,
        });
        var position_15 = await api.Position.ConfirmNewRiskLimitAsync(BybitCategory.Linear, "BTCUSDT" /* ...optional parameters... */);

        // Account API Methods (Private)
        var account_01 = await api.Account.GetBalancesAsync(/* ...optional parameters... */);
        var account_02 = await api.Account.UpgradeToUnifiedAccountAsync(/* ...optional parameters... */);
        var account_03 = await api.Account.GetBorrowHistoryAsync(/* ...optional parameters... */);
        var account_04 = await api.Account.GetCollateralInfoAsync(/* ...optional parameters... */);
        var account_05 = await api.Account.GetGreeksAsync(/* ...optional parameters... */);
        var account_06 = await api.Account.GetFeeRateAsync(BybitCategory.Spot /* ...optional parameters... */);
        var account_07 = await api.Account.GetAccountAsync(/* ...optional parameters... */);
        var account_08 = await api.Account.GetTransactionsAsync(/* ...optional parameters... */);
        var account_09 = await api.Account.SetMarginModeAsync(BybitMarginMode.Isolated /* ...optional parameters... */);
        var account_10 = await api.Account.SetMmpAsync("ETH", 5000, 0, 1.0m, 0.1m /* ...optional parameters... */);
        var account_11 = await api.Account.ResetMmpAsync("ETH" /* ...optional parameters... */);
        var account_12 = await api.Account.GetMmpAsync("ETH" /* ...optional parameters... */);
        var account_13 = await api.Account.GetTransferableAmountAsync("BTC,USDT" /* ...optional parameters... */);
        var account_14 = await api.Account.GetAccountSpotInstrumentsAsync("BTCUSDT" /* ...optional parameters... */);
        var account_15 = await api.Account.GetAccountFuturesInstrumentsAsync(BybitCategory.Linear /* ...optional parameters... */);
        var account_16 = await api.Account.ManualBorrowAsync("USDT", 100.0m /* ...optional parameters... */);
        var account_17 = await api.Account.ManualRepayWithoutConversionAsync("USDT", 10.0m /* ...optional parameters... */);
        var account_18 = await api.Account.ManualRepayAsync("USDT", 10.0m /* ...optional parameters... */);
        var account_19 = await api.Account.SetCollateralCoinAsync("BTC", BybitSwitchStatus.On /* ...optional parameters... */);
        var account_20 = await api.Account.BatchSetCollateralCoinsAsync([new BybitAccountBatchSetCollateralItem("BTC", BybitSwitchStatus.On)] /* ...optional parameters... */);
        var account_21 = await api.Account.GetDcpInfoAsync(/* ...optional parameters... */);
        var account_22 = await api.Account.GetSmpGroupAsync(/* ...optional parameters... */);
        var account_23 = await api.Account.SetSpotHedgingAsync(BybitSwitchStatus.Off /* ...optional parameters... */);
        var account_24 = await api.Account.GetTradeBehaviorConfigAsync(/* ...optional parameters... */);
        var account_25 = await api.Account.SetDeltaNeutralModeAsync(true /* ...optional parameters... */);
        var account_26 = await api.Account.SetPriceLimitBehaviorAsync(BybitCategory.Spot, true /* ...optional parameters... */);
        var account_27 = await api.Account.RepayLiabilityAsync("USDT" /* ...optional parameters... */);
        var account_28 = await api.Account.GetOptionAssetInfoAsync(/* ...optional parameters... */);
        var account_29 = await api.Account.GetPayInfoAsync("SOL" /* ...optional parameters... */);
        var account_30 = await api.Account.GetTradeAnalysisAsync("ETHUSDT" /* ...optional parameters... */);

        // Asset API Methods (Private)
        var asset_01 = await api.Asset.GetExchangeHistoryAsync(/* ...optional parameters... */);
        var asset_02 = await api.Asset.GetDeliveryHistoryAsync(BybitCategory.Option /* ...optional parameters... */);
        var asset_03 = await api.Asset.GetSettlementHistoryAsync(BybitCategory.Linear /* ...optional parameters... */);
        var asset_04 = await api.Asset.GetSpotBalancesAsync(/* ...optional parameters... */);
        var asset_05 = await api.Asset.GetAssetBalancesAsync(BybitAccountType.Spot /* ...optional parameters... */);
        var asset_06 = await api.Asset.GetAssetBalanceAsync("USDT", BybitAccountType.Fund /* ...optional parameters... */);
        var asset_07 = await api.Asset.GetTransferableAssetsAsync(BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
        var asset_08 = await api.Asset.InternalTransferAsync("USDT", 100.0m, BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
        var asset_09 = await api.Asset.GetInternalTransfersAsync(/* ...optional parameters... */);
        var asset_10 = await api.Asset.GetSubUsersAsync(/* ...optional parameters... */);
        var asset_11 = await api.Asset.UniversalTransferAsync("USDT", 100.0m, "-----FROM-UID-----", "-----TO-UID-----", BybitAccountType.Fund, BybitAccountType.Fund /* ...optional parameters... */);
        var asset_12 = await api.Asset.GetUniversalTransfersAsync(/* ...optional parameters... */);
        var asset_13 = await api.Asset.GetDepositAllowedAssetsAsync(/* ...optional parameters... */);
        var asset_14 = await api.Asset.SetDepositAccountAsync(BybitAccountType.Fund /* ...optional parameters... */);
        var asset_15 = await api.Asset.GetDepositsAsync(/* ...optional parameters... */);
        var asset_16 = await api.Asset.GetDepositsAsync(1_000_001 /* ...optional parameters... */);
        var asset_17 = await api.Asset.GetInternalDepositsAsync(/* ...optional parameters... */);
        var asset_18 = await api.Asset.GetDepositAddressAsync("USDT" /* ...optional parameters... */);
        var asset_19 = await api.Asset.GetDepositAddressAsync(1_000_001, "USDT" /* ...optional parameters... */);
        var asset_20 = await api.Asset.GetAssetAsync(/* ...optional parameters... */);
        var asset_21 = await api.Asset.GetWithdrawalsAsync(/* ...optional parameters... */);
        var asset_22 = await api.Asset.GetWithdrawableQuantityAsync("USDT" /* ...optional parameters... */);
        var asset_23 = await api.Asset.WithdrawAsync("USDT", 100.0m, "-----ADDRESS-----" /* ...optional parameters... */);
        var asset_24 = await api.Asset.CancelWithdrawalAsync("-----WITHDRAWAL-ID-----" /* ...optional parameters... */);

        // User API Methods (Private)
        var user_01 = await api.User.CreateSubAccountAsync(BybitSubAccountType.NormalSubAccount, "-----USERNAME-----" /* ...optional parameters... */);
        var user_02 = await api.User.CreateSubAccountApiKeyAsync(1_000_001, false, new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_03 = await api.User.GetSubAccountsAsync(/* ...optional parameters... */);
        var user_04 = await api.User.GetSubAccountsAsync(100 /* ...optional parameters... */);
        var user_05 = await api.User.FreezeSubAccountAsync(1_000_001, false /* ...optional parameters... */);
        var user_06 = await api.User.GetApiKeyInformationAsync(/* ...optional parameters... */);
        var user_07 = await api.User.ModifyMasterAccountApiKeyAsync(new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_08 = await api.User.ModifySubAccountApiKeyAsync(new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_09 = await api.User.DeleteMasterAccountApiKeyAsync(/* ...optional parameters... */);
        var user_10 = await api.User.DeleteSubAccountApiKeyAsync(/* ...optional parameters... */);

        // Margin API Methods (Public / Private)
        var margin_01 = await api.Margin.GetVipMarginDataAsync(/* ...optional parameters... */);
        var margin_02 = await api.Margin.GetTieredCollateralRatiosAsync(/* ...optional parameters... */);
        var margin_03 = await api.Margin.GetCurrencyDataAsync(/* ...optional parameters... */);
        var margin_04 = await api.Margin.GetHistoricalInterestRatesAsync(new BybitMarginInterestRateHistoryRequest("BTC")
        {
            VipLevel = "No VIP",
        });
        var margin_05 = await api.Margin.SwitchMarginModeAsync(true /* ...optional parameters... */);
        var margin_06 = await api.Margin.SetLeverageAsync(10.0m /* ...optional parameters... */);
        var margin_07 = await api.Margin.SetLeverageAsync(new BybitMarginSetLeverageRequest(4.0m)
        {
            Currency = "BTC",
        });
        var margin_08 = await api.Margin.GetStatusAndLeverageAsync(/* ...optional parameters... */);
        var margin_09 = await api.Margin.GetMaxBorrowableAmountAsync("BTC" /* ...optional parameters... */);
        var margin_10 = await api.Margin.GetPositionTiersAsync(/* ...optional parameters... */);
        var margin_11 = await api.Margin.GetCoinStateAsync(/* ...optional parameters... */);
        var margin_12 = await api.Margin.GetAvailableAmountToRepayAsync("BTC" /* ...optional parameters... */);
        var margin_13 = await api.Margin.SetAutoRepayModeAsync(true /* ...optional parameters... */);
        var margin_14 = await api.Margin.GetAutoRepayModeAsync(/* ...optional parameters... */);
        var margin_15 = await api.Margin.GetFixedBorrowOrderQuotesAsync(new BybitMarginFixedBorrowQuoteRequest("ETH")
        {
            OrderBy = BybitFixedBorrowOrderBy.AnnualRate,
            Limit = 10,
        });
        var margin_16 = await api.Margin.BorrowFixedRateAsync(new BybitMarginFixedBorrowRequest("BTC", 0.01m, 0.02m, 30)
        {
            RepayType = BybitFixedBorrowRepayType.AutoRepayment,
        });
        var margin_17 = await api.Margin.RenewFixedRateBorrowAsync("-----LOAN-ID-----" /* ...optional parameters... */);
        var margin_18 = await api.Margin.GetFixedBorrowOrderInfoAsync(new BybitMarginFixedBorrowOrderInfoRequest
        {
            OrderCurrency = "ETH",
            Limit = 10,
        });
        var margin_19 = await api.Margin.GetFixedBorrowContractInfoAsync(new BybitMarginFixedBorrowContractInfoRequest
        {
            OrderCurrency = "USDT",
            Limit = 10,
        });
        var margin_20 = await api.Margin.GetLiabilityInfoAsync("BTC" /* ...optional parameters... */);

        // Lending API Methods (Private)
        var lending_01 = await api.InstitutionalLoan.GetProductsAsync(/* ...optional parameters... */);
        var lending_02 = await api.InstitutionalLoan.GetLoanOrdersAsync(/* ...optional parameters... */);
        var lending_03 = await api.InstitutionalLoan.GetRepayOrdersAsync(/* ...optional parameters... */);
        #endregion

        #region WebSocket API Examples
        var ws = new BybitWebSocketClient(new BybitWebSocketClientOptions());
        ws.SetApiCredentials(new ApiCredentials("-----API-KEY-----", "-----API-SECRET-----"));

        // Sample Pairs
        var pairs = new List<string> { "BTCUSDT", "LTCUSDT", "ETHUSDT", "XRPUSDT", "BCHUSDT", "EOSUSDT", "ETCUSDT", "TRXUSDT", "QTUMUSDT", "XLMUSDT", "ADAUSDT" };

        // Public Streams
        foreach (var pair in pairs)
        {
            await ws.SubscribeToTradesAsync(BybitCategory.Spot, pair, (data) =>
            {
                // ... Your logic here
            });

            await ws.SubscribeToTradesAsync(BybitCategory.Spot, pair, (data) =>
            {
                // ... Your logic here
            });
        }

        await ws.SubscribeToSpotTickersAsync("BTCUSDT", (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToLinearTickersAsync("BTCUSDT", (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToInverseTickersAsync("BTCUSDT", (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToSpotTickersAsync(pairs, (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToLinearTickersAsync(pairs, (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToInverseTickersAsync(pairs, (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToOptionTickersAsync(pairs, (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitInterval.OneHour, (data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToLiquidationsAsync(BybitCategory.Inverse, "BTCUSDT", (data) =>
        {
            // ... Your logic here
        });

        // Private Streams
        await ws.SubscribeToPositionUpdatesAsync((data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToExecutionUpdatesAsync((data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToOrderUpdatesAsync((data) =>
        {
            // ... Your logic here
        });

        await ws.SubscribeToWalletUpdatesAsync((data) =>
        {
            // ... Your logic here
        });

        var sub = await ws.SubscribeToGreekUpdatesAsync((data) =>
        {
            // ... Your logic here
        });

        // Unsubscribe
        await ws.UnsubscribeAsync(sub.Data); // or
        await ws.UnsubscribeAsync(sub.Data.Id);
        #endregion
    }
}
