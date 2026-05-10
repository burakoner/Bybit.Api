namespace Bybit.Api.Web3;

/// <summary>
/// Web3 business token list request.
/// </summary>
public record BybitWeb3BizTokenListRequest
{
    /// <summary>
    /// Token tag filter.
    /// </summary>
    [JsonProperty("tokenTag", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerEnumConverter))]
    public BybitWeb3TokenTagFilter? TokenTag { get; set; }
}
