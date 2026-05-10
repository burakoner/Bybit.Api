using ApiSharp.Models;
using Bybit.Api.BybitCard;
using Bybit.Api.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.BybitCard;

public class BybitCardJsonTests
{
    [Fact]
    public void CardAssetRecords_MapDocumentShape()
    {
        var result = DeserializeResult<BybitCardPage<BybitCardAssetRecord>>("asset-records.json");
        var record = Assert.Single(result.Data);

        Assert.Equal(100, result.PageSize);
        Assert.Equal(1, result.PageNo);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal("1234", record.Pan4);
        Assert.Equal(BybitCardTradeStatus.Completed, record.TradeStatus);
        Assert.Equal(BybitCardTransactionSide.Transaction, record.Side);
        Assert.Equal(101.50m, record.BasicAmount);
        Assert.Equal(1672211918471L, record.TxnCreate);
        Assert.Equal("TXN20230101001", record.TxnId);
        Assert.Equal(100001L, record.Uid);
        Assert.Null(record.FxPad);
        Assert.Equal(0.50m, record.InterchangeFee);
        Assert.Equal(BybitCardTransactionStatus.Success, record.Status);
        Assert.Equal("5411", record.MccCode);
    }

    [Fact]
    public void CardPointResponses_MapDocumentShapes()
    {
        var balance = DeserializeResult<BybitCardPointBalance>("point-balance.json");
        var records = DeserializeResult<BybitCardPage<BybitCardPointRecord>>("point-records.json");
        var tier = DeserializeResult<BybitCardTierInfo>("tier-info.json");
        var cashback = DeserializeResult<BybitCardCashbackDetail>("cashback-detail.json");

        Assert.Equal("100001", balance.AccountId);
        Assert.Equal(5000L, balance.AvailablePoint);
        Assert.Equal(200L, balance.PendingPoint);
        Assert.Equal("active", balance.Status);
        Assert.Equal(1672211918471L, balance.UpdateTimestamp);
        Assert.Equal(30, balance.SettlementPeriod);

        var pointRecord = Assert.Single(records.Data);
        Assert.Equal(10, records.PageSize);
        Assert.Equal(50, records.TotalCount);
        Assert.Equal(100L, pointRecord.Point);
        Assert.Equal(BybitCardPointSide.Earn, pointRecord.Side);
        Assert.Equal("BIZ20230101001", pointRecord.BusinessId);
        Assert.Equal("TXN20230101001", pointRecord.BusinessTransactionId);
        Assert.Equal(100m, pointRecord.TransactionAmount);
        Assert.Equal(0m, pointRecord.PayFiatAmount);

        Assert.Equal(10m, tier.UsedLimit);
        Assert.Equal(500m, tier.Limit);
        Assert.Equal("1", tier.Unit);
        Assert.Equal("GOLD", tier.Tier);
        Assert.True(tier.AutoCashback);

        Assert.Equal(500L, cashback.Points);
        Assert.Equal(1m, cashback.Amount);
        Assert.Equal("USDT", cashback.Currency);
        Assert.Equal(BybitCardCashbackCurrencyType.Crypto, cashback.CurrencyType);
        Assert.Equal(12345L, cashback.SourceId);
        Assert.Equal(BybitCardCashbackOrderShowStatus.Success, cashback.OrderShowStatus);
    }

    [Fact]
    public void CardMallItems_MapDocumentShape()
    {
        var result = DeserializeResult<BybitCardPage<BybitCardMallItem>>("mall-items.json");
        var item = Assert.Single(result.Data);

        Assert.Equal(1, result.PageNo);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(5, result.TotalCount);
        Assert.Equal("ITEM001", item.ItemId);
        Assert.Equal(1, item.Priority);
        Assert.Equal(1672211918471L, item.OnTimestamp);
        Assert.Equal(1704000000000L, item.OffTimestamp);
        Assert.Equal(5000m, item.Price);
        Assert.Equal(4500m, item.DiscountPrice);
        Assert.Equal(1000, item.TotalNum);
        Assert.Equal(200, item.RedeemNum);
        Assert.Equal(BybitCardMallCurrencyType.Point, item.CurrencyType);
        Assert.Equal(BybitCardMallItemType.Virtual, item.ItemType);
        Assert.Equal(BybitCardMallItemBizType.Points, item.ItemBizType);
    }

    [Fact]
    public void Requests_SerializeMappedEnumsAndFilters()
    {
        var assetRecords = Serialize(new BybitCardAssetRecordsRequest
        {
            StatusCode = BybitCardAssetRecordStatusCode.Cleared,
            Limit = 10,
            Page = 1,
            Type = BybitCardAssetRecordQueryType.Financial,
            MerchantName = "Amazon",
        });
        var pointRecords = Serialize(new BybitCardPointRecordsRequest
        {
            PageSize = 10,
            PageNo = 1,
            Side = BybitCardPointSide.Earn,
        });
        var mallItems = Serialize(new BybitCardMallItemsRequest
        {
            PageNo = 1,
            PageSize = 10,
            ItemType = BybitCardMallItemType.Virtual,
            ItemBusinessType = BybitCardMallItemBizType.Points,
            OrderBy = BybitCardMallOrderBy.Price,
            Ascending = true,
            Source = BybitCardMallSource.Vip,
        });
        var cashback = Serialize(new BybitCardCashbackDetailRequest("TXN20230101001"));

        Assert.Equal("1", assetRecords["statusCode"]!.Value<string>());
        Assert.Equal("SIDE_QUERY_FINANCIAL", assetRecords["type"]!.Value<string>());
        Assert.Equal("Amazon", assetRecords["merchName"]!.Value<string>());

        Assert.Equal("1", pointRecords["side"]!.Value<string>());
        Assert.Equal(10, pointRecords["pageSize"]!.Value<int>());

        Assert.Equal("1", mallItems["itemType"]!.Value<string>());
        Assert.Equal("1", mallItems["itemBizType"]!.Value<string>());
        Assert.Equal("3", mallItems["orderBy"]!.Value<string>());
        Assert.True(mallItems["asc"]!.Value<bool>());
        Assert.Equal("1", mallItems["source"]!.Value<string>());

        Assert.Equal("TXN20230101001", cashback["bizTxnId"]!.Value<string>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetAssetRecordsAsync(limit: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetAssetRecordsAsync(limit: 501));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetAssetRecordsAsync(page: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetPointRecordsAsync(pageSize: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetPointRecordsAsync(pageNo: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetMallItemsAsync(pageNo: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetMallItemsAsync(pageSize: 0));
        await Assert.ThrowsAsync<ArgumentException>(() => client.BybitCard.GetCashbackDetailAsync(""));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "BybitCard", "Json", fileName);
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
