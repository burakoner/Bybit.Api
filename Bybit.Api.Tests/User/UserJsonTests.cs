using ApiSharp.Models;
using Bybit.Api.Enums;
using Bybit.Api.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.User;

public class UserJsonTests
{
    [Fact]
    public void SubAccountResponses_MapCurrentUidAndAccountModeShapes()
    {
        var created = DeserializeResult<BybitUserSubAccount>("create-subuid.json");
        var limited = DeserializeResult<SubMembersResult>("subuid-list.json");
        var custodial = DeserializeResult<SubMembersResult>("fund-custodial-subuid-list.json");

        Assert.Equal(53888000L, created.UID);
        Assert.Equal(BybitSubAccountType.NormalSubAccount, created.Type);
        Assert.Equal(BybitSubAccountStatus.Normal, created.Status);
        Assert.Equal("test", created.Label);

        Assert.Equal(BybitAccountMode.UTA2, limited.SubMembers[0].Mode);
        Assert.Equal(BybitAccountMode.UTA2Pro, limited.SubMembers[1].Mode);
        Assert.Equal(BybitSubAccountType.FundCustodialAccount, Assert.Single(custodial.SubMembers).Type);
        Assert.Equal(BybitAccountMode.UTA, custodial.SubMembers[0].Mode);
    }

    [Fact]
    public void ApiKeyResponses_MapCurrentPermissionAndMetadataFields()
    {
        var created = DeserializeResult<BybitUserApiKey>("create-sub-api-key.json");
        var info = DeserializeResult<BybitUserApiKeyInformation>("api-key-info.json");
        var subKeys = DeserializeResult<SubApiKeysResult>("sub-api-keys.json");
        var subKey = Assert.Single(subKeys.Result);

        Assert.Equal("16651283", created.Id);
#pragma warning disable CS0618
        Assert.Equal(16651283L, created.ID);
#pragma warning restore CS0618
        Assert.True(created.ReadOnly);
        Assert.Equal("Earn", Assert.Single(created.Permissions.Earn));

        Assert.Equal("2208369", info.Id);
        Assert.True(info.ReadOnly);
        Assert.Equal("0", info.ParentUid);
        Assert.Equal(21, info.DeadlineDays);
        Assert.Equal("FaitPayOrder", Assert.Single(info.Permissions.FiatBitPay));
        Assert.Empty(info.Permissions.FiatGlobalPay);
        Assert.Equal("BitCard", Assert.Single(info.Permissions.BitCard));
        Assert.Equal("ByXPost", Assert.Single(info.Permissions.ByXPost));
        Assert.Equal(0L, info.UserIdInt64);
        Assert.Equal(0L, info.InviterIdInt64);
        Assert.Equal(0L, info.AffiliateIdInt64);

        Assert.Equal("24828209", subKey.Id);
        Assert.False(subKey.ReadOnly);
        Assert.Equal(3, subKey.Status);
        Assert.Equal(new DateTime(2023, 12, 1, 2, 36, 6, DateTimeKind.Utc), subKey.ExpiredAt);
        Assert.Equal(BybitApiKeyType.Personal, subKey.Type);
        Assert.Equal("hmac", subKey.Flag);
        Assert.Equal("SubMemberTransferList", subKey.Permissions.Wallet[1]);
    }

    [Fact]
    public void WalletTypesAndFriendReferrals_MapCurrentListContainers()
    {
        var wallet = Assert.Single(DeserializeResult<AccountsResult>("wallet-type.json").Accounts);
        var referrals = DeserializeResult<FriendReferralResult>("friend-referrals.json");
        var referral = Assert.Single(referrals.Records);

        Assert.Equal(533285L, wallet.UserId);
        Assert.Contains(BybitAccountType.Unified, wallet.AccountType);
        Assert.Contains(BybitAccountType.Fund, wallet.AccountType);

        Assert.Equal("6866", referral.Id);
        Assert.Equal(1447787L, referral.InviteeUid);
        Assert.Equal(new DateTime(2023, 4, 11, 9, 44, 7, DateTimeKind.Utc), referral.CreatedTime);
        Assert.Equal(referrals.NextCursor, string.Empty);
    }

    [Fact]
    public void UserRequests_SerializeCurrentDocumentShapes()
    {
        var sign = new BybitUserSignAgreementRequest(true) { CategoryV2 = 2 };
        var createSub = new BybitUserCreateSubAccountRequest(BybitSubAccountType.NormalSubAccount, "user01")
        {
            Label = "test",
        };
        var createKey = new BybitUserCreateSubApiKeyRequest(53888000L, false, new BybitUserApiKeyPermissions
        {
            Wallet = ["AccountTransfer"],
            Earn = ["Earn"],
        })
        {
            IpAddresses = "192.168.0.1,192.168.0.2",
            Label = "testxxx",
        };
        var modify = new BybitUserModifySubApiKeyRequest
        {
            ApiKey = "sub-api-key",
            IpAddresses = "*",
            Permissions = new BybitUserApiKeyPermissions
            {
                Spot = ["SpotTrade"],
                FiatBitPay = ["FaitPayOrder"],
            },
        };

        var signJson = JObject.Parse(JsonConvert.SerializeObject(sign, SerializerOptions.WithConverters));
        var subJson = JObject.Parse(JsonConvert.SerializeObject(createSub, SerializerOptions.WithConverters));
        var keyJson = JObject.Parse(JsonConvert.SerializeObject(createKey, SerializerOptions.WithConverters));
        var modifyJson = JObject.Parse(JsonConvert.SerializeObject(modify, SerializerOptions.WithConverters));

        Assert.True(signJson["agree"]!.Value<bool>());
        Assert.Equal(2, signJson["categoryV2"]!.Value<int>());
        Assert.Equal(1, subJson["memberType"]!.Value<int>());
        Assert.False(subJson.ContainsKey("switch"));
        Assert.Equal("192.168.0.1,192.168.0.2", keyJson["ips"]!.Value<string>());
        Assert.Equal("Earn", keyJson["permissions"]!["Earn"]![0]!.Value<string>());
        Assert.Equal("sub-api-key", modifyJson["apikey"]!.Value<string>());
        Assert.Equal("FaitPayOrder", modifyJson["permissions"]!["FiatBitPay"]![0]!.Value<string>());
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "User", "Json", fileName);
        var json = File.ReadAllText(path);
        var result = JObject.Parse(json)["result"];

        Assert.NotNull(result);
        return result!.ToObject<T>(JsonSerializer.Create(SerializerOptions.WithConverters))!;
    }

    private sealed record SubMembersResult
    {
        public List<BybitUserSubAccount> SubMembers { get; set; } = [];
        public string NextCursor { get; set; } = string.Empty;
    }

    private sealed record SubApiKeysResult
    {
        public List<BybitUserApiKey> Result { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }

    private sealed record AccountsResult
    {
        public List<BybitUserWalletType> Accounts { get; set; } = [];
    }

    private sealed record FriendReferralResult
    {
        public string NextCursor { get; set; } = string.Empty;
        public List<BybitUserFriendReferral> Records { get; set; } = [];
    }
}
