namespace Bybit.Api.Loan;

/// <summary>
/// Bybit Lending Product Container
/// </summary>
internal class BybitLendingProductContainer
{
    [JsonProperty("marginProductInfo")]
    public List<BybitLoanProduct> Payload { get; set; } = [];
}

/// <summary>
/// Bybit Lending Product
/// </summary>
public class BybitLoanProduct
{
    /// <summary>
    /// Product Id
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// The maximum leverage for this loan product
    /// </summary>
    public decimal Leverage { get; set; }

    /// <summary>
    /// Whether to support Spot. 0:false; 1:true
    /// </summary>
    [JsonProperty("supportSpot"), JsonConverter(typeof(BooleanConverter))]
    public bool SpotSupport { get; set; }

    /// <summary>
    /// Whether to support USDT Perpetual. 0:false; 1:true
    /// </summary>
    [JsonProperty("supportContract"), JsonConverter(typeof(BooleanConverter))]
    public bool ContractSupport { get; set; }

    /// <summary>
    /// Whether to support Spot margin trading. 0:false; 1:true
    /// </summary>
    [JsonProperty("supportMarginTrading"), JsonConverter(typeof(BooleanConverter))]
    public bool MarginTradingSupport { get; set; }

    /// <summary>
    /// Line for deferred liquidation
    /// </summary>
    public decimal DeferredLiquidationLine { get; set; }

    /// <summary>
    /// Time for deferred liquidation
    /// </summary>
    [JsonProperty("deferredLiquidationTime")]
    public long? DeferredLiquidationTimestamp { get; set; }

    /// <summary>
    /// Time for deferred liquidation
    /// </summary>
    public DateTime? DeferredLiquidationTime { get { return DeferredLiquidationTimestamp?.ConvertFromMilliseconds(); } }

    /// <summary>
    /// Restrict line for withdrawal
    /// </summary>
    public decimal WithdrawLine { get; set; }

    /// <summary>
    /// Restrict line for transfer
    /// </summary>
    public decimal TransferLine { get; set; }

    /// <summary>
    /// Restrict line for Spot buy
    /// </summary>
    public decimal SpotBuyLine { get; set; }

    /// <summary>
    /// Restrict line for Spot trading
    /// </summary>
    public decimal SpotSellLine { get; set; }

    /// <summary>
    /// Restrict line for USDT Perpetual open position
    /// </summary>
    public decimal ContractOpenLine { get; set; }

    /// <summary>
    /// Line for liquidation
    /// </summary>
    public decimal LiquidationLine { get; set; }

    /// <summary>
    /// Line for stop liquidation
    /// </summary>
    public decimal StopLiquidationLine { get; set; }

    /// <summary>
    /// The allowed default leverage for USDT Perpetual
    /// </summary>
    public decimal ContractLeverage { get; set; }

    /// <summary>
    /// The transfer ratio for loan funds to transfer from Spot wallet to Contract wallet
    /// </summary>
    public decimal TransferRatio { get; set; }

    /// <summary>
    /// The whitelist of spot trading pairs
    /// If supportSpot="0", then it returns "[]"
    /// If empty array, then you can trade any symbols
    /// If not empty, then you can only trade listed symbols
    /// </summary>
    public List<string> SpotSymbols { get; set; } = [];

    /// <summary>
    /// The whitelist of contract trading pairs
    /// If supportContract="0", then it returns "[]"
    /// If empty array, then you can trade any symbols
    /// If not empty, then you can only trade listed symbols
    /// </summary>
    public List<string> ContractSymbols { get; set; } = [];

    /// <summary>
    /// Whether to support USDC contract. '0':false; '1':true
    /// </summary>
    [JsonProperty("supportUSDCContract"), JsonConverter(typeof(BooleanConverter))]
    public bool USDCContractSupport { get; set; }

    /// <summary>
    /// Whether to support Option. '0':false; '1':true
    /// </summary>
    [JsonProperty("supportUSDCOptions"), JsonConverter(typeof(BooleanConverter))]
    public bool USDCOptionsSupport { get; set; }

    /// <summary>
    /// Restrict line to open USDT Perpetual position
    /// </summary>
    public decimal? USDTPerpetualOpenLine { get; set; }

    /// <summary>
    /// Restrict line to open USDC Contract position
    /// </summary>
    public decimal? USDCContractOpenLine { get; set; }

    /// <summary>
    /// Restrict line to open Option position
    /// </summary>
    public decimal? USDCOptionsOpenLine { get; set; }

    /// <summary>
    /// Restrict line to trade USDT Perpetual
    /// </summary>
    public decimal? USDTPerpetualCloseLine { get; set; }

    /// <summary>
    /// Restrict line to trade USDC Contract
    /// </summary>
    public decimal? USDCContractCloseLine { get; set; }

    /// <summary>
    /// Restrict line to trade Option
    /// </summary>
    public decimal? USDCOptionsCloseLine { get; set; }

    /// <summary>
    /// The whitelist of USDC contract trading pairs
    /// If supportContract="0", then it returns "[]"
    /// If no whitelist symbols, it is [], and you can trade any
    /// If supportUSDCContract="0", it is []
    /// </summary>
    public List<string> USDCContractSymbols { get; set; } = [];

    /// <summary>
    /// The whitelist of Option symbols
    /// If supportContract="0", then it returns "[]"
    /// If no whitelisted, it is [], and you can trade any
    /// If supportUSDCOptions="0", it is []
    /// </summary>
    public List<string> USDCOptionsSymbols { get; set; } = [];

    /// <summary>
    /// The allowable maximum leverage for Spot margin trading. If supportMarginTrading=0, then it returns ""
    /// </summary>
    public decimal? MarginLeverage { get; set; }

    /// <summary>
    /// Object
    /// If supportContract="0", it is []
    /// If no whitelist USDT perp symbols, it returns all trading symbols and leverage by default
    /// If there are whitelist symbols, it return those whitelist data
    /// </summary>
    [JsonProperty("USDTPerpetualLeverage")]
    public List<BybitLoanLeverage> USDTPerpetualLeverage { get; set; } = [];

    /// <summary>
    /// Object
    /// If supportUSDCContract="0", it is []
    /// If no whitelist USDC contract symbols, it returns all trading symbols and leverage by default
    /// If there are whitelist symbols, it return those whitelist data
    /// </summary>
    [JsonProperty("USDCContractLeverage")]
    public List<BybitLoanLeverage> USDCContractLeverage { get; set; } = [];

    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; }
}