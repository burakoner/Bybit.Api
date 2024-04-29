namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Withdrawal Id
/// </summary>
public class BybitWithdrawalId
{
    /// <summary>
    /// Withdrawal Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}
