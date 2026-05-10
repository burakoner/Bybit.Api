using ApiSharp.Models;
using Bybit.Api.CryptoLoan;
using Bybit.Api.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.CryptoLoan;

public class CryptoLoanJsonTests
{
    [Fact]
    public void CommonResponses_MapCurrentDocumentShapes()
    {
        var borrowable = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanBorrowableCoin>>("borrowable-coins.json");
        var collateral = DeserializeResult<BybitCryptoLoanCollateralData>("collateral-coins.json");
        var adjustments = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanCollateralAdjustment>>("adjustment-history.json");
        var position = DeserializeResult<BybitCryptoLoanPosition>("position.json");
        var maxLoan = DeserializeResult<BybitCryptoLoanMaxLoanAmount>("max-loan-amount.json");

        var coin = Assert.Single(borrowable.List);
        Assert.Equal("ETH", coin.Currency);
        Assert.True(coin.FixedBorrowable);
        Assert.Equal(6, coin.FixedBorrowingAccuracy);
        Assert.Equal(1100m, coin.MaxBorrowingAmount);
        Assert.Equal(0.08m, coin.AnnualizedInterestRate14D);
        Assert.Null(coin.AnnualizedInterestRate7D);
        Assert.Equal(0.001429799316m, coin.FlexibleAnnualizedInterestRate);

        var tier = collateral.CollateralRatioConfigList[0].CollateralRatioList[1];
        Assert.Equal("ATOM,AAVE,BTC,BOB", collateral.CollateralRatioConfigList[0].Currencies);
        Assert.Equal(0.7m, tier.CollateralRatio);
        Assert.Equal(1, Assert.Single(collateral.CurrencyLiquidationList).LiquidationOrder);

        var adjustment = Assert.Single(adjustments.List);
        Assert.Equal("27491", adjustments.NextPageCursor);
        Assert.Equal(27511L, adjustment.AdjustId);
        Assert.Equal(0.813743m, adjustment.AfterLtv);
        Assert.Equal(BybitCryptoLoanAdjustmentDirection.ReduceCollateral, adjustment.Direction);
        Assert.Equal(BybitCryptoLoanOperationStatus.Success, adjustment.Status);

        Assert.Equal(0.524344m, position.Ltv);
        Assert.Equal(0.0000001361462m, Assert.Single(position.BorrowList).FlexibleHourlyInterestRate);
        Assert.Equal(9930.11m, Assert.Single(position.CollateralList).AmountUsd);
        Assert.Equal(800.13041095890410959m, Assert.Single(position.SupplyList).Amount);
        Assert.Equal(18381.41m, position.TotalCollateral);

        Assert.Equal("BTC", maxLoan.Currency);
        Assert.Equal(0.1722m, maxLoan.MaxLoan);
        Assert.Equal(16456.06m, maxLoan.NotionalUsd);
        Assert.Equal(9999999.9421m, maxLoan.RemainingQuota);
    }

    [Fact]
    public void FlexibleResponses_MapCurrentDocumentShapes()
    {
        var loans = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFlexibleLoan>>("flexible-loans.json");
        var borrows = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFlexibleBorrow>>("flexible-borrow-history.json");
        var repayments = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFlexibleRepayment>>("flexible-repayment-history.json");

        var loan = Assert.Single(loans.List);
        Assert.Equal("ETH", loan.LoanCurrency);
        Assert.Equal(0.0000018847396m, loan.HourlyInterestRate);
        Assert.Equal(0.10000019m, loan.TotalDebt);

        var borrow = Assert.Single(borrows.List);
        Assert.Equal("1363", borrows.NextPageCursor);
        Assert.Equal("1364", borrow.OrderId);
        Assert.Equal(1752569950643L, borrow.BorrowTime);
        Assert.Equal(0.006m, borrow.InitialLoanAmount);
        Assert.Equal(BybitCryptoLoanOperationStatus.Success, borrow.Status);

        var repayment = Assert.Single(repayments.List);
        Assert.Equal("1769", repayments.NextPageCursor);
        Assert.Equal("1773", repayment.RepayId);
        Assert.Equal(0.007m, repayment.RepayAmount);
        Assert.Equal(BybitCryptoLoanRepayType.User, repayment.RepayType);
    }

