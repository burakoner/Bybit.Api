namespace Bybit.Api.Web3;

/// <summary>
/// Web3 trade execution acknowledgement.
/// </summary>
public record BybitWeb3TradeExecution
{
    /// <summary>
    /// System-generated order number.
    /// </summary>
    public string OrderNo { get; set; } = string.Empty;
}
