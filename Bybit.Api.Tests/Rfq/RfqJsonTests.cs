using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.Rfq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Rfq;

public class RfqJsonTests
{
    [Fact]
    public void ConfigurationAndCommandResponses_MapCurrentDocumentShapes()
    {
        var config = DeserializeResult<BybitRfqConfig>("config.json");
        var created = DeserializeResult<BybitRfqCreateResult>("create-rfq.json");
        var canceled = DeserializeResult<BybitRfqId>("cancel-rfq.json");
        var cancelAll = DeserializeResult<List<BybitRfqCancelAllResult>>("cancel-all-rfq.json");
        var accepted = DeserializeResult<BybitRfqId>("accept-other-quote.json");
        var quote = DeserializeResult<BybitRfqQuoteResult>("create-quote.json");
        var executed = DeserializeResult<BybitRfqExecuteQuoteResult>("execute-quote.json");
        var canceledQuote = DeserializeResult<BybitRfqQuoteCancelResult>("cancel-quote.json");
        var cancelAllQuotes = DeserializeResult<List<BybitRfqQuoteCancelAllResult>>("cancel-all-quotes.json");

        Assert.Equal("1nu9d1", config.DeskCode);
        Assert.Equal(25, config.MaxLegs);
        Assert.Equal(50, config.MaxLiquidityProviders);
        Assert.Equal(10m, config.MinLimitQtySpotOrder);
        Assert.Equal("FundingRate", config.StrategyTypes[1].StrategyName);
        Assert.Equal("LP", config.Counterparties[0].Type);
        Assert.Null(config.Counterparties[1].Type);

        Assert.Equal("17526315514105706281", created.RfqId);
        Assert.Equal(BybitRfqStatus.Active, created.Status);
        Assert.Equal(1752632151414L, created.ExpiresAt);
        Assert.Equal("LP2", created.DeskCode);

        Assert.Equal("1756871488168105512459181956436945", canceled.RfqId);
        Assert.Equal("175766967076315412093641573648082", Assert.Single(cancelAll).RfqId);
        Assert.Equal(0, Assert.Single(cancelAll).Code);
        Assert.Equal("1754364447601610516653123084412812", accepted.RfqId);

        Assert.Equal("1757405933130044334361923221559805", quote.QuoteId);
        Assert.Equal(BybitRfqStatus.Active, quote.Status);
        Assert.Equal(1757405993126L, quote.ExpiresAt);

        Assert.Equal(BybitRfqStatus.PendingFill, executed.Status);
        Assert.Equal("1757407015586174663206671159484665", executed.QuoteId);

        Assert.Equal("1757407443083427576602342578477746", canceledQuote.QuoteId);
        Assert.Equal(0, Assert.Single(cancelAllQuotes).Code);
    }

    [Fact]
    public void QueryResponses_MapCurrentDocumentShapes()
    {
        var realtimeRfqs = DeserializeResult<RfqListResult<BybitRfqInfo>>("rfq-realtime.json");
        var historicalRfqs = DeserializeResult<RfqListResult<BybitRfqInfo>>("rfq-list.json");
        var realtimeQuotes = DeserializeResult<RfqListResult<BybitRfqQuote>>("quote-realtime.json");
        var historicalQuotes = DeserializeResult<RfqListResult<BybitRfqQuote>>("quote-list.json");
        var trades = DeserializeResult<RfqListResult<BybitRfqTrade>>("trade-list.json");
        var publicTrades = DeserializeResult<RfqListResult<BybitRfqPublicTrade>>("public-trades.json");

        var realtimeRfq = Assert.Single(realtimeRfqs.List);
        Assert.Equal("1756885055799241492396882271696580", realtimeRfq.RfqId);
        Assert.False(realtimeRfq.AcceptOtherQuote);
        Assert.Equal(BybitRfqStatus.Active, realtimeRfq.Status);
        Assert.Equal(BybitCategory.Linear, Assert.Single(realtimeRfq.Legs).Category);
        Assert.Equal(1m, Assert.Single(realtimeRfq.Legs).Quantity);

        var historicalRfq = Assert.Single(historicalRfqs.List);
        Assert.Equal("page_token%3D14912", historicalRfqs.Cursor);
        Assert.True(historicalRfq.AcceptOtherQuote);
        Assert.Equal(BybitRfqStatus.Expired, historicalRfq.Status);
        Assert.Equal(1756874158985L, historicalRfq.CreatedAt);

        var realtimeQuote = Assert.Single(realtimeQuotes.List);
        Assert.Equal(string.Empty, realtimeQuote.ExecQuoteSide);
        Assert.Equal(113790m, Assert.Single(realtimeQuote.QuoteBuyList).Price);
        Assert.Equal(0.5m, Assert.Single(realtimeQuote.QuoteSellList).Quantity);

        var historicalQuote = Assert.Single(historicalQuotes.List);
        Assert.Equal(BybitRfqStatus.Expired, historicalQuote.Status);
        Assert.Equal(1757405999156L, historicalQuote.UpdatedAt);

        var trade = Assert.Single(trades.List);
        Assert.Equal(BybitOrderSide.Buy, trade.QuoteSide);
        Assert.Equal(BybitRfqStatus.Failed, trade.Status);
        Assert.Equal("PerpBasis", trade.StrategyType);
        Assert.Null(trade.Legs[0].MarkPrice);
        Assert.Equal(111002, trade.Legs[0].ResultCode);
        Assert.Equal("taker", trade.Legs[1].RejectParty);

        var publicTrade = Assert.Single(publicTrades.List);
        Assert.Equal("page_token%3D14912%26last_time%3D1756826273947000000%26", publicTrades.Cursor);
        Assert.Equal(BybitCategory.Spot, Assert.Single(publicTrade.Legs).Category);
        Assert.Equal(100000m, Assert.Single(publicTrade.Legs).Price);
        Assert.Equal(110320m, Assert.Single(publicTrade.Legs).MarkPrice);
    }

