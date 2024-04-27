namespace Bybit.Api.Models.Lending;

internal class BybitLendingLtvInfo
{
    [JsonProperty("ltvInfo")]
    public IEnumerable<BybitLendingLifetimeValue> Payload { get; set; }
}

public class BybitLendingLifetimeValue
{
    public string ParentUID { get; set; }
    public decimal LifetimeValue { get; set; }
    public IEnumerable<string> SubAccountUids { get; set; }

    public decimal? UnpaidAmount { get; set; }
    public IEnumerable<BybitLendingUnpaidData> UnpaidInfo { get; set; }

    public decimal? Balance { get; set; }
    public IEnumerable<BybitLendingSpotBalance> SpotBalanceInfo { get; set; }
    public IEnumerable<BybitLendingContractBalance> ContractInfo { get; set; }
}

public class BybitLendingUnpaidData
{
    public string Token { get; set; }
    [JsonProperty("unpaidQty")]
    public decimal UnpaidQuantity { get; set; }
    public decimal UnpaidInterest { get; set; }
}

public class BybitLendingSpotBalance
{
    public string Token { get; set; }
    public decimal Price { get; set; }
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }
}

public class BybitLendingContractBalance
{
    public string Token { get; set; }
    public decimal Price { get; set; }
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }
}