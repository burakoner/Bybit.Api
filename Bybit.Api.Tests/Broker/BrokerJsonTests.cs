using ApiSharp.Models;
using Bybit.Api.Broker;
using Bybit.Api.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bybit.Api.Tests.Broker;

public class BrokerJsonTests
{
    [Fact]
    public void ExchangeBrokerResponses_MapCurrentDocumentShapes()
    {
        var earnings = DeserializeResult<BybitBrokerEarnings>("earnings.json");
        var account = DeserializeResult<BybitBrokerAccountInfo>("account-info.json");
        var deposits = DeserializeResult<RowsResult<BybitBrokerSubAccountDeposit>>("sub-deposit-records.json");

        var derivativeTotal = Assert.Single(earnings.TotalEarningCat.Derivatives);
        Assert.Equal("USDT", derivativeTotal.Coin);
        Assert.Equal(0.00027844m, derivativeTotal.Earning);

        var detail = Assert.Single(earnings.Details);
        Assert.Equal(117894077L, detail.UserId);
        Assert.Equal(BybitBrokerBusinessType.Derivatives, detail.BusinessType);
        Assert.Equal(0.000032332m, detail.MarkupEarning);
        Assert.Equal("ec2132f2-a7e0-4a0c-9219-9f3cbcd8e878", detail.OrderId);
        Assert.Equal(1701275846033L, detail.ExecTimestamp);

        Assert.Equal(2, account.SubAcctQty);
        Assert.Equal(20, account.MaxSubAcctQty);
        Assert.Equal("10.0%", account.BaseFeeRebateRate.Spot);
        Assert.Equal("3.00%", account.MarkupFeeRebateRate.Convert);
        Assert.Equal(1701395633402L, account.Timestamp);

        var deposit = Assert.Single(deposits.Rows);
        Assert.Equal("123456789", deposit.Id);
        Assert.Equal(117894077L, deposit.SubMemberId);
        Assert.Equal("USDT", deposit.Asset);
        Assert.Equal(100.123456m, deposit.Quantity);
        Assert.Equal(BybitDepositStatus.Success, deposit.Status);
        Assert.Equal(0m, deposit.DepositFee);
        Assert.Equal(12, deposit.Confirmations);
        Assert.Equal(-1m, deposit.BatchReleaseLimit);
        Assert.Equal(0, deposit.DepositType);
        Assert.Equal(0, deposit.TaxStatus);
        Assert.Equal("cursor-1", deposits.NextPageCursor);
    }

    [Fact]
    public void RateLimitResponses_MapCurrentDocumentShapes()
    {
        var setRate = DeserializeResult<SetRateLimitResult>("set-rate-limit.json");
        var rateLimitCap = DeserializeResult<ListResult<BybitBrokerRateLimitCap>>("rate-limit-cap.json");
        var rateLimits = DeserializeResult<ListResult<BybitBrokerRateLimit>>("rate-limits.json");

        var setResult = Assert.Single(setRate.Result);
        Assert.Equal("290118", setResult.Uids);
        Assert.Equal(BybitBrokerBusinessType.Spot, setResult.BusinessType);
        Assert.Equal(600, setResult.Rate);
        Assert.True(setResult.Success);
        Assert.Equal("API limit updated successfully", setResult.Message);

        var cap = Assert.Single(rateLimitCap.List);
        Assert.Equal(BybitBrokerBusinessType.Spot, cap.BusinessType);
        Assert.Equal(900, cap.EbCap);
        Assert.Equal(100, cap.UidCap);
        Assert.Equal(825, cap.TotalRate);

        var rateLimit = Assert.Single(rateLimits.List);
        Assert.Equal("104270393,1674166,1190923,101446030", rateLimit.Uids);
        Assert.Equal(BybitBrokerBusinessType.Spot, rateLimit.BusinessType);
        Assert.Equal(223, rateLimit.Rate);
    }

