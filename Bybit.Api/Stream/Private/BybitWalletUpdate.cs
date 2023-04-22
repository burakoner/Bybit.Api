namespace Bybit.Api.Helpers.Private;

public class BybitWalletUpdate
{
    [JsonProperty("accountType"), JsonConverter(typeof(LabelConverter<BybitAccount>))]
    public BybitAccount Account { get; set; }

    public decimal? AccountLTV { get; set; }
    public decimal? AccountIMRate { get; set; }
    public decimal? AccountMMRate { get; set; }
    public decimal? TotalEquity { get; set; }
    public decimal? TotalWalletBalance { get; set; }
    public decimal? TotalMarginBalance { get; set; }
    public decimal? TotalAvailableBalance { get; set; }
    public decimal? TotalPerpUPL { get; set; }
    public decimal? TotalInitialMargin { get; set; }
    public decimal? TotalMaintenanceMargin { get; set; }

    [JsonProperty("coin")]
    public IEnumerable<BybitWalletStreamAsset> Assets { get; set; }
}

public class BybitWalletStreamAsset
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    public decimal? Equity { get; set; }
    public decimal? UsdValue { get; set; }
    public decimal? WalletBalance { get; set; }
    public decimal? AvailableToWithdraw { get; set; }
    public decimal? AvailableToBorrow { get; set; }
    public decimal? BorrowAmount { get; set; }
    public decimal? AccruedInterest { get; set; }
    public decimal? TotalOrderIM { get; set; }
    public decimal? TotalPositionIM { get; set; }
    public decimal? TotalPositionMM { get; set; }
    public decimal? UnrealisedPnl { get; set; }
    public decimal? CumRealisedPnl { get; set; }
    public decimal? Bonus { get; set; }
    public decimal? Free { get; set; }
    public decimal? Locked { get; set; }
}
