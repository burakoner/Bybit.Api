using Bybit.Api.Common;

namespace Bybit.Api.Tests.Margin;

public class MarginPublicEndpointTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task PublicSpotMarginEndpoints_ReturnLiveData()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));
        var client = new BybitRestApiClient();

        var vipData = await client.Margin.GetVipMarginDataAsync(ct: cts.Token);
        AssertSuccess(vipData);
        Assert.NotEmpty(vipData.Data!);
        Assert.Contains(vipData.Data, x => x.List.Count > 0);

        var collateralRatios = await client.Margin.GetTieredCollateralRatiosAsync(ct: cts.Token);
        AssertSuccess(collateralRatios);
        Assert.NotEmpty(collateralRatios.Data!);
        Assert.Contains(collateralRatios.Data, x => x.CollateralRatioList.Count > 0);
    }

    private static void AssertSuccess<T>(BybitRestCallResult<T> result)
    {
        Assert.True(result.Success, result.Error?.ToString());
        Assert.NotNull(result.Data);
    }
}
