using ApiSharp.Models;
using Bybit.Api.Account;
using Bybit.Api.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Account;

public class AccountJsonTests
{
    [Fact]
    public void WalletBalance_WithEmptyAccountWideFields_DeserializesAsNull()
    {
        var result = DeserializeResult<AccountListResult<BybitAccountBalance>>("wallet-balance-empty-account-fields.json");
        var balance = Assert.Single(result.List);
        var asset = Assert.Single(balance.Assets);

        Assert.Equal(BybitAccountType.Unified, balance.AccountType);
        Assert.Null(balance.AccountInitialMarginRate);
        Assert.Null(balance.TotalEquity);
        Assert.Null(balance.TotalInitialMarginByMarkPrice);
        Assert.Null(asset.AvailableToBorrow);
        Assert.Null(asset.AvailableToWithdraw);
        Assert.True(asset.MarginCollateral);
        Assert.False(asset.CollateralSwitch);
    }

    [Fact]
    public void AccountInfo_MapsCurrentDeprecatedDcpAndSmpFields()
    {
        var account = DeserializeResult<BybitAccount>("account-info.json");

        Assert.Equal(BybitUnifiedMarginStatus.UnifiedTradingAccountPro_1_0, account.UnifiedMarginStatus);
        Assert.Equal(BybitMarginMode.Regular, account.MarginMode);
        Assert.Equal("OFF", account.DcpStatus);
        Assert.Equal(10, account.TimeWindow);
        Assert.Equal(0L, account.SelfMatchPreventionGroup);
        Assert.Equal("OFF", account.SpotHedgingStatus);
    }

    [Fact]
    public void AccountInstruments_MapSpotAndFuturesDocumentShapes()
    {
        var spot = Assert.Single(DeserializeResult<AccountListResult<BybitAccountSpotInstrument>>("account-instrument-spot.json").List);
        var linear = Assert.Single(DeserializeResult<AccountListResult<BybitAccountFuturesInstrument>>("account-instrument-linear.json").List);

        Assert.Equal(9L, spot.SymbolId);
        Assert.Null(spot.Type);
        Assert.True(spot.IsPublicRpi);
        Assert.True(spot.MyRpiPermission);
        Assert.Equal(60000m, spot.LotSizeFilter.PostOnlyMaximumLimitOrderSize);

        Assert.Equal(527L, linear.SymbolId);
        Assert.Null(linear.DeliveryFeeRate);
        Assert.Equal(BybitInstrumentType.Innovation, linear.Type);
        Assert.True(linear.IsPublicRpi);
        Assert.True(linear.MyRpiPermission);
    }

    [Fact]
    public void TransactionLog_MapsExtraFeesAsString()
    {
        var transaction = Assert.Single(DeserializeResult<AccountListResult<BybitAccountTransaction>>("transaction-log.json").List);

        Assert.Equal("2100000000007764263", transaction.Id);
        Assert.Equal("movePosition", transaction.TransactionSubType);
        Assert.Equal(string.Empty, transaction.ExtraFees);
        Assert.Equal(0.01m, transaction.Quantity);
        Assert.Null(transaction.FundingFee);
        Assert.Null(transaction.BonusChange);
    }

    [Fact]
    public void BorrowHistoryAndMmpState_MapRenamedAndCorrectFields()
    {
        var borrow = Assert.Single(DeserializeResult<AccountListResult<BybitAccountBorrow>>("borrow-history.json").List);
        var mmp = Assert.Single(DeserializeResult<AccountListResult<BybitAccountMmp>>("mmp-state.json").List);

        Assert.Equal("USDT", borrow.Asset);
        Assert.Equal(0.5m, borrow.CostExemption);
#pragma warning disable CS0618
        Assert.Equal(borrow.CostExemption, borrow.CostExcemption);
#pragma warning restore CS0618
        Assert.Equal("ETH", mmp.BaseAsset);
        Assert.Equal(1m, mmp.QuantityLimit);
        Assert.Equal(0.1m, mmp.DeltaLimit);
    }

    [Fact]
    public void CurrentAccountUtilityResponses_MapDocumentShapes()
    {
        var transferableAmount = DeserializeResult<BybitAccountTransferableAmount>("transferable-amount.json");
        var dcp = DeserializeResult<DcpInfoResult>("dcp-info.json");
        var optionAsset = Assert.Single(DeserializeResult<OptionAssetResult>("option-asset-info.json").Result);
        var payInfo = DeserializeResult<BybitAccountPayInfo>("pay-info.json");
        var tradeAnalysis = DeserializeResult<BybitAccountTradeAnalysis>("trade-analysis.json");
        var repay = DeserializeResult<AccountListResult<BybitAccountRepayLiability>>("repay-liability.json");

        Assert.Equal(4.54549050m, transferableAmount.AvailableWithdrawal);
        Assert.Equal(10805.54548970m, transferableAmount.AvailableWithdrawalMap["XRP"]);
        Assert.Equal(BybitDcpProduct.Spot, dcp.DcpInfos[0].Product);
        Assert.Equal(BybitSwitchStatus.On, dcp.DcpInfos[0].DcpStatus);
        Assert.Equal(10, dcp.DcpInfos[0].TimeWindow);
        Assert.Equal("BTC", optionAsset.Asset);
        Assert.Equal(-47.6318m, optionAsset.TotalUnrealizedPnl);
        Assert.Equal(1773230923530L, optionAsset.SendTimestamp);
        Assert.Equal("BTC", payInfo.CollateralInfo.CollateralList[1].Asset);
        Assert.True(payInfo.CollateralInfo.CollateralList[1].SpotHedgeAmount < 0);
        Assert.Equal(9, payInfo.CollateralInfo.CollateralList[1].CoinScale);
        Assert.Equal("SOL", payInfo.BorrowInfo!.Asset);
        Assert.Equal("ETH", tradeAnalysis.BaseAsset);
        Assert.Equal(18m, Assert.Single(tradeAnalysis.SumPriceList).SumExecValue);
        Assert.Equal(0.10549670m, repay.List[0].RepaymentQuantity);
    }

    [Fact]
    public void BatchCollateralItem_SerializesSwitchAsMappedString()
    {
        var request = new BybitAccountBatchSetCollateralItem("BTC", BybitSwitchStatus.On);
        var json = JObject.Parse(JsonConvert.SerializeObject(request, SerializerOptions.WithConverters));

        Assert.Equal("BTC", json["coin"]!.Value<string>());
        Assert.Equal("ON", json["collateralSwitch"]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Account", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record AccountListResult<T>
    {
        public List<T> List { get; set; } = [];
    }

    private sealed record DcpInfoResult
    {
        public List<BybitAccountDcpInfo> DcpInfos { get; set; } = [];
    }

    private sealed record OptionAssetResult
    {
        [JsonProperty("result")]
        public List<BybitAccountOptionAssetInfo> Result { get; set; } = [];
    }
}
