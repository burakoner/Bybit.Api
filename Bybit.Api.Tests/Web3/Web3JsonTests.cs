using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Web3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Web3;

public class Web3JsonTests
{
    [Fact]
    public void TradeQuote_MapsDocumentShape()
    {
        var quote = DeserializeResult<BybitWeb3TradeQuote>("trade-quote.json");
        var pricePriority = quote.ModeEstimations[0];

        Assert.Equal(BybitWeb3TradeType.Purchase, quote.TradeType);
        Assert.Equal("CEX_1", quote.FromTokenCode);
        Assert.Equal(100m, quote.FromTokenAmount);
        Assert.Equal(100m, quote.FromTokenAmountUsd);
        Assert.Equal(12_500_000m, quote.ToTokenAmount);
        Assert.Equal(0.005m, quote.Slippage);
        Assert.Equal(0.0003m, quote.Gas);
        Assert.Equal(0.20m, quote.PlatformFee);
        Assert.Equal(BybitWeb3QuoteMode.Auto, quote.QuoteMode);
        Assert.Equal("QD_20240101_001", quote.QuoteDataId);
        Assert.Equal(1704067230000L, quote.ExpireTime);
        Assert.Equal(BybitWeb3QuoteMode.PricePriority, pricePriority.QuoteMode);
        Assert.Equal(12_600_000m, pricePriority.EstimatedGas);
    }

    [Fact]
    public void TradeExecutionResponses_MapDocumentShapes()
    {
        var purchase = DeserializeResult<BybitWeb3TradeExecution>("purchase.json");
        var redeem = DeserializeResult<BybitWeb3TradeExecution>("redeem.json");

        Assert.Equal("ORD_20240101_001", purchase.OrderNo);
        Assert.Equal("ORD_20240101_002", redeem.OrderNo);
    }

    [Fact]
    public void TokenResponses_MapDocumentShapes()
    {
        var paymentTokens = DeserializeResult<List<BybitWeb3PaymentToken>>("payment-token-list.json");
        var bizTokens = DeserializeResult<List<BybitWeb3BizToken>>("biz-token-list.json");
        var prices = DeserializeResult<BybitWeb3TokenPriceList>("token-price-list.json");
        var details = DeserializeResult<BybitWeb3TokenDetails>("token-details.json");

        var payment = paymentTokens[0];
        Assert.Equal("CEX_1", payment.TokenCode);
        Assert.Equal(6, payment.TokenDecimals);
        Assert.Equal(50000m, payment.Limit);
        Assert.Contains("SOL", payment.SupportChains);

        var bizToken = Assert.Single(bizTokens);
        Assert.Equal("DEX_123", bizToken.TokenCode);
        Assert.Equal(BybitWeb3RiskFlag.NoRisk, bizToken.RiskFlag);
        Assert.Equal(1m, bizToken.MinOrderQuantity);
        Assert.Equal(50000m, bizToken.MaxOrderQuantity);
        Assert.Equal(1682000000L, bizToken.CreateTimeOnchain);

        var price = Assert.Single(prices.TokenPriceInfoList);
        Assert.Equal(0.00001m, price.Price);
        Assert.Equal(0.15m, price.Change24h);
        Assert.Equal(250000L, price.Holders);

        Assert.Equal(BybitWeb3TokenTag.OnChainHotToken, details.TokenTag);
        Assert.Equal(BybitWeb3TokenStatus.Listed, details.Status);
        Assert.Equal(BybitWeb3MessageDisplay.Hide, details.ShowMessage);
        Assert.Equal(100000m, details.MaxPositionQuantity);
    }