    [Fact]
    public void FixedResponses_MapCurrentDocumentShapes()
    {
        var market = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedMarketQuote>>("fixed-market-quote.json");
        var borrowContracts = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedBorrowContract>>("fixed-borrow-contract.json");
        var supplyContracts = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedSupplyContract>>("fixed-supply-contract.json");
        var borrowOrders = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedBorrowOrder>>("fixed-borrow-order.json");
        var supplyOrders = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedSupplyOrder>>("fixed-supply-order.json");
        var renewOrders = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedRenewOrder>>("fixed-renew-order.json");
        var repayments = DeserializeResult<CryptoLoanListResult<BybitCryptoLoanFixedRepayment>>("fixed-repayment-history.json");

        var quote = Assert.Single(market.List);
        Assert.Equal("USDT", quote.OrderCurrency);
        Assert.Equal(14, quote.Term);
        Assert.Equal(0.04m, quote.AnnualRate);
        Assert.Equal(988.78m, quote.Quantity);

        var borrowContract = Assert.Single(borrowContracts.List);
        Assert.Equal("568", borrowContracts.NextPageCursor);
        Assert.True(borrowContract.AutoRepay);
        Assert.Equal("571", borrowContract.LoanId);
        Assert.Equal(1752633756068L, borrowContract.BorrowTime);
        Assert.Equal(0.002531506849315069m, borrowContract.InterestPaid);
        Assert.Equal(BybitFixedBorrowContractStatus.Unrepaid, borrowContract.Status);
        Assert.Equal(BybitFixedBorrowRepayType.AutoRepayment, borrowContract.RepayType);

        var supplyContract = Assert.Single(supplyContracts.List);
        Assert.Equal("567", supplyContracts.NextPageCursor);
        Assert.Equal("567", supplyContract.SupplyId);
        Assert.Equal(0.13041095890410959m, supplyContract.InterestPaid);
        Assert.Equal(1753087596082L, supplyContract.ActualRedemptionTime);
        Assert.Equal(BybitCryptoLoanSupplyContractStatus.Supplying, supplyContract.Status);

        var borrowOrder = Assert.Single(borrowOrders.List);
        Assert.Equal(13010L, borrowOrder.OrderId);
        Assert.Equal(1752654035179L, borrowOrder.OrderTime);
        Assert.Equal(BybitCryptoLoanFixedOrderState.Matching, borrowOrder.State);
        Assert.Equal(BybitFixedBorrowRepayType.TransferToFlexibleLoan, borrowOrder.RepayType);

        var supplyOrder = Assert.Single(supplyOrders.List);
        Assert.Equal(13564L, supplyOrder.OrderId);
        Assert.Equal(800m, supplyOrder.FilledQty);
        Assert.Equal(BybitCryptoLoanFixedOrderState.PartiallyFilledAndCancelled, supplyOrder.State);

        var renew = Assert.Single(renewOrders.List);
        Assert.Equal(49L, renew.OrderId);
        Assert.Equal("2092164378648656896", renew.ContractNo);
        Assert.Equal(BybitFixedBorrowRepayType.TransferToFlexibleLoan, renew.AutoRepay);
        Assert.Equal(1764142142913L, renew.Time);

        var repayment = Assert.Single(repayments.List);
        Assert.Equal("1674", repayments.NextPageCursor);
        Assert.Equal("1782", repayment.RepayId);
        Assert.Equal(1.5m, repayment.RepayAmount);
        Assert.Equal(BybitCryptoLoanRepayType.User, repayment.RepayType);
        Assert.Equal(1.4m, repayment.Details[1].RepayAmount);
    }

    [Fact]
    public void Requests_SerializeStringNumericsAndMappedEnums()
    {
        var collateral = new BybitCryptoLoanCollateralRequestItem("USDT", 1000m);
        var maxLoan = new BybitCryptoLoanMaxLoanAmountRequest("BTC")
        {
            CollateralList = [new BybitCryptoLoanMaxLoanCollateralRequestItem("XRP", 1000m)],
        };
        var flexibleBorrow = new BybitCryptoLoanFlexibleBorrowRequest("BTC", 0.1m)
        {
            CollateralList = [collateral],
        };
        var fixedBorrow = new BybitCryptoLoanFixedBorrowRequest("ETH", 1.5m, 0.022m, 30)
        {
            AutoRepay = true,
            RepayType = BybitFixedBorrowRepayType.TransferToFlexibleLoan,
            CollateralList = [new BybitCryptoLoanCollateralRequestItem("BTC", 0.1m)],
        };
        var fixedMarket = new BybitCryptoLoanFixedMarketRequest("USDT", BybitFixedBorrowOrderBy.AnnualRate)
        {
            Term = 7,
            Sort = BybitSortDirection.Descending,
            Limit = 10,
        };

        var maxLoanJson = Serialize(maxLoan);
        var flexibleBorrowJson = Serialize(flexibleBorrow);
        var fixedBorrowJson = Serialize(fixedBorrow);
        var fixedMarketJson = Serialize(fixedMarket);

        Assert.Equal("XRP", maxLoanJson["collateralList"]![0]!["ccy"]!.Value<string>());
        Assert.Equal("1000", maxLoanJson["collateralList"]![0]!["amount"]!.Value<string>());

        Assert.Equal("0.1", flexibleBorrowJson["loanAmount"]!.Value<string>());
        Assert.Equal("1000", flexibleBorrowJson["collateralList"]![0]!["amount"]!.Value<string>());

        Assert.Equal("1.5", fixedBorrowJson["orderAmount"]!.Value<string>());
        Assert.Equal("0.022", fixedBorrowJson["annualRate"]!.Value<string>());
        Assert.Equal("30", fixedBorrowJson["term"]!.Value<string>());
        Assert.Equal("true", fixedBorrowJson["autoRepay"]!.Value<string>());
        Assert.Equal("2", fixedBorrowJson["repayType"]!.Value<string>());
        Assert.Equal("0.1", fixedBorrowJson["collateralList"]![0]!["amount"]!.Value<string>());

        Assert.Equal("apy", fixedMarketJson["orderBy"]!.Value<string>());
        Assert.Equal("7", fixedMarketJson["term"]!.Value<string>());
        Assert.Equal("1", fixedMarketJson["sort"]!.Value<string>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();
        var tooManyCollateralItems = Enumerable.Range(0, 101)
            .Select(x => new BybitCryptoLoanCollateralRequestItem("USDT", x + 1m))
            .ToList();

        await Assert.ThrowsAsync<ArgumentException>(() => client.CryptoLoan.BorrowFlexibleAsync("BTC", 0.1m, tooManyCollateralItems));
        await Assert.ThrowsAsync<ArgumentException>(() => client.CryptoLoan.GetFixedBorrowOrdersAsync(limit: 101));
        await Assert.ThrowsAsync<ArgumentException>(() => client.CryptoLoan.RepayFixedAsync());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "CryptoLoan", "Json", fileName);
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

    private sealed record CryptoLoanListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }
}
