namespace Bybit.Api.Account;

/// <summary>
/// Bybit account self match prevention group.
/// </summary>
public record BybitAccountSmpGroup
{
    /// <summary>
    /// SMP group ID. If the UID has no group, it is 0 by default.
    /// </summary>
    [JsonProperty("smpGroup")]
    public long SelfMatchPreventionGroup { get; set; }
}
