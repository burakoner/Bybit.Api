# Bybit.Api

A .Net wrapper for the Bybit API V5 as described on [Bybit](https://bybit-exchange.github.io/docs/), including all features the API provides using clear and readable objects.

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/burakoner/Bybit.Api/issues)**

## Donations

Donations are greatly appreciated and a motivation to keep improving.

**BTC**:  33WbRKqt7wXARVdAJSu1G1x3QnbyPtZ2bH  
**ETH**:  0x65b02db9b67b73f5f1e983ae10796f91ded57b64  
**USDT (TRC-20)**:  TXwqoD7doMESgitfWa8B2gHL7HuweMmNBJ  

## Installation

![Nuget version](https://img.shields.io/nuget/v/Bybit.Api.svg)  ![Nuget downloads](https://img.shields.io/nuget/dt/Bybit.Api.svg)
Available on [Nuget](https://www.nuget.org/packages/Bybit.Api).

```console
PM> Install-Package Bybit.Api
```

To get started with Bybit.Api first you will need to get the library itself. The easiest way to do this is to install the package into your project using  [NuGet](https://www.nuget.org/packages/Bybit.Api). Using Visual Studio this can be done in two ways.

### Using the package manager

In Visual Studio right click on your solution and select 'Manage NuGet Packages for solution...'. A screen will appear which initially shows the currently installed packages. In the top bit select 'Browse'. This will let you download net package from the NuGet server. In the search box type 'Bybit.Api' and hit enter. The Bybit.Api package should come up in the results. After selecting the package you can then on the right hand side select in which projects in your solution the package should install. After you've selected all project you wish to install and use Bybit.Api in hit 'Install' and the package will be downloaded and added to you projects.

### Using the package manager console

In Visual Studio in the top menu select 'Tools' -> 'NuGet Package Manager' -> 'Package Manager Console'. This should open up a command line interface. On top of the interface there is a dropdown menu where you can select the Default Project. This is the project that Bybit.Api will be installed in. After selecting the correct project type  `Install-Package Bybit.Api`  in the command line interface. This should install the latest version of the package in your project.

After doing either of above steps you should now be ready to actually start using Bybit.Api.

## Getting started

After installing it's time to actually use it. To get started we have to add the Bybit.Api namespace:  `using Bybit.Api;`.

Bybit.Api provides two clients to interact with the Bybit.Api. The  `BybitRestApiClient`  provides all rest API calls. The  `BybitWebSocketClient` provides functions to interact with the websocket provided by the Bybit.Api. Both clients are disposable and as such can be used in a `using` statement.

## Rest Api Examples

```csharp
var api = new BybitRestApiClient();
api.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX");

// Market API Methods (Public)
var market_01 = await api.Market.GetServerTimeAsync(/* ...optional parameters... */);
var market_02 = await api.Market.GetKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour /* ...optional parameters... */);
var market_03 = await api.Market.GetMarkKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour /* ...optional parameters... */);
var market_04 = await api.Market.GetIndexKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour /* ...optional parameters... */);
var market_05 = await api.Market.GetPremiumIndexKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour /* ...optional parameters... */);
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
var market_22 = await api.Market.GetLongShortRatioAsync(BybitCategory.Linear, "BTCUSDT", BybitRecordPeriod.OneDay /* ...optional parameters... */);

// Trade API Methods (Private)
var trade_01 = await api.Trade.PlaceOrderAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy, BybitOrderType.Market, 100.0m /* ...optional parameters... */);
var trade_02 = await api.Trade.AmendOrderAsync(BybitCategory.Spot, "XRPUSDT" /* ...optional parameters... */);
var trade_03 = await api.Trade.AmendOrderAsync(BybitCategory.Spot, "XRPUSDT", "-----ORDER-ID-----" /* ...optional parameters... */);
var trade_04 = await api.Trade.GetOpenOrdersAsync(BybitCategory.Spot /* ...optional parameters... */);
var trade_05 = await api.Trade.CancelOrdersAsync(BybitCategory.Spot /* ...optional parameters... */);
var trade_06 = await api.Trade.GetOrderHistoryAsync(BybitCategory.Spot /* ...optional parameters... */);
var trade_07 = await api.Trade.GetTradeHistoryAsync(BybitCategory.Spot /* ...optional parameters... */);
var trade_08 = await api.Trade.PlaceOrdersAsync(BybitCategory.Spot, new List<BybitBatchPlaceOrderRequest>() /* ...optional parameters... */);
var trade_09 = await api.Trade.AmendOrdersAsync(BybitCategory.Spot, new List<BybitBatchAmendOrderRequest>() /* ...optional parameters... */);
var trade_10 = await api.Trade.CancelOrdersAsync(BybitCategory.Spot, new List<BybitBatchCancelOrderRequest>() /* ...optional parameters... */);
var trade_11 = await api.Trade.GetBorrowQuotaAsync(BybitCategory.Spot, "XRPUSDT", BybitOrderSide.Buy /* ...optional parameters... */);
var trade_12 = await api.Trade.SetDisconnectionProtectAsync(10 /* ...optional parameters... */);

// Position API Methods (Private)
var position_01 = await api.Position.GetPositionsAsync(BybitCategory.Linear /* ...optional parameters... */);
var position_02 = await api.Position.SetLeverageAsync(BybitCategory.Linear, "BTCUSDT", 10.0m, 10.0m /* ...optional parameters... */);
var position_03 = await api.Position.SwitchMarginAsync(BybitCategory.Linear, "BTCUSDT", BybitTradeMode.CrossMargin, 10.0m, 10.0m /* ...optional parameters... */);
var position_04 = await api.Position.SetTakeProfitStopLossModeAsync(BybitCategory.Linear, "BTCUSDT", BybitTakeProfitStopLossMode.Full /* ...optional parameters... */);
var position_05 = await api.Position.SwitchPositionModeAsync(BybitCategory.Linear, BybitPositionMode.BothSides /* ...optional parameters... */);
var position_06 = await api.Position.SetRiskLimitAsync(BybitCategory.Linear, "BTCUSDT", 1_000_001 /* ...optional parameters... */);
var position_07 = await api.Position.SetTradingStopAsync(BybitCategory.Linear, "BTCUSDT", BybitPositionIndex.OneWayModePosition /* ...optional parameters... */);
var position_08 = await api.Position.SetAutoAddMarginAsync(BybitCategory.Linear, "BTCUSDT", true /* ...optional parameters... */);
var position_09 = await api.Position.AddMarginAsync(BybitCategory.Linear, "BTCUSDT", 10.0m /* ...optional parameters... */);
var position_10 = await api.Position.GetClosedProfitLossAsync(BybitCategory.Linear /* ...optional parameters... */);
var position_11 = await api.Position.MovePositionsAsync("-----FROM-UID-----", "-----TO-UID-----", Array.Empty<BybitMovePositionRequest>() /* ...optional parameters... */);
var position_12 = await api.Position.GetMovePositionHistoryAsync(BybitCategory.Linear /* ...optional parameters... */);
var position_13 = await api.Position.ConfirmNewRiskLimitAsync(BybitCategory.Linear, "BTCUSDT" /* ...optional parameters... */);

// Account API Methods (Private)
var account_01 = await api.Account.GetBalancesAsync(BybitAccountType.Spot /* ...optional parameters... */);
var account_02 = await api.Account.UpgradeToUnifiedAccountAsync(/* ...optional parameters... */);
var account_03 = await api.Account.GetBorrowHistoryAsync(/* ...optional parameters... */);
var account_04 = await api.Account.GetCollateralInfoAsync(/* ...optional parameters... */);
var account_05 = await api.Account.GetAssetGreeksAsync(/* ...optional parameters... */);
var account_06 = await api.Account.GetFeeRateAsync(BybitCategory.Spot /* ...optional parameters... */);
var account_07 = await api.Account.GetAccountInfoAsync(/* ...optional parameters... */);
var account_08 = await api.Account.GetTransactionHistoryAsync(/* ...optional parameters... */);
var account_09 = await api.Account.SetMarginModeAsync(BybitMarginMode.Isolated /* ...optional parameters... */);
var account_10 = await api.Account.SetMarketMakerProtectionAsync("ETH", 5000, 0, 1.0m, 0.1m /* ...optional parameters... */);
var account_11 = await api.Account.ResetMarketMakerProtectionAsync("ETH" /* ...optional parameters... */);
var account_12 = await api.Account.GetMarketMakerProtectionAsync("ETH" /* ...optional parameters... */);

// Asset API Methods (Private)
var asset_01 = await api.Asset.GetExchangeHistoryAsync(/* ...optional parameters... */);
var asset_02 = await api.Asset.GetDeliveryHistoryAsync(BybitCategory.Option /* ...optional parameters... */);
var asset_03 = await api.Asset.GetSettlementHistoryAsync(BybitCategory.Linear /* ...optional parameters... */);
var asset_04 = await api.Asset.GetSpotBalancesAsync(/* ...optional parameters... */);
var asset_05 = await api.Asset.GetAssetBalancesAsync(/* ...optional parameters... */);
var asset_06 = await api.Asset.GetAssetBalanceAsync("USDT", BybitAccountType.Fund /* ...optional parameters... */);
var asset_07 = await api.Asset.GetTransferableAssetsAsync(BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
var asset_08 = await api.Asset.InternalTransferAsync("USDT", 100.0m, BybitAccountType.Fund, BybitAccountType.Spot /* ...optional parameters... */);
var asset_09 = await api.Asset.GetInternalTransfersAsync(/* ...optional parameters... */);
var asset_10 = await api.Asset.GetSubusersAsync(/* ...optional parameters... */);
var asset_11 = await api.Asset.UniversalTransferAsync("USDT", 100.0m, "-----FROM-UID-----", "-----TO-UID-----", BybitAccountType.Fund, BybitAccountType.Fund /* ...optional parameters... */);
var asset_12 = await api.Asset.GetUniversalTransfersAsync(/* ...optional parameters... */);
var asset_13 = await api.Asset.GetDepositAllowedAssetsAsync(/* ...optional parameters... */);
var asset_14 = await api.Asset.SetDepositAccountAsync(BybitAccountType.Fund /* ...optional parameters... */);
var asset_15 = await api.Asset.GetDepositsAsync(/* ...optional parameters... */);
var asset_16 = await api.Asset.GetSubUserDepositsAsync("-----SUBUSER-UID-----" /* ...optional parameters... */);
var asset_17 = await api.Asset.GetInternalDepositsAsync(/* ...optional parameters... */);
var asset_18 = await api.Asset.GetMasterDepositAddressAsync("USDT" /* ...optional parameters... */);
var asset_19 = await api.Asset.GetSubUserDepositAddressAsync("-----SUBUSER-UID-----", "USDT" /* ...optional parameters... */);
var asset_20 = await api.Asset.GetAssetInformationAsync(/* ...optional parameters... */);
var asset_21 = await api.Asset.GetWithdrawalsAsync(/* ...optional parameters... */);
var asset_22 = await api.Asset.GetWithdrawableQuantityAsync("USDT" /* ...optional parameters... */);
var asset_23 = await api.Asset.WithdrawAsync("USDT", 100.0m, "-----ADDRESS-----" /* ...optional parameters... */);
var asset_24 = await api.Asset.CancelWithdrawalAsync("-----WITHDRAWAL-ID-----" /* ...optional parameters... */);

// User API Methods (Private)
var user_01 = await api.User.CreateSubAccountAsync(BybitSubAccountType.NormalSubAccount, "-----USERNAME-----" /* ...optional parameters... */);
var user_02 = await api.User.CreateSubAccountApiKeyAsync(1_000_001, false, new BybitApiKeyPermissions() /* ...optional parameters... */);
var user_03 = await api.User.GetSubAccountsAsync(/* ...optional parameters... */);
var user_04 = await api.User.GetSubAccountsAsync(100 /* ...optional parameters... */);
var user_05 = await api.User.FreezeSubAccountAsync(1_000_001, false /* ...optional parameters... */);
var user_06 = await api.User.GetApiKeyInformationAsync(/* ...optional parameters... */);
var user_07 = await api.User.ModifyMasterAccountApiKeyAsync(new BybitApiKeyPermissions() /* ...optional parameters... */);
var user_08 = await api.User.ModifySubAccountApiKeyAsync(new BybitApiKeyPermissions() /* ...optional parameters... */);
var user_09 = await api.User.DeleteMasterAccountApiKeyAsync(/* ...optional parameters... */);
var user_10 = await api.User.DeleteSubAccountApiKeyAsync(/* ...optional parameters... */);

// Leverage Tokens API Methods (Private)
var ltoken_01 = await api.Tokens.GetLeverageTokensAsync(/* ...optional parameters... */);
var ltoken_02 = await api.Tokens.GetLeverageTokenMarketsAsync("BTC3L" /* ...optional parameters... */);
var ltoken_03 = await api.Tokens.PurchaseAsync("BTC3L", 1.0m /* ...optional parameters... */);
var ltoken_04 = await api.Tokens.RedeemAsync("BTC3L", 1.0m/* ...optional parameters... */);
var ltoken_05 = await api.Tokens.GetHistoryAsync(/* ...optional parameters... */);

// Margin API Methods (Private)
var margin_01 = await api.Margin.ToggleMarginModeAsync(true /* ...optional parameters... */);
var margin_02 = await api.Margin.SetLeverageAsync(10.0m /* ...optional parameters... */);

// Lending API Methods (Private)
var lending_01 = await api.Lending.GetLendingProductsAsync(/* ...optional parameters... */);
var lending_02 = await api.Lending.GetLoanOrdersAsync(/* ...optional parameters... */);
var lending_03 = await api.Lending.GetRepayOrdersAsync(/* ...optional parameters... */);
```

## WebSocket Api Examples

The Bybit.Api socket client provides several socket endpoint to which can be subscribed.

```csharp
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

await ws.SubscribeToKlinesAsync(BybitCategory.Spot, "BTCUSDT", BybitKlineInterval.OneHour, (data) =>
{
    // ... Your logic here
});

await ws.SubscribeToLiquidationsAsync(BybitCategory.Inverse, "BTCUSDT", (data) =>
{
    // ... Your logic here
});

await ws.SubscribeToLeverageTokenKlinesAsync("BTC3L", BybitKlineInterval.OneDay, (data) =>
{
    // ... Your logic here
});

await ws.SubscribeToLeverageTokenTickersAsync("BTC3L", (data) =>
{
    // ... Your logic here
});

await ws.SubscribeToLeverageTokenNetAssetValuesAsync("BTC3L", (data) =>
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
```

## Release Notes

* Version 2.(0 -> 4).0 - (28 Apr -> 03 May) 2024
  * Changed main structures
  * Changed some method names
  * Added new models, methods and features
  * Added summaries to methods and fields
  * Improved models for better usability
  * Improved response root models
  * Synced with Bybit Api 2024-04-25 version

* Version 1.3.5 - 25 Apr 2024
  * ApSharp updated to 2.2.1
  * Fixed minor issues

* Version 1.3.0 - 10 Feb 2024
  * ApSharp updated to 2.1.0
  * Fixed issue [https://github.com/burakoner/Bybit.Api/issues/6](https://github.com/burakoner/Bybit.Api/issues/6)
  * Fixed issue [https://github.com/burakoner/Bybit.Api/issues/5](https://github.com/burakoner/Bybit.Api/issues/5)

* Version 1.2.6 - 17 Dec 2023
  * Added multiple ticker subscription support to websocket client

* Version 1.2.5 - 10 Dec 2023
  * ApSharp updated to 2.0.5
  * Fixed some enum errors in models
  * Fixed issue [https://github.com/burakoner/Bybit.Api/issues/4](https://github.com/burakoner/Bybit.Api/issues/4)

* Version 1.2.0 - 21 Nov 2023
  * ApSharp updated to 2.0.3
  * Fixed issue [https://github.com/burakoner/Bybit.Api/issues/2](https://github.com/burakoner/Bybit.Api/issues/2)

* Version 1.1.6 - 03 Sep 2023

* Version 1.1.3 - 11 May 2023
  * Fixed some model properties
  * Edited RestClient Structure. Synced with Bybit Api docs structure.
  * Synced with Bybit Api 2023-05-10 version

* Version 1.1.2 - 30 Apr 2023
  * Fixed some property types in ticker models

* Version 1.0.0 - 19 Apr 2023
  * First Release
