Version 5.6.507 - 09 May 2026
- Updated Market REST API coverage against the current Bybit v5 documentation.
- Added Market endpoints for index price components, order price limit, ADL alert, and fee group structure.
- Added request-object overloads for complex Market queries while preserving existing method signatures.
- Fixed Market response mappings for option ticker IV fields, recent trade execution IDs, spot instrument `stTag`, RPI orderbook quantities, and nullable string numeric fields.
- Added focused Market JSON deserialization tests and live public endpoint integration coverage.
- Split Market request models into one file per request type and widened Market ID fields to `long`.
- Updated Trade REST API coverage against the current Bybit v5 documentation.
- Added the Trade pre-check order endpoint and request-object overloads for place, amend, cancel, query, history, borrow quota, and DCP calls.
- Added BBO order placement fields, DCP product scope support, and the missing `settleCoin` trade history request model field.
- Fixed Trade response mappings for spot `basePrice`, batch place `createAt`, OCO stop-loss trigger labels, future spread execution type, slippage fields, and extra fee fields.
- Fixed batch trade request serialization so optional order IDs and quantities are omitted instead of sending empty strings or zero values.
- Added focused Trade JSON deserialization and request serialization tests.
- Updated Spot Margin Trade REST API coverage against the current Bybit v5 documentation.
- Added Spot Margin endpoints for VIP margin data, tiered collateral ratios, currency data, historical interest, status/leverage, borrow limits, position tiers, coin state, repayment, auto-repay, fixed-rate borrow, and liability information.
- Added request-object overloads for complex Spot Margin queries and fixed-rate borrow flows while preserving the existing margin mode and leverage calls.
- Fixed the Spot Margin historical interest endpoint path and added currency-scoped spot margin leverage support.
- Added focused Spot Margin JSON deserialization tests and live public endpoint integration coverage.
- Updated Position REST API coverage against the current Bybit v5 documentation.
- Added request-object overloads for Position queries and commands while preserving existing method signatures.
- Fixed move-position requests to use POST body parameters, aligned move-history with its optional category parameter, and allowed option trading-stop requests.
- Added Position response mappings for break-even price, open time, MMR update aliases, auto-add-margin booleans, and long user IDs.
- Added focused Position JSON deserialization and request serialization tests.
- Updated Account REST API coverage against the current Bybit v5 documentation.
- Added Account endpoints for transferable amount, account instruments, manual borrow/repay, collateral switches, DCP/SMP info, spot hedging, trade behavior settings, delta-neutral mode, price-limit behavior, liability repayment, option asset info, pay info, and trade analysis.
- Added request-object overloads for Account wallet balance, borrow history, fee rate, transaction logs, account instruments, manual borrow/repay, collateral batch updates, MMP updates, and trade analysis while preserving existing method signatures.
- Fixed Account response mappings for nullable wallet account-wide fields, borrow history `costExemption`, Greeks `baseCoin`, MMP `deltaLimit`, transaction `extraFees`, account DCP/SMP fields, option asset info, pay info, and trade analysis data.
- Added focused Account JSON deserialization and request serialization tests.
- Updated Asset REST API coverage against the current Bybit v5 documentation.
- Added Asset endpoints for funding history, portfolio margin info, total members assets, asset overview, withdrawal address book, VASP list, and standard Convert operations.
- Added request-object overloads for complex Asset queries, transfer/deposit/withdrawal histories, transfer creation, withdrawals, and Convert flows while preserving existing method signatures.
- Fixed Asset response mappings for coin chain limits, deposit tax fields, internal deposit sender IDs, withdrawable UTA/Earn wallets, string withdrawal IDs, withdrawal address timestamps, VASP lists, and Convert statuses.
- Added focused Asset JSON deserialization and request serialization tests.
- Updated User REST API coverage against the current Bybit v5 documentation.
- Added User endpoints for signing agreements, fund custodial sub account lists, sub account API key lists, UID wallet types, deleting sub UIDs, and friend referrals.
- Added request-object overloads for sub account creation, sub API key creation, paged sub account lists, API key updates, sub API key lists, and referral queries while preserving existing method signatures.
- Fixed User request handling for optional quick login, sub account pagination cursors, optional read-only updates, IP binding strings, and the current master API key update request shape.
- Added User response mappings for fund custodial account type, UTA 2.0 account modes, expanded API key permissions, API key metadata, wallet types, and friend referrals.
- Added focused User JSON deserialization and request serialization tests.
- Added Spread Trading REST API coverage against the current Bybit v5 documentation.
- Added Spread Market endpoints for instruments, orderbook, tickers, and recent public trades.
- Added Spread Trade endpoints for create, amend, cancel, cancel all, open orders, order history, trade history, and maximum order quantity.
- Added typed Spread request/response models, enums, examples, JSON deserialization tests, request serialization tests, and live public endpoint coverage.
- Added RFQ Trading REST API coverage against the current Bybit v5 documentation.
- Added RFQ endpoints for creating/canceling RFQs, accepting non-LP quotes, creating/executing/canceling quotes, querying RFQs, quotes, trade history, public trades, and RFQ configuration.
- Added typed RFQ request/response models, enums, examples, JSON deserialization tests, request serialization tests, and client-side validation tests.
- Added Affiliate REST API coverage against the current Bybit v5 documentation.
- Added Affiliate endpoints for affiliate user lists and affiliate user information.
- Added typed Affiliate request/response models, examples, JSON deserialization tests, request serialization tests, and client-side validation tests.
- Added Crypto Loan (New) REST API coverage against the current Bybit v5 documentation.
- Added Crypto Loan common, flexible loan, and fixed loan endpoints including public market data, collateral management, borrowing, repayment, supply, contract, order, and history queries.
- Added typed Crypto Loan request/response models, enums, examples, JSON deserialization tests, request serialization tests, client-side validation tests, and live public endpoint coverage.
- Updated Institutional Loan REST API coverage against the current Bybit v5 documentation.
- Added Institutional Loan margin coin, loan-to-value, UID association, and repayment endpoints with request-object overloads while preserving existing method signatures.
- Fixed Institutional Loan response mappings for nullable product/order line fields, repayment business type and status values, current margin coin conversion tiers, LTV liquidation states, and repayment command status.
- Added Institutional Loan examples, focused JSON deserialization tests, request serialization tests, client-side validation tests, and live public endpoint coverage.

Version 5.5.1019 - 19 Oct 2025
- ApSharp updated to 4.1.0
- Merged pull request Fix: make nullable balance fields to avoid JsonSerializationException https://github.com/burakoner/Bybit.Api/pull/10

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
