using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.InstitutionalLoan;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.InstitutionalLoan;

public class InstitutionalLoanJsonTests
{
    [Fact]
    public void ProductAndMarginCoinResponses_MapCurrentDocumentShapes()
    {
        var productResult = DeserializeResult<ProductResult>("product-info.json");
        var marginCoinResult = DeserializeResult<MarginCoinResult>("margin-coin-info.json");

        var product = Assert.Single(productResult.MarginProductInfo);
        Assert.Equal("91", product.ProductId);
        Assert.Equal(4m, product.Leverage);
        Assert.True(product.SpotSupport);
        Assert.False(product.ContractSupport);
        Assert.True(product.MarginTradingSupport);
        Assert.Null(product.DeferredLiquidationLine);
        Assert.Null(product.DeferredLiquidationTimestamp);
        Assert.Null(product.WithdrawLine);
        Assert.Null(product.TransferLine);
        Assert.Null(product.SpotBuyLine);
        Assert.Null(product.SpotSellLine);
        Assert.Null(product.ContractOpenLine);
        Assert.Equal(0.75m, product.LiquidationLine);
        Assert.Equal(0.35m, product.StopLiquidationLine);

        var marginToken = Assert.Single(marginCoinResult.MarginToken);
        Assert.Equal("81", marginToken.ProductId);
        var tokenInfo = Assert.Single(marginToken.TokenInfo);
        Assert.Equal("USDT", tokenInfo.Token);
        Assert.Equal("0-500", tokenInfo.ConvertRatioList[0].Ladder);
        Assert.Equal(0.95m, tokenInfo.ConvertRatioList[0].ConvertRatio);
    }

    [Fact]
    public void LoanAndRepayOrderResponses_MapCurrentDocumentShapes()
    {
        var loan = Assert.Single(DeserializeResult<LoanOrdersResult>("loan-order.json").LoanInfo);
        var repay = Assert.Single(DeserializeResult<RepayOrdersResult>("repay-history.json").RepayInfo);

        Assert.Equal("1468005106166530304", loan.OrderId);
        Assert.Equal("96", loan.OrderProductId);
        Assert.Equal(1631521L, loan.ParentUID);
        Assert.Equal(1689735916000L, loan.LoanTimestamp);
        Assert.Equal("USDT", loan.LoanAsset);
        Assert.Equal(204m, loan.LoanAmount);
        Assert.Equal(52.07924201m, loan.UnpaidAmount);
        Assert.Equal(BybitLendingOrderStatus.Outstanding, loan.Status);
        Assert.Null(loan.WithdrawLine);
        Assert.Null(loan.TransferLine);
        Assert.Equal(0.71m, loan.SpotBuyLine);
        Assert.Null(loan.DeferredLiquidationLine);
        Assert.Null(loan.DeferredLiquidationTimestamp);
        Assert.Equal("USDT", loan.ReserveToken);
        Assert.Equal(25m, loan.ReserveQuantity);
        Assert.True(loan.MarginTradingSupport);
        Assert.Equal(7m, Assert.Single(loan.USDTPerpetualLeverage).Leverage);
        Assert.Equal(8m, Assert.Single(loan.USDCContractLeverage).Leverage);

        Assert.Equal("8189", repay.RepayOrderId);
        Assert.Equal(1663126393000L, repay.RepaidTimestamp);
        Assert.Equal(30000m, repay.Quantity);
        Assert.Equal(BybitLendingRepayType.NormalRepayment, repay.BusinessType);
        Assert.Equal(BybitLendingRepayType.NormalRepayment, repay.Type);
        Assert.Equal(BybitLoanRepayStatus.Success, repay.Status);
    }

