using Bybit.Api.Common;
using Bybit.Api.Enums;

namespace Bybit.Api.Tests.Market;

public class MarketPublicEndpointTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task PublicMarketEndpoints_ReturnLiveData()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));
        var client = new BybitRestApiClient();

        var time = await client.Market.GetServerTimeAsync(cts.Token);
        AssertSuccess(time);
        Assert.True(time.Data!.Time > DateTime.UtcNow.AddMinutes(-10));

        var orderbook = await client.Market.GetOrderbookAsync(BybitCategory.Spot, "BTCUSDT", 1, cts.Token);
        AssertSuccess(orderbook);
        Assert.Equal("BTCUSDT", orderbook.Data!.Symbol);
        Assert.NotEmpty(orderbook.Data.Bids);
        Assert.NotEmpty(orderbook.Data.Asks);

        var indexComponents = await client.Market.GetIndexPriceComponentsAsync("BTCUSDT", cts.Token);
        AssertSuccess(indexComponents);
        Assert.Equal("BTCUSDT", indexComponents.Data!.IndexName);
        Assert.NotEmpty(indexComponents.Data.Components);

        var priceLimit = await client.Market.GetOrderPriceLimitAsync(BybitCategory.Linear, "BTCUSDT", cts.Token);
        AssertSuccess(priceLimit);
        Assert.Equal("BTCUSDT", priceLimit.Data!.Symbol);
        Assert.True(priceLimit.Data.BuyLimit > 0);
        Assert.True(priceLimit.Data.SellLimit > 0);

        var adlAlert = await client.Market.GetAdlAlertAsync("BTCUSDT", cts.Token);
        AssertSuccess(adlAlert);
        Assert.NotEmpty(adlAlert.Data!.List);

        var feeGroup = await client.Market.GetFeeGroupInfoAsync("contract", "1", cts.Token);
        AssertSuccess(feeGroup);
        Assert.NotEmpty(feeGroup.Data!.List);
    }

    private static void AssertSuccess<T>(BybitRestCallResult<T> result)
    {
        Assert.True(result.Success, result.Error?.ToString());
        Assert.NotNull(result.Data);
    }
}
