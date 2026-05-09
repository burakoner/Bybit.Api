using ApiSharp.Models;
using Bybit.Api.Asset;
using Bybit.Api.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Asset;

public class AssetJsonTests
{
    [Fact]
    public void CoinInfo_MapsCurrentChainFieldsAndNullableDecimals()
    {
        var asset = Assert.Single(DeserializeResult<RowsResult<BybitAsset>>("coin-info.json").Rows);
        var ethereum = Assert.Single(asset.Chains, x => x.Chain == "ETH");
        var mantle = Assert.Single(asset.Chains, x => x.Chain == "MANTLE");

        Assert.Equal("MNT", asset.Asset);
#pragma warning disable CS0618
        Assert.Equal(10000000m, asset.RemainingWithdrawableQuantity);
#pragma warning restore CS0618
        Assert.Equal(6, ethereum.Confirmations);
        Assert.Equal(3m, ethereum.WithdrawalFee);
        Assert.Equal(0.022m, ethereum.WithdrawalPercentageFee);
        Assert.Equal("0x3c3a81e81dc49a522a592e7622a7e711c06bf354", ethereum.ContractAddress);
        Assert.Equal(65, ethereum.SafeConfirmations);
        Assert.Equal(10000000m, ethereum.MaximumWithdrawal);
        Assert.Null(mantle.WithdrawalFee);
    }

    [Fact]
    public void FundingHistoryAndWithdrawableAmount_MapCurrentShapes()
    {
        var funding = Assert.Single(DeserializeResult<ListResult<BybitAssetFundingTransaction>>("funding-history.json").List);
        var withdrawable = DeserializeResult<BybitAssetWithdrawableAmount>("withdrawable-amount.json");

        Assert.Equal("290118", funding.MemberId);
        Assert.Equal("BTC", funding.Asset);
        Assert.Equal(0.00003561m, funding.TransactionAmount);
        Assert.Equal(7.5547230662687035m, funding.BalanceAfterTransaction);
        Assert.Equal(new DateTime(2026, 3, 4, 12, 16, 3, DateTimeKind.Utc), funding.CreatedAt);

        Assert.Equal(595051.7m, withdrawable.LimitAmountUsd);
        Assert.Null(withdrawable.WithdrawableAmounts.Spot);
        Assert.Equal(498751.0882m, withdrawable.WithdrawableAmounts.UnifiedTradingAccount!.WithdrawableQuantity);
#pragma warning disable CS0618
        Assert.Equal(withdrawable.WithdrawableAmounts.UnifiedTradingAccount.WithdrawableQuantity, withdrawable.WithdrawableAmounts.UnifiedTradingAccount.WithdrwawableQuantity);
#pragma warning restore CS0618
        Assert.Equal(5m, withdrawable.WithdrawableAmounts.Earn!.AvailableBalance);
    }

    [Fact]
    public void AssetOverviewAndTotalMembersAssets_MapNestedDocumentShapes()
    {
        var overview = DeserializeResult<BybitAssetOverview>("asset-overview.json");
        var totalMembers = DeserializeResult<BybitAssetTotalMembersAssets>("total-members-assets.json");

        Assert.Equal(1024.55m, overview.TotalEquity);
        var account = Assert.Single(overview.List);
        Assert.Equal("UnifiedTradingAccount", account.AccountType);
        Assert.Equal(1773230923530L, account.SnapshotTime);
        Assert.Equal("BTC", Assert.Single(account.CoinDetail).Asset);
        Assert.Equal(301m, Assert.Single(account.Categories).Equity);
        Assert.Equal(70000m, account.CoinDetail[0].ExtMap!.PriceUpper);

        Assert.Equal(12345.67m, totalMembers.Total);
        var member = Assert.Single(totalMembers.List);
        Assert.Equal(1234567890123456789L, member.UserId);
        Assert.True(member.IsMaster);
        Assert.Equal(12345.67m, member.OriginalBalance);
        Assert.Equal("UNIFIED", Assert.Single(member.Items).Type);
    }