    [Fact]
    public void Requests_SerializeStringNumericsAndMappedEnums()
    {
        var createRfq = new BybitRfqCreateRequest(["LP4", "LP5"], [
            new BybitRfqLegRequest(BybitCategory.Linear, "BTCUSDT", BybitOrderSide.Buy, 2m),
        ])
        {
            RfqLinkId = "rfq00993",
            Anonymous = false,
            StrategyType = "custom",
        };
        var createQuote = new BybitRfqCreateQuoteRequest("1754364447601610516653123084412812")
        {
            QuoteLinkId = "quote00993",
            Anonymous = true,
            ExpireIn = 60,
            QuoteBuyList = [new BybitRfqQuoteLegRequest(BybitCategory.Linear, "BTCUSDT", 106000m)],
            QuoteSellList = [new BybitRfqQuoteLegRequest(BybitCategory.Linear, "BTCUSDT", 126500m)],
        };
        var executeQuote = new BybitRfqExecuteQuoteRequest("1754364447601610516653123084412812", "111", BybitOrderSide.Buy);
        var cancelQuote = new BybitRfqCancelQuoteRequest
        {
            QuoteLinkId = "quote00993",
        };

        var createRfqJson = Serialize(createRfq);
        var createQuoteJson = Serialize(createQuote);
        var executeQuoteJson = Serialize(executeQuote);
        var cancelQuoteJson = Serialize(cancelQuote);

        Assert.Equal("LP4", createRfqJson["counterparties"]![0]!.Value<string>());
        Assert.Equal("linear", createRfqJson["list"]![0]!["category"]!.Value<string>());
        Assert.Equal("Buy", createRfqJson["list"]![0]!["side"]!.Value<string>());
        Assert.Equal("2", createRfqJson["list"]![0]!["qty"]!.Value<string>());
        Assert.False(createRfqJson["anonymous"]!.Value<bool>());

        Assert.Equal("quote00993", createQuoteJson["quoteLinkId"]!.Value<string>());
        Assert.True(createQuoteJson["anonymous"]!.Value<bool>());
        Assert.Equal(60, createQuoteJson["expireIn"]!.Value<int>());
        Assert.Equal("106000", createQuoteJson["quoteBuyList"]![0]!["price"]!.Value<string>());
        Assert.Equal("126500", createQuoteJson["quoteSellList"]![0]!["price"]!.Value<string>());

        Assert.Equal("Buy", executeQuoteJson["quoteSide"]!.Value<string>());
        Assert.Equal("quote00993", cancelQuoteJson["quoteLinkId"]!.Value<string>());
        Assert.False(cancelQuoteJson.ContainsKey("quoteId"));
        Assert.False(cancelQuoteJson.ContainsKey("rfqId"));
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.Rfq.CancelRfqAsync());
        await Assert.ThrowsAsync<ArgumentException>(() => client.Rfq.CancelQuoteAsync());
        await Assert.ThrowsAsync<ArgumentException>(() => client.Rfq.CreateQuoteAsync("rfq-id"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Rfq.GetRfqsAsync(limit: 101));
        await Assert.ThrowsAsync<NotSupportedException>(() => client.Rfq.CreateRfqAsync(["LP4"], [
            new BybitRfqLegRequest(BybitCategory.Inverse, "BTCUSD", BybitOrderSide.Buy, 1m),
        ]));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Rfq", "Json", fileName);
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

    private sealed record RfqListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string Cursor { get; set; } = string.Empty;
    }
}
