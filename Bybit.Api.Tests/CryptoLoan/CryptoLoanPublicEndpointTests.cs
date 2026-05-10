using Bybit.Api.Common;
using Bybit.Api.Enums;

namespace Bybit.Api.Tests.CryptoLoan;

public class CryptoLoanPublicEndpointTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task PublicCryptoLoanEndpoints_ReturnLiveData()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));
        var client = new BybitRestApiClient();

        var borrowableCoins = await client.CryptoLoan.GetBorrowableCoinsAsync(currency: "BTC", ct: cts.Token);
        AssertSuccess(borrowableCoins);
        Assert.NotEmpty(borrowableCoins.Data!);
        Assert.Contains(borrowableCoins.Data!, x => x.Currency == "BTC");

        var collateralCoins = await client.CryptoLoan.GetCollateralCoinsAsync(currency: "BTC", ct: cts.Token);
        AssertSuccess(collateralCoins);
        Assert.NotEmpty(collateralCoins.Data!.CollateralRatioConfigList);

        var lendingMarket = await client.CryptoLoan.GetFixedLendingMarketAsync("USDT", BybitFixedBorrowOrderBy.AnnualRate, limit: 1, ct: cts.Token);
        AssertSuccess(lendingMarket);

        var borrowingMarket = await client.CryptoLoan.GetFixedBorrowingMarketAsync("USDT", BybitFixedBorrowOrderBy.AnnualRate, limit: 1, ct: cts.Token);
        AssertSuccess(borrowingMarket);
    }

    private static void AssertSuccess<T>(BybitRestCallResult<T> result)
    {
        Assert.True(result.Success, result.Error?.ToString());
        Assert.NotNull(result.Data);
    }
}