    [Fact]
    public void WithdrawAddressVaspAndConvertResponses_MapCurrentShapes()
    {
        var address = Assert.Single(DeserializeResult<RowsResult<BybitAssetWithdrawalAddress>>("withdrawal-addresses.json").Rows);
        var vasp = Assert.Single(DeserializeResult<VaspResult>("vasp-list.json").Vasp);
        var coin = Assert.Single(DeserializeResult<CoinsResult<BybitAssetConvertCoin>>("convert-coin-list.json").Coins);
        var quote = DeserializeResult<BybitAssetConvertQuote>("convert-quote.json");
        var execution = DeserializeResult<BybitAssetConvertExecution>("convert-execution.json");
        var status = DeserializeResult<BybitAssetConvertResult>("convert-status.json").Result;
        var history = Assert.Single(DeserializeResult<ListResult<BybitAssetConvertTransaction>>("convert-history.json").List);

        Assert.Equal("USDT", address.Asset);
        Assert.Equal(new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc), address.CreatedTime);
        Assert.Equal("basic-finance", vasp.VaspEntityId);

        Assert.Equal("ETH", coin.Asset);
        Assert.Equal(8, coin.AccuracyLength);
        Assert.Equal(12.25m, coin.Balance);
        Assert.False(coin.DisableFrom);
        Assert.True(coin.DisableTo);

        Assert.Equal("10100108106409343501030232064", quote.QuoteTransactionId);
        Assert.Equal(0.05m, quote.ExchangeRate);
        Assert.Equal(0.1m, quote.FromAmount);
        Assert.Empty(quote.ExtTaxAndFee);

        Assert.Equal(BybitConvertStatus.Processing, execution.ExchangeStatus);
        Assert.Equal(BybitConvertStatus.Success, status.ExchangeStatus);
        Assert.Equal(0.05m, status.ConvertRate);
        Assert.Equal("opFrom", status.ExtInfo!.ParamType);
        Assert.Equal(history.ExchangeTxId, status.ExchangeTxId);
    }

    [Fact]
    public void WithdrawAndConvertRequests_SerializeNumericStringsAndBeneficiary()
    {
        var withdraw = new BybitAssetWithdrawRequest("USDT", 24m, "0x99ced129603abc771c0dabe935c326ff6c86645d")
        {
            Chain = "ETH",
            ForceChain = 0,
            AccountType = BybitAssetWithdrawAccountType.FundUnifiedEarn,
            TransactionPurpose = "Payment for goods and services",
            Beneficiary = new BybitAssetWithdrawalBeneficiary
            {
                Name = "Jane Doe",
                VaspEntityId = "others",
                LegalType = "individual",
            },
        };

        var convert = new BybitAssetConvertQuoteRequest("eb_convert_funding", "ETH", "BTC", "ETH", 0.1m)
        {
            ParameterType = "opFrom",
            ParameterValue = "broker-id-001",
        };

        var withdrawJson = JObject.Parse(JsonConvert.SerializeObject(withdraw, SerializerOptions.WithConverters));
        var convertJson = JObject.Parse(JsonConvert.SerializeObject(convert, SerializerOptions.WithConverters));

        Assert.Equal("24", withdrawJson["amount"]!.Value<string>());
        Assert.Equal("FUND,UTA,EARN", withdrawJson["accountType"]!.Value<string>());
        Assert.Equal("Jane Doe", withdrawJson["beneficiary"]!["beneficiaryName"]!.Value<string>());
        Assert.Equal("0.1", convertJson["requestAmount"]!.Value<string>());
        Assert.Equal("eb_convert_funding", convertJson["accountType"]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Asset", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record RowsResult<T>
    {
        public List<T> Rows { get; set; } = [];
    }

    private sealed record ListResult<T>
    {
        public List<T> List { get; set; } = [];
    }

    private sealed record CoinsResult<T>
    {
        public List<T> Coins { get; set; } = [];
    }

    private sealed record VaspResult
    {
        public List<BybitAssetVasp> Vasp { get; set; } = [];
    }
}