    [Fact]
    public void VoucherResponses_MapCurrentDocumentShapes()
    {
        var spec = DeserializeResult<BybitBrokerVoucherSpec>("voucher-spec.json");
        var issued = DeserializeResult<BybitBrokerIssuedVoucher>("issued-voucher.json");

        Assert.Equal("80209", spec.Id);
        Assert.Equal("USDT", spec.Coin);
        Assert.Equal(BybitBrokerVoucherAmountUnit.Usd, spec.AmountUnit);
        Assert.Equal("PRODUCT_LINE_CONTRACT", spec.ProductLine);
        Assert.Equal("SUB_PRODUCT_LINE_CONTRACT_DEFAULT", spec.SubProductLine);
        Assert.Equal(10000m, spec.TotalAmount);
        Assert.Equal(100m, spec.UsedAmount);

        Assert.Equal("5714139", issued.AccountId);
        Assert.Equal("189528", issued.AwardId);
        Assert.Equal("demo000", issued.SpecCode);
        Assert.Equal(1m, issued.Amount);
        Assert.True(issued.IsClaimed);
        Assert.Equal(1725926400L, issued.StartTimestamp);
        Assert.Equal(1726531200L, issued.EffectiveTimestamp);
        Assert.Null(issued.UsedAmount);
    }

    [Fact]
    public void Requests_SerializeStringNumericsAndMappedEnums()
    {
        var setRate = Serialize(new BybitBrokerSetRateLimitRequest([
            new BybitBrokerSetRateLimitItem("290118", BybitBrokerBusinessType.Spot, 600),
        ]));
        var issue = Serialize(new BybitBrokerIssueVoucherRequest("2846381", "123456", "award001", 100m, "v-28478"));
        var issued = Serialize(new BybitBrokerIssuedVoucherRequest("5714139", "189528", "demo000") { WithUsedAmount = false });

        Assert.Equal("290118", setRate["list"]![0]!["uids"]!.Value<string>());
        Assert.Equal("SPOT", setRate["list"]![0]!["bizType"]!.Value<string>());
        Assert.Equal(600, setRate["list"]![0]!["rate"]!.Value<int>());

        Assert.Equal("2846381", issue["accountId"]!.Value<string>());
        Assert.Equal("award001", issue["specCode"]!.Value<string>());
        Assert.Equal("100", issue["amount"]!.Value<string>());
        Assert.Equal("v-28478", issue["brokerId"]!.Value<string>());

        Assert.Equal("demo000", issued["specCode"]!.Value<string>());
        Assert.False(issued["withUsedAmount"]!.Value<bool>());
    }

    [Fact]
    public async Task ClientValidations_RejectInvalidRequestsBeforeNetwork()
    {
        var client = new BybitRestApiClient();

        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.GetEarningsAsync(begin: "20231201"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.GetEarningsAsync(limit: 1001));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.GetSubAccountDepositRecordsAsync(limit: 51));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.SetRateLimitsAsync([]));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.SetRateLimitsAsync([new BybitBrokerSetRateLimitItem("290118", BybitBrokerBusinessType.Spot, 0)]));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.GetRateLimitsAsync(limit: 1001));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.IssueVoucherAsync("1", "2", "too-long1", 1m, "broker"));
        await Assert.ThrowsAsync<ArgumentException>(() => client.Broker.GetIssuedVoucherAsync("1", "2", "too-long1"));
    }

    private static T DeserializeResult<T>(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Broker", "Json", fileName);
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

    private sealed record RowsResult<T>
    {
        public List<T> Rows { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }

    private sealed record ListResult<T>
    {
        public List<T> List { get; set; } = [];
        public string NextPageCursor { get; set; } = string.Empty;
    }

    private sealed record SetRateLimitResult
    {
        [JsonProperty("result")]
        public List<BybitBrokerRateLimitSetResult> Result { get; set; } = [];
    }
}
