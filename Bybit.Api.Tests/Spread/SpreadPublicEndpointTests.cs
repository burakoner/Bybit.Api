using Bybit.Api.Common;

namespace Bybit.Api.Tests.Spread;

public class SpreadPublicEndpointTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async Task PublicSpreadMarketEndpoints_ReturnLiveData()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));
        var client = new BybitRestApiClient();

        var instruments = await client.Spread.GetInstrumentsAsync(limit: 1, ct: cts.Token);
        AssertSuccess(instruments);

        var instrument = Assert.Single(instruments.Data!);
        Assert.False(string.IsNullOrEmpty(instrument.Symbol));

        var orderbook = await client.Spread.GetOrderbookAsync(instrument.Symbol, 1, cts.Token);
        AssertSuccess(orderbook);
        Assert.Equal(instrument.Symbol, orderbook.Data!.Symbol);
        Assert.NotEmpty(orderbook.Data.Bids);
        Assert.NotEmpty(orderbook.Data.Asks);

        var tickers = await client.Spread.GetTickersAsync(instrument.Symbol, cts.Token);
        AssertSuccess(tickers);
        Assert.Equal(instrument.Symbol, Assert.Single(tickers.Data!).Symbol);

        var trades = await client.Spread.GetRecentTradesAsync(instrument.Symbol, 1, cts.Token);
        AssertSuccess(trades);
        Assert.Equal(instrument.Symbol, Assert.Single(trades.Data!).Symbol);
    }

    private static void AssertSuccess<T>(BybitRestCallResult<T> result)
    {
        Assert.True(result.Success, result.Error?.ToString());
        Assert.NotNull(result.Data);
    }
}
