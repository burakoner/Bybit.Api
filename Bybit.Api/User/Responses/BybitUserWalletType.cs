namespace Bybit.Api.User;

/// <summary>
/// Bybit UID wallet type.
/// </summary>
public record BybitUserWalletType
{
    /// <summary>
    /// Master or sub user ID.
    /// </summary>
    [JsonProperty("uid")]
    public long UserId { get; set; }

    /// <summary>
    /// Available wallet account types.
    /// </summary>
    public List<BybitAccountType> AccountType { get; set; } = [];
}
