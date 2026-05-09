using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Margin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Margin;

public class MarginJsonTests
{
    [Fact]
    public void VipMarginData_MapsNestedVipCoinList()
    {
        var result = DeserializeResult<MarginVipResult>("vip-margin-data.json");
        var vip = Assert.Single(result.VipCoinList);
        var coin = Assert.Single(vip.List);

        Assert.Equal("No VIP", vip.VipLevel);
        Assert.Equal("BTC", coin.Currency);
        Assert.True(coin.Borrowable);
        Assert.True(coin.MarginCollateral);
        Assert.Equal(0.95m, coin.CollateralRatio);
        Assert.Equal(0.0000015021220000m, coin.HourlyBorrowRate);
        Assert.Equal(11, coin.LiquidationOrder);
        Assert.Equal(3m, coin.MaxBorrowingAmount);
    }

    [Fact]
    public void TieredCollateralRatio_MapsPositiveInfinityMaxQuantityAsNull()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginTieredCollateralRatio>>("tiered-collateral-ratio.json");
        var ratio = Assert.Single(result.List);
        var lastTier = ratio.CollateralRatioList.Last();

        Assert.Equal("BTC", ratio.Currency);
        Assert.Equal(1000000m, lastTier.MinQty);
        Assert.Null(lastTier.MaxQty);
        Assert.Equal(0m, lastTier.CollateralRatio);
    }

    [Fact]
    public void CurrencyData_MapsDisabledFixedBorrowFieldsAsNull()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginCurrencyData>>("currency-data.json");
        var currency = Assert.Single(result.List);

        Assert.Equal("BTC", currency.Currency);
        Assert.True(currency.FlexibleManualBorrowable);
        Assert.Equal(0.001m, currency.MinFlexibleManualBorrowQty);
        Assert.Equal(8, currency.FlexibleManualBorrowAccuracy);
        Assert.False(currency.FixedManualBorrowable);
        Assert.Null(currency.MinFixedManualBorrowQty);
        Assert.Null(currency.FixedManualBorrowAccuracy);
        Assert.Null(currency.FixedInterestRateAccuracy);
        Assert.Null(currency.MinFixedInterestRate);
        Assert.Null(currency.MaxFixedInterestRate);
    }

    [Fact]
    public void StatusAndLeverage_MapsOffModeAndEmptyLeverageAsNull()
    {
        var result = DeserializeResult<BybitMarginStatus>("status-and-leverage.json");

        Assert.False(result.SpotMarginMode);
        Assert.Null(result.SpotLeverage);
        Assert.Null(result.EffectiveLeverage);
    }

    [Fact]
    public void SpotMarginMode_MapsStringBoolean()
    {
        var result = DeserializeResult<BybitSpotMarginMode>("spot-margin-mode.json");

        Assert.False(result.SpotMarginMode);
    }

    [Fact]
    public void HistoricalInterestRate_MapsTimestampAndDecimalRate()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginInterestRate>>("historical-interest-rate.json");
        var rate = Assert.Single(result.List);

        Assert.Equal(1721469600000L, rate.Timestamp);
        Assert.Equal("USDC", rate.Currency);
        Assert.Equal(0.000014621596m, rate.HourlyBorrowRate);
        Assert.Equal("No VIP", rate.VipLevel);
    }

    [Fact]
    public void MaxBorrowableAmount_MapsMaxLoanAlias()
    {
        var result = DeserializeResult<BybitMarginMaxBorrowableAmount>("max-borrowable-amount.json");

        Assert.Equal("BTC", result.Currency);
        Assert.Equal(17.54689892m, result.MaxBorrowableAmount);
    }

    [Fact]
    public void RepaymentAvailableAmount_MapsDecimalStringAmount()
    {
        var result = DeserializeResult<BybitMarginRepaymentAvailableAmount>("repayment-available-amount.json");

        Assert.Equal("BTC", result.Currency);
        Assert.Equal(0.02m, result.LossLessRepaymentAmount);
    }

    [Fact]
    public void CoinState_MapsNumericAndEmptySpotLeverageValues()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginCoinState>>("coin-state.json");

        Assert.Equal(3m, result.List[0].SpotLeverage);
        Assert.Null(result.List[1].SpotLeverage);
    }

    [Fact]
    public void PositionTiers_MapsMarginRateAliases()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginPositionTier>>("position-tiers.json");
        var tier = Assert.Single(Assert.Single(result.List).PositionTiersRatioList);

        Assert.Equal(1, tier.Tier);
        Assert.Equal(390m, tier.BorrowLimit);
        Assert.Equal(0.04m, tier.PositionMaintenanceMarginRate);
        Assert.Equal(0.2m, tier.PositionInitialMarginRate);
        Assert.Equal(5m, tier.MaxLeverage);
    }

    [Fact]
    public void AutoRepayMode_MapsStringBoolean()
    {
        var result = DeserializeResult<MarginAutoRepayResult>("auto-repay-mode.json");
        var mode = Assert.Single(result.Data);

        Assert.Equal("ETH", mode.Currency);
        Assert.True(mode.AutoRepayMode);
    }

    [Fact]
    public void FixedBorrowQuote_MapsQuantityAlias()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginFixedBorrowQuote>>("fixed-borrow-quote.json");
        var quote = Assert.Single(result.List);

        Assert.Equal("ETH", quote.OrderCurrency);
        Assert.Equal(30, quote.Term);
        Assert.Equal(0.026m, quote.AnnualRate);
        Assert.Equal(0.1m, quote.Quantity);
    }

    [Fact]
    public void FixedBorrowOrderId_StaysStringForPrefixedId()
    {
        var result = DeserializeResult<BybitMarginFixedBorrowOrderId>("fixed-borrow-order-id.json");

        Assert.Equal("FIXED_BORROW_4563567182f746ec9f73e4357264d8c7187", result.OrderId);
    }

    [Fact]
    public void FixedBorrowOrderInfo_UsesStringOrderIdAndMappedEnums()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginFixedBorrowOrder>>("fixed-borrow-order-info.json");
        var order = Assert.Single(result.List);

        Assert.Equal("30", result.NextPageCursor);
        Assert.Equal("FIXED_BORROW_a17089fc526441faa52eb99b0b9feb69185", order.OrderId);
        Assert.Equal(1764120783000L, order.OrderTime);
        Assert.Equal(1000m, order.FilledQty);
        Assert.Equal(BybitFixedBorrowOrderState.FullyFilled, order.State);
        Assert.Equal(BybitFixedBorrowRepayType.AutoRepayment, order.RepayType);
        Assert.Equal(BybitFixedBorrowStrategyType.Partial, order.StrategyType);
    }

    [Fact]
    public void FixedBorrowContractInfo_UsesStringLoanIdAndMappedEnums()
    {
        var result = DeserializeResult<MarginListResult<BybitMarginFixedBorrowContract>>("fixed-borrow-contract-info.json");
        var contract = Assert.Single(result.List);

        Assert.Equal("0", result.NextPageCursor);
        Assert.Equal("2092341042506646784", contract.LoanId);
        Assert.Equal("FIXED_BORROW_a17089fc526441faa52eb99b0b9feb69185", contract.OrderId);
        Assert.Equal(1764162490000L, contract.BorrowTime);
        Assert.Equal(1764288000000L, contract.RepaymentTime);
        Assert.Equal(BybitFixedBorrowContractStatus.Overdue, contract.Status);
        Assert.Equal(1, contract.Term);
        Assert.Equal(BybitFixedBorrowRepayType.AutoRepayment, contract.RepayType);
        Assert.Equal(BybitFixedBorrowStrategyType.Partial, contract.StrategyType);
    }

    [Fact]
    public void LiabilityInfo_MapsDecimalStringFields()
    {
        var result = DeserializeResult<BybitMarginLiabilityInfo>("liability-info.json");

        Assert.Equal("BTC", result.Currency);
        Assert.Equal(0.05m, result.TotalBorrowAmount);
        Assert.Equal(0.02m, result.FixedBorrowAmount);
        Assert.Equal(0.03m, result.FlexibleBorrowAmount);
        Assert.Equal(0.04m, result.SpotTotalBorrow);
        Assert.Equal(0.01m, result.DerivativesBorrow);
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Margin", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record MarginListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string? NextPageCursor { get; set; }
    }

    private sealed record MarginVipResult
    {
        public List<BybitMarginVipData> VipCoinList { get; set; } = [];
    }

    private sealed record MarginAutoRepayResult
    {
        public List<BybitMarginAutoRepayMode> Data { get; set; } = [];
    }
}
