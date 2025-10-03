Version 5.5.1003 - 03 Oct 2025
Enhance Bybit API client with new features and records
- Added new constants for RPI orderbook and delivery price APIs.
- Introduced `GetRpiOrderbookAsync` and `GetNewDeliveryPriceAsync`.
- Enhanced `BybitMarketSpotInstrument` with new properties.
- Replaced price limit fields with `PriceLimitRatioX` and `PriceLimitRatioY`.
- Added `Type`, `DisplayName`, and `RiskParameters` to futures instruments.
- Made `LaunchTime` and `DeliveryTime` nullable in multiple records.
- Converted classes in `Bybit.Api/Account/Responses` to records.
- Introduced `BybitInstrumentType` enum for instrument categorization.
- Added `BybitMarketDeliveryPriceNew` record for delivery price data.
- Added new records for orders, positions, PnL, and risk limits to align with Bybit's API.
- Refactored REST API clients with updated methods for trading operations.
- Introduced slippage tolerance support in `PlaceOrderAsync`.
- Removed legacy code and enhanced documentation for improved maintainability.
- Refactored `BybitPositionRestApiClient` and moved it to the `Bybit.Api.Position` namespace. 
- Updated position management methods and added new ones, including `GetClosedOptionsPositionsAsync` and `MovePositionsAsync`. 
- Replaced `AddMarginAsync` with `AddOrReduceMarginAsync`.
- Updated `api.Loan` to `api.InstitutionalLoan` and enhanced lending methods.
- Improved `BybitAccountBalance` and `BybitAccountCollateralInfo` models by adding new fields and removing unused ones.
- Introduced new models for positions and profit/loss, replacing legacy models.
- Standardized property names, improved method summaries, and removed redundant code.
- Added support for unified margin account enhancements and new transaction log fields.
- Introduced breaking changes to streamline the API client.

Version 5.5.930 - 30 Sep 2025
- Namespace Bybit.Api.Loan renamed to Bybit.Api.InstitutionalLoan
- Removed Spot Leverage Token Section
- Enabled nullable data type in project
- Records used in data models instead of classes

Version 5.5.610 - 10 Jun 2025
Version 5.5.521 - 20 May 2025
Version 5.5.515 - 15 May 2025
Version 5.5.212 - 12 Feb 2025
Version 5.5.131 - 31 Jan 2025
Version 5.5.101 - 01 Jan 2025
- ApSharp updated to 3.3.1

Version 5.4.1223 - 22 Dec 2024
Version 5.4.1221 - 21 Dec 2024
Version 5.4.1107 - 05 Nov 2024
Version 5.4.1026 - 26 Oct 2024
Version 5.4.1019 - 19 Oct 2024
Version 5.4.1012 - 11 Oct 2024
Version 5.4.1011 - 10 Oct 2024

Version 2.(0 -&gt; 4).0 - (28 Apr -&gt; 03 May) 2024
- Changed main structures
- Changed some method names
- Added new models, methods and features
- Added summaries to methods and fields
- Improved models for better usability
- Improved response root models
- Synced with Bybit Api 2024-04-25 version

Version 1.3.5 - 25 Apr 2024
- ApSharp updated to 2.2.1
- Fixed minor issues

Version 1.3.0 - 10 Feb 2024
- ApSharp updated to 2.1.0
- Fixed issue https://github.com/burakoner/Bybit.Api/issues/6
- Fixed issue https://github.com/burakoner/Bybit.Api/issues/5

Version 1.2.6 - 17 Dec 2023
- Added multiple ticker subscription support to websocket client

Version 1.2.5 - 10 Dec 2023
- ApSharp updated to 2.0.5
- Fixed some enum errors in models
- Fixed issue https://github.com/burakoner/Bybit.Api/issues/4

Version 1.2.0 - 21 Nov 2023
- ApSharp updated to 2.0.3
- Fixed issue https://github.com/burakoner/Bybit.Api/issues/2

Version 1.1.6 - 03 Sep 2023

Version 1.1.3 - 11 May 2023
- Fixed some model properties
- Edited RestClient Structure. Synced with Bybit Api docs structure.
- Synced with Bybit Api 2023-05-10 version

Version 1.1.2 - 30 Apr 2023
- Fixed some property types in ticker models