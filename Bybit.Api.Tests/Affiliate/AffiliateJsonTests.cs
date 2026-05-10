using ApiSharp.Models;
using Bybit.Api.Affiliate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Affiliate;

public class AffiliateJsonTests
{
    [Fact]
    public void UserList_MapsCurrentDocumentShape()
    {
        var result = DeserializeResult<AffiliateListResult<BybitAffiliateUser>>("user-list.json");

        Assert.Equal("16197", result.NextPageCursor);
        Assert.Equal(2, result.List.Count);

        var first = result.List[0];
        Assert.Equal(103895898L, first.UserId);
        Assert.Equal("2024-10-29", first.RegisterTime);
        Assert.True(first.IsKyc);
        Assert.Equal(12861.362976m, first.TakerVol30Day);
        Assert.Equal(262.60865m, first.MakerVol30Day);
        Assert.Null(first.DepositAmount30Day);
        Assert.Equal(194231.4175m, first.TakerVol);
        Assert.Equal(0.00835765m, first.CommissionsVol["USDT"]);
        Assert.Equal(0.00000002m, first.Commissions365Day["BTC"]);

        var second = result.List[1];
        Assert.Equal(1547321L, second.UserId);
        Assert.False(second.IsKyc);
        Assert.Null(second.TakerVol30Day);
        Assert.Equal(222360.70498115m, second.TradeVol365Day);
        Assert.Equal(2.35583601m, second.CommissionsVol["MNT"]);
    }

    [Fact]
    public void UserInfo_MapsCurrentDocumentShape()
    {
        var info = DeserializeResult<BybitAffiliateUserInfo>("user-info.json");

        Assert.Equal(1087997L, info.Uid);
        Assert.Equal("5", info.VipLevel);
        Assert.Equal(17061.64983m, info.TakerVol30Day);
        Assert.Equal(1228101.96738934m, info.TradeVol365Day);
        Assert.Equal(4, info.TotalWalletBalance);
        Assert.Equal("2026-02-04 00:00:00", info.DepositUpdateTime);
        Assert.Equal(0, info.KycLevel);
        Assert.Equal(1828890.6352m, info.TradfiTradeVol30Day);
        Assert.Null(info.Commissions30Day["BTC"]);
        Assert.Equal(17.0461748m, info.Commissions30Day["USDT"]);
        Assert.Equal(130.48078429m, info.Commissions365Day["USDT"]);
    }

    [Fact]
    public void Requests_SerializeCurrentDocumentShape()
    {
        var list = new BybitAffiliateUserListRequest
        {
            Size = 2,
            Cursor = "0",
            Need365Day = true,
            Need30Day = true,
            NeedDeposit = true,
            StartDate = "2025-10-21",
            EndDate = "2025-10-22",
        };
        var info = new BybitAffiliateUserInfoRequest(1_513_500L);

        var listJson = JObject.Parse(JsonConvert.SerializeObject(list, SerializerOptions.WithConverters));
        var infoJson = JObject.Parse(JsonConvert.SerializeObject(info, SerializerOptions.WithConverters));

        Assert.Equal(2, listJson["size"]!.Value<int>());
        Assert.Equal("0", listJson["cursor"]!.Value<string>());
        Assert.True(listJson["need365"]!.Value<bool>());
        Assert.True(listJson["need30"]!.Value<bool>());
        Assert.True(listJson["needDeposit"]!.Value<bool>());
        Assert.Equal("2025-10-21", listJson["startDate"]!.Value<string>());
        Assert.Equal("2025-10-22", listJson["endDate"]!.Value<string>());
        Assert.Equal(1_513_500L, infoJson["uid"]!.Value<long>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.Affiliate.GetUsersAsync(size: 1001));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Affiliate", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record AffiliateListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }
}