    [Fact]
    public void LtvResponses_MapNormalAndLiquidatingStates()
    {
        var ltv = DeserializeResult<BybitLoanLtv>("ltv.json");
        var info = Assert.Single(ltv.LtvInfo);

        Assert.Null(ltv.LiquidationStatus);
        Assert.Equal(0.75m, info.Ltv);
        Assert.Null(info.RemainingLiquidationTime);
        Assert.Equal("xxxxx", info.ParentUid);
        Assert.Equal("60568258", Assert.Single(info.SubAccountUids));
        Assert.Equal(30m, info.UnpaidAmount);
        Assert.Equal(30m, Assert.Single(info.UnpaidInfo).UnpaidQty);
        Assert.Equal(40m, info.Balance);
        Assert.Equal(40m, Assert.Single(info.BalanceInfo).Quantity);
        Assert.Equal(40m, Assert.Single(info.BalanceInfo).ConvertedAmount);

        var liquidating = DeserializeResult<BybitLoanLtv>("ltv-liquidation.json");
        var liquidatingInfo = Assert.Single(liquidating.LtvInfo);

        Assert.Equal(BybitLoanLiquidationStatus.TransferInProgress, liquidating.LiquidationStatus);
        Assert.Equal(BybitLoanLiquidationStatus.TransferInProgress, liquidatingInfo.LiquidationStatus);
        Assert.Null(liquidatingInfo.Ltv);
        Assert.Null(liquidatingInfo.UnpaidAmount);
        Assert.Null(liquidatingInfo.Balance);
        Assert.Empty(liquidatingInfo.UnpaidInfo);
        Assert.Empty(liquidatingInfo.BalanceInfo);
    }

    [Fact]
    public void CommandResponses_MapCurrentDocumentShapes()
    {
        var association = DeserializeResult<BybitLoanUidAssociation>("bind-uid.json");
        var repayment = DeserializeResult<BybitLoanRepayResult>("repay.json");

        Assert.Equal("592324", association.Uid);
        Assert.Equal(BybitLoanUidOperation.Bind, association.Operation);
        Assert.Equal(BybitLoanRepayOrderStatus.Processing, repayment.RepayOrderStatus);
    }

    [Fact]
    public void Requests_SerializeStringNumericsAndMappedEnums()
    {
        var bind = Serialize(new BybitLoanBindUidRequest("592324", BybitLoanUidOperation.Bind));
        var unbind = Serialize(new BybitLoanBindUidRequest("592324", BybitLoanUidOperation.Unbind));
        var repay = Serialize(new BybitLoanRepayRequest("USDT", 500000m));

        Assert.Equal("592324", bind["uid"]!.Value<string>());
        Assert.Equal("0", bind["operate"]!.Value<string>());
        Assert.Equal("1", unbind["operate"]!.Value<string>());
        Assert.Equal("USDT", repay["token"]!.Value<string>());
        Assert.Equal("500000", repay["quantity"]!.Value<string>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidPagingLimitsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.InstitutionalLoan.GetLoanOrdersAsync(limit: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.InstitutionalLoan.GetLoanOrdersAsync(new BybitLoanOrdersRequest { Limit = 101 }));
        await Assert.ThrowsAsync<ArgumentException>(() => client.InstitutionalLoan.GetRepayOrdersAsync(limit: 101));
        await Assert.ThrowsAsync<ArgumentException>(() => client.InstitutionalLoan.GetRepayOrdersAsync(new BybitLoanRepayOrdersRequest { Limit = 0 }));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "InstitutionalLoan", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private static JObject Serialize(object request)
    {
        var json = JsonConvert.SerializeObject(request, SerializerOptions.WithConverters);
        return JObject.Parse(json);
    }

    private sealed record ProductResult
    {
        public List<BybitLoanProduct> MarginProductInfo { get; set; } = [];
    }

    private sealed record MarginCoinResult
    {
        public List<BybitLoanToken> MarginToken { get; set; } = [];
    }

    private sealed record LoanOrdersResult
    {
        public List<BybitLoanOrder> LoanInfo { get; set; } = [];
    }

    private sealed record RepayOrdersResult
    {
        public List<BybitLoanRepayOrder> RepayInfo { get; set; } = [];
    }
}
