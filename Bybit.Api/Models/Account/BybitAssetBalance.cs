namespace Bybit.Api.Models.Account;

public class BybitAssetBalances
{
    [JsonProperty("accountType")]
    public BybitAccount Account { get; set; }

    [JsonProperty("memberId")]
    public string UserId { get; set; }

    [JsonProperty("balance")]
    public List<BybitAssetBalancesItem> Balances { get; set; } = [];
}

public class BybitAssetBalancesItem
{
    [JsonProperty("coin")]
    public string Asset { get; set; }
    public decimal WalletBalance { get; set; }
    public decimal TransferBalance { get; set; }
    public decimal? Bonus { get; set; }
    public decimal? TransferSafeAmount { get; set; }
}
