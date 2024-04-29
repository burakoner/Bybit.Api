namespace Bybit.Api.Models.Account;

internal class BybitCategoryAssetBalances
{
    public BybitCategoryAssetBalance Spot { get; set; } = null!;
}

public class BybitCategoryAssetBalance
{
    public string Status { get; set; }
    public List<BybitCategoryAssetBalanceItem> Assets { get; set; } = [];
}

public class BybitCategoryAssetBalanceItem
{
    [JsonProperty("coin")]
    public string Asset { get; set; }
    public decimal Frozen { get; set; }
    public decimal Free { get; set; }
    [JsonProperty("withdraw")]
    public decimal? Withdrawing { get; set; }
}
