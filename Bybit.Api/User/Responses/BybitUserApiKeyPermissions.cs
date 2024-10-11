namespace Bybit.Api.User;

/// <summary>
/// Bybit API Key Permissions
/// </summary>
public class BybitUserApiKeyPermissions
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
    /// Wallet. ["AccountTransfer","SubMemberTransferList"]
    /// </summary>
    public List<string> Wallet { get; set; } = [];
    
    /// <summary>
    /// USDC Contract. ["OptionsTrade"]
    /// </summary>
    public List<string> Options { get; set; } = [];
    
    /// <summary>
    /// Exchange. ["ExchangeHistory"]
    /// </summary>
    public List<string> Exchange { get; set; } = [];

    /// <summary>
    /// Copytrade. ["CopyTrading"]
    /// </summary>
    public List<string> CopyTrading { get; set; } = [];

    /// <summary>
    /// Permission of blocktrade. Not applicable to sub account, always []
    /// </summary>
    public List<string> BlockTrade { get; set; } = [];

    /// <summary>
    /// Permission of NFT. Not applicable to sub account, always []
    /// </summary>
    public List<string> NFT { get; set; } = [];

    /// <summary>
    /// Permission of Affiliate. Only affiliate can have this permission, otherwise always []
    /// </summary>
    public List<string> Affiliate { get; set; } = [];
}