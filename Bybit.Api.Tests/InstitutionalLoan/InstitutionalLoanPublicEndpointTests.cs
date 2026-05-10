using Bybit.Api.Common;

namespace Bybit.Api.Tests.InstitutionalLoan;

public class InstitutionalLoanPublicEndpointTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task PublicInstitutionalLoanEndpoints_ReturnLiveData()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));
        var client = new BybitRestApiClient();

        var products = await client.InstitutionalLoan.GetProductsAsync(ct: cts.Token);
        AssertSuccess(products);
        Assert.NotEmpty(products.Data!);

        var marginCoins = await client.InstitutionalLoan.GetMarginCoinsAsync(ct: cts.Token);
        AssertSuccess(marginCoins);
        Assert.NotEmpty(marginCoins.Data!);
    }

    private static void AssertSuccess<T>(BybitRestCallResult<T> result)
    {
        Assert.True(result.Success, result.Error?.ToString());
        Assert.NotNull(result.Data);
    }
}
