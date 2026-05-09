namespace Bybit.Api.User;

/// <summary>
/// Bybit API Key Permissions
/// </summary>
public record BybitUserApiKeyPermissions
{
    /// <summary>
    /// Contract Trade. ["Order","Position"]
    /// </summary>
    public List<string> ContractTrade { get; set; } = [];
    
    /// <summary>
    /// Spot Trade. ["SpotTrade"]
    /// </summary>
    public List<string> Spot { get; set; } = [];

    /// <summary>
    /// Wallet. ["AccountTransfer","SubMemberTransfer","SubMemberTransferList","Withdraw"]
    /// </summary>
    public List<string> Wallet { get; set; } = [];

    /// <summary>
    /// USDC Contract. ["OptionsTrade"]
    /// </summary>
    public List<string> Options { get; set; } = [];

    /// <summary>
    /// Unified account has this permission by default ["DerivativesTrade"]
    /// For classic account, it is always[].
    /// </summary>
    public List<string> Derivatives { get; set; } = [];

    /// <summary>
    /// Always [] as Master Trader account just use ContractTrade to start CopyTrading
    /// </summary>
    public List<string> CopyTrading { get; set; } = [];

    /// <summary>
    /// Permission of blocktrade. Not applicable to sub account, always []
    /// </summary>
    public List<string> BlockTrade { get; set; } = [];

    /// <summary>
    /// Exchange. ["ExchangeHistory"]
    /// </summary>
    public List<string> Exchange { get; set; } = [];

    /// <summary>
    /// Permission of NFT NFTQueryProductList. Not applicable to sub account, always []
    /// </summary>
    public List<string> NFT { get; set; } = [];

    /// <summary>
    /// Permission of Affiliate. Only affiliate can have this permission, otherwise always []
    /// </summary>
    public List<string> Affiliate { get; set; } = [];

    /// <summary>
    /// Earn product. ["Earn"]
    /// </summary>
    public List<string> Earn { get; set; } = [];

    /// <summary>
    /// P2P. ["FiatP2POrder", "Advertising"]
    /// </summary>
    public List<string> FiatP2P { get; set; } = [];

    /// <summary>
    /// Deprecated Bybit Pay permission. Use FiatBitPay instead.
    /// </summary>
    public List<string> FiatBybitPay { get; set; } = [];

    /// <summary>
    /// Bybit Pay. ["FaitPayOrder"]
    /// </summary>
    public List<string> FiatBitPay { get; set; } = [];

    /// <summary>
    /// Fiat convert broker. ["FiatConvertBrokerOrder"]
    /// </summary>
    public List<string> FiatConvertBroker { get; set; } = [];

    /// <summary>
    /// Fiat global pay permission.
    /// </summary>
    public List<string> FiatGlobalPay { get; set; } = [];

    /// <summary>
    /// Bybit card permission. ["BitCard"]
    /// </summary>
    public List<string> BitCard { get; set; } = [];

    /// <summary>
    /// Community post permission. ["ByXPost"]
    /// </summary>
    public List<string> ByXPost { get; set; } = [];
}
