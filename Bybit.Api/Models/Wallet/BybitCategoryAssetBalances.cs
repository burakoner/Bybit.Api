namespace Bybit.Api.Models.Wallet;

internal class BybitCategoryAssetBalances
{
    public BybitCategoryAssetBalance Spot { get; set; } = null!;
}

public class BybitCategoryAssetBalance
{
    public string Status { get; set; }
    public IEnumerable<BybitCategoryAssetBalanceItem> Assets { get; set; } = Array.Empty<BybitCategoryAssetBalanceItem>();
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