    [Fact]
    public void OrderAndAssetResponses_MapDocumentShapes()
    {
        var orders = DeserializeResult<BybitWeb3OrderResult>("order-list.json");
        var assetList = DeserializeResult<BybitWeb3AssetList>("asset-list.json");
        var assetDetail = DeserializeResult<BybitWeb3AssetDetail>("asset-detail.json");

        var order = Assert.Single(orders.Orders);
        Assert.Equal(1, orders.Total);
        Assert.Equal(BybitWeb3OrderType.Market, order.OrderType);
        Assert.Equal(BybitWeb3TradeType.Purchase, order.TradeType);
        Assert.Equal(BybitWeb3OrderStatus.Success, order.OrderStatus);
        Assert.Equal(100m, order.FromTokenAmount);
        Assert.Equal(0.0003m, order.GasOnchain);
        Assert.Equal(1704067200L, order.CreateTime);
        Assert.Equal(1704067230L, order.ExecutionTime);

        var asset = Assert.Single(assetList.AssetList);
        Assert.Equal(1250.50m, assetList.TotalAssetUsd);
        Assert.Equal(BybitWeb3TradeFlag.Tradable, asset.TradeFlag);
        Assert.Equal(BybitWeb3AssetStatus.Running, asset.AssetStatus);
        Assert.Equal(75m, asset.Pnl);
        Assert.Equal(0.0000085m, asset.CostPrice);

        var detail = Assert.Single(assetDetail.AssetList);
        Assert.Equal("ETH", detail.ChainCode);
        Assert.Equal(500m, detail.TokenAmountUsd);
    }

    [Fact]
    public void Requests_SerializeDocumentShapes()
    {
        var quote = Serialize(new BybitWeb3TradeQuoteRequest(BybitWeb3TradeType.Purchase, "CEX_1", 100m, "DEX_123")
        {
            QuoteMode = BybitWeb3QuoteMode.Auto,
        });
        var purchase = Serialize(new BybitWeb3PurchaseRequest("CEX_1", 100m, "DEX_123", 0.01m, "quote-data", 0.0003m, BybitWeb3QuoteMode.Auto, "code"));
        var orderList = Serialize(new BybitWeb3OrderListRequest(20, 1)
        {
            TradeType = BybitWeb3TradeType.All,
            OrderStatus = [BybitWeb3OrderStatus.Success, BybitWeb3OrderStatus.Failed],
            Days = 7,
            Direction = BybitWeb3PaginationDirection.Next,
        });
        var priceList = Serialize(new BybitWeb3TokenPriceListRequest([
            new BybitWeb3TokenAddressInfo("ETH", "0x6982508145454ce325ddbe47a25d4ec3d2311933"),
        ]));

        Assert.Equal(1, quote["tradeType"]!.Value<int>());
        Assert.Equal("100", quote["fromTokenAmount"]!.Value<string>());
        Assert.Equal(0, quote["quoteMode"]!.Value<int>());

        Assert.Equal("100", purchase["fromTokenAmount"]!.Value<string>());
        Assert.Equal("0.01", purchase["slippage"]!.Value<string>());
        Assert.Equal("0.0003", purchase["gas"]!.Value<string>());
        Assert.Equal(0, purchase["quoteMode"]!.Value<int>());

        Assert.Equal(0, orderList["tradeType"]!.Value<int>());
        Assert.Equal(20, orderList["limit"]!.Value<int>());
        Assert.Equal(1, orderList["pageIndex"]!.Value<int>());
        Assert.Equal(new[] { 2, 3 }, orderList["orderStatus"]!.Values<int>().ToArray());
        Assert.Equal("next", orderList["direction"]!.Value<string>());

        Assert.Equal("ETH", priceList["tokenAddressInfo"]![0]!["chainCode"]!.Value<string>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetTradeQuoteAsync(BybitWeb3TradeType.All, "CEX_1", 100m, "DEX_123"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetTradeQuoteAsync(BybitWeb3TradeType.Purchase, "CEX_1", 0m, "DEX_123"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.ExecutePurchaseAsync("CEX_1", 100m, "DEX_123", 0.01m, "", 0.0003m, BybitWeb3QuoteMode.Auto, "code"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetPaymentTokensAsync("", "token"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetOrdersAsync(limit: 0, pageIndex: 1));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetOrdersAsync(limit: 101, pageIndex: 1));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetOrdersAsync(limit: 20, pageIndex: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetOrdersAsync(limit: 20, pageIndex: 1, days: 91));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetOrdersAsync(limit: 20, pageIndex: 1, orderStatus: []));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetTokenPricesAsync([]));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetTokenPricesAsync(Enumerable.Range(0, 21).Select(x => new BybitWeb3TokenAddressInfo("ETH", $"0x{x}"))));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetTokenDetailsAsync("ETH", ""));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Web3.GetAssetDetailAsync("", "0xabc"));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Web3", "Json", fileName);
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
}
