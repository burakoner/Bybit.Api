namespace Bybit.Api.Models.User;

public class BybitApiKeyPermissions
{
    public List<string> BlockTrade { get; set; } = [];
    public List<string> ContractTrade { get; set; } = [];
    public List<string> CopyTrading { get; set; } = [];
    public List<string> Derivatives { get; set; } = [];
    public List<string> Exchange { get; set; } = [];
    public List<string> NFT { get; set; } = [];
    public List<string> Options { get; set; } = [];
    public List<string> Spot { get; set; } = [];
    public List<string> Wallet { get; set; } = [];
}