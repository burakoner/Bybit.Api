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
        var asset_01 = await api.Asset.GetFundingHistoryAsync(/* ...optional parameters... */);
        var asset_02 = await api.Asset.GetExchangeHistoryAsync(/* ...optional parameters... */);
        var asset_03 = await api.Asset.GetDeliveryHistoryAsync(BybitCategory.Option /* ...optional parameters... */);
        var asset_04 = await api.Asset.GetDeliveryHistoryAsync(new BybitAssetDeliveryHistoryRequest(BybitCategory.Option) { ExpiryDate = "25MAR22" });
        var asset_05 = await api.Asset.GetSettlementHistoryAsync(BybitCategory.Linear /* ...optional parameters... */);
        var asset_06 = await api.Asset.GetSubUsersAsync(/* ...optional parameters... */);
        var asset_07 = await api.Asset.GetPortfolioMarginAsync(/* ...optional parameters... */);
        var asset_08 = await api.Asset.GetTotalMembersAssetsAsync(/* ...optional parameters... */);
        var asset_09 = await api.Asset.GetSpotBalancesAsync(/* ...optional parameters... */);
        var asset_10 = await api.Asset.GetAssetBalancesAsync(BybitAccountType.Spot /* ...optional parameters... */);
        var asset_11 = await api.Asset.GetAssetBalancesAsync(new BybitAssetBalancesRequest(BybitAccountType.Unified) { Asset = "USDT" });
        var asset_12 = await api.Asset.GetAssetBalanceAsync("USDT", BybitAccountType.Fund /* ...optional parameters... */);
        var asset_13 = await api.Asset.GetWithdrawableQuantityAsync("USDT" /* ...optional parameters... */);
        var asset_14 = await api.Asset.GetAssetOverviewAsync(/* ...optional parameters... */);
        var asset_15 = await api.Asset.GetTransferableAssetsAsync(BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
        var asset_16 = await api.Asset.InternalTransferAsync("USDT", 100.0m, BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
        var asset_17 = await api.Asset.GetInternalTransfersAsync(/* ...optional parameters... */);
        var asset_18 = await api.Asset.UniversalTransferAsync("USDT", 100.0m, "-----FROM-UID-----", "-----TO-UID-----", BybitAccountType.Fund, BybitAccountType.Fund /* ...optional parameters... */);
        var asset_19 = await api.Asset.GetUniversalTransfersAsync(/* ...optional parameters... */);
        var asset_20 = await api.Asset.GetDepositAllowedAssetsAsync(/* ...optional parameters... */);
        var asset_21 = await api.Asset.SetDepositAccountAsync(BybitAccountType.Fund /* ...optional parameters... */);
        var asset_22 = await api.Asset.GetDepositsAsync(/* ...optional parameters... */);
        var asset_23 = await api.Asset.GetDepositsAsync(1_000_001 /* ...optional parameters... */);
        var asset_24 = await api.Asset.GetInternalDepositsAsync(/* ...optional parameters... */);
        var asset_25 = await api.Asset.GetDepositAddressAsync("USDT" /* ...optional parameters... */);
        var asset_26 = await api.Asset.GetDepositAddressAsync(1_000_001, "USDT" /* ...optional parameters... */);
        var asset_27 = await api.Asset.GetAssetAsync(/* ...optional parameters... */);
        var asset_28 = await api.Asset.GetWithdrawalsAsync(/* ...optional parameters... */);
        var asset_29 = await api.Asset.GetWithdrawalAddressesAsync(/* ...optional parameters... */);
        var asset_30 = await api.Asset.GetVaspsAsync(/* ...optional parameters... */);
        var asset_31 = await api.Asset.WithdrawAsync(new BybitAssetWithdrawRequest("USDT", 100.0m, "-----ADDRESS-----")
        {
            AccountType = BybitAssetWithdrawAccountType.Fund,
            Chain = "ETH",
        });
        var asset_32 = await api.Asset.CancelWithdrawalAsync("-----WITHDRAWAL-ID-----" /* ...optional parameters... */);
        var asset_33 = await api.Asset.GetConvertCoinsAsync("eb_convert_funding" /* ...optional parameters... */);
        var asset_34 = await api.Asset.RequestConvertQuoteAsync(new BybitAssetConvertQuoteRequest("eb_convert_funding", "ETH", "BTC", "ETH", 0.1m));
        var asset_35 = await api.Asset.ConfirmConvertQuoteAsync("-----QUOTE-TX-ID-----" /* ...optional parameters... */);
        var asset_36 = await api.Asset.GetConvertStatusAsync("-----QUOTE-TX-ID-----", "eb_convert_funding" /* ...optional parameters... */);
        var asset_37 = await api.Asset.GetConvertHistoryAsync(/* ...optional parameters... */);

        // User API Methods (Private)
        var user_01 = await api.User.SignAgreementAsync(categoryV2: 2 /* ...optional parameters... */);
        var user_02 = await api.User.CreateSubAccountAsync(BybitSubAccountType.NormalSubAccount, "-----USERNAME-----" /* ...optional parameters... */);
        var user_03 = await api.User.CreateSubAccountAsync(new BybitUserCreateSubAccountRequest(BybitSubAccountType.NormalSubAccount, "-----USERNAME-----")
        {
            QuickLogin = true,
            Label = "example",
        });
        var user_04 = await api.User.CreateSubAccountApiKeyAsync(1_000_001, false, new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_05 = await api.User.GetSubAccountsAsync(/* ...optional parameters... */);
        var user_06 = await api.User.GetSubAccountsAsync(100 /* ...optional parameters... */);
        var user_07 = await api.User.GetFundCustodialSubAccountsAsync(/* ...optional parameters... */);
        var user_08 = await api.User.FreezeSubAccountAsync(1_000_001, false /* ...optional parameters... */);
        var user_09 = await api.User.GetApiKeyInformationAsync(/* ...optional parameters... */);
        var user_10 = await api.User.GetSubAccountApiKeysAsync("-----SUB-UID-----" /* ...optional parameters... */);
        var user_11 = await api.User.GetWalletTypesAsync("-----SUB-UID-----" /* ...optional parameters... */);
        var user_12 = await api.User.ModifyMasterAccountApiKeyAsync(new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_13 = await api.User.ModifySubAccountApiKeyAsync(new BybitUserApiKeyPermissions() /* ...optional parameters... */);
        var user_14 = await api.User.DeleteSubAccountAsync("-----SUB-UID-----" /* ...optional parameters... */);
        var user_15 = await api.User.DeleteMasterAccountApiKeyAsync(/* ...optional parameters... */);
        var user_16 = await api.User.DeleteSubAccountApiKeyAsync(/* ...optional parameters... */);
        var user_17 = await api.User.GetFriendReferralsAsync(status: 0, size: 20 /* ...optional parameters... */);

        // Spread Trading API Methods (Public / Private)
        var spread_01 = await api.Spread.GetInstrumentsAsync(limit: 1 /* ...optional parameters... */);
        var spread_02 = await api.Spread.GetOrderbookAsync("SOLUSDT_SOL/USDT", 1 /* ...optional parameters... */);
        var spread_03 = await api.Spread.GetTickersAsync("SOLUSDT_SOL/USDT" /* ...optional parameters... */);
        var spread_04 = await api.Spread.GetRecentTradesAsync("SOLUSDT_SOL/USDT", 10 /* ...optional parameters... */);
        var spread_05 = await api.Spread.PlaceOrderAsync("SOLUSDT_SOL/USDT", BybitOrderSide.Buy, BybitOrderType.Limit, 0.1m, 21.0m, "-----CLIENT-ORDER-ID-----", BybitTimeInForce.PostOnly /* ...optional parameters... */);
        var spread_06 = await api.Spread.AmendOrderAsync("SOLUSDT_SOL/USDT", clientOrderId: "-----CLIENT-ORDER-ID-----", quantity: 0.2m, price: 14.0m /* ...optional parameters... */);
        var spread_07 = await api.Spread.CancelOrderAsync(clientOrderId: "-----CLIENT-ORDER-ID-----" /* ...optional parameters... */);
        var spread_08 = await api.Spread.CancelAllOrdersAsync(symbol: "SOLUSDT_SOL/USDT" /* ...optional parameters... */);
        var spread_09 = await api.Spread.GetOpenOrdersAsync(/* ...optional parameters... */);
        var spread_10 = await api.Spread.GetOrderHistoryAsync(orderId: "-----ORDER-ID-----" /* ...optional parameters... */);
        var spread_11 = await api.Spread.GetTradeHistoryAsync(orderId: "-----ORDER-ID-----" /* ...optional parameters... */);
        var spread_12 = await api.Spread.GetMaxOrderQuantityAsync("SOLUSDT_SOL/USDT", BybitSpreadMaxQuantitySide.Buy, 21.0m /* ...optional parameters... */);

        // RFQ Trading API Methods (Private)
        var rfq_01 = await api.Rfq.GetRfqConfigAsync(/* ...optional parameters... */);
        var rfq_02 = await api.Rfq.CreateRfqAsync(["LP4", "LP5"], [
            new BybitRfqLegRequest(BybitCategory.Linear, "BTCUSDT", BybitOrderSide.Buy, 1.0m),
        ] /* ...optional parameters... */);
        var rfq_03 = await api.Rfq.CancelRfqAsync(rfqId: "-----RFQ-ID-----" /* ...optional parameters... */);
        var rfq_04 = await api.Rfq.CancelAllRfqsAsync(/* ...optional parameters... */);
        var rfq_05 = await api.Rfq.AcceptOtherQuoteAsync("-----RFQ-ID-----" /* ...optional parameters... */);
        var rfq_06 = await api.Rfq.CreateQuoteAsync("-----RFQ-ID-----",
            quoteBuyList: [new BybitRfqQuoteLegRequest(BybitCategory.Linear, "BTCUSDT", 106000.0m)],
            quoteSellList: [new BybitRfqQuoteLegRequest(BybitCategory.Linear, "BTCUSDT", 126500.0m)] /* ...optional parameters... */);
        var rfq_07 = await api.Rfq.ExecuteQuoteAsync("-----RFQ-ID-----", "-----QUOTE-ID-----", BybitOrderSide.Buy /* ...optional parameters... */);
        var rfq_08 = await api.Rfq.CancelQuoteAsync(quoteId: "-----QUOTE-ID-----" /* ...optional parameters... */);
        var rfq_09 = await api.Rfq.CancelAllQuotesAsync(/* ...optional parameters... */);
        var rfq_10 = await api.Rfq.GetRfqsRealtimeAsync(/* ...optional parameters... */);
        var rfq_11 = await api.Rfq.GetRfqsAsync(limit: 20 /* ...optional parameters... */);
        var rfq_12 = await api.Rfq.GetQuotesRealtimeAsync(/* ...optional parameters... */);
        var rfq_13 = await api.Rfq.GetQuotesAsync(limit: 20 /* ...optional parameters... */);
        var rfq_14 = await api.Rfq.GetTradeHistoryAsync(limit: 20 /* ...optional parameters... */);
        var rfq_15 = await api.Rfq.GetPublicTradesAsync(limit: 20 /* ...optional parameters... */);

        // Affiliate API Methods (Private)
        var affiliate_01 = await api.Affiliate.GetUsersAsync(size: 2, need365Day: true, need30Day: true, needDeposit: true /* ...optional parameters... */);
        var affiliate_02 = await api.Affiliate.GetUsersAsync(new BybitAffiliateUserListRequest
        {
            Size = 2,
            Cursor = "0",
            Need365Day = true,
            Need30Day = true,
            NeedDeposit = true,
            StartDate = "2025-10-21",
            EndDate = "2025-10-22",
        });
        var affiliate_03 = await api.Affiliate.GetUserInfoAsync(1_513_500 /* ...optional parameters... */);

        // Crypto Loan API Methods (Public / Private)
        var cryptoLoan_01 = await api.CryptoLoan.GetBorrowableCoinsAsync(currency: "BTC" /* ...optional parameters... */);
        var cryptoLoan_02 = await api.CryptoLoan.GetCollateralCoinsAsync(currency: "BTC" /* ...optional parameters... */);
        var cryptoLoan_03 = await api.CryptoLoan.GetMaxCollateralReductionAmountAsync("BTC" /* ...optional parameters... */);
        var cryptoLoan_04 = await api.CryptoLoan.AdjustCollateralAsync("BTC", 0.01m, BybitCryptoLoanAdjustmentDirection.AddCollateral /* ...optional parameters... */);
        var cryptoLoan_05 = await api.CryptoLoan.GetCollateralAdjustmentHistoryAsync(collateralCurrency: "BTC", limit: 10 /* ...optional parameters... */);
        var cryptoLoan_06 = await api.CryptoLoan.GetPositionAsync(/* ...optional parameters... */);
        var cryptoLoan_07 = await api.CryptoLoan.GetMaxLoanAmountAsync("BTC", [new BybitCryptoLoanMaxLoanCollateralRequestItem("USDT", 1000m)] /* ...optional parameters... */);
        var cryptoLoan_08 = await api.CryptoLoan.BorrowFlexibleAsync("BTC", 0.01m, [new BybitCryptoLoanCollateralRequestItem("USDT", 1000m)] /* ...optional parameters... */);
        var cryptoLoan_09 = await api.CryptoLoan.RepayFlexibleAsync("BTC", 0.005m /* ...optional parameters... */);
        var cryptoLoan_10 = await api.CryptoLoan.RepayFlexibleWithCollateralAsync("USDT", "BTC", 500m /* ...optional parameters... */);
        var cryptoLoan_11 = await api.CryptoLoan.GetFlexibleLoansAsync("BTC" /* ...optional parameters... */);
        var cryptoLoan_12 = await api.CryptoLoan.GetFlexibleBorrowHistoryAsync(limit: 10 /* ...optional parameters... */);
        var cryptoLoan_13 = await api.CryptoLoan.GetFlexibleRepaymentHistoryAsync(loanCurrency: "BTC" /* ...optional parameters... */);
        var cryptoLoan_14 = await api.CryptoLoan.GetFixedLendingMarketAsync("USDT", BybitFixedBorrowOrderBy.AnnualRate /* ...optional parameters... */);
        var cryptoLoan_15 = await api.CryptoLoan.GetFixedBorrowingMarketAsync("USDT", BybitFixedBorrowOrderBy.AnnualRate /* ...optional parameters... */);
        var cryptoLoan_16 = await api.CryptoLoan.BorrowFixedAsync("ETH", 1.5m, 0.022m, 30, repayType: BybitFixedBorrowRepayType.AutoRepayment /* ...optional parameters... */);
        var cryptoLoan_17 = await api.CryptoLoan.RenewFixedBorrowAsync("-----LOAN-ID-----" /* ...optional parameters... */);
        var cryptoLoan_18 = await api.CryptoLoan.SupplyFixedAsync("USDT", 2002.21m, 0.35m, 7 /* ...optional parameters... */);
        var cryptoLoan_19 = await api.CryptoLoan.CancelFixedBorrowOrderAsync("-----BORROW-ORDER-ID-----" /* ...optional parameters... */);
        var cryptoLoan_20 = await api.CryptoLoan.CancelFixedSupplyOrderAsync("-----SUPPLY-ORDER-ID-----" /* ...optional parameters... */);
        var cryptoLoan_21 = await api.CryptoLoan.GetFixedBorrowContractsAsync(orderCurrency: "ETH" /* ...optional parameters... */);
        var cryptoLoan_22 = await api.CryptoLoan.GetFixedSupplyContractsAsync(supplyCurrency: "USDT" /* ...optional parameters... */);
        var cryptoLoan_23 = await api.CryptoLoan.GetFixedBorrowOrdersAsync(orderId: "-----BORROW-ORDER-ID-----" /* ...optional parameters... */);
        var cryptoLoan_24 = await api.CryptoLoan.GetFixedRenewOrdersAsync(limit: 10 /* ...optional parameters... */);
        var cryptoLoan_25 = await api.CryptoLoan.GetFixedSupplyOrdersAsync(orderId: "-----SUPPLY-ORDER-ID-----" /* ...optional parameters... */);
        var cryptoLoan_26 = await api.CryptoLoan.RepayFixedAsync(loanId: "-----LOAN-ID-----" /* ...optional parameters... */);
        var cryptoLoan_27 = await api.CryptoLoan.RepayFixedWithCollateralAsync("ETH", "USDT", 0.1m /* ...optional parameters... */);
        var cryptoLoan_28 = await api.CryptoLoan.GetFixedRepaymentHistoryAsync(repayId: "-----REPAY-ID-----" /* ...optional parameters... */);

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
