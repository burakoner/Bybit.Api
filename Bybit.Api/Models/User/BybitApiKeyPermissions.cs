namespace Bybit.Api.Models.User;

public class BybitApiKeyPermissions
{
    public IEnumerable<string> BlockTrade { get; set; } = Array.Empty<string>();
    public IEnumerable<string> ContractTrade { get; set; } = Array.Empty<string>();
    public IEnumerable<string> CopyTrading { get; set; } = Array.Empty<string>();
    public IEnumerable<string> Derivatives { get; set; } = Array.Empty<string>();
    public IEnumerable<string> Exchange { get; set; } = Array.Empty<string>();
    public IEnumerable<string> NFT { get; set; } = Array.Empty<string>();
    public IEnumerable<string> Options { get; set; } = Array.Empty<string>();
    public IEnumerable<string> Spot { get; set; } = Array.Empty<string>();
    public IEnumerable<string> Wallet { get; set; } = Array.Empty<string>();
}